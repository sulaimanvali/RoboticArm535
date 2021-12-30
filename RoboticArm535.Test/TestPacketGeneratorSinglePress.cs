using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboticArm535Library;

namespace RoboticArm535.Test
{
    [TestClass]
    public class TestPacketGeneratorSinglePress
    {
        private void checkPacket(byte[] actual, byte[] expected)
        {
            for (int i = 0; i < actual.Length; i++)
                Assert.AreEqual<byte>(expected[i], actual[i]);
        }

        [TestMethod]
        public void GenSinglePress_LedOn_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.LedOn);
            checkPacket(bytes, new byte[] { 0, 0, 0x01 });
        }

        [TestMethod]
        public void GenSinglePress_LedOff_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.LedOff);
            checkPacket(bytes, new byte[] { 0, 0, 0x00 });
        }

        [TestMethod]
        public void GenSinglePress_GripClose_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.GripClose);
            checkPacket(bytes, new byte[] { 0x01, 0, 0 });
        }

        [TestMethod]
        public void GenSinglePress_GripOpen_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.GripOpen);
            checkPacket(bytes, new byte[] { 0x02, 0, 0 });
        }

        [TestMethod]
        public void GenSinglePress_WristUp_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.WristUp);
            checkPacket(bytes, new byte[] { 0x04, 0, 0 });
        }

        [TestMethod]
        public void GenSinglePress_WristDown_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.WristDown);
            checkPacket(bytes, new byte[] { 0x08, 0, 0 });
        }

        [TestMethod]
        public void GenSinglePress_ElbowUp_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.ElbowUp);
            checkPacket(bytes, new byte[] { 0x10, 0, 0 });
        }

        [TestMethod]
        public void GenSinglePress_ElbowDown_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.ElbowDown);
            checkPacket(bytes, new byte[] { 0x20, 0, 0 });
        }

        [TestMethod]
        public void GenSinglePress_StemBack_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.StemBack);
            checkPacket(bytes, new byte[] { 0x40, 0, 0 });
        }

        [TestMethod]
        public void GenSinglePress_StemAhead_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.StemAhead);
            checkPacket(bytes, new byte[] { 0x80, 0, 0 });
        }

        [TestMethod]
        public void GenSinglePress_BaseRight_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.BaseRight);
            checkPacket(bytes, new byte[] { 0, 0x01, 0 });
        }

        [TestMethod]
        public void GenSinglePress_BaseLeft_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.BaseLeft);
            checkPacket(bytes, new byte[] { 0, 0x02, 0 });
        }
    }
}
