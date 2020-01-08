using System;

namespace R365_Calc
{
    public class Calculator
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter a thing: ");
                string input = Console.ReadLine();
                int output = Calculate(input);
                Console.WriteLine("Result:" + output);
            }
        }

        public static int Calculate(string input)
        {
            string[] nums = input.Split(",");
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
