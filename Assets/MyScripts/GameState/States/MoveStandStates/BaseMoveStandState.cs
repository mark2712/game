using UnityEngine;
using UnityEngine.InputSystem;


public abstract class BaseMoveStandState : GameStateFSM
{
    protected MoveStateManager moveStateManager = GameContext.moveStateManager;

    public override void Update()
    {
        GameContext.cameraPlayerController.Update();
    }

    public override void LookInput(Vector2 lookInput)
    {
        GameContext.cameraPlayerController.SetLookInput(lookInput);
    }

    public override void MoveInput(Vector2 moveInput)
    {
        GameContext.playerController.SetMoveInput(moveInput);
    }

    public override void ScrollPerformed(InputAction.CallbackContext ctx)
    {
        GameContext.cameraPlayerController.OnScrollInputPerformed(ctx);
    }

    public override void SpacePerformed()
    {
        // GoToState<JumpState>();
        GameContext.playerController.Jump();
    }

    public override void ConsolePerformed()
    {
        gameStateManager.GoToLayer(new MenuState());
    }

    public override void KeyT_performed()
    {
        CounterFPS.Inc();
    }

    public override void KeyZ_performed()
    {
        GameContext.camerasController.ChangeActiveCameraThirdFirstPerson();
    }

    public override void KeyI_performed()
    {
        gameStateManager.GoToState(new InventoryState());
    }



    public override void ShiftPerformed()
    {
        moveStateManager.ShiftPerformed();
    }

    public override void ShiftCanceled()
    {
        moveStateManager.ShiftCanceled();
    }

    public override void CtrlPerformed()
    {
        moveStateManager.CtrlPerformed();
    }

    public override void CtrlCanceled()
    {
        moveStateManager.CtrlCanceled();
    }

    public override void KeyX_performed()
    {
        moveStateManager.KeyX_performed();
    }

    public override void KeyC_performed()
    {
        moveStateManager.KeyC_performed();
    }
}
