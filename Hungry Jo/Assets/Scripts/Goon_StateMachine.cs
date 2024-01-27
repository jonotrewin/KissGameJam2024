using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_StateMachine : StateMachine
{
    private Goon_State_ReadyToOrder _readyToOrder;
    [SerializeField]public Goon_Statistics _statistics;
    private void Start()
    {
        _readyToOrder = new Goon_State_ReadyToOrder(this);
        base.Start();
      
   
    }
    protected override BasicState GetInitialState()
    {
        return _readyToOrder; //change this later to waiting to be seated
        

    }

    

   


}
