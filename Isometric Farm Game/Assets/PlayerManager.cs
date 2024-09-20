using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerManager : MonoBehaviour
{
    public Tilemap tilemap;
    public Vector3 mousePosition;
    public Vector3 worldPosition;
    public Vector3Int gridPosition;
    public Queue<Vector3> targets;

    // Start is called before the first frame update
    void Start()
    {
        targets = new Queue<Vector3>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetMouseButtonDown(0))
        {
            if (!targets.Contains(mousePosition))
            {
                gridPosition = tilemap.WorldToCell(mousePosition);
                worldPosition = tilemap.CellToWorld(gridPosition);
                targets.Enqueue(mousePosition);

            }
        }


    }
    
    public Vector3 GetWorldPosition(Vector3Int gridPosition)
    {
        return gridPosition;
    }
    
    public Vector3Int GetGridPosition(Vector3 gridPosition)
    {
        return tilemap.WorldToCell(gridPosition);
    }
}
