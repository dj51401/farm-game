using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : BaseState
{
    AiStateMachine aiStateMachine;
    public WalkingState(string name, AiStateMachine stateMachine) : base(name, stateMachine)
    {
        aiStateMachine = stateMachine;
    }
    public override void EnterState()
    {
        aiStateMachine.ai.destination = aiStateMachine.currentTarget;

    }
    public override void PhysicsUpdateState()
    {

    }
    public override void UpdateState()
    {
        base.UpdateState();
        if (aiStateMachine.ai.reachedDestination)
        {
            aiStateMachine.ChangeState(aiStateMachine.digState);
        }
    }
    public override void ExitState()
    {

    }
}
