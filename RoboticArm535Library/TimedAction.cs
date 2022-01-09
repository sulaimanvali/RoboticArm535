using RoboticArm535Library;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticArm535Library
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
            var elems = opCodeAndDuration.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (elems.Length != 2)
                throw new Exception($"Unable to parse \"{opCodeAndDuration}\". Expected 2 elements.");

            if (!Enum.TryParse<OpCode>(elems[0], out OpCode opCode))
                throw new Exception($"Invalid command: {elems[0]}");

            if (!float.TryParse(elems[1], NumberStyles.Float, CultureInfo.InvariantCulture, out float duration))
                throw new Exception($"Invalid duration: {elems[1]}");

            if (duration < 0)
                throw new Exception($"Duration requested cannot be negative: {duration}");

            return new TimedAction(opCode, duration);
        }

        public static TimedAction[] ParseLines(string script)
        {
            var lines = script.Trim().Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            var result = new TimedAction[lines.Length];
            for (int i = 0; i < lines.Length; i++)
                result[i] = TimedAction.Parse(lines[i]);

            return result;
        }

        public override string ToString()
        {
            return string.Format($"{OpCode} {DurationSecs:F2}", CultureInfo.InvariantCulture);
        }
    }
}
