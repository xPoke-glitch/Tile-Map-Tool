using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public partial class MapEditor : EditorWindow
{
   
    [MenuItem("Tools/Map Editor")]
    public static void StartEditor()
    {
        MapEditor mapEditorWindow = EditorWindow.GetWindow<MapEditor>("Map Editor", true);
        mapEditorWindow.Show();
    }

    void OnEnable()
    {
        // Find the "Hidden/Internal-Colored" shader, and cache it for use.
        _material = new Material(Shader.Find("Hidden/Internal-Colored"));

        InitializeMatrix();

        PopulateDropDownOptions();
    }

    private void OnDisable()
    {
        SaveMatrix();
    }

    void OnGUI()
    {
        DrawGrid();
        DrawDrawTileSection();
        DrawAddTileSection();
    }

}
#endif
