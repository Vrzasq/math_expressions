using System;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.CSharp;

namespace math_expressions.ExpressionSolver.MathSolvers
{
    public class CSharpMathSolver : IMathExpressionSolver
    {
        private const string resourceName = "math_expressions.ExpressionSolver.templates.CalculatorTemplate.txt";
        private const string calculatorClass = "math_expressions.ExpressionSolver.MathSolvers.CalculatorTemplate";
        private const string templatePlaceholder = "###EXPRESSION###";
        private const string resultMethod = "GetResult";
        private const string divisionByZero = "/0";

        private readonly string template;

        public CSharpMathSolver()
        {
            template = GetTemplate();
        }


        public double Solve(string expression)
        {
            string sanitizedInput = Sanitize(expression);

            if (sanitizedInput.Contains(divisionByZero))
                throw new InvalidOperationException("Can't divide by 0");

            string executableCode = GetCodeExecutableCode(expression);

            using (CodeDomProvider codeProvider = new CSharpCodeProvider())
            {
                var compilerResult = codeProvider.CompileAssemblyFromSource(CompilerParams, executableCode);

                if (compilerResult.Errors.HasErrors)
                {
                    ArgumentException exception = BuildCompilerException(compilerResult.Errors);
                    throw exception;
                }

                object calculatorInstance = compilerResult.CompiledAssembly.CreateInstance(calculatorClass);

                var calculatorMethod = GetResultMethod(compilerResult.CompiledAssembly);
                var result = calculatorMethod.Invoke(calculatorInstance, new object[] { });

                if (result != null)
                    return (double)result;
                else
                    throw new ArgumentException($"Failed to resolve expression {expression}");
            }
        }


        private ArgumentException BuildCompilerException(CompilerErrorCollection errors)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Failed to compile expression:");
            sb.Append(Environment.NewLine);

            for (int i = 0; i < errors.Count; i++)
                sb.Append(errors[i]);

            return new ArgumentException(sb.ToString());
        }


        private MethodInfo GetResultMethod(Assembly assembly)
        {
            var calcultorType = assembly.GetType(calculatorClass);
            return calcultorType.GetRuntimeMethod(resultMethod, new Type[] { });
        }


        private CompilerParameters CompilerParams =>
            new CompilerParameters
            {
                CompilerOptions = "/target:library /optimize",
                GenerateExecutable = false,
                GenerateInMemory = true
            };


        private string GetCodeExecutableCode(string expression) =>
            template.Replace(templatePlaceholder,
                expression
                .Replace("+", "+(double)")
                .Replace("-", "-(double)")
                .Replace("*", "*(double)")
                .Replace("/", "/(double)")
                );


        private string GetTemplate()
        {
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            using (StreamReader streamReader = new StreamReader(stream))
            {
                string result = streamReader.ReadToEnd();
                return result;
            }
        }


        private string Sanitize(string expression) =>
            expression.Replace(" ", string.Empty);

    }
}
