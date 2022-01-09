using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using LibUsbDotNet;
using LibUsbDotNet.Info;
using LibUsbDotNet.LibUsb;
using LibUsbDotNet.Main;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboticArm535Library;

namespace RoboticArm535.Test
{
    [TestClass]
    public class TestUsbComms
    {
        [TestMethod]
        public void UsbComms_LedOn_OK()
        {
            var fakeUsbDevice = new FakeUsbDevice();
            var usb = new UsbComms(fakeUsbDevice);
            usb.TurnLed(true);
            var expected = new List<byte[]>() { new byte[] { 0, 0, 0x01 } };
            checkPacket(expected, fakeUsbDevice.PacketsSent);
        }

        [TestMethod]
        public void UsbComms_LedOff_OK()
        {
            var fakeUsbDevice = new FakeUsbDevice();
            var usb = new UsbComms(fakeUsbDevice);
            usb.TurnLed(false);
            var expected = new List<byte[]>() { new byte[] { 0, 0, 0x00 } };
            checkPacket(expected, fakeUsbDevice.PacketsSent);
        }

        [TestMethod]
        public void UsbComms_MoveMotor_OK()
        {
            var fakeUsbDevice = new FakeUsbDevice();
            var usb = new UsbComms(fakeUsbDevice);
            usb.MoveMotor(OpCode.GripOpen);
            var expected = new List<byte[]>() { new byte[] { 0x02, 0, 0 } };
            checkPacket(expected, fakeUsbDevice.PacketsSent);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UsbComms_MoveMotorWait_ExpectException()
        {
            var fakeUsbDevice = new FakeUsbDevice();
            var usb = new UsbComms(fakeUsbDevice);
            usb.MoveMotor(OpCode.Wait);
        }

        [TestMethod]
        public void UsbComms_Cmd_OK()
        {
            var fakeUsbDevice = new FakeUsbDevice();
            var usb = new UsbComms(fakeUsbDevice);
            usb.Cmd(Out.Led.On, Out.Grip.Open, Out.Wrist.Down, Out.Elbow.Down, Out.Stem.Ahead, Out.Base.Left);
            var expected = new List<byte[]>() { new byte[] { 0xaa, 0x02, 0x01 } };
            checkPacket(expected, fakeUsbDevice.PacketsSent);
        }

        [TestMethod]
        public void UsbComms_CmdTimed_OK()
        {
            var fakeUsbDevice = new FakeUsbDevice();
            var usb = new UsbComms(fakeUsbDevice);
            usb.Cmd(OpCode.LedOn, 0.1f);
            var expected = new List<byte[]>() { new byte[] { 0, 0, 0x01 }, new byte[] { 0, 0, 0 } };
            checkPacket(expected, fakeUsbDevice.PacketsSent);
        }

        [TestMethod]
        public void UsbComms_CmdWait_OK()
        {
            var fakeUsbDevice = new FakeUsbDevice();
            var usb = new UsbComms(fakeUsbDevice);
            usb.Cmd(OpCode.Wait, 0.1f); // no exception should be thrown
        }

        [TestMethod]
        public void UsbComms_SendPacket_OK()
        {
            var fakeUsbDevice = new FakeUsbDevice();
            var usb = new UsbComms(fakeUsbDevice);
            var packet = new byte[] { 0xa5, 0x7b, 0x38 };
            usb.SendPacket(packet);
            var expected = new List<byte[]>() { packet };
            checkPacket(expected, fakeUsbDevice.PacketsSent);
        }

        // ================== Private methods ==================
        private static void checkPacket(List<byte[]> expectedPackets, List<byte[]> actualPackets)
        {
            Assert.AreEqual(expectedPackets.Count, actualPackets.Count);
            for (int packetIndex = 0; packetIndex < expectedPackets.Count; packetIndex++)
            {
                var expPacket = expectedPackets[packetIndex];
                var actPacket = actualPackets[packetIndex];
                for (int i = 0; i < expPacket.Length; i++)
                    Assert.AreEqual<byte>(expPacket[i], actPacket[i]);
            }
        }
    }



