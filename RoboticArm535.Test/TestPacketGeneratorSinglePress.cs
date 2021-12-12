using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboticArm535Library;

namespace RoboticArm535.Test
{
    [TestClass]
    public class TestPacketGeneratorSinglePress
    {
        [TestMethod]
        public void GenSinglePress_LedOn_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.LedOn);
            var expected = new byte[] { 0, 0, 0x01 };
            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual<byte>(expected[i], bytes[i]);
        }

        [TestMethod]
        public void GenSinglePress_LedOff_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.AllOff);
            var expected = new byte[] { 0, 0, 0x00 };
            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual<byte>(expected[i], bytes[i]);
        }

        [TestMethod]
        public void GenSinglePress_GripClose_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.GripClose);
            var expected = new byte[] { 0x01, 0, 0 };
            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual<byte>(expected[i], bytes[i]);
        }

        [TestMethod]
        public void GenSinglePress_GripOpen_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.GripOpen);
            var expected = new byte[] { 0x02, 0, 0 };
            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual<byte>(expected[i], bytes[i]);
        }

        [TestMethod]
        public void GenSinglePress_WristUp_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.WristUp);
            var expected = new byte[] { 0x04, 0, 0 };
            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual<byte>(expected[i], bytes[i]);
        }

        [TestMethod]
        public void GenSinglePress_WristDown_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.WristDown);
            var expected = new byte[] { 0x08, 0, 0 };
            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual<byte>(expected[i], bytes[i]);
        }

        [TestMethod]
        public void GenSinglePress_ElbowUp_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.ElbowUp);
            var expected = new byte[] { 0x10, 0, 0 };
            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual<byte>(expected[i], bytes[i]);
        }

        [TestMethod]
        public void GenSinglePress_ElbowDown_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.ElbowDown);
            var expected = new byte[] { 0x20, 0, 0 };
            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual<byte>(expected[i], bytes[i]);
        }

        [TestMethod]
        public void GenSinglePress_StemBack_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.StemBack);
            var expected = new byte[] { 0x40, 0, 0 };
            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual<byte>(expected[i], bytes[i]);
        }

        [TestMethod]
        public void GenSinglePress_StemAhead_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.StemAhead);
            var expected = new byte[] { 0x80, 0, 0 };
            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual<byte>(expected[i], bytes[i]);
        }

        [TestMethod]
        public void GenSinglePress_BaseRight_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.BaseRight);
            var expected = new byte[] { 0, 0x01, 0 };
            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual<byte>(expected[i], bytes[i]);
        }

        [TestMethod]
        public void GenSinglePress_BaseLeft_Ok()
        {
            var bytes = PacketGenerator.GenSinglePress(OpCode.BaseLeft);
            var expected = new byte[] { 0, 0x02, 0 };
            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual<byte>(expected[i], bytes[i]);
        }
    }
}
