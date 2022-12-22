using FanControl.Plugins;
using System;
using System.Linq;
using System.Threading;

namespace FanControl.AquacomputerQuadro {
    public class AquacomputerQuadroPlugin : IPlugin2 {
        private HidLibrary.HidDevice HidDevice = null;
        internal ReaderWriterLock rwl;
        internal DataStructs.SensorData data;

        public string Name => "Aquacomputer Quadro Plugin";

        private readonly IPluginLogger _logger;
        public AquacomputerQuadroPlugin(IPluginLogger logger) {
            _logger = logger;
            rwl = new ReaderWriterLock();
            data = new DataStructs.SensorData();
        }

        public void Close() {
            HidDevice?.CloseDevice();
            HidDevice = null;
        }

        public void Initialize() {
            HidLibrary.HidEnumerator hidEnumerator = new HidLibrary.HidEnumerator();
            HidDevice = (HidLibrary.HidDevice)hidEnumerator.Enumerate(0x0C70, 0xF00D).FirstOrDefault();

            if (HidDevice == null) {
                _logger.Log("AquacomputerQuadroPlugin: ERROR! Unable to find device!");
                return;
            }
        }

        public void Load(IPluginSensorsContainer _container) {
            if (HidDevice != null) {
                _container.TempSensors.Add(new Sensor(this, "Temperature1", "Temperature 1", x => (Convert.ToInt16(x)) / 100.0f));
                _container.TempSensors.Add(new Sensor(this, "Temperature2", "Temperature 2", x => (Convert.ToInt16(x)) / 100.0f));
                _container.TempSensors.Add(new Sensor(this, "Temperature3", "Temperature 3", x => (Convert.ToInt16(x)) / 100.0f));
                _container.TempSensors.Add(new Sensor(this, "Temperature4", "Temperature 4", x => (Convert.ToInt16(x)) / 100.0f));
                _container.FanSensors.Add(new Sensor(this, "Fan1Speed", "Fan 1", x => (ushort)x));
                _container.FanSensors.Add(new Sensor(this, "Fan2Speed", "Fan 2", x => (ushort)x));
                _container.FanSensors.Add(new Sensor(this, "Fan3Speed", "Fan 3", x => (ushort)x));
                _container.FanSensors.Add(new Sensor(this, "Fan4Speed", "Fan 4", x => (ushort)x));
            }
        }

        public void Update() {
            if (HidDevice == null)
                return;

            try {
                rwl.AcquireWriterLock(100);
                try {
                    var deviceData = HidDevice.Read(500);

                    if (deviceData != null && deviceData.Status == HidLibrary.HidDeviceData.ReadStatus.Success) {
                        int offset = 0;
                        var header = EndianAttribute.GetStructAtOffset<DataStructs.Header>(deviceData.Data, ref offset);
                        var firmware = EndianAttribute.GetStructAtOffset<DataStructs.Firmware>(deviceData.Data, ref offset);
                        data = EndianAttribute.GetStructAtOffset<DataStructs.SensorData>(deviceData.Data, ref offset);
                    }
                } finally {
                    rwl.ReleaseWriterLock();
                }
            } catch (ApplicationException ex) {
                _logger.Log("AquacomputerQuadroPlugin Exception: " + ex);
            }
        }
    }
}
