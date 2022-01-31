using System;

namespace StoreModel
{
    class Program
    {
        static void Main(string[] args)
        {
            // var testInterface = new StoreInterface();
            // testInterface.PrintAllVegetables();
            var lineFormatting = "{0,-20}|  {1,-10}|  {2,-10}|  {3,-15}|  {4,-15}";

            var testBev = new Beverage("Beer", 5.50M, 003453, 500, "Glass bottle");
            Console.WriteLine(testBev.ToString(lineFormatting));
            Console.WriteLine(testBev.ToString());

        }
    }  
}