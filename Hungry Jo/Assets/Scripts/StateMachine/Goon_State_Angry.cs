using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_State_Angry : BasicState
{
    Goon_StateMachine goonStateMachine;


    public Goon_State_Angry(Goon_StateMachine gsm) : base("Angry", gsm)
    {
        goonStateMachine = gsm;
    }
    public override void Enter()
    {
        AudioManager.instance.Play("Angry");
        base.Enter();
       
    }

    public override void UpdateLogic()
    {
        LowerGeneralHappiness();
    }

    private void LowerGeneralHappiness()
    {
        Collider[] colliders = Physics.OverlapSphere(stateMachine.transform.position, GameSettingsManager.instance.angryEffectRadius);

        foreach (Collider collider in colliders)
        {
            if(collider.TryGetComponent<Goon_Statistics>(out Goon_Statistics goonStats))
            {
                goonStats.LowerHappiness(GameSettingsManager.instance.angryEffectStrength);
            }
        }
        
     }
}
