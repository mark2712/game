using UnityEngine;

public class PlayerControllerOld
{
    private float nowSpeed = 5f;
    public float moveSpeed = 5f;
    public float runSpeed = 9f;
    public float jumpForce = 2.2f;
    public float lookSpeed = 12f;
    public float gravity = -20f;
    private Vector3 _velocity;
    private bool _isGrounded = false;
    private bool onGrounded = false;
    private RaycastHit _groundedRayHit;
    public bool isMove;
    public bool gravityOn = true;
    private Vector2 _moveInput;
    private CharacterController _characterController;
    public Transform player; // Тело игрока
    public Transform playerModel;
    public CamerasController camerasController;
    public float playerHeightHalf;
    public float playerHeigh045;
    public float characterControllerHeight;
    float playerRadius;

    public PlayerControllerOld(GameObject Player, CamerasController camerasController, CharacterController characterController)
    {
        player = Player.transform;
        this.camerasController = camerasController;
        _characterController = characterController;
    }

    public void Awake()
    {
        if (camerasController == null) Debug.LogError("CameraController не найден! Убедитесь, что он находится на том же объекте, что и PlayerController.");
        if (_characterController == null) Debug.LogError("CharacterController не найден! Убедитесь, что он находится на том же объекте, что и PlayerController.");
        playerModel = player.Find("PlayerModel");
        if (playerModel == null) Debug.LogError("playerModel не найден!");
        _defaultSurfaceMaterial = player.Find("ColliderBottom").GetComponent<Collider>().sharedMaterial;
        if (_defaultSurfaceMaterial == null) Debug.LogError("Физический материал не найден!");
        _currentSurfaceMaterial = _defaultSurfaceMaterial;
        nowSpeed = moveSpeed; // Инициализация начальной скорости

        characterControllerHeight = _characterController.height;
        playerHeightHalf = _characterController.height / 2 * player.localScale.y + _characterController.skinWidth;
        playerRadius = _characterController.radius * player.localScale.x + _characterController.skinWidth;
        playerHeigh045 = playerHeightHalf * 0.9f;
        // _characterController.sharedMaterial = _defaultSurfaceMaterial;
    }


    public void Update()
    {
        if (gravityOn || _velocity.y > 0) { ApplyGravity(); } else { gravityOn = true; }
        CheckGround();
        IsPlayerCrushed();
        // _characterController.Move(Vector3.up * 0.001f);
    }
    public void LateUpdate() { }
    public void FixedUpdate() { }

    public void SetMoveInput(Vector2 moveInput) { _moveInput = moveInput; }
    public void SetRunSpeed() { nowSpeed = runSpeed; }
    public void SetMoveSpeed() { nowSpeed = moveSpeed; }
    public void Move()
    {
        Vector3 move = player.right * _moveInput.x + player.forward * _moveInput.y;
        _characterController.Move(move * nowSpeed * Time.deltaTime);
        isMove = move.magnitude > 0.01f;
    }

    // public void Move()
    // {
    //     Vector3 move = player.right * _moveInput.x + player.forward * _moveInput.y;

    //     // Постепенное ускорение
    //     velocity = Vector3.Lerp(velocity, move * nowSpeed, Time.deltaTime * acceleration);

    //     // Если нет ввода - персонаж замедляется (имитация скольжения)
    //     if (move.magnitude < 0.1f)
    //     {
    //         velocity = Vector3.Lerp(velocity, Vector3.zero, Time.deltaTime * friction);
    //     }

    //     _characterController.Move(velocity * Time.deltaTime);

    //     isMove = move.magnitude > 0.01f;
    // }

    private void ApplyGravity()
    {
        _isGrounded = _characterController.isGrounded;
        if (_isGrounded && _velocity.y < 0) { _velocity = new Vector3(0, -2f, 0); }
        _velocity.y += gravity * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (onGrounded)
        {
            float surfaceAngle = Vector3.Angle(_groundedRayHit.normal, Vector3.up);
            if (surfaceAngle > _characterController.slopeLimit) { /*Debug.Log("Слишком крутой уклон для прыжка!");*/ return; }

            Vector3 rbVelocity = _currentRb ? _currentRb.linearVelocity : Vector3.zero;

            float platformBoost = (rbVelocity.y > 0) ? rbVelocity.y : 0f;
            float _velocity_y = Mathf.Sqrt(jumpForce * -2f * gravity) + platformBoost;
            _velocity = new Vector3(rbVelocity.x, _velocity_y, rbVelocity.z);

            ExitPlatform();
        }
    }


