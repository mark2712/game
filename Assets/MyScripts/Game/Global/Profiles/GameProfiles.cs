using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GameProfiles
{
    private static readonly Logger Logger = new("GameProfiles");
    private Dictionary<string, GameProfile> _profiles = new();
    public IReadOnlyDictionary<string, GameProfile> Profiles => _profiles;

    public void Add(GameProfile profile)
    {
        _profiles[profile.ProfileId] = profile;
    }

    public void Remove(string profileId)
    {
        _profiles.Remove(profileId);
    }

    public string Create(string Name, string profileId = null)
    {
        GameProfile profile = new(Name);
        if (profileId != null)
        {
            profile.ProfileId = profileId;
        }

        if (_profiles.ContainsKey(profile.ProfileId))
        {
            return "Профиль с таким ID уже существует";
        }

        bool duplicate = _profiles.Values.Any(p => p.Name == profile.Name);
        if (duplicate)
        {
            profile.VisibleName = $"{profile.Name} {profile.ProfileId}";
        }

        Add(profile);
        return "Ок";
    }

    public void Archive(string profileId)
    {
        if (!_profiles.ContainsKey(profileId))
        {
            Logger.Warning($"Профиль {profileId} не найден, архивировать нечего.");
            return;
        }

        string ProfilesPath = DataPathManager.Profiles;
        string profileDir = Path.Combine(ProfilesPath, profileId);
        string archiveDir = Path.Combine(DataPathManager.ProfilesArchive, profileId);

        try
        {
            // если архивная папка уже существует — добавляем суффикс даты
            if (Directory.Exists(archiveDir))
            {
                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                archiveDir = Path.Combine(DataPathManager.ProfilesArchive, $"{profileId}_{timestamp}");
            }

            Directory.Move(profileDir, archiveDir);
            Remove(profileId);
            Logger.Info($"Профиль {profileId} перенесён в архив: {archiveDir}");
        }
        catch (Exception e)
        {
            Logger.Error($"Ошибка при архивации профиля {profileId}: {e.Message}");
        }
    }

    public void Load()
    {
        // ищем все папки профилей
        foreach (string profileDir in Directory.GetDirectories(DataPathManager.Profiles))
        {
            GameProfileData profileData = SaveDataJSON.Load<GameProfileData>(profileDir, "Profile");
            GameProfile profile = new("");
            profile.Load(profileData);
            _profiles[profile.ProfileId] = profile;
        }

        // создать профиль для сцены загрузки
        Create("SystemLoad", "SystemLoad");
    }

    public void Save()
    {
        foreach (var kvp in _profiles)
        {
            GameProfile profile = kvp.Value;
            SaveDataJSON.Save(profile.Save(), Path.Combine(DataPathManager.Profiles, profile.ProfileId), "Profile");
        }
    }
}


// [Serializable]
// public class GameProfilesData
// {
//     public List<GameProfile> _profiles = new();
// }