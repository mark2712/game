using System.Collections.Generic;
using UnityEngine;

public class EmotionController1 : MonoBehaviour
{
    private SkinnedMeshRenderer faceRenderer;
    private List<Emotion> emotions;
    private KeyCode[] emotionKeys;
    private List<string> blendShapeNames;
    private Dictionary<string, float> currentBlendShapeValues; // Текущие значения BlendShape
    public float transitionDuration = 1f; // Время на переход

    private void Awake()
    {
        Transform faceTransform = transform.Find("Face");
        if (faceTransform != null)
        {
            faceRenderer = faceTransform.GetComponent<SkinnedMeshRenderer>();
        }

        if (faceRenderer == null)
        {
            Debug.LogError("SkinnedMeshRenderer не найден на дочернем объекте Face!");
            return;
        }

        blendShapeNames = GetBlendShapeNames();
        emotions = EmotionDatabase.Emotions;

        emotionKeys = new KeyCode[]
        {
            KeyCode.Alpha1,
            KeyCode.Alpha2,
            KeyCode.Alpha3,
            KeyCode.Alpha4,
            KeyCode.Alpha5,
            KeyCode.Alpha6,
            KeyCode.Alpha7,
            KeyCode.Alpha8,
            KeyCode.Alpha9,
            KeyCode.Alpha0
        };

        // Инициализируем текущие значения BlendShape
        currentBlendShapeValues = new Dictionary<string, float>();
        foreach (var name in blendShapeNames)
        {
            currentBlendShapeValues[name] = 0f;
        }
    }

    private void Update()
    {
        if (faceRenderer == null) return;

        // Проверяем нажатие клавиш
        for (int i = 0; i < emotionKeys.Length; i++)
        {
            if (i < emotions.Count && Input.GetKeyDown(emotionKeys[i]))
            {
                StartCoroutine(TransitionToEmotion(emotions[i], 2f));
            }
        }
    }

    private System.Collections.IEnumerator TransitionToEmotion(Emotion targetEmotion, float speed)
    {
        // Рассчитываем длительность перехода (меньшая скорость -> большее время)
        float transitionDuration = 1f / Mathf.Max(speed, 0.01f); // Минимальная скорость для избежания деления на ноль

        // Сохраняем начальные значения
        Dictionary<string, float> startValues = new Dictionary<string, float>(currentBlendShapeValues);

        // Получаем целевые значения
        Dictionary<string, float> targetValues = targetEmotion.blendShapeValues;

        float elapsedTime = 0f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / transitionDuration;

            // Интерполируем значения BlendShape
            foreach (var blendShapeName in blendShapeNames)
            {
                float startValue = startValues.ContainsKey(blendShapeName) ? startValues[blendShapeName] : 0f;
                float targetValue = targetValues.ContainsKey(blendShapeName) ? targetValues[blendShapeName] : 0f;

                float interpolatedValue = Mathf.Lerp(startValue, targetValue, t);
                currentBlendShapeValues[blendShapeName] = interpolatedValue;

                int blendShapeIndex = faceRenderer.sharedMesh.GetBlendShapeIndex(blendShapeName);
                if (blendShapeIndex != -1)
                {
                    faceRenderer.SetBlendShapeWeight(blendShapeIndex, interpolatedValue);
                }
            }

            yield return null;
        }

        // Устанавливаем финальные значения
        foreach (var blendShapeName in blendShapeNames)
        {
            float targetValue = targetValues.ContainsKey(blendShapeName) ? targetValues[blendShapeName] : 0f;
            currentBlendShapeValues[blendShapeName] = targetValue;

            int blendShapeIndex = faceRenderer.sharedMesh.GetBlendShapeIndex(blendShapeName);
            if (blendShapeIndex != -1)
            {
                faceRenderer.SetBlendShapeWeight(blendShapeIndex, targetValue);
            }
        }
    }

    private List<string> GetBlendShapeNames()
    {
        List<string> names = new List<string>();
        var mesh = faceRenderer.sharedMesh;
        for (int i = 0; i < mesh.blendShapeCount; i++)
        {
            names.Add(mesh.GetBlendShapeName(i));
        }
        return names;
    }
}