using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace States
{
    public abstract class State : IStateMonoBehaviour, IStateFlagsEvents, IStateInputEvents
    {
        public MainStateManager mainStateManager = GameContext.mainStateManager;
        public virtual bool Reentry => true; //разрешен переход из текущего стояния в это же стояние ThisState -> ThisState

        public virtual void GoToState<TNewState>() where TNewState : State
        {
            TNewState newState = Activator.CreateInstance(typeof(TNewState)) as TNewState;
            mainStateManager.GoToState(newState);
        }

        public virtual void GoToState(State newState)
        {
            mainStateManager.GoToState(newState);
        }

        public virtual State GetGameState()
        {
            throw new Exception("Можно вызвать только у GameState");
        }

        public virtual void OnMoveChanged() { }
        public virtual void OnGroundChanged() { }
        public virtual void OnShiftChanged() { }

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
    }



    interface IStateInputEvents
    {
        void Mouse1Performed();
        void Mouse2Performed();
        void Mouse3Performed();

        void TabPerformed();
        void ShiftPerformed();
        void ShiftCanceled();
        void CtrlPerformed();
        void CtrlCanceled();
        void AltPerformed();
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



GameFSM
'Game', 'Dialog', 'Cutscene', 'GameOver', 'Punch', 'Hit', 'ShootBow', 'Cast' - Самостоятельные состояния. Тоесть персонаж не может одновременно ходить, вести диалог и бить.

Game: (можно управлять персонажем)
    body (анимация отсюда распространяется не только на ноги, но и на всё тело)
        move - MoveFSM
            kick
            air
            jump
            normal { 'Stand', 'Forward', 'Backward', 'Left', 'Right', 'ForwardLeft', 'ForwardRight', 'BackwardLeft', 'BackwardRight' }
            run { 'Stand', 'Forward' }
        sneak - SneakFSM
            air
            jump
            normal { 'Stand', 'Forward' }
            slow { 'Stand', 'Forward' }
        water
            normal
            run
        fly
            normal
            run
    
    hands (работает параллельно с body, перекрывает руки из анимации body)
        leftAndRight
            action (Baff, Inventory, Magic...) - затрагивает только руки, не путать с ударами и магией
        leftOrRight
            left (HandLeftFSM)
                skill...
            right (HandRightFSM)
                weapon...
----

'Game', 'Dialog' и тд управляется стейтом

Глобальные флаги:
sneak/move управялется флагом isSneak
normal/run(slow) управялется флагом isShift

isSneak
isShift
isGround
*/