using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

#if UNITY_EDITOR
public partial class MapEditor : EditorWindow
{
    private int _selectedIndex = 0;
    private List<string> _options = new List<string>();

    private void PopulateDropDownOptions()
    {
        _options.Add("Option 1");
        _options.Add("Option 2");
        _options.Add("Option 3");
    }

    private void DrawTilesDropDown()
    {
        GUILayout.Label("Add Tile", EditorStyles.boldLabel);

        EditorGUILayout.BeginVertical();

        _selectedIndex = EditorGUILayout.Popup(_selectedIndex, _options.ToArray());

        EditorGUILayout.EndVertical();
    }
    
}
#endif
