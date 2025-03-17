using System;
using UnityEngine;

public class PlayerController
{
    // public float baseMoveSpeed = 4f;
    public float baseMoveSpeed
    {
        get => 4f;
        private set { }
    }
    public float nowMoveSpeed = 4f;
    public float jumpForce = 9f;
    public float gravityScaleNow = 2f;
    public byte slopeLimit = 55;
    public float _groundedRayLength;
    public bool isMove;
    public bool isMoveOn;
    public bool isJump = false;
    public bool isJumpOn;

    public event Action<bool> OnGroundStateChanged;
    private bool _isGround;
    public bool IsGround
    {
        get => _isGround;
        private set
        {
            if (_isGround != value)
            {
                _isGround = value;
                OnGroundStateChanged?.Invoke(_isGround);
            }
        }
    }

    public enum GroundState { Ground, Wall, Air }
    public GroundState groundedRay = GroundState.Ground;
    public GroundState groundedSphereRay = GroundState.Ground;
    public bool slopeLimitCollisionOn = false;

    private Vector3 move;
    private Vector2 _moveInput;
    private Vector3 _platformVelocity;

    public Transform player; // Тело игрока
    private CapsuleCollider _characterCollider;
    public Rigidbody characterRigidbody;
    private CapsuleCollider _characterBottomCollider;
    private Transform _stepOffsetContainer;
    private Transform stepOffset1;
    private Transform stepOffset2;
    private Transform stepOffsetBottom;
    private float rayStepHeight;
    private RaycastHit _groundedRayHit;
    private RaycastHit _groundedSphereRayHit;
    private LayerMask layerMask;

    private PhysicsMaterial _playerSkinMaterial;
    private PhysicsMaterial _playerMaterial;
    public Transform playerModel;

    public PlayerController(GameObject Player)
    {
        player = Player.transform;
    }

    public void SetMoveInput(Vector2 moveInput) { _moveInput = moveInput; }
    public void SyncCamera() { CameraPlayerController.self.playerCameraBody.position = player.position; }

    public void Awake()
    {
        _characterCollider = player.GetComponent<CapsuleCollider>();
        if (_characterCollider == null) Debug.LogError("Character CapsuleCollider не найден! Убедитесь, что он находится на объекте Player.");

        characterRigidbody = player.GetComponent<Rigidbody>();
        if (characterRigidbody == null) Debug.LogError("Character Rigidbody не найден! Убедитесь, что он находится на объекте Player.");

        _characterBottomCollider = player.Find("ColliderBottom").GetComponent<CapsuleCollider>();
        if (_characterBottomCollider == null) Debug.LogError("CharacterBottom CapsuleCollider не найден! Убедитесь, что он находится на объекте Player.");

        playerModel = player.Find("PlayerModel");
        if (playerModel == null) Debug.LogError("PlayerModel не найден!");

        _stepOffsetContainer = player.Find("StepOffsetContainer");
        stepOffset1 = _stepOffsetContainer.Find("StepOffset1");
        stepOffset2 = _stepOffsetContainer.Find("StepOffset2");
        stepOffsetBottom = _stepOffsetContainer.Find("StepOffsetBottom");
        rayStepHeight = stepOffset1.position.y - stepOffset2.position.y;

        _playerSkinMaterial = _characterCollider.sharedMaterial;
        _playerMaterial = _characterBottomCollider.sharedMaterial;


        layerMask = LayerMask.GetMask("Player");

        Transform playerBottomPoint = player.Find("PlayerBottomPoint");
        _groundedRayLength = player.position.y - playerBottomPoint.position.y;
    }

    public void Update()
    {
        SyncCamera();
    }

    public void FixedUpdate()
    {
        jumpForce = PlayerControllerRigidbodyMB.self.jumpForce;
        gravityScaleNow = PlayerControllerRigidbodyMB.self.gravityScale;

        groundedSphereRay = GroundState.Ground;
        groundedRay = GroundState.Ground;
        isJumpOn = true;
        isMoveOn = true;

        move = (player.right * _moveInput.x + player.forward * _moveInput.y).normalized * nowMoveSpeed;
        isMove = move.magnitude > 0.01f;

        if (isMove) // вращение персонажа в сторону камеры происходит тольок при движении
        {
            characterRigidbody.MoveRotation(CameraPlayerController.self.playerCameraBody.rotation);
            // characterRigidbody.MoveRotation(Quaternion.Slerp(characterRigidbody.rotation, CameraPlayerController.self.playerCameraBody.rotation, Time.deltaTime * 20f));
        }

        CheckGround();
        IsGround = groundedRay == GroundState.Ground || groundedSphereRay == GroundState.Ground;

        if (groundedSphereRay == GroundState.Wall)
        {
            if (groundedRay != GroundState.Ground)
            {
                isJumpOn = false;// прыжок запрещен
                isMoveOn = false; // движение ограничено
            }
        }

        if (slopeLimitCollisionOn)
        {
            if (!IsGround)
            {
                isJumpOn = false; // прыжок запрещен
                isMoveOn = false; // движение ограничено
            }
        }

        PhysicsMaterial MoveMaterial()
        {
            if (isMove)
            {
                return _playerSkinMaterial;
            }
            else
            {
                if (isMoveOn)
                {
                    return _playerMaterial;
                }
                else
                {
                    return _playerSkinMaterial;
                }
            }
        }

        _characterBottomCollider.sharedMaterial = MoveMaterial();

        Move();
        JumpSpase();
        ApplyGravity();
    }

