using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_StateMachine : StateMachine
{
    public Goon_State_WaitingToBeSeated _waitingToBeSeated;
    public Goon_State_ReadyToOrder _readyToOrder;


    [SerializeField]public Goon_Statistics _statistics;
    [SerializeField] public Goon_SitDown _sitDown;
    private void Awake()
    {

        Debug.Log("Blq blq");   
        _waitingToBeSeated = new Goon_State_WaitingToBeSeated(this);
        _readyToOrder = new Goon_State_ReadyToOrder(this);

        Debug.Log("Blq blqff f"+ _readyToOrder);

        _statistics = GetComponent<Goon_Statistics>();
        
      
   
    }

    
    protected override BasicState GetInitialState()
    {
        return _waitingToBeSeated; 

        

    }

    

   


}
