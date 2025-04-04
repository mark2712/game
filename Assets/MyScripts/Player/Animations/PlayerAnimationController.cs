using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController
{
    public enum Main
    {
        Stand = 1,
        Kick = 2,
        Run = 3,
        Air = 4,
        Jump = 5,
        SneakSlow = 7,
    }

    public enum Move { Forward = 1, ForwardRight = 2, ForwardLeft = 3, Right = 4, Left = 5, BackwardRight = 6, BackwardLeft = 7, Backward = 8, }
    public enum MoveSlow { Forward = 1, ForwardRight = 2, ForwardLeft = 3, Right = 4, Left = 5, BackwardRight = 6, BackwardLeft = 7, Backward = 8, }

    public enum Hands
    {
        None = 1,
        SwordRightHand = 2,
        SwordLeftHand = 3,
    }

    private readonly Animator animator;
    public int HandsLayerIndex;

    public PlayerAnimationController(Transform playerModelVRM)
    {
        animator = playerModelVRM.GetComponent<Animator>();
        HandsLayerIndex = animator.GetLayerIndex("Hands");
    }

    public void EditHandsLayerIndex(float weight)
    {
        animator.SetLayerWeight(HandsLayerIndex, weight);
    }

    public void ChangeMoveState(Move id)
    {
        ChangeState((int)id, "Move", false);
    }

    public void ChangeMoveSlowState(MoveSlow id)
    {
        ChangeState((int)id, "MoveSlow", false);
    }

    public void ChangeStateID(Main id, bool moveSync = true)
    {
        ChangeState((int)id, "Main", moveSync);
    }

    public void ChangeStateHands(Hands id, bool moveSync = true)
    {
        ChangeState((int)id, "Hands", moveSync);
    }


    public void ChangeState(int id, string NameID, bool moveSync = true)
    {
        animator.SetInteger("Main", 0);
        animator.SetInteger("Move", 0);
        animator.SetInteger("MoveSlow", 0);
        animator.SetInteger("Hands", 0);

        GameContext.PlayerModelRotationSync.MoveSync(moveSync);
        animator.SetInteger(NameID, id);
        animator.SetTrigger("ChangeState");
    }


    public void Kick() => ChangeStateID(Main.Kick);


    public void Stand() => ChangeStateID(Main.Stand, false);
    public void Run() => ChangeStateID(Main.Run);
    public void Air() => ChangeStateID(Main.Air, false);
    public void Jump() => ChangeStateID(Main.Jump, false);
    public void SneakSlow() => ChangeStateID(Main.SneakSlow);

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

    public void HandNone() => ChangeStateHands(Hands.None);
    public void SwordRightHand() => ChangeStateHands(Hands.SwordRightHand);
    public void SwordLeftHand() => ChangeStateHands(Hands.SwordLeftHand);
}