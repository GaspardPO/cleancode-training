using System;

namespace Parrot
{
    public class NorwegianBlueParrot : Parrot
    {
        private readonly bool _isNailed;
        private readonly double _voltage;
        private const double MaxSpeed = 24.0;

        public NorwegianBlueParrot(double voltage, bool isNailed)
        {
            _isNailed = isNailed;
            _voltage = voltage;
        }

        public double GetBaseSpeed()
        {
            return 12.0;
        }

        public double GetSpeed()
        {
            return _isNailed ? 0 : GetBaseSpeed(_voltage);
        }
        
        private double GetBaseSpeed(double voltage)
        {
            return Math.Min(MaxSpeed, voltage * GetBaseSpeed());
        }
    }
}