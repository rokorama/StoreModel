using System;
using System.Collections.Generic;

namespace StoreModel
{
    public class Basket
    {
        public List<BasketItem> Items { get; set; }
        public decimal SumOfAllItems { get; set; }
        private InputParser InputParser { get; }
        
        public Basket()
        {
            Items = new List<BasketItem>();
            SumOfAllItems = 0M;
            InputParser = new InputParser();
        }

        public void AddItemToBasket(BasketItem entry)
        {
            Items.Add(entry);
            SumOfAllItems += entry.Price;
            Console.WriteLine($"\n{entry.Name} has been added to your basket! Press any key to continue");
            InputParser.PromptForAnyKey();
        }

        public void PrintItemsInBasket()
        {
            Console.Clear();
            Console.WriteLine("\n\nYOUR SHOPPING BASKET\n");
            Console.WriteLine(String.Format("{0,-25}|{1,10}","Item","Price") + "\n");
            foreach (BasketItem item in Items)
            {
                Console.WriteLine(String.Format("{0,-25}|{1,10}", item.Name, item.Price));
            } 
            Console.WriteLine(String.Format("{0,25}|"," ",SumOfAllItems));
        }


        public void GenerateReceipt()
        {

        }

        
    }
}
