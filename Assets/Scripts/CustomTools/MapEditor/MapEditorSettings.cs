using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public // Create a new type of Settings Asset.
class MapEditorSettings : ScriptableObject
{
    public const string k_MyCustomSettingsPath = "Assets/Editor/MapEditorSettings.asset";

    public Table<MapEditorTile> Tiles;

    public List<MapEditorTile> TilePrefabsAdded;
    public List<string> TilePrefabNames;

    internal static MapEditorSettings GetOrCreateSettings()
    {
        var settings = AssetDatabase.LoadAssetAtPath<MapEditorSettings>(k_MyCustomSettingsPath);
        if (settings == null)
        {
            settings = ScriptableObject.CreateInstance<MapEditorSettings>();
            
            settings.Tiles = new Table<MapEditorTile>(30,20);
            settings.TilePrefabsAdded = new List<MapEditorTile>();
            settings.TilePrefabNames = new List<string>();

            AssetDatabase.CreateAsset(settings, k_MyCustomSettingsPath);
            AssetDatabase.SaveAssets();
        }
        return settings;
    }

    public void SetTiles(MapEditorTile[,] tiles)
    {
        var settings = AssetDatabase.LoadAssetAtPath<MapEditorSettings>(k_MyCustomSettingsPath);
        if (settings == null)
        {
            return;
        }

        settings.Tiles = new Table<MapEditorTile>(tiles);

        EditorUtility.SetDirty(settings);
        AssetDatabase.SaveAssets();
    }

    public void AddTilePrefab(string name, MapEditorTile tile)
    {
        var settings = AssetDatabase.LoadAssetAtPath<MapEditorSettings>(k_MyCustomSettingsPath);
        if (settings == null)
        {
            return;
        }

        settings.TilePrefabsAdded.Add(tile);
        settings.TilePrefabNames.Add(name);

        EditorUtility.SetDirty(settings);
        AssetDatabase.SaveAssets();
    }

    internal static SerializedObject GetSerializedSettings()
    {
        return new SerializedObject(GetOrCreateSettings());
    }
}