    private PhysicsMaterial _currentSurfaceMaterial;
    private PhysicsMaterial _defaultSurfaceMaterial;
    private Vector3 velocity = Vector3.zero;
    private float acceleration = 10f;
    private float friction = 5f;

    public Vector3 lastPlatformMovement;
    private Vector3 _previousGroundPosition;
    private Rigidbody _currentRb;

    private void CheckGround()
    {
        float rayDistance = playerHeightHalf + Mathf.Abs(_currentRb && _currentRb.linearVelocity.y < 0 ? _currentRb.linearVelocity.y : 0) + playerHeigh045 + 0.1f;
        // if (Physics.Raycast(player.position, Vector3.down, out _groundedRayHit, rayDistance, ~LayerMask.GetMask("Player")))
        if (Physics.SphereCast(new(player.position.x, player.position.y + playerHeigh045, player.position.z), playerRadius, Vector3.down, out _groundedRayHit, rayDistance - playerRadius, ~LayerMask.GetMask("Player")))
        {
            onGrounded = true;
            CheckGroundPhysicsMaterial();

            Rigidbody rb = _groundedRayHit.collider.GetComponent<Rigidbody>();
            MovingPlatformObj movingPlatformObj = _groundedRayHit.collider.GetComponent<MovingPlatformObj>();
            if (movingPlatformObj) { rb = movingPlatformObj.rb; }

            if (rb != null && _velocity.y < 0)
            {
                // Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Platform"), true);
                gravityOn = false;
                Vector3 currentGroundPosition = rb.transform.position;

                if (rb != _currentRb)
                {
                    _currentRb = rb;
                    _previousGroundPosition = currentGroundPosition;
                }
                Vector3 platformMovement = currentGroundPosition - _previousGroundPosition;

                Vector3 correctedGroundHit = _groundedRayHit.point + currentGroundPosition - rb.position;
                float groundOffset = correctedGroundHit.y + playerHeightHalf - player.position.y;

                AdjustCharacterController(platformMovement.y);

                platformMovement.y = groundOffset;
                _characterController.Move(platformMovement);

                lastPlatformMovement = platformMovement;
                _previousGroundPosition = currentGroundPosition;
            }
            else
            {
                ExitPlatform();
            }
        }
        else
        {
            ExitPlatform();
            onGrounded = false;
        }
    }

    private void ExitPlatform()
    {
        lastPlatformMovement = Vector3.zero;
        _currentRb = null;
        _characterController.height = characterControllerHeight;
        _characterController.center = Vector3.zero;
    }


    private void AdjustCharacterController(float platformMovementY)
    {
        if (platformMovementY > 0) // Если платформа поднимается
        {
            _characterController.height = characterControllerHeight / 2;
            _characterController.center = new Vector3(0, characterControllerHeight / 4, 0);
        }
        else // Если платформа опускается или стоит на месте
        {
            _characterController.height = characterControllerHeight;
            _characterController.center = new Vector3(0, 0, 0);
        }
    }


    private void CheckGroundPhysicsMaterial()
    {
        // Получаем физический материал поверхности
        PhysicsMaterial surfaceMaterial = _groundedRayHit.collider.sharedMaterial;
        if (surfaceMaterial == null) { surfaceMaterial = _defaultSurfaceMaterial; }

        // Если материал изменился, обновляем параметры
        if (surfaceMaterial.name != _currentSurfaceMaterial.name)
        {
            _currentSurfaceMaterial = surfaceMaterial;
            Debug.Log(_currentSurfaceMaterial.name);
            acceleration = Mathf.Lerp(5f, 15f, 1f - _currentSurfaceMaterial.dynamicFriction);
            friction = Mathf.Lerp(1f, 10f, _currentSurfaceMaterial.staticFriction);
        }
    }

    private void IsPlayerCrushed()
    {
        // Получаем параметры персонажа
        float playerHeightHalf = _characterController.height / 2 * player.localScale.y;
        float playerRadius = _characterController.radius * player.localScale.x;

        // Уменьшаем размеры на 20%
        float reducedHeight = playerHeightHalf * 0.8f; // Уменьшаем высоту на 20%
        float reducedRadius = playerRadius * 0.8f;    // Уменьшаем радиус на 20%

        // Определяем точки для капсулы
        Vector3 point1 = player.position + _characterController.center + Vector3.up * (reducedHeight - reducedRadius);
        Vector3 point2 = player.position + _characterController.center - Vector3.up * (reducedHeight - reducedRadius);

        // Проверяем, есть ли объекты внутри капсулы
        Collider[] colliders = Physics.OverlapCapsule(point1, point2, reducedRadius, ~LayerMask.GetMask("Player"));

        // if (colliders.Length > 0)
        // {
        //     Debug.Log(colliders.Length);
        // }
        // CheckColliders(colliders);
    }

