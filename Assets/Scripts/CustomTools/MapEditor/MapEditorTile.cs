using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditorTile
{
    public Color Color { get; private set; }
    public GameObject TileAssets { get; private set; }
    public GameObject TileObject { get; set; }

    public MapEditorTile()
    {
        this.Color = Color.black;
        this.TileAssets = null;
        this.TileObject = null;
    }

    public MapEditorTile(Color color, GameObject gameObject)
    {
        this.Color = color;
        this.TileAssets = gameObject;
        this.TileObject = null;
    }
}

