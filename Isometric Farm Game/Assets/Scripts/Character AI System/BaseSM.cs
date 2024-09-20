using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSM : MonoBehaviour
{
    public BaseState currentState;

    private void Start()
    {
        if(currentState != null)
        {
            currentState.EnterState();
        }
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.PhysicsUpdateState();
        }
    }

    public void ChangeState(BaseState newState)
    {
        currentState.ExitState();
        currentState = newState;
        newState.EnterState();
    }

}
