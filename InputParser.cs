using System;
using System.Collections.Generic;

namespace StoreModel
{
    public class InputParser
    {

        public InputParser()
        {

        }

        public char PromptCharFromUser()
        {
                Console.Write(">>> ");
                var selection = Console.ReadKey().KeyChar;
                return selection;
        }

        public char PromptCharFromUser(List<char> acceptableValues)
        {
            bool validInput = false;
            char selection = ' ';

            while (!validInput)
            {
                Console.Write(">>> ");
                selection = Console.ReadKey().KeyChar;
                if (!acceptableValues.Contains(selection))
                    Console.WriteLine("\n\nSorry, invalid input. Please try again!");
                else
                    validInput = true;
            }
            return selection;
        }

        public void PromptForAnyKey()
        {
            Console.Write(">>> ");
            Console.ReadKey();
        }

        public int GetIntFromChar(char inputChar)
        {
            return Convert.ToInt32(Char.GetNumericValue(inputChar));
        }

        public decimal PromptDecimalFromUser()
        {
            decimal result = 0;
            bool valueIsValid = false;
            while (!valueIsValid)
            {
            Console.Write(">>> ");
            if (Decimal.TryParse(Console.ReadLine(), out result))
                break;    
            Console.Write("\nInvalid input, please try again! Hit any key to retry.");
            Console.ReadKey();
            }
            return result;
        }

        public List<char> AddRangeOfAcceptableValues(int list)
        {
            var result = new List<char>();
            for (int indexCounter = 1; indexCounter <= list; indexCounter++)
            result.Add(Char.Parse(indexCounter.ToString()));
            return result;
        }
    }
}