    public void LateUpdate() { }

    private void Move()
    {
        if (move != Vector3.zero)
        {
            if (!isMoveOn)
            {
                move /= 40;
            }
            _characterBottomCollider.sharedMaterial = _playerSkinMaterial;

            Vector3 velocity = characterRigidbody.linearVelocity;
            Vector3 relativeMove = move + new Vector3(_platformVelocity.x, 0, _platformVelocity.z);
            Vector3 velocityChange = relativeMove - new Vector3(velocity.x, 0, velocity.z);

            if (IsGround)
            {
                float stepeHight = CheckForSteps(move);
                if (stepeHight > 0)
                {
                    JumpStep(Mathf.Min(stepeHight, _characterCollider.height / 2) * gravityScaleNow);
                }
            }
            else
            {
                velocityChange = Vector3.Lerp(Vector3.zero, velocityChange, 0.1f);
            }

            characterRigidbody.AddForce(velocityChange / Time.fixedDeltaTime, ForceMode.Acceleration);
        }
    }

    public void Jump() { isJump = true; }
    private void JumpSpase()
    {
        if (isJump)
        {
            isJump = false;
            Jump(jumpForce);
        }
    }
    private void JumpStep(float jumpForce)
    {
        Jump(jumpForce);
    }
    private void Jump(float jumpForce)
    {
        if (IsGround && isJumpOn)
        {
            float currentVerticalSpeed = characterRigidbody.linearVelocity.y;
            if (currentVerticalSpeed > 0) { currentVerticalSpeed = 0; }
            characterRigidbody.AddForce(Vector3.up * (jumpForce * characterRigidbody.mass - currentVerticalSpeed * characterRigidbody.mass), ForceMode.Impulse);
        }
    }

    private void ApplyGravity()
    {
        Vector3 gravity = Physics.gravity * gravityScaleNow; // Увеличиваем стандартную гравитацию
        characterRigidbody.AddForce(gravity, ForceMode.Acceleration);
    }

    private void CheckGround()
    {
        if (Physics.SphereCast(player.position, _characterCollider.radius * 0.48f, Vector3.down, out _groundedSphereRayHit, _groundedRayLength, ~layerMask))
        {
            groundedSphereRay = GroundState.Ground;
            _platformVelocity = Vector3.zero;

            Rigidbody rb = _groundedSphereRayHit.collider.GetComponentInParent<Rigidbody>();
            if (rb != null) { _platformVelocity = rb.linearVelocity; }

            Vector3 _groundNormal;
            Vector3 correctedRayOrigin = new Vector3(_groundedSphereRayHit.point.x, player.position.y, _groundedSphereRayHit.point.z);
            if (Physics.Raycast(correctedRayOrigin, Vector3.down, out RaycastHit correctedHit, _groundedRayLength, ~layerMask))
            {
                _groundNormal = correctedHit.normal;
            }
            else
            {
                _groundNormal = _groundedSphereRayHit.normal;
            }

            float surfaceAngle = Vector3.Angle(_groundNormal, Vector3.up);
            if (surfaceAngle > slopeLimit && surfaceAngle < 90)
            {
                groundedSphereRay = GroundState.Wall;
            }
        }
        else
        {
            groundedSphereRay = GroundState.Air;
        }

        if (Physics.Raycast(player.position, Vector3.down, out _groundedRayHit, _groundedRayLength, ~layerMask))
        {
            groundedRay = GroundState.Ground;

            float surfaceAngle = Vector3.Angle(_groundedRayHit.normal, Vector3.up);
            if (surfaceAngle > slopeLimit)
            {
                groundedRay = GroundState.Wall;
            }
        }
        else
        {
            groundedRay = GroundState.Air;
        }
    }



    private float CheckForSteps(Vector3 move)
    {
        _stepOffsetContainer.rotation = Quaternion.LookRotation(move, Vector3.up);

        if (Physics.Raycast(stepOffset1.position, Vector3.down, out RaycastHit hit, rayStepHeight, ~layerMask))
        {
            float step = hit.point.y - stepOffsetBottom.position.y;
            return step;
        }

        return 0f; // Нет препятствия
    }

}

