using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameStateFSM
{
    public GameStateManager gameStateManager = GameContext.gameStateManager;
    
    public virtual void GoToState<TNewState>() where TNewState : GameStateFSM
    {
        TNewState newState = Activator.CreateInstance(typeof(TNewState)) as TNewState;
        gameStateManager.GoToState(newState);
    }

    public virtual void GoToState(GameStateFSM newState)
    {
        gameStateManager.GoToState(newState);
    }

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void FixedUpdate() { }
    public virtual void Update() { }
    public virtual void LateUpdate() { }

    /* События ввода */
    public virtual void EscPerformed() { }
    public virtual void ConsolePerformed() { }

    public virtual void MoveInput(Vector2 moveInput) { }
    public virtual void LookInput(Vector2 lookInput) { }
    public virtual void ScrollPerformed(InputAction.CallbackContext ctx) { }

    public virtual void Mouse1Performed() { }
    public virtual void Mouse2Performed() { }
    public virtual void Mouse3Performed() { }

    public virtual void TabPerformed() { }
    public virtual void ShiftPerformed() { }
    public virtual void ShiftCanceled() { }
    public virtual void CtrlPerformed() { }
    public virtual void CtrlCanceled() { }
    public virtual void AltPerformed() { }
    public virtual void SpacePerformed() { }


    public virtual void KeyQ_performed() { }
    public virtual void KeyE_performed() { }
    public virtual void KeyR_performed() { }
    public virtual void KeyT_performed() { }
    public virtual void KeyI_performed() { }
    public virtual void KeyF_performed() { }
    public virtual void KeyZ_performed() { }
    public virtual void KeyX_performed() { }
    public virtual void KeyC_performed() { }

}
