using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : BaseState
{
    AiStateMachine aiStateMachine;
    public IdleState(string name, AiStateMachine stateMachine) : base(name, stateMachine)
    {
        aiStateMachine = stateMachine;
    }
    public override void EnterState() 
    {

    }
    public override void PhysicsUpdateState() 
    {
    
    }
    public override void UpdateState() 
    {
        if (aiStateMachine.targets.Count > 0)
        {
            aiStateMachine.ChangeState(aiStateMachine.walkingState);
        }
    }
    public override void ExitState() 
    {
        aiStateMachine.currentTarget = aiStateMachine.targets.Peek();

        aiStateMachine.targets.Dequeue();
    }

}
