using UnityEngine;

public class DynamicFixedDeltaTime : MonoBehaviour
{
    // private float _deltaTime = 0f;

    // void Start()
    // {
    //     _deltaTime = Time.fixedDeltaTime;
    // }

    // void Update()
    // {
    //     float currentFPS = 1 / Time.unscaledDeltaTime;
    //     if (currentFPS > 0 && currentFPS < 50)
    //     {
    //         Time.fixedDeltaTime = 1f / currentFPS;
    //     }
    //     else
    //     {
    //         Time.fixedDeltaTime = _deltaTime;
    //     }
    // }
}




// public class DynamicFixedDeltaTime : MonoBehaviour
// {
//     private float _deltaTime = 0f;
//     private float _deltaTimeAccumulator = 0f;
//     private int _frameCount = 0;
//     private const float _updateInterval = 0.1f; // Как часто обновлять FPS (в секундах)

//     void Start()
//     {
//         _deltaTime = Time.fixedDeltaTime;
//         Debug.Log(_deltaTime);
//     }

//     void Update()
//     {
//         // // Считаем FPS
//         // _deltaTimeAccumulator += Time.unscaledDeltaTime;
//         // _frameCount++;

//         UpdateFixedDeltaTime(1 / Time.unscaledDeltaTime);

//         // // Если прошло достаточно времени, обновляем FPS и fixedDeltaTime
//         // if (_deltaTimeAccumulator >= _updateInterval)
//         // {
//         //     float currentFPS = _frameCount / _deltaTimeAccumulator;
//         //     UpdateFixedDeltaTime(currentFPS);

//         //     // Сбрасываем счётчики
//         //     _deltaTimeAccumulator = 0f;
//         //     _frameCount = 0;
//         // }
//     }

//     // void UpdateFixedDeltaTime(float currentFPS)
//     // {
//     //     if (currentFPS < 60)
//     //     {
//     //         Time.fixedDeltaTime = _deltaTime / 2;
//     //     }
//     //     else
//     //     {
//     //         Time.fixedDeltaTime = _deltaTime;
//     //     }
//     // }

//     // void UpdateFixedDeltaTime(float currentFPS)
//     // {
//     //     if (currentFPS > 0 && currentFPS < 60)
//     //     {
//     //         float targetFixedDeltaTime = 1f / currentFPS;
//     //         Time.fixedDeltaTime = Mathf.Lerp(Time.fixedDeltaTime, targetFixedDeltaTime, 0.1f);
//     //     }
//     //     else
//     //     {
//     //         Time.fixedDeltaTime = _deltaTime;
//     //     }
//     // }




//     void UpdateFixedDeltaTime(float currentFPS)
//     {

//         // if (currentFPS > 0) { Time.fixedDeltaTime = 1f / currentFPS; }

//         if (currentFPS > 0 && currentFPS < 60)
//         {
//             Time.fixedDeltaTime = 1f / currentFPS;
//             // Debug.Log($"FPS: {currentFPS}, fixedDeltaTime: {Time.fixedDeltaTime}");
//         }
//         else
//         {
//             Time.fixedDeltaTime = _deltaTime;
//         }
//     }
// }