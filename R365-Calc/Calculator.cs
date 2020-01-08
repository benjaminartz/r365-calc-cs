using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

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
            string delimeter = @",|\n|\r\n";
            bool customDelimeter = false;

            if (input.StartsWith("//["))
            {
                int len = input.IndexOf("]\n") - 3;
                delimeter = input.Substring(3, len);
                input = input.Substring(len + 4);
                customDelimeter = true;
            } else if (input.StartsWith("//"))
            {
                delimeter = input.Substring(2, 1);
                input = input.Substring(4);
                customDelimeter = true;
            }
            string[] nums = customDelimeter ? input.Split(delimeter) : Regex.Split(input, delimeter);
            int result = 0;
            List<int> negatives = new List<int>();

            foreach (string numStr in nums)
            {
                int num = 0;
                try
                {
                    num = System.Convert.ToInt32(numStr);
                } catch (FormatException) { }
                
                if (num < 0)
                {
                    negatives.Add(num);
                }

                num = num > 1000 ? 0 : num;

                result += num;
            }

            if (negatives.Count > 0)
            {
                throw new Exception("Negative numbers are not allowed: [" + String.Join(",", negatives.ToArray()) + "]");
            }

            return result;
        }
    }
}
