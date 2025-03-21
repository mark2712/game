using UnityEngine;

public class InputController
{
    private readonly States.MainStateManager mainStateManager;
    private readonly States.EventQueue eventQueue;

    public InputController(States.MainStateManager mainStateManager)
    {
        this.mainStateManager = mainStateManager;
        eventQueue = mainStateManager.eventQueue;
    }

    public void InitializeInput(PlayerInputActions inputActions)
    {
        inputActions.Player.Esc.performed += _ => eventQueue.AddEvent(() => mainStateManager.EscPerformed());
        inputActions.Player.Console.performed += _ => eventQueue.AddEvent(() => mainStateManager.ConsolePerformed());

        inputActions.Player.Move.performed += ctx => eventQueue.AddEvent(() => mainStateManager.MoveInput(ctx.ReadValue<Vector2>()));
        inputActions.Player.Move.canceled += ctx => eventQueue.AddEvent(() => mainStateManager.MoveInput(Vector2.zero));

        inputActions.Player.Look.performed += ctx => eventQueue.AddEvent(() => mainStateManager.LookInput(ctx.ReadValue<Vector2>()));
        inputActions.Player.Look.canceled += ctx => eventQueue.AddEvent(() => mainStateManager.LookInput(Vector2.zero));

        inputActions.Player.Scroll.performed += ctx => eventQueue.AddEvent(() => mainStateManager.ScrollPerformed(ctx)); // Подписываемся на событие колесика мыши

        inputActions.Player.Mouse1.performed += _ => eventQueue.AddEvent(() => mainStateManager.Mouse1Performed());
        inputActions.Player.Mouse2.performed += _ => eventQueue.AddEvent(() => mainStateManager.Mouse2Performed());
        inputActions.Player.Mouse3.performed += _ => eventQueue.AddEvent(() => mainStateManager.Mouse3Performed());

        inputActions.Player.Tab.performed += _ => eventQueue.AddEvent(() => mainStateManager.TabPerformed());

        inputActions.Player.Shift.performed += _ => eventQueue.AddEvent(() => mainStateManager.ShiftPerformed());
        inputActions.Player.Shift.canceled += _ => eventQueue.AddEvent(() => mainStateManager.ShiftCanceled());

        inputActions.Player.Ctrl.performed += _ => eventQueue.AddEvent(() => mainStateManager.CtrlPerformed());
        inputActions.Player.Ctrl.canceled += _ => eventQueue.AddEvent(() => mainStateManager.CtrlCanceled());

        inputActions.Player.Alt.performed += _ => eventQueue.AddEvent(() => mainStateManager.AltPerformed());
        inputActions.Player.Alt.canceled += _ => eventQueue.AddEvent(() => mainStateManager.AltCanceled());

        inputActions.Player.Space.performed += _ => eventQueue.AddEvent(() => mainStateManager.SpacePerformed());

        inputActions.Player.Q.performed += _ => eventQueue.AddEvent(() => mainStateManager.KeyQ_performed());
        inputActions.Player.E.performed += _ => eventQueue.AddEvent(() => mainStateManager.KeyE_performed());
        inputActions.Player.R.performed += _ => eventQueue.AddEvent(() => mainStateManager.KeyR_performed());
        inputActions.Player.T.performed += _ => eventQueue.AddEvent(() => mainStateManager.KeyT_performed());
        inputActions.Player.I.performed += _ => eventQueue.AddEvent(() => mainStateManager.KeyI_performed());
        inputActions.Player.F.performed += _ => eventQueue.AddEvent(() => mainStateManager.KeyF_performed());
        inputActions.Player.Z.performed += _ => eventQueue.AddEvent(() => mainStateManager.KeyZ_performed());
        inputActions.Player.X.performed += _ => eventQueue.AddEvent(() => mainStateManager.KeyX_performed());
        inputActions.Player.C.performed += _ => eventQueue.AddEvent(() => mainStateManager.KeyC_performed());
    }
}
