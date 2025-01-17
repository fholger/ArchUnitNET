﻿namespace ArchUnitNET.Domain.PlantUml.Import
{
    internal class Stereotype
    {
        private readonly string _value;
        public Stereotype(string stereotype)
        {
            _value = stereotype ?? throw new System.ArgumentNullException(nameof(stereotype));
        }
        public string AsString()
        {
            return _value;
        }

        public override bool Equals(object obj)
        {
            return obj is Stereotype stereotype &&
                   _value == stereotype._value;
        }

        public override int GetHashCode()
        {
            var hashCode = 397 ^ (_value != null ? _value.GetHashCode() : 0);
            return hashCode;
        }
    }
}