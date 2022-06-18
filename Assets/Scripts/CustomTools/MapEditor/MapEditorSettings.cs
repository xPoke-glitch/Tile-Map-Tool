using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public // Create a new type of Settings Asset.
class MapEditorSettings : ScriptableObject
{
    public const string k_MyCustomSettingsPath = "Assets/Editor/MapEditorSettings.asset";

    public MapEditorTile[,] Tiles;

    internal static MapEditorSettings GetOrCreateSettings()
    {
        var settings = AssetDatabase.LoadAssetAtPath<MapEditorSettings>(k_MyCustomSettingsPath);
        if (settings == null)
        {
            settings = ScriptableObject.CreateInstance<MapEditorSettings>();
            settings.Tiles = new MapEditorTile[30, 20];
            for(int i = 0; i<settings.Tiles.GetLength(0); i++)
            {
                for(int j=0; j<settings.Tiles.GetLength(1); j++)
                {
                    settings.Tiles[i, j] = new MapEditorTile();
                }
            }
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
        if(Tiles == null)
        {
            Debug.Log("Tiles NULL");
            return;
        }
        for (int i = 0; i < settings.Tiles.GetLength(0); i++)
        {
            for (int j = 0; j < settings.Tiles.GetLength(1); j++)
            {
                settings.Tiles[i, j] = new MapEditorTile(tiles[i, j].Color, tiles[i, j].TileAssets);
            }
        }
    }

    internal static SerializedObject GetSerializedSettings()
    {
        return new SerializedObject(GetOrCreateSettings());
    }
}
