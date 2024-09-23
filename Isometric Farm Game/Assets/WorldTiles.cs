using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(fileName = "New Tile", menuName = "Tiles")]
public class WorldTiles : Tile
{
    Sprite originalSprite;
    public Sprite highlightedSprite;


    private void OnEnable()
    {
        originalSprite = sprite;

    }

    public void SelectTile()
    {
        sprite = highlightedSprite;
    }

    public void DeselectTile()
    {
        sprite = originalSprite;
    }
}
