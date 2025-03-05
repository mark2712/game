using UnityEngine;

public class InputController
{
    private GameStateManager _gameStateManager;

    public InputController(GameStateManager gameStateManager)
    {
        _gameStateManager = gameStateManager;
    }

    public void InitializeInput(PlayerInputActions inputActions)
    {
        inputActions.Player.Esc.performed += _ => _gameStateManager.EscPerformed();
        inputActions.Player.Console.performed += _ => _gameStateManager.ConsolePerformed();

        inputActions.Player.Move.performed += ctx => _gameStateManager.MoveInput(ctx.ReadValue<Vector2>());
        inputActions.Player.Move.canceled += ctx => _gameStateManager.MoveInput(Vector2.zero);

        inputActions.Player.Look.performed += ctx => _gameStateManager.LookInput(ctx.ReadValue<Vector2>());
        inputActions.Player.Look.canceled += ctx => _gameStateManager.LookInput(Vector2.zero);

        inputActions.Player.Scroll.performed += _gameStateManager.ScrollPerformed; // Подписываемся на событие колесика мыши

        inputActions.Player.Mouse1.performed += _ => _gameStateManager.Mouse1Performed();
        inputActions.Player.Mouse2.performed += _ => _gameStateManager.Mouse2Performed();
        inputActions.Player.Mouse3.performed += _ => _gameStateManager.Mouse3Performed();

        inputActions.Player.Tab.performed += _ => _gameStateManager.TabPerformed();

        inputActions.Player.Shift.performed += _ => _gameStateManager.ShiftPerformed();
        inputActions.Player.Shift.canceled += _ => _gameStateManager.ShiftCanceled();

        inputActions.Player.Ctrl.performed += _ => _gameStateManager.CtrlPerformed();
        inputActions.Player.Ctrl.canceled += _ => _gameStateManager.CtrlCanceled();

        inputActions.Player.Alt.performed += _ => _gameStateManager.AltPerformed();
        inputActions.Player.Space.performed += _ => _gameStateManager.SpacePerformed();

        inputActions.Player.Q.performed += _ => _gameStateManager.KeyQ_performed();
        inputActions.Player.E.performed += _ => _gameStateManager.KeyE_performed();
        inputActions.Player.R.performed += _ => _gameStateManager.KeyR_performed();
        inputActions.Player.T.performed += _ => _gameStateManager.KeyT_performed();
        inputActions.Player.I.performed += _ => _gameStateManager.KeyI_performed();
        inputActions.Player.F.performed += _ => _gameStateManager.KeyF_performed();
        inputActions.Player.Z.performed += _ => _gameStateManager.KeyZ_performed();
        inputActions.Player.X.performed += _ => _gameStateManager.KeyX_performed();
        inputActions.Player.C.performed += _ => _gameStateManager.KeyC_performed();
    }
}
