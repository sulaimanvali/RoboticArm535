using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboticArm535Library;
using System;

namespace RoboticArm535.Test
{
    [TestClass]
    public class TestTimedAction
    {
        [TestMethod]
        public void Parse_OK()
        {
            var t1 = TimedAction.Parse("GripClose 1.2");
            Assert.AreEqual(t1.OpCode, OpCode.GripClose);
            Assert.AreEqual(t1.DurationSecs, 1.2f);
        }

        [TestMethod]
        public void ParseLines_OK()
        {
            var lines = @"
GripClose 1.2
GripOpen  2.3
WristUp   3.4
WristDown 4.5
ElbowUp   5.6
ElbowDown 6.7
StemBack  7.8
StemAhead 8.9
BaseRight 9.1
BaseLeft  0.2
LedOff    1.3
LedOn     2.4
AllOff    3.5";
            var actions = TimedAction.ParseLines(lines);
            Assert.AreEqual<int>(13, actions.Length);

            Assert.AreEqual<OpCode>(OpCode.GripClose, actions[0].OpCode);
            Assert.AreEqual<float>(1.2f, actions[0].DurationSecs);

            Assert.AreEqual<OpCode>(OpCode.GripOpen, actions[1].OpCode);
            Assert.AreEqual<float>(2.3f, actions[1].DurationSecs);

            Assert.AreEqual<OpCode>(OpCode.WristUp, actions[2].OpCode);
            Assert.AreEqual<float>(3.4f, actions[2].DurationSecs);

            Assert.AreEqual<OpCode>(OpCode.WristDown, actions[3].OpCode);
            Assert.AreEqual<float>(4.5f, actions[3].DurationSecs);

            Assert.AreEqual<OpCode>(OpCode.ElbowUp, actions[4].OpCode);
            Assert.AreEqual<float>(5.6f, actions[4].DurationSecs);

            Assert.AreEqual<OpCode>(OpCode.ElbowDown, actions[5].OpCode);
            Assert.AreEqual<float>(6.7f, actions[5].DurationSecs);

            Assert.AreEqual<OpCode>(OpCode.StemBack, actions[6].OpCode);
            Assert.AreEqual<float>(7.8f, actions[6].DurationSecs);

            Assert.AreEqual<OpCode>(OpCode.StemAhead, actions[7].OpCode);
            Assert.AreEqual<float>(8.9f, actions[7].DurationSecs);

            Assert.AreEqual<OpCode>(OpCode.BaseRight, actions[8].OpCode);
            Assert.AreEqual<float>(9.1f, actions[8].DurationSecs);

            Assert.AreEqual<OpCode>(OpCode.BaseLeft, actions[9].OpCode);
            Assert.AreEqual<float>(0.2f, actions[9].DurationSecs);

            Assert.AreEqual<OpCode>(OpCode.LedOff, actions[10].OpCode);
            Assert.AreEqual<float>(1.3f, actions[10].DurationSecs);

            Assert.AreEqual<OpCode>(OpCode.LedOn, actions[11].OpCode);
            Assert.AreEqual<float>(2.4f, actions[11].DurationSecs);

            Assert.AreEqual<OpCode>(OpCode.AllOff, actions[12].OpCode);
            Assert.AreEqual<float>(3.5f, actions[12].DurationSecs);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parse_TooManyElems_ExpectException()
        {
            TimedAction.Parse("GripClose 1.2 dfjshdksjfh");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parse_BadOpCode_ExpectException()
        {
            TimedAction.Parse("GripClosefdfdgd 1.2");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parse_BadDuration_ExpectException()
        {
            TimedAction.Parse("GripClose 1.gfdgf2");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parse_EmptyString_ExpectException()
        {
            TimedAction.Parse("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Parse_NegativeDuration_ExpectException()
        {
            TimedAction.Parse("LedOn -2.4");
        }
    }
}
