using System.Collections.Generic;

namespace SOLID.OtherOCP
{
    public class CalculateurAires
    {
        public double SommeAires(IList<IFigure> figures)
        {
            var area = 0d;
            foreach (var figure in figures)
            {
                area += figure.getArea();

            }

            return area;
        }


    }
}