    /// <summary>
    /// Fake UsbDevice to stub out usb commands.
    /// </summary>
    public sealed class FakeUsbDevice : IUsbDevice
    {
        /// <summary>
        /// List of packets sent in order.
        /// </summary>
        public List<byte[]> PacketsSent { get; private set; } = new List<byte[]>();

        public DeviceHandle DeviceHandle => throw new NotImplementedException();
        public ReadOnlyCollection<UsbConfigInfo> Configs => throw new NotImplementedException();
        public UsbDeviceInfo Info => throw new NotImplementedException();
        public bool IsOpen => true;
        public int Configuration => throw new NotImplementedException();
        public ushort VendorId => throw new NotImplementedException();
        public ushort ProductId => throw new NotImplementedException();
        public bool ClaimInterface(int interfaceID)
        {
            Debug.WriteLine("ClaimInterface " + interfaceID);
            return true;
        }

        public IUsbDevice Clone()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            Debug.WriteLine("Close");
        }

        public int ControlTransfer(UsbSetupPacket setupPacket)
        {
            throw new NotImplementedException();
        }

        public int ControlTransfer(UsbSetupPacket setupPacket, byte[] buffer, int offset, int length)
        {
            PacketsSent.Add(buffer);
            return 3;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool GetAltInterface(out int alternateID)
        {
            throw new NotImplementedException();
        }

        public void GetAltInterfaceSetting(byte interfaceID, out byte selectedAltInterfaceID)
        {
            throw new NotImplementedException();
        }

        public bool GetDescriptor(byte descriptorType, byte index, short langId, IntPtr buffer, int bufferLength, out int transferLength)
        {
            throw new NotImplementedException();
        }

        public bool GetDescriptor(byte descriptorType, byte index, short langId, object buffer, int bufferLength, out int transferLength)
        {
            throw new NotImplementedException();
        }

        public bool GetLangIDs(out short[] langIDs)
        {
            throw new NotImplementedException();
        }

        public bool GetString(out string stringData, short langId, byte stringIndex)
        {
            throw new NotImplementedException();
        }

        public string GetStringDescriptor(byte descriptorIndex, bool failSilently = false)
        {
            throw new NotImplementedException();
        }

        public void Open()
        {
            Debug.WriteLine("Open");
        }

        public UsbEndpointReader OpenEndpointReader(ReadEndpointID readEndpointID, int readBufferSize)
        {
            throw new NotImplementedException();
        }

        public UsbEndpointReader OpenEndpointReader(ReadEndpointID readEndpointID, int readBufferSize, EndpointType endpointType)
        {
            throw new NotImplementedException();
        }

        public UsbEndpointReader OpenEndpointReader(ReadEndpointID readEndpointID)
        {
            throw new NotImplementedException();
        }

        public UsbEndpointWriter OpenEndpointWriter(WriteEndpointID writeEndpointID)
        {
            throw new NotImplementedException();
        }

        public UsbEndpointWriter OpenEndpointWriter(WriteEndpointID writeEndpointID, EndpointType endpointType)
        {
            throw new NotImplementedException();
        }

        public bool ReleaseInterface(int interfaceID)
        {
            throw new NotImplementedException();
        }

        public void ResetDevice()
        {
            throw new NotImplementedException();
        }

        public bool SetAltInterface(int alternateID)
        {
            throw new NotImplementedException();
        }

        public void SetConfiguration(int config)
        {
            throw new NotImplementedException();
        }

        public bool TryGetConfigDescriptor(byte configIndex, out UsbConfigInfo descriptor)
        {
            throw new NotImplementedException();
        }

        public bool TryOpen()
        {
            throw new NotImplementedException();
        }
    }
}
