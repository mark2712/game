using UnityEngine;

namespace Player
{
    public class GroundPlayerController : PlayerController
    {
        public override float NowMoveSpeed { get; set; }
        public float jumpForce = 9f;
        public float gravityScaleNow = 2f;

        public bool isMoveOn; // движение разрешено
        public bool isJumpOn; // прыжок разрешен
        protected Vector3 move; // хранит информацию о движении, отсюда можно получить направление движения

        public GroundPlayerController(GameObject Player) : base(Player) { }

        public override void Update()
        {
            SyncCamera();
        }

        public override void FixedUpdate()
        {
            jumpForce = PlayerControllerRigidbodyMB.self.jumpForce;
            gravityScaleNow = PlayerControllerRigidbodyMB.self.gravityScale;

            groundedSphereRay = GroundState.Ground;
            groundedRay = GroundState.Ground;
            isJumpOn = true;
            isMoveOn = true;

            move = (player.right * MoveInput.x + player.forward * MoveInput.y).normalized * NowMoveSpeed;
            IsMove = move.magnitude > 0.01f;

            if (IsMove) // вращение персонажа в сторону камеры происходит только при движении
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
                if (IsMove)
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

        protected void Move()
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

        protected void JumpSpase()
        {
            if (IsJump)
            {
                IsJump = false;
                Jump(jumpForce);
            }
        }
        protected void JumpStep(float jumpForce)
        {
            Jump(jumpForce);
        }
        protected void Jump(float jumpForce)
        {
            if (IsGround && isJumpOn)
            {
                float currentVerticalSpeed = characterRigidbody.linearVelocity.y;
                if (currentVerticalSpeed > 0) { currentVerticalSpeed = 0; }
                characterRigidbody.AddForce(Vector3.up * (jumpForce * characterRigidbody.mass - currentVerticalSpeed * characterRigidbody.mass), ForceMode.Impulse);
            }
        }

        protected void ApplyGravity()
        {
            Vector3 gravity = Physics.gravity * gravityScaleNow; // Увеличиваем стандартную гравитацию
            characterRigidbody.AddForce(gravity, ForceMode.Acceleration);
        }

        protected float CheckForSteps(Vector3 move)
        {
            _MoveDirection2D.rotation = Quaternion.LookRotation(move, Vector3.up);

            if (Physics.Raycast(stepOffset1.position, Vector3.down, out RaycastHit hit, rayStepHeight, ~layerMask))
            {
                float step = hit.point.y - stepOffsetBottom.position.y;
                return step;
            }

            return 0f; // Нет препятствия
        }

    }
}