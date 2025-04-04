using UnityEngine;

public class InputController
{
    private readonly States.SM mainSM;
    public Vector2 MoveInput = Vector2.zero;
    public Vector2 LookInput = Vector2.zero;

    public InputController(States.SM mainSM)
    {
        this.mainSM = mainSM;
    }

    public void SetMoveInput(Vector2 moveInput) { MoveInput = moveInput; }
    public void SetLookInput(Vector2 lookInput) { LookInput = lookInput; }

    public void InitializeInput(PlayerInputActions inputActions)
    {
        inputActions.Player.Esc.performed += _ => mainSM.EscPerformed();
        inputActions.Player.Console.performed += _ => mainSM.ConsolePerformed();

        // inputActions.Player.Move.performed += ctx => mainSM.MoveInput(ctx.ReadValue<Vector2>());
        // inputActions.Player.Move.canceled += ctx => mainSM.MoveInput(Vector2.zero);

        // inputActions.Player.Look.performed += ctx => mainSM.LookInput(ctx.ReadValue<Vector2>());
        // inputActions.Player.Look.canceled += ctx => mainSM.LookInput(Vector2.zero);

        inputActions.Player.Move.performed += ctx => SetMoveInput(ctx.ReadValue<Vector2>());
        inputActions.Player.Move.canceled += ctx => SetMoveInput(Vector2.zero);

        inputActions.Player.Look.performed += ctx => SetLookInput(ctx.ReadValue<Vector2>());
        inputActions.Player.Look.canceled += ctx => SetLookInput(Vector2.zero);

        inputActions.Player.Scroll.performed += ctx => mainSM.ScrollPerformed(ctx); // Подписываемся на событие колесика мыши

        inputActions.Player.Mouse1.performed += _ => mainSM.Mouse1Performed();
        inputActions.Player.Mouse2.performed += _ => mainSM.Mouse2Performed();
        inputActions.Player.Mouse3.performed += _ => mainSM.Mouse3Performed();

        inputActions.Player.Tab.performed += _ => mainSM.TabPerformed();

        inputActions.Player.Shift.performed += _ => mainSM.ShiftPerformed();
        inputActions.Player.Shift.canceled += _ => mainSM.ShiftCanceled();

        inputActions.Player.Ctrl.performed += _ => mainSM.CtrlPerformed();
        inputActions.Player.Ctrl.canceled += _ => mainSM.CtrlCanceled();

        inputActions.Player.Alt.performed += _ => mainSM.AltPerformed();
        inputActions.Player.Alt.canceled += _ => mainSM.AltCanceled();

        inputActions.Player.Space.performed += _ => mainSM.SpacePerformed();

        inputActions.Player.Q.performed += _ => mainSM.KeyQ_performed();
        inputActions.Player.E.performed += _ => mainSM.KeyE_performed();
        inputActions.Player.R.performed += _ => mainSM.KeyR_performed();
        inputActions.Player.T.performed += _ => mainSM.KeyT_performed();
        inputActions.Player.I.performed += _ => mainSM.KeyI_performed();
        inputActions.Player.F.performed += _ => mainSM.KeyF_performed();
        inputActions.Player.Z.performed += _ => mainSM.KeyZ_performed();
        inputActions.Player.X.performed += _ => mainSM.KeyX_performed();
        inputActions.Player.C.performed += _ => mainSM.KeyC_performed();
    }
}
