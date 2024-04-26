using System;
using Ex13.Entities.Enums;

namespace Ex13.Entities
{
    class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius, Color color) : base(color)
        {
            Radius = radius;
        }
        
        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }
    }
}