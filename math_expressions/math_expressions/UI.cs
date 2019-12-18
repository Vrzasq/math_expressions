using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace math_expressions
{
    public class UI
    {
        private static UI instance;
        private const string logoPath = @".\assets\logo.txt";
        private string[] logo;

        private UI()
        {
            logo = File.ReadAllLines(logoPath);
        }

        public static UI Instance
        {
            get
            {
                if (instance == null)
                    instance = new UI();

                return instance;
            }
        }

        public void DisplayLogo(bool animate)
        {
            for (int i = 0; i < logo.Length; i++)
                Console.WriteLine(logo[i]);
        }

        public void GreetUser()
        {
            Console.WriteLine("Hello User :)");
            Console.WriteLine("Im am solving math expressions. Ex \"1+2*3/2/1*8-5\"");
            Console.WriteLine();
        }

        public void IntroduceEngines()
        {
            Console.WriteLine("Currently supporting 2 engines:");
            Console.WriteLine("1. EpressionTree - faster - only support basic operations (+, -, *, /) for non negative intigers");
            Console.WriteLine("2. CSharp - slower - with full support");
        }

        public int ChooseEngine()
        {
            Console.WriteLine();
            Console.WriteLine("Choose engine:");
            Console.Write("(1 / 2):  ");

            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Write("\b");
                keyInfo = Console.ReadKey();
            }
            while (keyInfo.Key != ConsoleKey.D1 && keyInfo.Key != ConsoleKey.D2);

            for (int i = 0; i < 2; i++)
                Console.WriteLine();

            return int.Parse(keyInfo.KeyChar.ToString());
        }

        public void EndMessage()
        {
            Console.WriteLine("To continue press [Enter]. To quit press [Escape].");
        }

        public void PresentResult<T>(T result)
        {
            Console.WriteLine();
            Console.WriteLine($"Result: {result}");
            Console.WriteLine();
        }

        public string GetUserMathExpression()
        {
            Console.WriteLine("Please type Your math expression below and press [Enter]:");
            string input = Console.ReadLine();

            return input;
        }
    }
}
