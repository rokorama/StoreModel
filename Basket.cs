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
            Console.WriteLine("\n\nYOUR SHOPPING BASKET\n\n");
            Console.WriteLine(String.Format("{0,-25}|{1,10}","Item","Price") + "\n");
            foreach (BasketItem item in Items)
            {
                Console.WriteLine(String.Format("{0,-25}|{1,10}", item.Name, item.Price));
            } 
            Console.WriteLine(String.Format("{0,25}|",SumOfAllItems));
        }

        public void Checkout(decimal userBudget)
        {
            bool totalWithinBudget = false;

            Console.WriteLine("\n\nCHECKOUT\n\n");
            Console.WriteLine("\tAll items total: " + SumOfAllItems);
            Console.WriteLine("\n\tYour budget:   " + userBudget);
            if (totalWithinBudget)
            {
                Console.Clear();
                Console.WriteLine("\n\nThank you for your order!");
            }
            while (!totalWithinBudget)
            {
                Console.WriteLine("Sorry, insufficient funds! Please check your basket and try again");
            }

            Console.WriteLine("\n\nEnter your email address if you wish to receive an invoice, or hit Enter to skip:");
            Console.Write(">>> ");
            var emailInput = Console.ReadLine();
            // Console.WriteLine()
            // if (String.IsNullOrEmpty(emailInput))



        }

        public void GenerateReceipt()
        {

        }

        
    }
}
