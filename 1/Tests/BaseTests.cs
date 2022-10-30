
namespace Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        [TestCase(5.0, 78.54)]
        [TestCase(2.0, 12.57)]
        public void TestCircleArea(double radius, double expectedResult)
        {
            var circle = new Circle(radius);

            var cirleArea = Math.Round(circle.GetArea(), 2);

            cirleArea.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(new double[] { 5.0, 7.0, 10.0 }, 16.25)]
        [TestCase(new double[] { 13.5, 15.0, 20.18 }, 101.25)] // Прямоугольный
        public void TestTriangleArea(double[] sides, double expectedResult)
        {
            var triangle = new Triangle(sides);

            var triangleArea =  Math.Round(triangle.GetArea(), 2);

            triangleArea.Should().Be(expectedResult);
        }

        [Test]
        [TestCase(new double[] { 5.0, 12.0, 13.0 }, true)] // Прямоугольный
        [TestCase(new double[] { 10.0, 10.0, 10.0 }, false)]
        public void TestTriangleRightDetermination(double[] sides, bool expectedResult)
        {
            var triangle = new Triangle(sides);

            triangle.IsRight.Should().Be(expectedResult);
        }
    }
}