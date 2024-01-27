using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_State_WaitingToBeSeated : BasicState
{
    Goon_StateMachine _gSM;

    public Goon_State_WaitingToBeSeated(Goon_StateMachine gsm) : base("WaitingToBeSeated", gsm)
    {
       _gSM= gsm;
    }

    public override void UpdateLogic()
    {
        Debug.Log("LALA");
        stateMachine.GetComponent<Goon_StateMachine>()._statistics.LowerHappiness(1);

        if(_gSM._sitDown.isSittingDown)
        {
            stateMachine.ChangeStates(_gSM._readyToOrder);
        }

        base.UpdateLogic();
    }


    public override void Enter()
    {
            
    }

}
