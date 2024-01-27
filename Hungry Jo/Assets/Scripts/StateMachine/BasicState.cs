using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicState 
{
    public string stateName;
    protected StateMachine stateMachine;

    public BasicState(string name, StateMachine stateMachine)
    {
        this.stateName = name;
        this.stateMachine = stateMachine;
    }

    public virtual void Enter()
    {

    }

    public virtual void UpdateLogic()
    { }

    public virtual void UpdatePhysics()
    {

    }

    public virtual void Exit()
    {
    }

}
