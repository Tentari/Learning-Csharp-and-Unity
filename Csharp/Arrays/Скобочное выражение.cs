using System;

namespace Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char openBracket = '(';
            char closeBracket = ')';
            int openBracketCount = 0;
            int maxDepth = 0;

            bool isCorrect = true;

            char[] chars = {openBracket,openBracket,closeBracket,closeBracket,closeBracket,openBracket};

            foreach (char onechar in chars)
            {
                Console.Write(onechar);
            }

            Console.WriteLine();

            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == openBracket)
                {
                    openBracketCount++;
                }
                else if (chars[i] == closeBracket)
                {
                    openBracketCount--;
                }

                if (openBracketCount < 0)
                {
                    isCorrect = false;
                }

                if (maxDepth < openBracketCount)
                {
                    maxDepth = openBracketCount;
                }
            }

            if (isCorrect == true && openBracketCount == 0)
            {
                Console.WriteLine($"Our max depth is {maxDepth}");
            }
            else
            {
                Console.WriteLine("Our array is incorrect");
            }

            Console.ReadKey();
        }
    }
}
