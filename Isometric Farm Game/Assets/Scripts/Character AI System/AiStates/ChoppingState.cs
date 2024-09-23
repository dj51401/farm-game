using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingState : BaseState
{
    AiStateMachine aiStateMachine;
    float timer = 3f;
    float time = 0;
    public ChoppingState(string name, AiStateMachine stateMachine) : base(name, stateMachine)
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
        time += Time.deltaTime;
        if (time > timer)
        {
            time = 0;
            aiStateMachine.objectsTilemap.SetTile(aiStateMachine.GetGridPosition(aiStateMachine.currentTarget), null);
            aiStateMachine.objectsTilemap.RefreshAllTiles();

            aiStateMachine.ChangeState(aiStateMachine.idleState);
        }
    }
    public override void ExitState()
    {

    }
}
