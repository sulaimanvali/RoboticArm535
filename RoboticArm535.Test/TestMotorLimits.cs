using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboticArm535Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboticArm535.Test
{
    [TestClass]
    public class TestMotorLimits
    {
        [TestMethod]
        public void CapDuration_Grip_Ok()
        {
            var opcode = OpCode.GripClose;
            var limits = new MotorLimits();
            // if we pass in a very high duration, we get back the cap
            Assert.AreEqual<float>(limits.MaxTimeGrip, limits.CapDuration(opcode, 40.0f));

            // if we pass in a lower than cap duration, we get back our value
            Assert.AreEqual<float>(1.123f, limits.CapDuration(opcode, 1.123f));
        }

        [TestMethod]
        public void CapDuration_Wrist_Ok()
        {
            var opcode = OpCode.WristUp;
            var limits = new MotorLimits();
            // if we pass in a very high duration, we get back the cap
            Assert.AreEqual<float>(limits.MaxTimeWrist, limits.CapDuration(opcode, 40.0f));

            // if we pass in a lower than cap duration, we get back our value
            Assert.AreEqual<float>(1.123f, limits.CapDuration(opcode, 1.123f));
        }

        [TestMethod]
        public void CapDuration_Elbow_Ok()
        {
            var opcode = OpCode.ElbowUp;
            var limits = new MotorLimits();
            // if we pass in a very high duration, we get back the cap
            Assert.AreEqual<float>(limits.MaxTimeElbow, limits.CapDuration(opcode, 40.0f));

            // if we pass in a lower than cap duration, we get back our value
            Assert.AreEqual<float>(1.123f, limits.CapDuration(opcode, 1.123f));
        }

        [TestMethod]
        public void CapDuration_Stem_Ok()
        {
            var opcode = OpCode.StemAhead;
            var limits = new MotorLimits();
            // if we pass in a very high duration, we get back the cap
            Assert.AreEqual<float>(limits.MaxTimeStem, limits.CapDuration(opcode, 40.0f));

            // if we pass in a lower than cap duration, we get back our value
            Assert.AreEqual<float>(1.123f, limits.CapDuration(opcode, 1.123f));
        }

        [TestMethod]
        public void CapDuration_Base_Ok()
        {
            var opcode = OpCode.BaseRight;
            var limits = new MotorLimits();
            // if we pass in a very high duration, we get back the cap
            Assert.AreEqual<float>(limits.MaxTimeBase, limits.CapDuration(opcode, 40.0f));

            // if we pass in a lower than cap duration, we get back our value
            Assert.AreEqual<float>(1.123f, limits.CapDuration(opcode, 1.123f));
        }

        [TestMethod]
        public void CapDuration_GripAndElbow_Ok()
        {
            var opcode = OpCode.GripOpen | OpCode.ElbowUp;
            var limits = new MotorLimits();
            // if we pass in a very high duration, we get back the cap.
            // This shows that we get back the cap for Grip not Elbow, which has a higher cap.
            Assert.AreEqual<float>(limits.MaxTimeGrip, limits.CapDuration(opcode, 10.0f));

            // if we pass in a lower than cap duration, we get back our value
            Assert.AreEqual<float>(1.123f, limits.CapDuration(opcode, 1.123f));
        }

        [TestMethod]
        public void CapDuration_AllOpCodes_Ok()
        {
            var opcode = OpCode.GripOpen | OpCode.WristUp | OpCode.ElbowUp | OpCode.StemBack | OpCode.BaseRight;
            var limits = new MotorLimits();
            // if we pass in a very high duration, we get back the cap.
            // This shows that we get back the cap for Grip not Elbow, which has a higher cap.
            Assert.AreEqual<float>(limits.MaxTimeGrip, limits.CapDuration(opcode, 10.0f));

            // if we pass in a lower than cap duration, we get back our value
            Assert.AreEqual<float>(1.123f, limits.CapDuration(opcode, 1.123f));
        }
    }
}
