namespace math_expressions.ExpressionSolver
{
    /// <summary>
    /// Generic interface for solving math expression
    /// </summary>
    /// <typeparam name="TRequest">input expression Ex. string</typeparam>
    /// <typeparam name="TResult">output result Ex. double</typeparam>
    public interface IMathExpressionSolver<TRequest, TResult>
    {
        TResult Solve(TRequest expression);
    }
}
