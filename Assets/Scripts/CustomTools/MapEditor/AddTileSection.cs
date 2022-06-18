using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public partial class MapEditor : EditorWindow
{
    
    private int _selectedIndex = 0;
    
    private Vector2Int _tilePoint = new Vector2Int();

    private List<string> _options = new List<string>();
    private Dictionary<string, MapEditorTile> _optionsDictionary = new Dictionary<string, MapEditorTile>();

    private void PopulateDropDownOptions()
    {
        _optionsDictionary.Add("ForestTile", new MapEditorTile(Color.green, AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/ForestTile.prefab")));
        _optionsDictionary.Add("DesertTile", new MapEditorTile(Color.yellow, AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/DesertTile.prefab")));

        foreach (string option in _optionsDictionary.Keys)
        {
            _options.Add(option);
        }
    }

    private void DrawTilesDropDown()
    {
        GUILayout.Label("Add Tile", EditorStyles.boldLabel);

        EditorGUILayout.BeginVertical();

        // DropDown
        _selectedIndex = EditorGUILayout.Popup(_selectedIndex, _options.ToArray());

        // X - Y Labels
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("X Tile");
        GUILayout.Label("Y Tile");
        EditorGUILayout.EndVertical();
        
        // X - Y TextFields 
        EditorGUILayout.BeginHorizontal();
        _tilePoint.x = EditorGUILayout.IntField(_tilePoint.x);
        _tilePoint.y = EditorGUILayout.IntField(_tilePoint.y);
        EditorGUILayout.EndHorizontal();

        // Left and Right Arrows
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Left"))
        {
            _tilePoint.x--;
        }
        if (GUILayout.Button("Right"))
        {
            _tilePoint.x++;
        }
        EditorGUILayout.EndHorizontal();

        // Up and Down Arrows
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Up"))
        {
            _tilePoint.y--;
        }
        if (GUILayout.Button("Down"))
        {
            _tilePoint.y++;
        }
        EditorGUILayout.EndHorizontal();


        if (_tilePoint.x >= _tileMatrix.GetLength(0))
        {
            _tilePoint.x = _tileMatrix.GetLength(0)-1;
        }
        if (_tilePoint.y >= _tileMatrix.GetLength(1))
        {
            _tilePoint.y = _tileMatrix.GetLength(1) - 1;
        }
        if (_tilePoint.x < 0)
            _tilePoint.x = 0;
        if (_tilePoint.y < 0)
            _tilePoint.y = 0;


        // Add Button
        if (GUILayout.Button("Add Tile"))
        {
            if (_tileMatrix[_tilePoint.x, _tilePoint.y].TileObject != null) 
            {
                DestroyImmediate(_tileMatrix[_tilePoint.x, _tilePoint.y].TileObject);
            }
            _tileMatrix[_tilePoint.x, _tilePoint.y] = new MapEditorTile(_optionsDictionary[_options[_selectedIndex]].Color, _optionsDictionary[_options[_selectedIndex]].TileAssets);
            _tileMatrix[_tilePoint.x, _tilePoint.y].TileObject = Instantiate(_tileMatrix[_tilePoint.x, _tilePoint.y].TileAssets, new Vector3(_tilePoint.x*2, 0, -_tilePoint.y*2), Quaternion.identity);
        }

        // Remove Button
        if (GUILayout.Button("Remove Tile"))
        {
            if (_tileMatrix[_tilePoint.x, _tilePoint.y].TileObject != null)
            {
                DestroyImmediate(_tileMatrix[_tilePoint.x, _tilePoint.y].TileObject);
                _tileMatrix[_tilePoint.x, _tilePoint.y] = new MapEditorTile();
            }
        }

        
        // Show where the Tile will be
        if (Event.current.type == EventType.Repaint)
        {
            _material.SetPass(0);
            OpenGLHelper.DrawRectangle(new Vector2Int(_tilePoint.x * 10 + 5, _tilePoint.y *10 + 5), 10, 10, _optionsDictionary[_options[_selectedIndex]].Color);
        }
        EditorGUILayout.EndVertical();
    }
    
}
#endif