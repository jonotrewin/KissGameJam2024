using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goon_State_ReadyToOrder : BasicState
{
    Goon_StateMachine goonStateMachine;
    public Goon_State_ReadyToOrder(Goon_StateMachine gsm) : base("ReadyToOrder",gsm)
    {
        goonStateMachine = gsm;
    }
    // Start is called before the first frame update
    public override void UpdateLogic()
    {
        base.UpdateLogic();




    }
    
    public void OnMouseDown()
    {

    }
}
