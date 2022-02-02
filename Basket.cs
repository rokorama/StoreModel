using System;
using System.Collections.Generic;

namespace StoreModel
{
    public class Basket
    {
        public List<BasketItem> Items { get; set; }
        private decimal SumOfAllItems { get; set; }
        
        public Basket()
        {
            Items = new List<BasketItem>();
            SumOfAllItems = 0M;
        }

        public void AddItemToBasket(BasketItem entry)
        {
            Items.Add(entry);
            SumOfAllItems += entry.Price;
            Console.WriteLine($"\n{entry.Name} has been added to your basket! Press any key to continue");
            Console.ReadKey();   
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
            Console.WriteLine($"\nTotal amount: {SumOfAllItems}");
        }

        public void CompleteTransaction()
        {

        }

        public void GenerateReceipt()
        {

        }

        
    }
}
