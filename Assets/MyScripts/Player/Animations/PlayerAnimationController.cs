using UnityEngine;

public class PlayerAnimationController
{
    public enum ID
    {
        Stand = 1,
        Move = 2,
        Run = 3,
        Air = 4,
        Jump = 5,
        Sneak = 6,
        SneakSlow = 7,

        MoveRight = 8,
        MoveLeft = 9,
        MoveForwardRight = 10,
        MoveBackwardRight = 11,
        MoveForwardLeft = 12,
        MoveBackwardLeft = 13,
        MoveBackward = 14,
    }

    private readonly Animator animator;

    public PlayerAnimationController(Transform playerModelVRM)
    {
        animator = playerModelVRM.GetComponent<Animator>();
    }

    public void ChangeState(ID id, bool moveSync = true)
    {
        GameContext.playerModelRotationSync.MoveSync(moveSync);
        animator.SetInteger("ID", (int)id);
        animator.SetTrigger("ChangeState");
    }

    public void Stand() => ChangeState(ID.Stand, false);
    public void Move() => ChangeState(ID.Move, false);
    public void Run() => ChangeState(ID.Run);
    public void Air() => ChangeState(ID.Air);
    public void Jump() => ChangeState(ID.Jump);
    public void Sneak() => ChangeState(ID.Sneak);
    public void SneakSlow() => ChangeState(ID.SneakSlow);

    public void MoveRight() => ChangeState(ID.MoveRight, false);
    public void MoveLeft() => ChangeState(ID.MoveLeft, false);
    public void MoveForwardRight() => ChangeState(ID.MoveForwardRight, false);
    public void MoveBackwardRight() => ChangeState(ID.MoveBackwardRight, false);
    public void MoveForwardLeft() => ChangeState(ID.MoveForwardLeft, false);
    public void MoveBackwardLeft() => ChangeState(ID.MoveBackwardLeft, false);
    public void MoveBackward() => ChangeState(ID.MoveBackward, false);
}