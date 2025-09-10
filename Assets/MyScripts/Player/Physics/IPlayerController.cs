using System;
using UnityEngine;

public interface IPlayerController
{
    float NowMoveSpeed { get; set; }

    event Action<bool> OnGroundChanged;
    bool IsGround { get; }

    Vector2 MoveInput { get; set; }
    void SetMoveInput(Vector2 moveInput);
    float MoveInputUp { get; set; }
    float MoveInputDown { get; set; }

    void SyncCamera();
    void Jump();

    void FixedUpdate() { }
    void Update() { }
    void LateUpdate() { }
}


public interface IPlayerPhysicsController
{
    float NowMoveSpeed { get; set; }
    event Action<bool> OnGroundChanged;
    bool IsGround { get; } // персонаж на земле (работает во всех средах)
    Vector3 MoveInput { get; set; } // если персонаж ходит по земле то учитывается только двуменая состовляющая
    void SyncCamera(); // камера синхронизируется с направлением движения персонажа
    void Jump(); // прыжок
    void FixedUpdate() { }
    void Update() { }
    void LateUpdate() { }
}