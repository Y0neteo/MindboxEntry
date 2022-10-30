using GeometricCalculation.Data.Shapes.Base;

namespace GeometricCalculation.Data.Shapes
{
    public class Triangle : IShape
    {
        private double[] _sides;
        public Triangle(double[] sides)
        {
            Sides = sides;
        }

        public double[] Sides
        {
            get => _sides;
            set
            {
                if (value.Any(val => val <= 0))
                    throw new ArgumentException(DataUtils.negativeSideExceptionMessage);
                if (value.Any(double.IsNaN) || value.Length != 3 || (!CanTriangleExist(value)))
                    throw new ArgumentException(DataUtils.unsuitableValueMessage);
                _sides = value;
            }
        }

        public bool IsRight => IsTriangleRight();

        public double GetPerimeter() => _sides.Aggregate(0.0, (counter, value) => counter + value);

        public double GetArea()
        {
            if (IsRight)
                return GetAreaForRightTriangle();

            return GetAreaByAllSides();
        }

        // Площадь треугольника по формуле Герона
        private double GetAreaByAllSides()
        {
            var semiPerimeter = GetPerimeter() / 2;
            var someCalculation = semiPerimeter * (semiPerimeter - _sides[0]) * (semiPerimeter - _sides[1]) * (semiPerimeter - _sides[2]);

            return Math.Sqrt(someCalculation);
        }

        // Площадь прямоугольного треугольника по половине произведения катетов
        private double GetAreaForRightTriangle() => _sides.OrderBy(val => val)
                                                          .Take(2)
                                                          .Aggregate((first,second) => first * second / 2);

        //Проверка прямоугольного треугольника по 3 сторонам
        private bool IsTriangleRight()
        {
            var largestSideSquare = Math.Pow(_sides.Max(), 2);
            var sumOfSquaresOfTwoBasedSides =_sides.OrderBy(val => val)
                                                          .Take(2)
                                                          .Aggregate((first,second) => (first * first) + (second * second));

            return largestSideSquare == sumOfSquaresOfTwoBasedSides;
        }

        // Проверка сторон для постройки треугольника
        private static bool CanTriangleExist(double[] sides)
        {
            var comparableSides = sides.Select(value => Convert.ToInt32(value)).ToArray();

            return comparableSides[0] <= comparableSides[1] + comparableSides[2] &&
               comparableSides[1] <= comparableSides[0] + comparableSides[2] &&
               comparableSides[2] <= comparableSides[0] + comparableSides[1];
        }
    }
}