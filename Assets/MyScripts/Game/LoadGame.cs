using System;
using System.Collections.Generic;
using System.IO;
using Mobs;
using UnityEngine;





// public class LoadGame
// {
//     public string SaveId { get; private set; }

//     public MobsManager MobsManager = new();
//     public ScenesData ScenesData = new();

//     public void Save(string currentSceneName)
//     {
//         // Создаём уникальный ID по времени
//         SaveId = DateTime.Now.ToString("yyyyMMdd_HHmmss");

//         // Убедимся что все папки есть
//         DataPathManager.EnsureDirectories();

//         // --- Сохраняем мобов ---
//         string mobsPath = Path.Combine(DataPathManager.MobsSavesPath, $"{SaveId}.json");
//         string mobsJson = MobsManager.Save();
//         File.WriteAllText(mobsPath, mobsJson);

//         // --- Сохраняем сцену ---
//         string sceneDir = Path.Combine(DataPathManager.ScenesSavesPath, currentSceneName);
//         Directory.CreateDirectory(sceneDir); // на всякий случай
//         string scenePath = Path.Combine(sceneDir, $"{SaveId}.json");

//         string sceneJson = ScenesData.Save();
//         File.WriteAllText(scenePath, sceneJson);

//         Debug.Log($"[SaveGame] Сохранение {SaveId} завершено.");
//     }

//     public void Load(string saveId, string currentSceneName)
//     {
//         SaveId = saveId;

//         // --- Загружаем мобов ---
//         string mobsPath = Path.Combine(DataPathManager.MobsSavesPath, $"{SaveId}.json");
//         if (File.Exists(mobsPath))
//         {
//             string mobsJson = File.ReadAllText(mobsPath);
//             MobsManager.Load(mobsJson);
//         }
//         else
//         {
//             Debug.LogWarning($"[LoadGame] Не найден файл мобов {mobsPath}");
//         }

//         // --- Загружаем сцену ---
//         string scenePath = Path.Combine(DataPathManager.ScenesSavesPath, currentSceneName, $"{SaveId}.json");
//         if (File.Exists(scenePath))
//         {
//             string sceneJson = File.ReadAllText(scenePath);
//             ScenesData.Load(sceneJson);
//         }
//         else
//         {
//             Debug.LogWarning($"[LoadGame] Не найден файл сцены {scenePath}");
//         }
//     }
// }
