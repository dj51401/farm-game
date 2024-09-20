using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigState : BaseState
{
    AiStateMachine aiStateMachine;
    float timer = 2f;
    float time = 0;
    public DigState(string name, AiStateMachine stateMachine) : base(name, stateMachine)
    {
        aiStateMachine = stateMachine;
    }
    public override void EnterState()
    {
        Debug.Log(aiStateMachine.playerManager.targets.Peek());

    }
    public override void PhysicsUpdateState()
    {

    }
    public override void UpdateState()
    {
        time += Time.deltaTime;
        if(time > timer)
        {
            time = 0;
            aiStateMachine.ChangeTile(aiStateMachine.playerManager.GetGridPosition(aiStateMachine.currentTarget));

            aiStateMachine.ChangeState(aiStateMachine.idleState);
        }
    }
    public override void ExitState()
    {
        
    }

}
