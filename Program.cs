using System;

namespace StoreModel
{
    class Program
    {
        static void Main(string[] args)
        {
            var testInterface = new StoreInterface();
            testInterface.PrintAllBeverages();
            testInterface.PrintAllCandy();
            testInterface.PrintAllMeats();
            testInterface.PrintAllVegetables();

        }
    }  
}