using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboticArm535Library;

namespace RoboticArm535.Test
{
    [TestClass]
    public class TestPacketGeneratorMultiPress
    {
        [TestMethod]
        public void GenMultiPress_AllOff_Ok()
        {
            var bytes = PacketGenerator.GenMultiPress(Out.Led.Off, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            var expected = new byte[] { 0, 0, 0 };
            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual<byte>(expected[i], bytes[i]);
        }

        [TestMethod]
        public void GenMultiPress_LedOn_Ok()
        {
            var bytes = PacketGenerator.GenMultiPress(Out.Led.On, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            var expected = new byte[] { 0, 0, 0x01 };
            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual<byte>(expected[i], bytes[i]);
        }

        [TestMethod]
        public void GenMultiPress_OnCloseUpAheadRight_Ok()
        {
            var bytes = PacketGenerator.GenMultiPress(Out.Led.On, Out.Grip.Close, Out.Wrist.Up, Out.Elbow.Up, Out.Stem.Ahead, Out.Base.Right);
            var expected = new byte[] { 0x95, 0x01, 0x01 };
            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual<byte>(expected[i], bytes[i]);
        }

        [TestMethod]
        public void GenMultiPress_OffOpenDownBackLeft_Ok()
        {
            var bytes = PacketGenerator.GenMultiPress(Out.Led.Off, Out.Grip.Open, Out.Wrist.Down, Out.Elbow.Down, Out.Stem.Back, Out.Base.Left);
            var expected = new byte[] { 0x6a, 0x02, 0x00 };
            for (int i = 0; i < bytes.Length; i++)
                Assert.AreEqual<byte>(expected[i], bytes[i]);
        }
    }
}
