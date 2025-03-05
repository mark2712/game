// using UnityEngine;

// public class PlayerControllerColliderHit : MonoBehaviour
// {

//     // private Vector3 lastSafePosition; // Последняя безопасная позиция
//     // private CharacterController _characterController;

//     // void Start()
//     // {
//     //     _characterController = transform.GetComponent<CharacterController>();
//     // }

//     // private void Update()
//     // {
//     //     // Запоминаем последнюю позицию, если персонаж не внутри коллайдера
//     //     if (!Physics.CheckSphere(transform.position, _characterController.radius, LayerMask.GetMask("Wall")))
//     //     {
//     //         lastSafePosition = transform.position;
//     //     }
//     // }

//     private void OnControllerColliderHit(ControllerColliderHit hit)
//     {
//         // if (hit.normal.y < 0.9f) // Игнорируем столкновения с полом
//         // {
//         //     MovingPlatformObj movingPlatformObj = hit.gameObject.GetComponent<MovingPlatformObj>();

//         //     if (movingPlatformObj != null)
//         //     {
//         //         Vector3 platformMovement = movingPlatformObj.movingPlatform.futurePosition - movingPlatformObj.movingPlatform.currentPosition;

//         //         // Предполагаемое новое положение игрока
//         //         Vector3 predictedPosition = transform.position + platformMovement;

//         //         // Проверяем, оказался ли персонаж ВНУТРИ коллайдера
//         //         bool isInside = Vector3.Distance(predictedPosition, hit.point) < _characterController.radius + _characterController.skinWidth;

//         //         if (isInside)
//         //         {
//         //             Debug.Log("⚠ Коррекция из-за движения платформы");

//         //             // Проверяем, есть ли сзади свободное место
//         //             Vector3 backStep = -hit.normal * (_characterController.radius + _characterController.skinWidth);
//         //             Vector3 testPosition = transform.position + backStep;
//         //             if (!Physics.CheckSphere(testPosition, _characterController.radius, ~LayerMask.GetMask("Player")))
//         //             {
//         //                 // Если сзади свободно, корректируем позицию
//         //                 transform.position = hit.point + hit.normal * (_characterController.radius + _characterController.skinWidth);
//         //             }
//         //             else
//         //             {
//         //                 Debug.Log("❌ Отмена коррекции — зажат между объектами");
//         //             }
//         //         }
//         //     }
//         // }


//         // if (hit.normal.y < 0.9f)
//         // {
//         //     MovingPlatformObj movingPlatformObj = hit.gameObject.GetComponent<MovingPlatformObj>();

//         //     if (movingPlatformObj != null)
//         //     {
//         //         Vector3 platformMovement = movingPlatformObj.movingPlatform.futurePosition - movingPlatformObj.movingPlatform.currentPosition;

//         //         // Предполагаемое новое положение игрока
//         //         Vector3 predictedPosition = transform.position + platformMovement;

//         //         // Если предсказанное положение оказывается ВНУТРИ коллайдера
//         //         if (Vector3.Distance(predictedPosition, hit.point) < _characterController.radius + _characterController.skinWidth)
//         //         {
//         //             Debug.Log("⚠ Коррекция из-за движения платформы");
//         //             transform.position = hit.point + hit.normal * _characterController.radius; // Отталкиваем от стены
//         //         }
//         //     }
//         // }

//         // if (hit.normal.y < 0.9f)
//         // {
//         //     MovingPlatformObj movingPlatformObj = hit.gameObject.GetComponent<MovingPlatformObj>();
//         //     Vector3 delta = movingPlatformObj.rb.linearVelocity;

//         //     if (movingPlatformObj)
//         //     {
//         //         if (Vector3.Distance(transform.position, hit.point) > _characterController.radius)
//         //         {
//         //             // Персонаж явно застрял внутри
//         //             Debug.Log("Застревание! Телепорт назад.");
//         //             transform.position = lastSafePosition - delta; // Телепортируем назад
//         //         }
//         //     }
//         // }
//     }

//     // void OnControllerColliderHit(ControllerColliderHit hit)
//     // {
//     //     // Если столкновение снизу, игнорируем его
//     //     // if (hit.normal.y > 0.9f)
//     //     // {
//     //     //     Debug.Log("Столкновение снизу");
//     //     // }
//     //     // else
//     //     // {
//     //     //     Debug.Log("Столкновение с другой стороны");
//     //     // }
//     //     Debug.Log(hit.moveDirection);
//     //     Debug.Log(hit.moveLength);
//     //     Debug.Log(hit.normal);
//     // }
// }




