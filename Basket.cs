using System;
using System.Collections.Generic;
using StoreModel.Models;

namespace StoreModel
{
    public class Basket
    {
        public List<BasketItem> BasketList { get; set; }
        public decimal PriceOfAllItems { get; set; }
        private InputParser InputParser { get; }
        
        public Basket()
        {
            BasketList = new List<BasketItem>();
            PriceOfAllItems = 0M;
        }

        public void AddItemToBasket(BasketItem entry)
        {
            BasketList.Add(entry);
            PriceOfAllItems += entry.Price;
            Console.WriteLine($"\n{entry.Name} has been added to your basket! Press any key to continue");
            Console.ReadKey();   
        }
    }
}
