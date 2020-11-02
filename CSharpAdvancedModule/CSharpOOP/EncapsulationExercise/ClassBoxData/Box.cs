using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public double Length
        {
            get => length;

            private set
            {
                ValidateSide(value, nameof(Length));
                length = value;
            }
        }
        public double Width
        {
            get => width;

            private set
            {
                ValidateSide(value, nameof(Width));
                width = value;
            }
        }
        public double Height
        {
            get => height;

            private set
            {
                ValidateSide(value, nameof(Height));
                height = value;
            }
        }

        public void GetSurfaceArea()
        {
            double surfaceArea = (2*Length*Width) + (2*Length*Height) + (2*Height*Width);
            Console.WriteLine($"Surface Area - {surfaceArea:f2}");
        }
        public void GetLateralArea()
        {
            double lateralArea = (2*Length*Height) + (2*Height*Width);
            Console.WriteLine($"Lateral Surface Area - {lateralArea:f2}");
        }
        public void GetVolume()
        {
            double volume = Length * Height * Width;
            Console.WriteLine($"Volume - {volume:f2}");
        }
        private void ValidateSide(double side, string paramName)
        {
            if (side <= 0)
            {
                throw new ArgumentException($"{paramName} cannot be zero or negative.");
            }
        }
    }
}
