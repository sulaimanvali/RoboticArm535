using RoboticArm535Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticArm535
{
    public class TimedAction
    {
        public TimedAction(OpCode opCode, float durationSecs)
        {
            this.OpCode = opCode;
            this.DurationSecs = durationSecs;
        }

        public OpCode OpCode { get; private set; }
        public float DurationSecs { get; private set; }

        public static TimedAction Parse(string opCodeAndDuration)
        {
            var elems = opCodeAndDuration.Split();
            if (elems.Length != 2)
                throw new Exception($"Unable to parse {opCodeAndDuration}. Expected 2 elements.");
            return new TimedAction(Enum.Parse<OpCode>(elems[0]), float.Parse(elems[1]));
        }

        public override string ToString()
        {
            return $"{OpCode} {DurationSecs:F2}";
        }
    }
}
