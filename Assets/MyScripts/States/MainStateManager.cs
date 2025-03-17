using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace States
{
    public class MainStateManager : IStateMonoBehaviour, IStateFlagsEvents, IStateInputEvents
    {
        public State state;

        public void GoToStateEnter(State newState)
        {
            if (newState is GameState) { newState = newState.GetGameState(); }
            state = newState;
            Debug.Log($"Переход в состояние: {state.GetType().Name}");
            state.Enter();
        }

        public void GoToState(State newState)
        {
            if (newState is GameState) { newState = newState.GetGameState(); }
            if (!newState.Reentry && state.GetType() == newState.GetType()) { return; }
            state.Exit();
            GoToStateEnter(newState);
        }

        // Layers
        private Stack<State> _stateStack = new Stack<State>();

        public void GoToLayer(State newState)
        {
            _stateStack.Push(state);
            GoToStateEnter(newState);
        }

        public void ReturnToLayer()
        {
            if (_stateStack.Count > 0)
            {
                state.Exit();
                state = _stateStack.Pop();
                Debug.Log($"Возврат к состоянию: {state.GetType().Name}");
            }
        }

        // Events
        public void OnGroundChanged() { state?.OnGroundChanged(); }
        public void OnShiftChanged() { state?.OnShiftChanged(); }


        public void FixedUpdate() { state?.FixedUpdate(); }
        public void Update() { state?.Update(); }
        public void LateUpdate() { state?.LateUpdate(); }

        public void EscPerformed() { state?.EscPerformed(); }
        public void ConsolePerformed() { state?.ConsolePerformed(); }
        public void MoveInput(Vector2 moveInput) { state?.MoveInput(moveInput); }
        public void LookInput(Vector2 lookInput) { state?.LookInput(lookInput); }
        public void ScrollPerformed(InputAction.CallbackContext ctx) { state?.ScrollPerformed(ctx); }

        public void Mouse1Performed() { state?.Mouse1Performed(); }
        public void Mouse2Performed() { state?.Mouse2Performed(); }
        public void Mouse3Performed() { state?.Mouse3Performed(); }

        public void TabPerformed() { state?.TabPerformed(); }
        public void ShiftPerformed() { state?.ShiftPerformed(); }
        public void ShiftCanceled() { state?.ShiftCanceled(); }
        public void CtrlPerformed() { state?.CtrlPerformed(); }
        public void CtrlCanceled() { state?.CtrlCanceled(); }
        public void AltPerformed() { state?.AltPerformed(); }
        public void SpacePerformed() { state?.SpacePerformed(); }

        public void KeyQ_performed() { state?.KeyQ_performed(); }
        public void KeyE_performed() { state?.KeyE_performed(); }
        public void KeyR_performed() { state?.KeyR_performed(); }
        public void KeyT_performed() { state?.KeyT_performed(); }
        public void KeyI_performed() { state?.KeyI_performed(); }
        public void KeyF_performed() { state?.KeyF_performed(); }
        public void KeyZ_performed() { state?.KeyZ_performed(); }
        public void KeyX_performed() { state?.KeyX_performed(); }
        public void KeyC_performed() { state?.KeyC_performed(); }
    }

}