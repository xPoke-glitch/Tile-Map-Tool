using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public partial class MapEditor : EditorWindow
{
    private string _tileToAddName;
    private Color _tileToAddColor;

    private void DrawAddTileSection()
    {
        GUILayout.Label("Add Tile", EditorStyles.boldLabel);

        EditorGUILayout.BeginVertical();

        EditorGUILayout.BeginHorizontal();

        _tileToAddName = EditorGUILayout.TextField(_tileToAddName);
        _tileToAddColor = EditorGUILayout.ColorField(_tileToAddColor);
        _tileToAddColor.a = 1.0f;
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Add"))
        {
            if (!string.IsNullOrEmpty(_tileToAddName))
            {
                GameObject testObj = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/" + _tileToAddName + ".prefab");
                if(testObj != null)
                {
                    if (_optionsDictionary.ContainsKey(_tileToAddName))
                    {
                        EditorUtility.DisplayDialog("Tile Already Exist", "The tile is already in the dropdown list", "Confirm");
                    }
                    else
                    {
                        _settings = MapEditorSettings.GetOrCreateSettings();
                        MapEditorTile tileTemp = new MapEditorTile(_tileToAddColor, AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/" + _tileToAddName + ".prefab"));
                        _optionsDictionary.Add(_tileToAddName, tileTemp);
                        _options.Add(_tileToAddName);

                        _settings.AddTilePrefab(_tileToAddName, tileTemp);

                        _tileToAddColor = Color.black;
                        _tileToAddName = "";
                    }
                }
                else
                {
                    EditorUtility.DisplayDialog("Tile Not Found", "The tile is not found in Assets/Prefabs - Please check the folder", "Confirm");
                }
            }
            else
            {
                EditorUtility.DisplayDialog("Tile Not Found", "The tile name can not be null or empty", "Confirm");
            }
        }

        EditorGUILayout.EndVertical();
    }
}
#endif
