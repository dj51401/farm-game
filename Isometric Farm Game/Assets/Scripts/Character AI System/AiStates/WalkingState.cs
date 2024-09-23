using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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
        CheckDestination();
    }

    public override void ExitState()
    {

    }
    private void CheckDestination()
    {
        Vector3Int gridPosition = aiStateMachine.GetGridPosition(aiStateMachine.currentTarget);
        gridPosition.z = 0;


        if(aiStateMachine.ai.remainingDistance <= .2f)
        {
            if (aiStateMachine.objectsTilemap.GetTile(gridPosition) == aiStateMachine.treeTile)
            {
                aiStateMachine.ChangeState(aiStateMachine.choppingState);
            }
            if (aiStateMachine.objectsTilemap.GetTile(gridPosition) == null)
            {
                aiStateMachine.ChangeState(aiStateMachine.digState);
            }
        }

    }

}
