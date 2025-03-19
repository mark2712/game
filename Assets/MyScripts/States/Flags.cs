using System;

namespace States
{
    public static class Flags
    {
        public static bool Combat = false;
        public static bool Water = false;
        public static bool Fly = false;

        public static event Action<bool> OnMoveChanged;
        public static event Action<bool> OnGroundChanged;
        public static event Action<bool> OnShiftChanged;
        public static event Action<bool> OnSneakChanged;

        private static bool _move = false;
        public static bool Move
        {
            get => _move;
            set
            {
                if (_move != value)
                {
                    _move = value;
                    OnMoveChanged?.Invoke(_move);
                }
            }
        }

        private static bool _ground = false;
        public static bool Ground
        {
            get => _ground;
            set
            {
                if (_ground != value)
                {
                    _ground = value;
                    OnGroundChanged?.Invoke(_ground);
                }
            }
        }

        private static bool _shift = false;
        public static bool Shift
        {
            get => _shift;
            set
            {
                if (_shift != value)
                {
                    _shift = value;
                    OnShiftChanged?.Invoke(_shift);
                }
            }
        }

        private static bool _sneak = false;
        public static bool Sneak
        {
            get => _sneak;
            set
            {
                if (_sneak != value)
                {
                    _sneak = value;
                    OnSneakChanged?.Invoke(_sneak);
                }
            }
        }
    }
}