using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goon_State_ReadyToOrder : BasicState, IInteract
{
    Goon_StateMachine goonStateMachine;

    
    public Goon_State_ReadyToOrder(Goon_StateMachine gsm) : base("ReadyToOrder",gsm)
    {
        goonStateMachine = gsm;
    }

    public override void Enter()
    {
        Debug.Log("Looks like we made it!");
        base.Enter();
    }
    // Start is called before the first frame update
    public override void UpdateLogic()
    {
        goonStateMachine._statistics.LowerHappiness(1);

        if (goonStateMachine._statistics.hasDrink)
        {
            stateMachine.ChangeStates(goonStateMachine._drinking);
            Debug.Log("Drinking!");

        }

        if (!goonStateMachine._sitDown.isSittingDown && !goonStateMachine._statistics.hasDrink)
        {
            stateMachine.ChangeStates(goonStateMachine._waitingToBeSeated);
            Debug.Log("Order Interrupted!");

        }

        CheckForRivalGangSitting();
        

        base.UpdateLogic();
    }

    private void CheckForRivalGangSitting()
    {
        Collider[] colliders = Physics.OverlapSphere(stateMachine.transform.position, GameSettingsManager.instance.DistanceToEnemyGangToAnger);

        foreach(Collider collider in colliders)
        {
           if(collider.TryGetComponent<Goon_SitDown>(out Goon_SitDown sitDown) && sitDown.isSittingDown)
            {
                sitDown.GetComponent<Goon_Statistics>().LowerHappiness(GameSettingsManager.instance.enemyGangProximityDamageMultiplier);
                goonStateMachine._statistics.LowerHappiness(GameSettingsManager.instance.enemyGangProximityDamageMultiplier);
                Debug.Log("Enemy Gang Spotted");

            }
        }    

    }
}
