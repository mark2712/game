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

        inputActions.Player.Num1.performed += _ => mainSM.Num1_performed();
        inputActions.Player.Num2.performed += _ => mainSM.Num2_performed();
        inputActions.Player.Num3.performed += _ => mainSM.Num3_performed();
        inputActions.Player.Num4.performed += _ => mainSM.Num4_performed();
        inputActions.Player.Num5.performed += _ => mainSM.Num5_performed();
        inputActions.Player.Num6.performed += _ => mainSM.Num6_performed();
        inputActions.Player.Num7.performed += _ => mainSM.Num7_performed();
        inputActions.Player.Num8.performed += _ => mainSM.Num8_performed();
        inputActions.Player.Num9.performed += _ => mainSM.Num9_performed();
        inputActions.Player.Num0.performed += _ => mainSM.Num0_performed();

        inputActions.Player.F1.performed += _ => mainSM.F1_performed();
        inputActions.Player.F2.performed += _ => mainSM.F2_performed();
        inputActions.Player.F3.performed += _ => mainSM.F3_performed();
        inputActions.Player.F4.performed += _ => mainSM.F4_performed();

        // inputActions.Player.F6.performed += _ => mainSM.KeyC_performed();
        // inputActions.Player.F9.performed += _ => mainSM.KeyC_performed();
    }
}
