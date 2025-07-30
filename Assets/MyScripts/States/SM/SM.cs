using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace States
{
    public abstract partial class SM
    {
        public SMController smController;
        public virtual State State { get; set; }
        public virtual State DefaultState { get; set; }

        public virtual void UpdateState()
        {
            if (NextLayerState != null)
            {
                GoToLayer();
            }
        }

        public virtual void GoToStateEnter(State newState)
        {
            State = newState;

            foreach (var conflict in newState.Conflicts)
            {
                conflict.Resolve();
            }

            string debugStateColor = this.GetType().Name switch
            {
                "MainSM" => "#ffe2ae",
                "HandsSM" => "#c2aeff",
                "RightHandSM" => "#aec7ff",
                "LeftHandSM" => "#aeecff",
                "ModalSM" => "#edfb7c",
                _ => "#ffffff",
            };
            // Debug.Log($"<color={debugStateColor}>Переход в состояние: <b>{State.GetType().Name}</b> ({this.GetType().Name})</color>");
            State.Enter();
        }

        /*
        ВАЖНО! Переход к сотояниям нужно осуществлять строго в состянии (через очередь событий). Если переход произойдет не как вызов метода у текущего сотояния, то могут быть потенциальные проблемы. Используйте такой переход с умом. Так же можно положить новое состояние сразу в State, но это можно делать только в особых случаях.
        */
        public virtual void GoToState(State newState)
        {
            if (!newState.Reentry && State.GetType() == newState.GetType()) { return; }
            State?.Exit();
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
        public void FixedUpdate() { State.FixedUpdate(); }
        public void Update() { State.Update(); }
        public void LateUpdate() { State.LateUpdate(); }

        public void TriggerEvent(StateEventType eventType)
        {
            EventQueue.AddEvent(() => State.HandleEvent(eventType));
        }

        public void OnMoveChanged() { EventQueue.AddEvent(() => State.OnMoveChanged()); }
        public void OnGroundChanged() { EventQueue.AddEvent(() => State.OnGroundChanged()); }
        public void OnShiftChanged() { EventQueue.AddEvent(() => State.OnShiftChanged()); }
        public void OnSneakChanged() { EventQueue.AddEvent(() => State.OnSneakChanged()); }

        public void OnHandsRopeChanged() { EventQueue.AddEvent(() => State.OnHandsRopeChanged()); }
        public void OnLegsRopeChanged() { EventQueue.AddEvent(() => State.OnLegsRopeChanged()); }

        // public void OnGameOverChanged() { EventQueue.AddEvent(() => State.OnGameOverChanged()); }
        // public void StartDialog() { EventQueue.AddEvent(() => State.StartDialog()); }


        public void EscPerformed() { EventQueue.AddEvent(() => State.EscPerformed()); }
        public void ConsolePerformed() { EventQueue.AddEvent(() => State.ConsolePerformed()); }
        public void ScrollPerformed(InputAction.CallbackContext ctx) { EventQueue.AddEvent(() => State.ScrollPerformed(ctx)); }

        public void Mouse1Performed() { EventQueue.AddEvent(() => State.Mouse1Performed()); }
        public void Mouse2Performed() { EventQueue.AddEvent(() => State.Mouse2Performed()); }
        public void Mouse3Performed() { EventQueue.AddEvent(() => State.Mouse3Performed()); }

        public void TabPerformed() { EventQueue.AddEvent(() => State.TabPerformed()); }
        public void ShiftPerformed() { EventQueue.AddEvent(() => State.ShiftPerformed()); }
        public void ShiftCanceled() { EventQueue.AddEvent(() => State.ShiftCanceled()); }
        public void CtrlPerformed() { EventQueue.AddEvent(() => State.CtrlPerformed()); }
        public void CtrlCanceled() { EventQueue.AddEvent(() => State.CtrlCanceled()); }
        public void AltPerformed() { EventQueue.AddEvent(() => State.AltPerformed()); }
        public void AltCanceled() { EventQueue.AddEvent(() => State.AltCanceled()); }
        public void SpacePerformed() { EventQueue.AddEvent(() => State.SpacePerformed()); }

        public void KeyQ_performed() { EventQueue.AddEvent(() => State.KeyQ_performed()); }
        public void KeyE_performed() { EventQueue.AddEvent(() => State.KeyE_performed()); }
        public void KeyR_performed() { EventQueue.AddEvent(() => State.KeyR_performed()); }
        public void KeyT_performed() { EventQueue.AddEvent(() => State.KeyT_performed()); }
        public void KeyI_performed() { EventQueue.AddEvent(() => State.KeyI_performed()); }
        public void KeyF_performed() { EventQueue.AddEvent(() => State.KeyF_performed()); }
        public void KeyZ_performed() { EventQueue.AddEvent(() => State.KeyZ_performed()); }
        public void KeyX_performed() { EventQueue.AddEvent(() => State.KeyX_performed()); }
        public void KeyC_performed() { EventQueue.AddEvent(() => State.KeyC_performed()); }

        public void Num1_performed() { EventQueue.AddEvent(() => State.Num1_performed()); }
        public void Num2_performed() { EventQueue.AddEvent(() => State.Num2_performed()); }
        public void Num3_performed() { EventQueue.AddEvent(() => State.Num3_performed()); }
        public void Num4_performed() { EventQueue.AddEvent(() => State.Num4_performed()); }
        public void Num5_performed() { EventQueue.AddEvent(() => State.Num5_performed()); }
        public void Num6_performed() { EventQueue.AddEvent(() => State.Num6_performed()); }
        public void Num7_performed() { EventQueue.AddEvent(() => State.Num7_performed()); }
        public void Num8_performed() { EventQueue.AddEvent(() => State.Num8_performed()); }
        public void Num9_performed() { EventQueue.AddEvent(() => State.Num9_performed()); }
        public void Num0_performed() { EventQueue.AddEvent(() => State.Num0_performed()); }

        public void F1_performed() { EventQueue.AddEvent(() => State.F1_performed()); }
        public void F2_performed() { EventQueue.AddEvent(() => State.F2_performed()); }
        public void F3_performed() { EventQueue.AddEvent(() => State.F3_performed()); }
        public void F4_performed() { EventQueue.AddEvent(() => State.F4_performed()); }
    }
}