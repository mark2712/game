using UnityEngine;
using System.IO;
using System;

public static class SaveDataJSON
{
    // Сохраняет данные в JSON-файл
    public static void Save<T>(string path, T data)
    {
        try
        {
            string jsonData = JsonUtility.ToJson(data, prettyPrint: true);
            File.WriteAllText(path, jsonData);
            Debug.Log($"Данные успешно сохранены в {path}");
        }
        catch (Exception e)
        {
            Debug.LogError($"Ошибка сохранения данных: {e.Message}");
        }
    }

    // Загружает данные из JSON-файла
    public static T Load<T>(string path) where T : new()
    {
        if (!File.Exists(path))
        {
            Debug.LogWarning($"Файл {path} не найден. Возвращаю default(T).");
            return new T(); // или default(T), если допустимо null
        }

        try
        {
            string jsonData = File.ReadAllText(path);
            T loadedData = JsonUtility.FromJson<T>(jsonData);
            Debug.Log($"Данные успешно загружены из {path}");
            return loadedData;
        }
        catch (Exception e)
        {
            Debug.LogError($"Ошибка загрузки данных: {e.Message}");
            return new T(); // или throw, если нужно прерывать выполнение
        }
    }
}