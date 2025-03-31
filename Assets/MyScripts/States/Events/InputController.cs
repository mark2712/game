using UnityEngine;

public class InputController
{
    private readonly States.StateManager mainStateManager;
    public Vector2 MoveInput = Vector2.zero;

    public InputController(States.StateManager mainStateManager)
    {
        this.mainStateManager = mainStateManager;
    }

    public void SetMoveInput(Vector2 moveInput) { MoveInput = moveInput; }

    public void InitializeInput(PlayerInputActions inputActions)
    {
        inputActions.Player.Esc.performed += _ => mainStateManager.EscPerformed();
        inputActions.Player.Console.performed += _ => mainStateManager.ConsolePerformed();

        // inputActions.Player.Move.performed += ctx => mainStateManager.MoveInput(ctx.ReadValue<Vector2>());
        // inputActions.Player.Move.canceled += ctx => mainStateManager.MoveInput(Vector2.zero);

        inputActions.Player.Move.performed += ctx => SetMoveInput(ctx.ReadValue<Vector2>());
        inputActions.Player.Move.canceled += ctx => SetMoveInput(Vector2.zero);

        inputActions.Player.Look.performed += ctx => mainStateManager.LookInput(ctx.ReadValue<Vector2>());
        inputActions.Player.Look.canceled += ctx => mainStateManager.LookInput(Vector2.zero);

        inputActions.Player.Scroll.performed += ctx => mainStateManager.ScrollPerformed(ctx); // Подписываемся на событие колесика мыши

        inputActions.Player.Mouse1.performed += _ => mainStateManager.Mouse1Performed();
        inputActions.Player.Mouse2.performed += _ => mainStateManager.Mouse2Performed();
        inputActions.Player.Mouse3.performed += _ => mainStateManager.Mouse3Performed();

        inputActions.Player.Tab.performed += _ => mainStateManager.TabPerformed();

        inputActions.Player.Shift.performed += _ => mainStateManager.ShiftPerformed();
        inputActions.Player.Shift.canceled += _ => mainStateManager.ShiftCanceled();

        inputActions.Player.Ctrl.performed += _ => mainStateManager.CtrlPerformed();
        inputActions.Player.Ctrl.canceled += _ => mainStateManager.CtrlCanceled();

        inputActions.Player.Alt.performed += _ => mainStateManager.AltPerformed();
        inputActions.Player.Alt.canceled += _ => mainStateManager.AltCanceled();

        inputActions.Player.Space.performed += _ => mainStateManager.SpacePerformed();

        inputActions.Player.Q.performed += _ => mainStateManager.KeyQ_performed();
        inputActions.Player.E.performed += _ => mainStateManager.KeyE_performed();
        inputActions.Player.R.performed += _ => mainStateManager.KeyR_performed();
        inputActions.Player.T.performed += _ => mainStateManager.KeyT_performed();
        inputActions.Player.I.performed += _ => mainStateManager.KeyI_performed();
        inputActions.Player.F.performed += _ => mainStateManager.KeyF_performed();
        inputActions.Player.Z.performed += _ => mainStateManager.KeyZ_performed();
        inputActions.Player.X.performed += _ => mainStateManager.KeyX_performed();
        inputActions.Player.C.performed += _ => mainStateManager.KeyC_performed();
    }
}
