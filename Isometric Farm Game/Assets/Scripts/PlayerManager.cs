using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class PlayerManager : MonoBehaviour
{
    public Vector3 mousePosition;

    public InputActionAsset actions;
    public InputAction pointAction;
    public InputAction selectAction;

    private void OnEnable()
    {
        actions.FindActionMap("Gameplay").Enable();
    }
    private void OnDisable()
    {
        actions.FindActionMap("Gameplay").Disable();
    }

    // Start is called before the first frame update
    void Awake()
    {
        pointAction = actions.FindActionMap("Gameplay").FindAction("Point");
        selectAction = actions.FindActionMap("Gameplay").FindAction("Select");

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(pointAction.ReadValue<Vector2>());

    }

}
