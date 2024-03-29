﻿using System;

namespace math_expressions.ExpressionProvider.ValueProvider.Providers
{
    public class DoubleValueProvider : IValueProvider<double>
    {
        public double GetValue(string value)
        {
            if (double.TryParse(value.Replace('.', ','), out double result))
                return result;

            throw new ArgumentException($"Failed to parse value: [{value}]");
        }
    }
}
