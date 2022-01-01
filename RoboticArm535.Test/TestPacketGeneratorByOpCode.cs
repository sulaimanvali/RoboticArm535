using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboticArm535Library;
using System;

namespace RoboticArm535.Test
{
    [TestClass]
    public class TestPacketGeneratorByOpCode
    {
        private static void checkPacket(byte[] expected, byte[] actual)
        {
            for (int i = 0; i < actual.Length; i++)
                Assert.AreEqual<byte>(expected[i], actual[i]);
        }

        [TestMethod]
        public void GenByOpCode_LedOn_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.LedOn);
            checkPacket(new byte[] { 0, 0, 0x01 }, bytes);
        }

        [TestMethod]
        public void GenByOpCode_LedOff_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.LedOff);
            checkPacket(new byte[] { 0, 0, 0x00 }, bytes);
        }

        [TestMethod]
        public void GenByOpCode_GripClose_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.GripClose);
            checkPacket(new byte[] { 0x01, 0, 0 }, bytes);
        }

        [TestMethod]
        public void GenByOpCode_GripOpen_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.GripOpen);
            checkPacket(new byte[] { 0x02, 0, 0 }, bytes);
        }

        [TestMethod]
        public void GenByOpCode_WristUp_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.WristUp);
            checkPacket(new byte[] { 0x04, 0, 0 }, bytes);
        }

        [TestMethod]
        public void GenByOpCode_WristDown_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.WristDown);
            checkPacket(new byte[] { 0x08, 0, 0 }, bytes);
        }

        [TestMethod]
        public void GenByOpCode_ElbowUp_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.ElbowUp);
            checkPacket(new byte[] { 0x10, 0, 0 }, bytes);
        }

        [TestMethod]
        public void GenByOpCode_ElbowDown_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.ElbowDown);
            checkPacket(new byte[] { 0x20, 0, 0 }, bytes);
        }

        [TestMethod]
        public void GenByOpCode_StemBack_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.StemBack);
            checkPacket(new byte[] { 0x40, 0, 0 }, bytes);
        }

        [TestMethod]
        public void GenByOpCode_StemAhead_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.StemAhead);
            checkPacket(new byte[] { 0x80, 0, 0 }, bytes);
        }

        [TestMethod]
        public void GenByOpCode_BaseRight_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.BaseRight);
            checkPacket(new byte[] { 0, 0x01, 0 }, bytes);
        }

        [TestMethod]
        public void GenByOpCode_BaseLeft_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.BaseLeft);
            checkPacket(new byte[] { 0, 0x02, 0 }, bytes);
        }

        [TestMethod]
        public void GenByOpCode_AllOff_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.AllOff);
            checkPacket(new byte[] { 0, 0, 0 }, bytes);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GenByOpCode_Wait_ExpectException()
        {
            PacketGenerator.GenByOpCode(OpCode.Wait);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GenByOpCode_LedOnAndOff_ExpectException()
        {
            PacketGenerator.GenByOpCode(OpCode.LedOn | OpCode.LedOff);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GenByOpCode_GripOpenAndClose_ExpectException()
        {
            PacketGenerator.GenByOpCode(OpCode.GripOpen | OpCode.GripClose);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GenByOpCode_WristUpAndDown_ExpectException()
        {
            PacketGenerator.GenByOpCode(OpCode.WristUp | OpCode.WristDown);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GenByOpCode_ElbowUpAndDown_ExpectException()
        {
            PacketGenerator.GenByOpCode(OpCode.ElbowUp | OpCode.ElbowDown);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GenByOpCode_StemAheadAndBack_ExpectException()
        {
            PacketGenerator.GenByOpCode(OpCode.StemAhead | OpCode.StemBack);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GenByOpCode_BaseRightAndLeft_ExpectException()
        {
            PacketGenerator.GenByOpCode(OpCode.BaseRight | OpCode.BaseLeft);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GenByOpCode_AllOffAndSomeOn_ExpectException()
        {
            PacketGenerator.GenByOpCode(OpCode.AllOff | OpCode.BaseLeft);
        }
    }
}
