using System;

namespace FanControl.AquacomputerQuadro {
    public class Sensor : Plugins.IPluginSensor {
        protected System.Reflection.FieldInfo _field;
        private readonly string _description;
        private readonly string _fieldName;
        private readonly Func<object, float?> _lambda;
        private readonly AquacomputerQuadroPlugin _parent;
        float? _value = null;

        internal Sensor(AquacomputerQuadroPlugin parent, string fieldName, string description, Func<object, float?> lambda) {
            _fieldName = fieldName;
            _description = description;
            _lambda = lambda;
            _parent = parent;
            _field = typeof(DataStructs.SensorData).GetField(fieldName);
        }

        public string Id => _fieldName;
        public string Name => _description;
        public float? Value => _value;

        public void Update() {
            try {
                _parent.rwl.AcquireReaderLock(100);
                try {
                    _value = _lambda(_field.GetValue(_parent.data));
                } finally {
                    _parent.rwl.ReleaseReaderLock();
                }
            } catch (ApplicationException) { }
        }
    }
}
