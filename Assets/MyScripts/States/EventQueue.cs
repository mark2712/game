using System;
using System.Collections.Generic;

namespace States
{
    public class EventQueue
    {
        private Queue<Func<State>> queue = new Queue<Func<State>>();

        public void AddEvent(Func<State> action)
        {
            queue.Enqueue(action);
        }

        public void ProcessEvents(SM SM)
        {
            while (queue.Count > 0)
            {
                State newState = queue.Dequeue().Invoke();
                newState?.SM.GoToState(newState);
            }
        }
    }
}