using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goon_StateMachine : StateMachine
{
    public Goon_State_WaitingToBeSeated _waitingToBeSeated;
    public Goon_State_ReadyToOrder _readyToOrder;
    public Goon_State_Drinking _drinking;
    public Goon_State_Leave _leave;
    public Goon_State_Angry _angry;


    [SerializeField]public Goon_Statistics _statistics;
    [SerializeField] public Goon_SitDown _sitDown;
    private void Awake()
    {

         
        _waitingToBeSeated = new Goon_State_WaitingToBeSeated(this);
        _readyToOrder = new Goon_State_ReadyToOrder(this);
        _drinking = new Goon_State_Drinking(this);
        _leave = new Goon_State_Leave(this);
        _angry = new Goon_State_Angry(this);

      

        _statistics = GetComponent<Goon_Statistics>();
        _sitDown = GetComponent<Goon_SitDown>();
        
      
   
    }

    
    protected override BasicState GetInitialState()
    {
        return _waitingToBeSeated; 

        

    }

    private void Update()
    {
        base.Update();
        if(_statistics.CurrentHappiness < GameSettingsManager.instance.angryThreshold)
        {
            _currentState = _angry;
            _statistics.loseReputationOnThrowOut = false;
        }
    }






}
