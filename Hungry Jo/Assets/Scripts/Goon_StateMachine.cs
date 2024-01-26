using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_StateMachine : StateMachine
{
    private Goon_State_ReadyToOrder _readyToOrder;
    private void Start()
    {
        _readyToOrder = new Goon_State_ReadyToOrder(this);
    }
    protected override BasicState GetInitialState()
    {
        return base.GetInitialState();
    }
}
