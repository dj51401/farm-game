using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSM : MonoBehaviour
{
    public BaseState currentState;

    void Start()
    {
        if(currentState != null)
        {
            currentState.EnterState();
        }
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    void FixedUpdate()
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
