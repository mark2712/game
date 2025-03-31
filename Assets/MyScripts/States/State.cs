using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public abstract class State : IStateMonoBehaviour, IStateFlagsEvents, IStateInputEvents
    {
        public virtual StateManager StateManager => GameContext.mainStateManager;
        protected float timer;
        public virtual bool Reentry => true; //разрешен переход из текущего стояния в это же стояние ThisState -> ThisState

        protected virtual void GoToState<TNewState>() where TNewState : State
        {
            TNewState newState = Activator.CreateInstance(typeof(TNewState)) as TNewState;
            StateManager.GoToState(newState);
        }
        protected virtual void GoToState(State newState)
        {
            StateManager.GoToState(newState);
        }

        protected virtual void GoToGameState()
        {
            StateManager.GoToState(StateManager.GetGameState());
        }

        protected void StartTimer(float durationMs)
        {
            timer = Time.time + durationMs / 1000f;
        }
        protected bool IsTimerFinished()
        {
            bool isFinished = Time.time >= timer;
            if (isFinished)
            {
                timer = Time.time;
            }
            return isFinished;
        }

        public virtual void ParentEnter() { }
        public virtual void ParentReturn() { }
        public virtual void ParentReentry() { }
        public virtual void ParentExit() { }
        public virtual void Enter() { }
        public virtual void Exit() { }

        public virtual void FixedUpdate() { }
        public virtual void Update() { }
        public virtual void LateUpdate() { }

        /* События флагов */
        public virtual void OnMoveChanged() { }
        public virtual void OnGroundChanged() { }
        public virtual void OnShiftChanged() { }
        public virtual void OnSneakChanged() { }

        /* События ввода */
        public virtual void MoveInput(Vector2 moveInput) { }
        public virtual void LookInput(Vector2 lookInput) { }
        public virtual void ScrollPerformed(InputAction.CallbackContext ctx) { }

        public virtual void Mouse1Performed() { }
        public virtual void Mouse2Performed() { }
        public virtual void Mouse3Performed() { }

        public virtual void EscPerformed() { }
        public virtual void ConsolePerformed() { }
        public virtual void TabPerformed() { }
        public virtual void ShiftPerformed() { }
        public virtual void ShiftCanceled() { }
        public virtual void CtrlPerformed() { }
        public virtual void CtrlCanceled() { }
        public virtual void AltPerformed() { }
        public virtual void AltCanceled() { }
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

    interface IStateMonoBehaviour
    {
        void FixedUpdate();
        void Update();
        void LateUpdate();
    }

    interface IStateFlagsEvents
    {
        void OnMoveChanged();
        void OnGroundChanged();
        void OnShiftChanged();
        void OnSneakChanged();
    }



    interface IStateInputEvents
    {
        void Mouse1Performed();
        void Mouse2Performed();
        void Mouse3Performed();

        void EscPerformed();
        void ConsolePerformed();
        void TabPerformed();
        void ShiftPerformed();
        void ShiftCanceled();
        void CtrlPerformed();
        void CtrlCanceled();
        void AltPerformed();
        void AltCanceled();
        void SpacePerformed();

        void KeyQ_performed();
        void KeyE_performed();
        void KeyR_performed();
        void KeyT_performed();
        void KeyI_performed();
        void KeyF_performed();
        void KeyZ_performed();
        void KeyX_performed();
        void KeyC_performed();
    }
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