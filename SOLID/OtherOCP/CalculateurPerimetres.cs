using System.Collections.Generic;

namespace SOLID.OtherOCP
{
    public class CalculateurPerimetres
    {
        public double SommePerimetres(IList<IFigure> figures)
        {
            var perimeter = 0d;
            foreach (var figure in figures)
            {
                perimeter += figure.getPerimeter();
            }

            return perimeter;
        }
    }
}