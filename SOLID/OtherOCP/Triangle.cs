namespace SOLID.OtherOCP
{
    public class Triangle : IFigure
    {
        public int Base { get; set; }
        public int Hauteur { get; set; }
        public int Cote2 { get; set; }
        public int Cote3 { get; set; }

        public double getArea()
        {
            return (double)(this.Base * this.Hauteur) / 2;
        }

        public double getPerimeter()
        {
            return this.Base + this.Cote2 + this.Cote3;
        }
    }
}