using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_State_Drinking : BasicState
{
    Goon_StateMachine goonStateMachine;

    int drinkingTimerThreshold = 3000;
    float drinkingTimer = 0;

    public Goon_State_Drinking(Goon_StateMachine gsm) : base("Drinking", gsm)
    {
        goonStateMachine = gsm;
    }

    public override void UpdateLogic()
    {
        Debug.Log("Yoohoo");
        drinkingTimer++;

        if(drinkingTimer>drinkingTimerThreshold)
        {
            goonStateMachine.ChangeStates(goonStateMachine._leave);
        }
    }




}
