using GeometricCalculation.Data.Shapes.Base;

namespace GeometricCalculation.Calculator
{
    public static class Calculator
    {
        public static double GetShapeArea(Shape shape) => shape.GetArea();
        public static double GetShapePerimeter(Shape shape) => shape.GetPerimeter();
    }
}
