using System;
using UnityEngine;

public static class GlobalGame
{
    public static UI.UIController UIController = new();
    public static GameProfiles Profiles = new();
    public static GlobalGameSettings Settings = new();
    public static GameTime Time = new();
    public static UpdateInterval UpdateInterval = new();
    static GlobalGame()
    {
        UIController = new();
        // Time = new();
        // UpdateInterval = new();
    }

    public static void Load()
    {
        GlobalGameData globalGameData = SaveDataJSON.Load<GlobalGameData>(DataPathManager.Saves, "GlobalGameData");
        Settings ??= globalGameData.GlobalGameSettings;
    }

    public static void Save()
    {
        GlobalGameData globalGameData = new()
        {
            GlobalGameSettings = Settings,
        };
        SaveDataJSON.Save(globalGameData, DataPathManager.Saves, "GlobalGameData");
    }
}

[Serializable]
public class GlobalGameData
{
    public GlobalGameSettings GlobalGameSettings = new();
}