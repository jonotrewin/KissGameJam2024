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
        

        base.UpdateLogic();
    }
   
}