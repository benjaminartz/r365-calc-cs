using System;
using System.Text.RegularExpressions;

namespace R365_Calc
{
    public class Calculator
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a thing: (Press Enter TWICE when done)");
                string input = "";
                string line;
                do {
                    line = Console.ReadLine();
                    input += line + "\n";
                } while (line != "");
                int output = Calculate(input);
                Console.WriteLine("Result:" + output);
            }
        }

        public static int Calculate(string input)
        {
            string[] nums = Regex.Split(input, @",|\n|\r\n");
            int result = 0;

            foreach (string numStr in nums)
            {
                int num = 0;
                try
                {
                    num = System.Convert.ToInt32(numStr);
                } catch (FormatException) { }

                result += num;
            }

            return result;
        }
    }
}
