using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController
{
    public enum ID
    {
        Stand = 1,
        Run = 3,
        Air = 4,
        Jump = 5,
        SneakSlow = 7,
    }

    public enum Move { Forward = 1, ForwardRight = 2, ForwardLeft = 3, Right = 4, Left = 5, BackwardRight = 6, BackwardLeft = 7, Backward = 8, }
    public enum MoveSlow { Forward = 1, ForwardRight = 2, ForwardLeft = 3, Right = 4, Left = 5, BackwardRight = 6, BackwardLeft = 7, Backward = 8, }

    private readonly Animator animator;

    public PlayerAnimationController(Transform playerModelVRM)
    {
        animator = playerModelVRM.GetComponent<Animator>();
    }

    public void ChangeMoveState(Move id)
    {
        ChangeState((int)id, "Move", false);
    }

    public void ChangeMoveSlowState(MoveSlow id)
    {
        ChangeState((int)id, "MoveSlow", false);
    }

    public void ChangeStateID(ID id, bool moveSync = true)
    {
        ChangeState((int)id, "ID", moveSync);
    }

    public void ChangeState(int id, string NameID, bool moveSync = true)
    {
        animator.SetInteger("Move", 0);
        animator.SetInteger("MoveSlow", 0);
        animator.SetInteger("ID", 0);

        GameContext.playerModelRotationSync.MoveSync(moveSync);
        animator.SetInteger(NameID, id);
        animator.SetTrigger("ChangeState");
    }



    public void Stand() => ChangeStateID(ID.Stand, false);
    public void Run() => ChangeStateID(ID.Run);
    public void Air() => ChangeStateID(ID.Air);
    public void Jump() => ChangeStateID(ID.Jump);
    public void SneakSlow() => ChangeStateID(ID.SneakSlow);

    public void MoveForward() => ChangeMoveState(Move.Forward);
    public void MoveRight() => ChangeMoveState(Move.Right);
    public void MoveLeft() => ChangeMoveState(Move.Left);
    public void MoveForwardRight() => ChangeMoveState(Move.ForwardRight);
    public void MoveBackwardRight() => ChangeMoveState(Move.BackwardRight);
    public void MoveForwardLeft() => ChangeMoveState(Move.ForwardLeft);
    public void MoveBackwardLeft() => ChangeMoveState(Move.BackwardLeft);
    public void MoveBackward() => ChangeMoveState(Move.Backward);

    public void MoveSlowForward() => ChangeMoveSlowState(MoveSlow.Forward);
    public void MoveSlowRight() => ChangeMoveSlowState(MoveSlow.Right);
    public void MoveSlowLeft() => ChangeMoveSlowState(MoveSlow.Left);
    public void MoveSlowForwardRight() => ChangeMoveSlowState(MoveSlow.ForwardRight);
    public void MoveSlowBackwardRight() => ChangeMoveSlowState(MoveSlow.BackwardRight);
    public void MoveSlowForwardLeft() => ChangeMoveSlowState(MoveSlow.ForwardLeft);
    public void MoveSlowBackwardLeft() => ChangeMoveSlowState(MoveSlow.BackwardLeft);
    public void MoveSlowBackward() => ChangeMoveSlowState(MoveSlow.Backward);
}