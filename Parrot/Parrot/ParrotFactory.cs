using System;

namespace Parrot
{
    public class ParrotFactory
    {
        public static Parrot Create(ParrotTypeEnum type, int numberOfCoconuts, double voltage, bool isNailed)
        {
            switch (type){
                case ParrotTypeEnum.NORWEGIAN_BLUE:
                    return new NorwegianBlueParrot(voltage,isNailed);
                case ParrotTypeEnum.AFRICAN:
                    return new AfricanParrot(numberOfCoconuts);
                case ParrotTypeEnum.EUROPEAN:
                    return new EuropeanParrot();
                default:
                    throw new ArgumentException("This Parrot is not implemented");
            };
        }
    }
}