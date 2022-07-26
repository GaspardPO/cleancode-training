using System.Drawing;

namespace SOLID.SingleResponsability;

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
        _graphics.DrawLine(Pens.Black, rectangle.TopLeft.X, rectangle.TopLeft.Y, rectangle.BottomRight.X, rectangle.TopLeft.Y
        );
        //bottom horizontal line
        _graphics.DrawLine(Pens.Black, rectangle.TopLeft.X, rectangle.BottomRight.Y, rectangle.BottomRight.X, rectangle.BottomRight.Y
        );
        //left vertical line
        _graphics.DrawLine(Pens.Black, rectangle.TopLeft.X, rectangle.TopLeft.Y, rectangle.TopLeft.X, rectangle.TopLeft.Y - rectangle.Heigth
        );
        //right vertical line
        _graphics.DrawLine(Pens.Black, rectangle.BottomRight.X, rectangle.BottomRight.Y - rectangle.Heigth, rectangle.BottomRight.X, rectangle.BottomRight.Y
        );
    }
}