using States;
using UnityEngine;

public class InputController
{
    private States.MainStateManager _mainStateManager;

    public InputController(States.MainStateManager mainStateManager)
    {
        _mainStateManager = mainStateManager;
    }

    public void InitializeInput(PlayerInputActions inputActions)
    {
        inputActions.Player.Esc.performed += _ => _mainStateManager.EscPerformed();
        inputActions.Player.Console.performed += _ => _mainStateManager.ConsolePerformed();

        inputActions.Player.Move.performed += ctx => _mainStateManager.MoveInput(ctx.ReadValue<Vector2>());
        inputActions.Player.Move.canceled += ctx => _mainStateManager.MoveInput(Vector2.zero);

        inputActions.Player.Look.performed += ctx => _mainStateManager.LookInput(ctx.ReadValue<Vector2>());
        inputActions.Player.Look.canceled += ctx => _mainStateManager.LookInput(Vector2.zero);

        inputActions.Player.Scroll.performed += _mainStateManager.ScrollPerformed; // Подписываемся на событие колесика мыши

        inputActions.Player.Mouse1.performed += _ => _mainStateManager.Mouse1Performed();
        inputActions.Player.Mouse2.performed += _ => _mainStateManager.Mouse2Performed();
        inputActions.Player.Mouse3.performed += _ => _mainStateManager.Mouse3Performed();

        inputActions.Player.Tab.performed += _ => _mainStateManager.TabPerformed();

        inputActions.Player.Shift.performed += _ => _mainStateManager.ShiftPerformed();
        inputActions.Player.Shift.canceled += _ => _mainStateManager.ShiftCanceled();

        inputActions.Player.Ctrl.performed += _ => _mainStateManager.CtrlPerformed();
        inputActions.Player.Ctrl.canceled += _ => _mainStateManager.CtrlCanceled();

        inputActions.Player.Alt.performed += _ => _mainStateManager.AltPerformed();
        inputActions.Player.Space.performed += _ => _mainStateManager.SpacePerformed();

        inputActions.Player.Q.performed += _ => _mainStateManager.KeyQ_performed();
        inputActions.Player.E.performed += _ => _mainStateManager.KeyE_performed();
        inputActions.Player.R.performed += _ => _mainStateManager.KeyR_performed();
        inputActions.Player.T.performed += _ => _mainStateManager.KeyT_performed();
        inputActions.Player.I.performed += _ => _mainStateManager.KeyI_performed();
        inputActions.Player.F.performed += _ => _mainStateManager.KeyF_performed();
        inputActions.Player.Z.performed += _ => _mainStateManager.KeyZ_performed();
        inputActions.Player.X.performed += _ => _mainStateManager.KeyX_performed();
        inputActions.Player.C.performed += _ => _mainStateManager.KeyC_performed();
    }
}
