using Xunit;

namespace SOLID.Liskov
{
    public class GeometryTest
    {
        [Fact]
        public void Area_should_be_height_times_width_1()
        {
            area_should_be_height_times_width(new Rectangle());
        }

        [Fact]
        public void Area_should_be_height_times_width_2()
        {
            var square = new Square() { Side = 4 };

            Assert.Equal(16, square.Area);
            Assert.Equal(16, square.Height * square.Width);
        }

        private void area_should_be_height_times_width(Rectangle rect)
        {
            rect.Width = 5;
            rect.Height = 4;
            Assert.Equal(20, rect.Area);
        }
    }
}