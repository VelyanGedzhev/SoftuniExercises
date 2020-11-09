﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        private double height;
        private double width;
        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }

       
        public override double CalculateArea()
        {
            return width * height;
        }

        public override double CalculatePerimeter()
        {
            return width * 2 + height * 2;
        }
        public override string Draw()
        {
            return base.Draw() +"Rectangle";
        }
    }
}
