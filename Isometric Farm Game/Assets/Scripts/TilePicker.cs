using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class TilePicker : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    [SerializeField] Tile dirtTile;

    [SerializeField] GameObject farmer;
    Vector3Int gridPosition;
    Vector3 worldPosition;
    public Transform target;
    IAstarAI ai;
    // Start is called before the first frame update
    void Start()
    {
        ai = farmer.GetComponent<IAstarAI>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            gridPosition = tilemap.WorldToCell(mousePosition);
            worldPosition = tilemap.CellToWorld(gridPosition);
            ai.destination = worldPosition;

        }

        if(ai.reachedDestination)
            ChangeTile(gridPosition);
    }

    private void ChangeTile(Vector3Int tilePosition)
    {
        tilePosition.z = 0;
        tilemap.SetTile(tilePosition, dirtTile);
        tilemap.RefreshAllTiles();
    }

}
