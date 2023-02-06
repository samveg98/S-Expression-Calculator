using System;

namespace SamvegEncircle
{

    class SExpression
    {
        public int Calculate(string userInput)
        {
            while (userInput.Contains(")"))
            {
                int rightSide = userInput.IndexOf(")");
                int leftSide = userInput.Substring(0, rightSide).LastIndexOf("(");

                int value = EvaluateSingle(userInput.Substring(leftSide + 1, rightSide - leftSide - 1));

                if (leftSide == 0)
                {
                    return value;
                }
                else
                {
                    userInput = userInput.Substring(0, leftSide) + value + userInput.Substring(rightSide + 1);
                }
            }
            return int.Parse(userInput);
        }

        private int EvaluateSingle(string strInput)
        {
            string[] strSubset = strInput.Split(' ');

            if (strSubset[0] == "add")
            {
                return int.Parse(strSubset[1]) + int.Parse(strSubset[2]);
            }
            else if (strSubset[0] == "multiply")
            {
                return int.Parse(strSubset[1]) * int.Parse(strSubset[2]);
            }
            else
            {
                return int.Parse(strInput);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();

            Console.WriteLine(new SExpression().Calculate(userInput));
        }
    }
}
