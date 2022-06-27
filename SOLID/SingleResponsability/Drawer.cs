using System.Drawing;

namespace SOLID.SingleResponsability
{
    public class Drawer
    {
        private readonly Graphics _graphics;

        public Drawer(Graphics graphics)
        {
            _graphics = graphics;
        }

        public void Draw(Rectangle rectangle)
        {
            //top horizontal line
            _graphics.DrawLine(Pens.Black,
                rectangle.topLeft.X, rectangle.topLeft.Y,
                rectangle.bottomRight.X, rectangle.topLeft.Y
            );
            //bottom horizontal line
            _graphics.DrawLine(Pens.Black,
                rectangle.topLeft.X, rectangle.bottomRight.Y,
                rectangle.bottomRight.X, rectangle.bottomRight.Y
            );
            //left vertical line
            _graphics.DrawLine(Pens.Black,
                rectangle.topLeft.X, rectangle.topLeft.Y,
                rectangle.topLeft.X, rectangle.topLeft.Y - rectangle.Heigth
            );
            //right vertical line
            _graphics.DrawLine(Pens.Black,
                rectangle.bottomRight.X, rectangle.bottomRight.Y - rectangle.Heigth,
                rectangle.bottomRight.X, rectangle.bottomRight.Y
            );
        }
    }
}