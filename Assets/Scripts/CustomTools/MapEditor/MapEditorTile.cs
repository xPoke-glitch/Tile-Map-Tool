using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapEditorTile
{
    public Color Color { get => _color; }
    public GameObject TileAssets { get => _tileAssets; }
    public GameObject TileObject { get => _tileObject; set { _tileObject = value; } }
    
    [SerializeField]
    private Color _color;
    [SerializeField]
    private GameObject _tileAssets;
    [SerializeField]
    private GameObject _tileObject;

    public MapEditorTile()
    {
        _color = Color.black;
        _tileAssets = null;
        _tileObject = null;
    }

    public MapEditorTile(Color color, GameObject gameObject)
    {
        _color = color;
        _tileAssets = gameObject;
        _tileObject = null;
    }
}

