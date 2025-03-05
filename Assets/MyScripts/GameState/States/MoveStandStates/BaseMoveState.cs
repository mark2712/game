using UnityEngine;
public abstract class BaseMoveState : BaseMoveStandState
{
    public override void FixedUpdate()
    {
        if (!GameContext.playerController.isMove)
        {
            if (moveStateManager.isSneaking)
            {
                GoToState<SneakStandState>();
            }
            else
            {
                GoToState<StandState>();
            }
        }
    }
}
