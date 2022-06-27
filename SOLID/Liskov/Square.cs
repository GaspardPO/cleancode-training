using System.Collections.Generic;

namespace SOLID.Liskov
{
    public class Square
    {
        public int Height
        {
            get => Side;
        }

        public int Width
        {
            get => Side;
        }

        public int Side { get; set; }

        public int Area => Side*Side;
    }
}