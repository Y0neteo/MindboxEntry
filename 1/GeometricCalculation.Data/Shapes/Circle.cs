using GeometricCalculation.Data.Shapes.Base;

namespace GeometricCalculation.Data.Shapes
{
    public class Circle : Shape
    {
        private double _radius;
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius
        {
            get => _radius;
            set
            {
                if (value <= 0)
                    throw new ArgumentException(DataUtils.negativeRadiusExceptionMessage);
                _radius = value;
            }
        }

        public override double GetArea() => _radius * _radius * Math.PI;

        public override double GetPerimeter() => Math.PI * 2 * _radius;
    }
}