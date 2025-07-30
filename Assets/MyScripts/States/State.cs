using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace States
{
    public enum StateEventType
    {
        JumpFinished,
        HitFinished,
        InventoryOpened,
    }

    public abstract class ConflictRule
    {
        public SMController SMController = GameContext.SMController;
        public abstract void Resolve();
    }

    public abstract class State
    {
        public SMController SMController = GameContext.SMController;
        public virtual SM SM { get; set; }
        public virtual bool Reentry => true; // разрешен переход из текущего состояния в это же состояния ThisState -> ThisState


        /* Конфликтные состояния */
        public virtual List<ConflictRule> Conflicts => new(); // все указанные State перейдут в DefaultState 

        // ConflictAll - если состояние это TNotAllowedState или его потомок то будет принудительный переход в TGoToStste (DefaultState если нет TGoToStste)
        public class ConflictAll<TNotAllowedState> : ConflictRule where TNotAllowedState : State, new()
        {
            public override void Resolve()
            {
                foreach (var sm in SMController.allSM)
                {
                    if (sm.State is TNotAllowedState || sm.State.GetType().IsSubclassOf(typeof(TNotAllowedState)))
                    {
                        sm.GoToState(sm.DefaultState);
                    }
                }
            }
        }

        public class ConflictAll<TNotAllowedState, TGoToStste> : ConflictRule where TNotAllowedState : State where TGoToStste : State, new()
        {
            public override void Resolve()
            {
                foreach (var sm in SMController.allSM)
                {
                    if (sm.State is TNotAllowedState || sm.State.GetType().IsSubclassOf(typeof(TNotAllowedState)))
                    {
                        sm.GoToState(new TGoToStste());
                    }
                }
            }
        }

        /* Создание кастомных событий */
        public delegate State StateEventHandler(State state);
        private readonly Dictionary<StateEventType, StateEventHandler> _eventHandlers = new();

        protected void RegisterEvent(StateEventType type, StateEventHandler handler)
        {
            _eventHandlers[type] = handler;
        }

        // выполнить событие
        public virtual State HandleEvent(StateEventType type)
        {
            return _eventHandlers.TryGetValue(type, out var handler) ? handler(this) : null;
        }


        /* Переход в состояние */
        protected virtual void GoToState<TNewState>() where TNewState : State
        {
            TNewState newState = Activator.CreateInstance(typeof(TNewState)) as TNewState;
            SM.GoToState(newState);
        }
        protected virtual void GoToState(State newState)
        {
            SM.GoToState(newState);
        }

        protected virtual void GoToGameState()
        {
            SM.GoToState(SM.GetGameState());
        }

        /* Таймер */
        private Dictionary<string, float> timers = new Dictionary<string, float>();

        protected void StartTimer(float durationMs, string name = "Timer")
        {
            timers[name] = Time.time + durationMs / 1000f;
        }

        protected bool IsTimerFinished(string name = "Timer")
        {
            if (timers.TryGetValue(name, out float endTime))
            {
                if (Time.time >= endTime)
                {
                    timers[name] = Time.time; // Сброс таймера
                    return true;
                }
            }
            return false;
        }


        /* SM */
        public virtual void Enter() { }
        public virtual void Exit() { }

        /* События MonoBehaviour */
        public virtual void FixedUpdate() { }
        public virtual void Update() { }
        public virtual void LateUpdate() { }

        /* События флагов */
        public virtual State OnMoveChanged() { return null; }
        public virtual State OnGroundChanged() { return null; }
        public virtual State OnShiftChanged() { return null; }
        public virtual State OnSneakChanged() { return null; }
        public virtual State OnHandsRopeChanged() { return null; }
        public virtual State OnLegsRopeChanged() { return null; }

        /* Прочие события */
        // public virtual State StartDialog() { return null; }

        /* События ввода */
        public virtual State ScrollPerformed(InputAction.CallbackContext ctx) { return null; }

        public virtual State Mouse1Performed() { return null; }
        public virtual State Mouse2Performed() { return null; }
        public virtual State Mouse3Performed() { return null; }

        public virtual State EscPerformed() { return null; }
        public virtual State ConsolePerformed() { return null; }
        public virtual State TabPerformed() { return null; }
        public virtual State ShiftPerformed() { return null; }
        public virtual State ShiftCanceled() { return null; }
        public virtual State CtrlPerformed() { return null; }
        public virtual State CtrlCanceled() { return null; }
        public virtual State AltPerformed() { return null; }
        public virtual State AltCanceled() { return null; }
        public virtual State SpacePerformed() { return null; }

        public virtual State KeyQ_performed() { return null; }
        public virtual State KeyE_performed() { return null; }
        public virtual State KeyR_performed() { return null; }
        public virtual State KeyT_performed() { return null; }
        public virtual State KeyI_performed() { return null; }
        public virtual State KeyF_performed() { return null; }
        public virtual State KeyZ_performed() { return null; }
        public virtual State KeyX_performed() { return null; }
        public virtual State KeyC_performed() { return null; }

        public virtual State Num1_performed() { return null; }
        public virtual State Num2_performed() { return null; }
        public virtual State Num3_performed() { return null; }
        public virtual State Num4_performed() { return null; }
        public virtual State Num5_performed() { return null; }
        public virtual State Num6_performed() { return null; }
        public virtual State Num7_performed() { return null; }
        public virtual State Num8_performed() { return null; }
        public virtual State Num9_performed() { return null; }
        public virtual State Num0_performed() { return null; }

        public virtual State F1_performed() { return null; }
        public virtual State F2_performed() { return null; }
        public virtual State F3_performed() { return null; }
        public virtual State F4_performed() { return null; }
    }
}
