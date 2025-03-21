using System;
using System.Collections.Generic;

namespace States
{
    public class EventQueue
    {
        private Queue<Action> queue = new Queue<Action>();

        public void AddEvent(Action action)
        {
            queue.Enqueue(action);
        }

        public void ProcessEvents()
        {
            while (queue.Count > 0)
            {
                queue.Dequeue().Invoke();
            }
        }
    }
}