using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboticArm535Library;
using System;

namespace RoboticArm535.Test
{
    [TestClass]
    public class TestPacketGeneratorByOpCode
    {
        private static void checkPacket(byte[] actual, byte[] expected)
        {
            for (int i = 0; i < actual.Length; i++)
                Assert.AreEqual<byte>(expected[i], actual[i]);
        }

        [TestMethod]
        public void GenByOpCode_LedOn_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.LedOn);
            checkPacket(bytes, new byte[] { 0, 0, 0x01 });
        }

        [TestMethod]
        public void GenByOpCode_LedOff_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.LedOff);
            checkPacket(bytes, new byte[] { 0, 0, 0x00 });
        }

        [TestMethod]
        public void GenByOpCode_GripClose_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.GripClose);
            checkPacket(bytes, new byte[] { 0x01, 0, 0 });
        }

        [TestMethod]
        public void GenByOpCode_GripOpen_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.GripOpen);
            checkPacket(bytes, new byte[] { 0x02, 0, 0 });
        }

        [TestMethod]
        public void GenByOpCode_WristUp_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.WristUp);
            checkPacket(bytes, new byte[] { 0x04, 0, 0 });
        }

        [TestMethod]
        public void GenByOpCode_WristDown_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.WristDown);
            checkPacket(bytes, new byte[] { 0x08, 0, 0 });
        }

        [TestMethod]
        public void GenByOpCode_ElbowUp_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.ElbowUp);
            checkPacket(bytes, new byte[] { 0x10, 0, 0 });
        }

        [TestMethod]
        public void GenByOpCode_ElbowDown_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.ElbowDown);
            checkPacket(bytes, new byte[] { 0x20, 0, 0 });
        }

        [TestMethod]
        public void GenByOpCode_StemBack_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.StemBack);
            checkPacket(bytes, new byte[] { 0x40, 0, 0 });
        }

        [TestMethod]
        public void GenByOpCode_StemAhead_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.StemAhead);
            checkPacket(bytes, new byte[] { 0x80, 0, 0 });
        }

        [TestMethod]
        public void GenByOpCode_BaseRight_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.BaseRight);
            checkPacket(bytes, new byte[] { 0, 0x01, 0 });
        }

        [TestMethod]
        public void GenByOpCode_BaseLeft_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.BaseLeft);
            checkPacket(bytes, new byte[] { 0, 0x02, 0 });
        }

        [TestMethod]
        public void GenByOpCode_AllOff_Ok()
        {
            var bytes = PacketGenerator.GenByOpCode(OpCode.AllOff);
            checkPacket(bytes, new byte[] { 0, 0, 0 });
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GenByOpCode_Wait_ExpectException()
        {
            PacketGenerator.GenByOpCode(OpCode.Wait);
        }
    }
}
