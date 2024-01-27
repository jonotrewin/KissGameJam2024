using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_State_WaitingToBeSeated : BasicState
{
    Goon_StateMachine goonStateMachine;

    public Goon_State_WaitingToBeSeated(Goon_StateMachine gsm) : base("WaitingToBeSeated", gsm)
    {
        goonStateMachine = gsm;
    }

    public override void UpdateLogic()
    {
       
        goonStateMachine._statistics.LowerHappiness(1);
        base.UpdateLogic();
    }
}
