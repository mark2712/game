using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    // public abstract class State : IStateMonoBehaviour, IStateFlagsEvents, IStateInputEvents
    public abstract class State
    {
        public virtual SM SM => GameContext.MainSM;
        public virtual bool Reentry => true; //разрешен переход из текущего стояния в это же стояние ThisState -> ThisState

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

        // Таймер
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

        // public virtual State ParentEnter() { return null; }
        // public virtual State ParentReturn() { return null; }
        // public virtual State ParentReentry() { return null; }
        // public virtual State ParentExit() { return null; }

        /* События MonoBehaviour */
        public virtual State FixedUpdate() { return null; }
        public virtual State Update() { return null; }
        public virtual State LateUpdate() { return null; }

        /* События флагов */
        public virtual State OnMoveChanged() { return null; }
        public virtual State OnGroundChanged() { return null; }
        public virtual State OnShiftChanged() { return null; }
        public virtual State OnSneakChanged() { return null; }

        /* События ввода */
        // public virtual State MoveInput(Vector2 moveInput) { return null; }
        // public virtual State LookInput(Vector2 lookInput) { return null; }
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
    }

    //     interface IStateMonoBehaviour
    //     {
    //         State FixedUpdate();
    //         State Update();
    //         State LateUpdate();
    //     }

    //     interface IStateFlagsEvents
    //     {
    //         State OnMoveChanged();
    //         State OnGroundChanged();
    //         State OnShiftChanged();
    //         State OnSneakChanged();
    //     }



    //     interface IStateInputEvents
    //     {
    //         State Mouse1Performed();
    //         State Mouse2Performed();
    //         State Mouse3Performed();

    //         State EscPerformed();
    //         State ConsolePerformed();
    //         State TabPerformed();
    //         State ShiftPerformed();
    //         State ShiftCanceled();
    //         State CtrlPerformed();
    //         State CtrlCanceled();
    //         State AltPerformed();
    //         State AltCanceled();
    //         State SpacePerformed();

    //         State KeyQ_performed();
    //         State KeyE_performed();
    //         State KeyR_performed();
    //         State KeyT_performed();
    //         State KeyI_performed();
    //         State KeyF_performed();
    //         State KeyZ_performed();
    //         State KeyX_performed();
    //         State KeyC_performed();
    //     }
}






/*
global: { 'Game', 'Dialog', 'Cutscene', 'GameOver' }
world: { 'Ground', 'Air', 'Water', 'GroundWater', 'WaterSurface' }
combat: { 'Off', 'On', 'Skill' }
move: { 'Stand', 'Forward', 'Backward', 'Left', 'Right', 'ForwardLeft', 'ForwardRight', 'BackwardLeft', 'BackwardRight' }
shift: { 'Off', 'On' }
sneak: { 'Off', 'On' }
action: { 'Off', 'Punch', 'Hit', 'Bow', 'Cast', 'Magic', 'Baff', 'Inventory', 'Menu', 'Dialog' }
baff: { 'Off', 'Cold', 'Fire' }


GameOver, Cutscene, Dialog, Action, Move


PauseState - ставит игру на паузу (например открытие консоли ~), единственне сотояние для которого нужны Layers

GameFSM
'Game', 'Dialog', 'Cutscene', 'GameOver', 'Punch', 'Hit', 'ShootBow', 'Cast' - Самостоятельные состояния. Тоесть персонаж не может одновременно ходить, вести диалог и бить.

Game: (body) можно управлять персонажем, анимация отсюда распространяется на всё тело. Переход сюда управляется флагами Flags
    move - MoveFSM
        kick
        air
        stand
        normal { 'Forward', 'Backward', 'Left', 'Right', 'ForwardLeft', 'ForwardRight', 'BackwardLeft', 'BackwardRight' }
        run (Forward)
    sneak - SneakFSM
        air
        jump
        stand
        normal (Forward)
        slow (Forward)
    water
        normal
        run
    fly
        normal
        run
    jump
    air (base)

hands (работает параллельно с другими сотояниями, перекрывает руки)
    action (Baff, Inventory, Magic...) - затрагивает только руки, не путать с ударами и магией
    leftOrRight
        left (HandLeftFSM)
            skill...
        right (HandRightFSM)
            weapon...

*/