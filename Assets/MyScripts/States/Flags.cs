using System;

namespace States
{
    public static class Flags
    {
        public static bool Sneak = false;
        public static bool Combat = false;
        public static bool Water = false;
        public static bool Fly = false;

        public static event Action<bool> OnGroundChanged;
        public static event Action<bool> OnShiftChanged;

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
    }
}