namespace math_expressions.ExpressionSolver
{
    /// <summary>
    /// Generic interface for solving math expression
    /// </summary>
    public interface IMathExpressionSolver
    {
        /// <exception cref="System.ArgumentException">Incorrect input was provided</exception>
        /// <exception cref="System.InvalidOperationException">Expression can't be evaluated or 0 division</exception>
        double Solve(string expression);
    }
}
