using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboticArm535Library;

namespace RoboticArm535.Test
{
    [TestClass]
    public class TestPacketGeneratorByOutputs
    {
        private static void checkPacket(byte[] expected, byte[] actual)
        {
            for (int i = 0; i < actual.Length; i++)
                Assert.AreEqual<byte>(expected[i], actual[i]);
        }

        [TestMethod]
        public void GenByOutputs_LedOff_Ok()
        {
            var bytes = PacketGenerator.GenByOutputs(Out.Led.Off, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            checkPacket(new byte[] { 0, 0, 0 }, bytes);
        }

        [TestMethod]
        public void GenByOutputs_LedOn_Ok()
        {
            var bytes = PacketGenerator.GenByOutputs(Out.Led.On, Out.Grip.Stop, Out.Wrist.Stop, Out.Elbow.Stop, Out.Stem.Stop, Out.Base.Stop);
            checkPacket(new byte[] { 0, 0, 0x01 }, bytes);
        }

        [TestMethod]
        public void GenByOutputs_OnCloseUpAheadRight_Ok()
        {
            var bytes = PacketGenerator.GenByOutputs(Out.Led.On, Out.Grip.Close, Out.Wrist.Up, Out.Elbow.Up, Out.Stem.Ahead, Out.Base.Right);
            checkPacket(new byte[] { 0x95, 0x01, 0x01 }, bytes);
        }

        [TestMethod]
        public void GenByOutputs_OffOpenDownBackLeft_Ok()
        {
            var bytes = PacketGenerator.GenByOutputs(Out.Led.Off, Out.Grip.Open, Out.Wrist.Down, Out.Elbow.Down, Out.Stem.Back, Out.Base.Left);
            checkPacket(new byte[] { 0x6a, 0x02, 0x00 }, bytes);
        }
    }
}
