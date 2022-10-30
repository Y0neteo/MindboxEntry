using GeometricCalculation.Data.Shapes.Base;

namespace GeometricCalculation.Calculator
{
    public static class Calculator
    {
        public static double GetShapeArea(IShape shape) => shape.GetArea();
        public static double GetShapePerimeter(IShape shape) => shape.GetPerimeter();
    }
}
