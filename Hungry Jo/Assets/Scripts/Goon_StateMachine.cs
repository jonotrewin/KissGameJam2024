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

         
        _waitingToBeSeated = new Goon_State_WaitingToBeSeated(this);
        _readyToOrder = new Goon_State_ReadyToOrder(this);

      

        _statistics = GetComponent<Goon_Statistics>();
        _sitDown = GetComponent<Goon_SitDown>();
        
      
   
    }

    
    protected override BasicState GetInitialState()
    {
        return _waitingToBeSeated; 

        

    }

    

   


}
