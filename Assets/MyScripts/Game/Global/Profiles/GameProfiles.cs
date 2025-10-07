using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UniRx;
using UnityEngine;

public class GameProfiles
{
    private static readonly Logger Logger = new("GameProfiles");
    private readonly ReactiveDictionary<string, GameProfile> _profiles = new();
    public IReadOnlyReactiveDictionary<string, GameProfile> Profiles => _profiles; // Только чтение и подписки

    public void Add(GameProfile profile)
    {
        _profiles[profile.ProfileId.Value] = profile;
    }

    public void Remove(string profileId)
    {
        _profiles.Remove(profileId);
    }

    public GameProfile Create(string Name, string profileId = null, ProfileTypes type = ProfileTypes.System)
    {
        GameProfile profile = new(Name);
        if (profileId != null)
        {
            profile.ProfileId.Value = profileId;
        }

        if (_profiles.ContainsKey(profile.ProfileId.Value))
        {
            Logger.Warning("Профиль с таким ID уже существует");
            return null;
        }

        bool duplicate = _profiles.Values.Any(p => p.Name == profile.Name);
        if (duplicate)
        {
            profile.VisibleName.Value = $"{profile.Name} {profile.ProfileId}";
        }

        profile.ProfileType.Value = type;
        Add(profile);
        return profile;
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
            _profiles[profile.ProfileId.Value] = profile;
        }

        // создать профиль для сцены загрузки
        Create("SystemLoad", "SystemLoad");
        Create("Test Profile 1", "Test Profile 1", ProfileTypes.User);
        Create("Test Profile 2", "Test Profile 2", ProfileTypes.User);
    }

    public void Save()
    {
        foreach (var kvp in _profiles)
        {
            GameProfile profile = kvp.Value;
            SaveDataJSON.Save(profile.Save(), Path.Combine(DataPathManager.Profiles, profile.ProfileId.Value), "Profile");
        }
    }
}


// [Serializable]
// public class GameProfilesData
// {
//     public List<GameProfile> _profiles = new();
// }