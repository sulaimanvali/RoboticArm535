using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticArm535Library
{
    public class MotorLimits
    {
        // Default maximum durations were taken from a quick test. Not meant to be precise.
        public float MaxTimeGrip { get; set; } = 2.7f;
        public float MaxTimeWrist { get; set; } = 8.5f;
        public float MaxTimeElbow { get; set; } = 20.0f;
        public float MaxTimeStem { get; set; } = 14.0f;
        public float MaxTimeBase { get; set; } = 20.0f;

        /// <summary>
        /// Cap duration based on motors requested.
        /// </summary>
        /// <param name="opCode"></param>
        /// <param name="durationSecs"></param>
        /// <returns></returns>
        public float CapDuration(OpCode opCode, float durationSecs)
        {
            if (opCode.HasFlag(OpCode.GripOpen) || opCode.HasFlag(OpCode.GripClose))
                durationSecs = Math.Min(durationSecs, MaxTimeGrip);

            if (opCode.HasFlag(OpCode.WristUp) || opCode.HasFlag(OpCode.WristDown))
                durationSecs = Math.Min(durationSecs, MaxTimeWrist);

            if (opCode.HasFlag(OpCode.ElbowUp) || opCode.HasFlag(OpCode.ElbowDown))
                durationSecs = Math.Min(durationSecs, MaxTimeElbow);

            if (opCode.HasFlag(OpCode.StemAhead) || opCode.HasFlag(OpCode.StemBack))
                durationSecs = Math.Min(durationSecs, MaxTimeStem);

            if (opCode.HasFlag(OpCode.BaseRight) || opCode.HasFlag(OpCode.BaseLeft))
                durationSecs = Math.Min(durationSecs, MaxTimeBase);
            
            return durationSecs;
        }
    }
}
