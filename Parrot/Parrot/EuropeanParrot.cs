namespace Parrot
{
    public class EuropeanParrot : Parrot
    {
        public double GetBaseSpeed()
        {
            return 12.0;
        }

        public double GetSpeed()
        {
            return GetBaseSpeed();
        }
    }
}