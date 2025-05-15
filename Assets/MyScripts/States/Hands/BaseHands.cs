using UnityEngine;

namespace States
{
    public abstract class BaseHands : State
    {
        public override SM SM => SMController.HandsSM;

        public override State OnHandsRopeChanged()
        {
            return SM.GetHandsState();
        }

        public override State Mouse1Performed()
        {
            State legsNewState = SMController.LegsSM.State.Mouse1Performed();
            if (legsNewState == null)
            {
                return new PunchR(); // у ног нет возможности принять участья в атаке, значит атака только рукой
            }
            else
            {
                return new Punch(); // если у ног есть возможность атаковать и у рук тоже то атакуем всем телом
            }
        }

        public override State F1_performed()
        {
            Flags.Inverse(FlagName.HandsRope);
            // Flags.Inverse автоматически запустит событие смены состояния на HandsRope, но тут можно сразу вернуть GetHandsState, но будет 2 события перехода в HandsRope.
            // return SM.GetHandsState();
            return null; // рекомендуется оставить этот вариант
        }
    }
}