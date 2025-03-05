using System.IO;
using UnityEngine;

public static class DataPathManager
{
    // Основной путь к папке AllData
    public static string BasePath
    {
        get
        {
#if UNITY_EDITOR
            return Path.Combine(Application.dataPath, "AllData");
#else
            return Path.Combine(Application.persistentDataPath, "AllData");
#endif
        }
    }

    // Подкаталог для моделей
    public static string ModelsVRMPath => Path.Combine(BasePath, "ModelsVRM");

    // Подкаталог для сохранений
    public static string SavesPath => Path.Combine(BasePath, "Saves");

    // Подкаталог для профилей
    public static string ProfilesPath => Path.Combine(SavesPath, "Profiles");

    // Путь к конкретному профилю
    public static string GetProfilePath(string profileName)
    {
        return Path.Combine(ProfilesPath, profileName);
    }

    // Убедимся, что папки существуют
    public static void EnsureDirectories()
    {
        Directory.CreateDirectory(BasePath);
        Directory.CreateDirectory(ModelsVRMPath);
        Directory.CreateDirectory(SavesPath);
        Directory.CreateDirectory(ProfilesPath);
    }
}