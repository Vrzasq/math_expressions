namespace math_expressions.ExpressionSolver.ValueProvider.Providers
{
    public class DoubleValueProvider : IValueProvider<double>
    {
        public double GetValue(string value)
        {
            if (double.TryParse(value.Replace('.', ','), out double result))
                return result;

            return 0;
        }
    }
}
