using System;

namespace States
{
    public abstract class HandsState : State
    {
        public override MainStateManager StateManager => GameContext.handsStateManager;
    }
}