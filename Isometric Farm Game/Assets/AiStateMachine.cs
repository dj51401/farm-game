using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class AiStateMachine : BaseSM
{
    public Tilemap tilemap;
    public Tile dirtTile;

    public WalkingState walkingState;
    public IdleState idleState;
    public DigState digState;


    public Vector3 currentTarget;

    public IAstarAI ai;

    public PlayerManager playerManager;

    void Awake()
    {
        walkingState = new WalkingState("Walking State", this);
        idleState = new IdleState("Idle State", this);
        digState = new DigState("Dig State", this);
        ai = GetComponent<IAstarAI>();
        currentState = idleState;
    }

    public void ChangeTile(Vector3Int tilePosition)
    {
        tilePosition.z = 0;
        tilemap.SetTile(tilePosition, dirtTile);
        tilemap.RefreshAllTiles();
    }


}
