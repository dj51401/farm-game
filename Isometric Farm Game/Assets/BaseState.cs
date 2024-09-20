using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BaseState
{

    public string name;
    protected BaseSM stateMachine;

    public BaseState(string name, BaseSM stateMachine)
    {
        this.name = name;
        this.stateMachine = stateMachine;
    }
    
    public virtual void EnterState() { }
    public virtual void PhysicsUpdateState() { }
    public virtual void UpdateState() { }
    public virtual void ExitState() { }


}
