using System;

namespace Grafy
{
    public sealed class TooLowValueExcepion : Exception
    {
        private int _minValue;
        private int _value;
        public TooLowValueExcepion(int value, int min_value)
        {
            _value = value;
            _minValue = min_value;        
        }
        public override string ToString()
        {
            return base.Message + "\nPodana wartosc ( " + _value + " ) jest mniejsza od " + _minValue + ".";
        }
    }
}
