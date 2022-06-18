using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName ="MapEditorData",menuName ="MapEditor/Data")]
public class MapEditorData : ScriptableObject
{
    public MapEditorTile[,] Tiles;
}
