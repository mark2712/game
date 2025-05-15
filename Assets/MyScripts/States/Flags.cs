using System;
using System.Collections.Generic;

namespace States
{
    public enum FlagName
    {
        Move,
        Shift,
        Sneak,
        Hit,

        Ground,
        Water,
        Fly,

        Stun,
        Drop,
        Fainted,
        Dead,
        // Destroyed,
        // GameOver,
        // Combat,
        LegsShackled,
        LegsRope,
        HandsShackled,
        HandsRope,
    }

    public static class Flags
    {
        private static readonly Dictionary<FlagName, bool> _values = new();
        private static readonly Dictionary<FlagName, Action<bool>> _callbacks = new();

        static Flags()
        {
            foreach (FlagName flag in Enum.GetValues(typeof(FlagName)))
                _values[flag] = false;
        }

        public static bool Get(FlagName flag) => _values[flag];

        public static void Inverse(FlagName flag)
        {
            Set(flag, !Get(flag));
        }

        public static void Set(FlagName flag, bool value)
        {
            if (_values[flag] != value)
            {
                _values[flag] = value;
                PlayerSpeed.Update();
                if (_callbacks.TryGetValue(flag, out var callback))
                    callback?.Invoke(value);
            }
        }

        public static void Subscribe(FlagName flag, Action<bool> callback)
        {
            if (_callbacks.ContainsKey(flag))
                _callbacks[flag] += callback;
            else
                _callbacks[flag] = callback;
        }

        public static void Unsubscribe(FlagName flag, Action<bool> callback)
        {
            if (_callbacks.ContainsKey(flag))
                _callbacks[flag] -= callback;
        }
    }
}