    void CheckColliders(Collider[] colliders)
    {
        foreach (Collider col in colliders)
        {
            // Проверяем, является ли объект MovingPlatformObj
            MovingPlatformObj movingPlatform = col.GetComponent<MovingPlatformObj>();
            if (movingPlatform != null)
            {
                Debug.Log("MovingPlatformObj: " + col.name);
                continue; // Переходим к следующему коллайдеру
            }

            // Проверяем, есть ли у объекта Rigidbody
            Rigidbody rb = col.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Debug.Log("Rigidbody: " + col.name);
                continue; // Переходим к следующему коллайдеру
            }

            // Если это не MovingPlatformObj и не Rigidbody, выводим "Другой"
            Debug.Log("Другой: " + col.name);
        }
    }
}





// Vector3 rayOrigin = new Vector3(_groundedRayHit.point.x, player.position.y, _groundedRayHit.point.z);
// Physics.Raycast(rayOrigin, Vector3.down, out RaycastHit hit, rayDistance, ~LayerMask.GetMask("Player"));

// Vector3 correctedGroundHit = hit.point + currentGroundPosition - rb.position;
// float groundOffset = correctedGroundHit.y + playerHeightHalf - player.position.y;








// Vector3 sphereCorrection = _groundedRayHit.normal * playerRadius;
// Vector3 correctedGroundHit = _groundedRayHit.point + sphereCorrection + (currentGroundPosition - rb.position);
// float groundOffset = correctedGroundHit.y + playerHeightHalf - player.position.y - playerRadius;
// platformMovement.y = groundOffset;

// Vector3 correctedGroundHit = _groundedRayHit.point + currentGroundPosition - rb.position;
// float groundOffset = correctedGroundHit.y + playerHeightHalf - player.position.y;








// private void CheckGround()
//     {
//         // _groundedRayHit.distance == _characterController.height / 2 * player.localScale.y + _characterController.skinWidth // от player.position
//         // if (Physics.SphereCast(player.position, playerRadius, Vector3.down, out _groundedRayHit, playerHeightHalf + 5f, ~LayerMask.GetMask("Player")))
//         //Mathf.Max(0.1f, lastPlatformMovement.y) 0.1f + Mathf.Abs(lastPlatformMovement.y)
//         if (Physics.Raycast(player.position, Vector3.down, out _groundedRayHit, playerHeightHalf + 0.1f + Mathf.Abs(lastPlatformMovement.y), ~LayerMask.GetMask("Player")))
//         {
//             onGrounded = true;
//             CheckGroundPhysicsMaterial();

//             Rigidbody rb = _groundedRayHit.collider.GetComponent<Rigidbody>();
//             MovingPlatformObj movingPlatformObj = _groundedRayHit.collider.GetComponent<MovingPlatformObj>();

//             if (movingPlatformObj)
//             {
//                 rb = _groundedRayHit.collider.GetComponent<MovingPlatformObj>().rb;
//             }

//             if (rb != null && _velocity.y < 0)
//             {
//                 // Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Platform"), true);
//                 gravityOn = false;
//                 Vector3 currentGroundPosition = rb.transform.position;

//                 if (rb != _currentRb)
//                 {
//                     _currentRb = rb;
//                     _previousGroundPosition = currentGroundPosition;
//                 }

//                 lastPlatformMovement = rb.linearVelocity;
//                 Vector3 platformMovement = currentGroundPosition - _previousGroundPosition;
//                 Vector3 correctedGroundHit = _groundedRayHit.point + currentGroundPosition - rb.position;
//                 float groundOffset = correctedGroundHit.y + playerHeightHalf - player.position.y;
//                 // platformMovement.y = Mathf.Lerp(platformMovement.y, groundOffset, 5f / Time.deltaTime);
//                 platformMovement.y = groundOffset;
//                 AdjustCharacterController(platformMovement.y);
//                 _characterController.Move(platformMovement);
//                 _previousGroundPosition = currentGroundPosition;
//             }
//             else
//             {
//                 ExitPlatform();
//             }
//         }
//         else
//         {
//             ExitPlatform();
//             onGrounded = false;
//         }
//     }

// private void ExitPlatform()
//     {
//         _currentRb = null;
//         lastPlatformMovement = Vector3.zero;
//         _characterController.height = characterControllerHeight;
//         _characterController.center = new Vector3(0, 0, 0);
//     }