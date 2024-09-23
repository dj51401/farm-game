using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AiStateMachine : BaseSM
{
    public Tilemap groundTilemap;
    public Tilemap objectsTilemap;
    public Tile dirtTile;
    public Tile grassTile;
    public Tile treeTile;

    public WalkingState walkingState;
    public IdleState idleState;
    public DigState digState;
    public ChoppingState choppingState;
    public Queue<Vector3> targets;


    public Vector3 currentTarget;

    public IAstarAI ai;

    public PlayerManager playerManager;

    void Awake()
    {
        walkingState = new WalkingState("Walking State", this);
        idleState = new IdleState("Idle State", this);
        digState = new DigState("Dig State", this);
        choppingState = new ChoppingState("Chopping State", this);

        ai = GetComponent<IAstarAI>();
        currentState = idleState;
        targets = new Queue<Vector3>();
    }

    void Update()
    {

        if (playerManager.selectAction.WasPressedThisFrame())
        {
            if (!targets.Contains(playerManager.mousePosition))
            {
                targets.Enqueue(playerManager.mousePosition);

            }
        }

        if (currentState != null)
        {
            currentState.UpdateState();
        }
    }

    public void ChangeTile(Vector3Int tilePosition)
    {

        tilePosition.z = 0;
        groundTilemap.SetTile(tilePosition, dirtTile);
        groundTilemap.RefreshAllTiles();
    }

    public Vector3Int GetGridPosition(Vector3 gridPosition)
    {
        Vector3Int v = groundTilemap.WorldToCell(gridPosition);
        v.z = 0;
        return v;
    }


}
