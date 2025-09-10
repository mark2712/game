using System.IO;
using UnityEngine;

public static class DataPathManager
{
    // Основной путь к папке AllData
    public static string Base
    {
        get
        {
#if UNITY_EDITOR
            return EnsureDirectory(Path.Combine(Application.dataPath, "AllData"));
#else
            return EnsureDirectory(Path.Combine(Application.persistentDataPath, "AllData"));
#endif
        }
    }

    public static string ModelsVRM => EnsureDirectory(Path.Combine(Base, "ModelsVRM"));

    // Подкаталог для сохранений
    public static string Saves => EnsureDirectory(Path.Combine(Base, "Saves"));
    public static string Profiles => EnsureDirectory(Path.Combine(Saves, "Profiles"));
    public static string ProfilesArchive => EnsureDirectory(Path.Combine(Saves, "ProfilesArchive"));

    /// <summary>
    /// Гарантирует, что директория существует. Если нет — создаёт её.
    /// </summary>
    private static string EnsureDirectory(string path)
    {
        if (!Directory.Exists(path))
            Directory.CreateDirectory(path);
        return path;
    }
}