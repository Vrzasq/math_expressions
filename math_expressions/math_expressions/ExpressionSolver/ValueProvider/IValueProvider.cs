using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math_expressions.ExpressionSolver.ValueProvider
{
    public interface IValueProvider<T>
    {
        T GetValue(string value);
    }
}
