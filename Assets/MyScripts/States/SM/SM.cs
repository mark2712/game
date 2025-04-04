using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace States
{
    public partial class SM
    {
        public virtual State State { get; set; }
        public SM parentSM;
        public EventQueue eventQueue = new();

        public SM(SM parentSM = null)
        {
            this.parentSM = parentSM;
        }

        public virtual void UpdateState()
        {
            eventQueue.ProcessEvents(this);
            if (NextLayerState != null)
            {
                GoToLayer();
            }
        }

        public virtual void GoToStateEnter(State newState)
        {
            State = newState;
            Debug.Log($"Переход в состояние: {State.GetType().Name}");
            State.Enter();
        }

        /*
        ВАЖНО! Переход к сотояниям нужно осуществлять строго в состянии. Если переход произойдет не как вызов метода у текущего сотояния, то могут быть потенциальные проблемы. Используйте такой переход с умом.
        */
        public virtual void GoToState(State newState)
        {
            if (!newState.Reentry && State.GetType() == newState.GetType()) { return; }
            State.Exit();
            GoToStateEnter(newState);
        }

        // Layers
        // используется только для паузы, может терять промежуточные состояния и переходы
        private Stack<State> _stateStack = new Stack<State>();
        private State NextLayerState;

        protected void GoToLayer()
        {
            _stateStack.Push(State);
            GoToStateEnter(NextLayerState);
            NextLayerState = null;
        }

        public void GoToLayer(State newState)
        {
            NextLayerState = newState;
        }

        public void ReturnToLayer()
        {
            if (_stateStack.Count > 0)
            {
                State.Exit();
                State = _stateStack.Pop();
                Debug.Log($"Возврат к состоянию: {State.GetType().Name}");
            }
        }

        // Events
        public void OnMoveChanged() { eventQueue.AddEvent(() => State.OnMoveChanged()); }
        public void OnGroundChanged() { eventQueue.AddEvent(() => State.OnGroundChanged()); }
        public void OnShiftChanged() { eventQueue.AddEvent(() => State.OnShiftChanged()); }
        public void OnSneakChanged() { eventQueue.AddEvent(() => State.OnSneakChanged()); }
        // public void OnGameOverChanged() { eventQueue.AddEvent(() => State.OnGameOverChanged()); }

        public void FixedUpdate() { eventQueue.AddEvent(() => State.FixedUpdate()); }
        public void Update() { eventQueue.AddEvent(() => State.Update()); }
        public void LateUpdate() { eventQueue.AddEvent(() => State.LateUpdate()); }

        public void EscPerformed() { eventQueue.AddEvent(() => State.EscPerformed()); }
        public void ConsolePerformed() { eventQueue.AddEvent(() => State.ConsolePerformed()); }
        // public void MoveInput(Vector2 moveInput) { eventQueue.AddEvent(() => State.MoveInput(moveInput)); }
        // public void LookInput(Vector2 lookInput) { eventQueue.AddEvent(() => State.LookInput(lookInput)); }
        public void ScrollPerformed(InputAction.CallbackContext ctx) { eventQueue.AddEvent(() => State.ScrollPerformed(ctx)); }

        public void Mouse1Performed() { eventQueue.AddEvent(() => State.Mouse1Performed()); }
        public void Mouse2Performed() { eventQueue.AddEvent(() => State.Mouse2Performed()); }
        public void Mouse3Performed() { eventQueue.AddEvent(() => State.Mouse3Performed()); }

        public void TabPerformed() { eventQueue.AddEvent(() => State.TabPerformed()); }
        public void ShiftPerformed() { eventQueue.AddEvent(() => State.ShiftPerformed()); }
        public void ShiftCanceled() { eventQueue.AddEvent(() => State.ShiftCanceled()); }
        public void CtrlPerformed() { eventQueue.AddEvent(() => State.CtrlPerformed()); }
        public void CtrlCanceled() { eventQueue.AddEvent(() => State.CtrlCanceled()); }
        public void AltPerformed() { eventQueue.AddEvent(() => State.AltPerformed()); }
        public void AltCanceled() { eventQueue.AddEvent(() => State.AltCanceled()); }
        public void SpacePerformed() { eventQueue.AddEvent(() => State.SpacePerformed()); }

        public void KeyQ_performed() { eventQueue.AddEvent(() => State.KeyQ_performed()); }
        public void KeyE_performed() { eventQueue.AddEvent(() => State.KeyE_performed()); }
        public void KeyR_performed() { eventQueue.AddEvent(() => State.KeyR_performed()); }
        public void KeyT_performed() { eventQueue.AddEvent(() => State.KeyT_performed()); }
        public void KeyI_performed() { eventQueue.AddEvent(() => State.KeyI_performed()); }
        public void KeyF_performed() { eventQueue.AddEvent(() => State.KeyF_performed()); }
        public void KeyZ_performed() { eventQueue.AddEvent(() => State.KeyZ_performed()); }
        public void KeyX_performed() { eventQueue.AddEvent(() => State.KeyX_performed()); }
        public void KeyC_performed() { eventQueue.AddEvent(() => State.KeyC_performed()); }
    }

}