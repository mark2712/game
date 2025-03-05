using UnityEngine;
public abstract class BaseStandState : BaseMoveStandState
{
    public override void FixedUpdate()
    {
        if (GameContext.playerController.isMove)
        {
            // if (GameContext.gameStateManager.state.GetType().Name != moveStateManager.nowMoveState?.GetType().Name)
            // {
            //     moveStateManager.UpdateState();
            //     GoToState(moveStateManager.nowMoveState);
            // }
        }
    }

    // public override void MoveInput(Vector2 moveInput)
    // {
    //     base.MoveInput(moveInput);
    //     GameContext.playerController.isMove = true;
    //     GoToState(moveStateManager.nowMoveState);
    // }
}
