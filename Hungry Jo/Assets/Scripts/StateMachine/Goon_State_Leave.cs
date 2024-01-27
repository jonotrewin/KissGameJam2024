using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_State_Leave : BasicState
{
    Goon_StateMachine goonStateMachine;

    
    public Goon_State_Leave(Goon_StateMachine gsm) : base("Leave", gsm)
    {
        goonStateMachine = gsm;
    }
    public override void Enter()
    {
        base.Enter();
        goonStateMachine._statistics.loseReputationOnThrowOut = false;
    }

    public override void UpdateLogic()
    {
        
    }
}
