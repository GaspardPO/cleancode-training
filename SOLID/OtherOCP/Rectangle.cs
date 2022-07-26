namespace SOLID.OtherOCP
{
    public class Rectangle : IFigure
    {
        public int Longueur { get; set; }
        public int Largeur { get; set; }

        public double getArea()
        {
            return this.Largeur * this.Longueur ;
        }

    }
}