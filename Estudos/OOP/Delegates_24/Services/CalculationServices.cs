using System;

namespace Delegates_24.Services
{
    class CalculationServices
    {
        public static double Max(double x, double y) {
            return (x > y) ? x : y;
        }

        public static double Sum(double x, double y) {
            return x + y;
        }

        public static double Square(double x) {
            return x * x;
        }
    }
}