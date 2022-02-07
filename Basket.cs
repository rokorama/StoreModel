using System;
using System.Collections.Generic;

namespace StoreModel
{
    public class Basket
    {
        public List<BasketItem> BasketList { get; set; }
        public decimal SumOfAllItems { get; set; }
        private InputParser InputParser { get; }
        
        public Basket()
        {
            BasketList = new List<BasketItem>();
            SumOfAllItems = 0M;
        }

        public void AddItemToBasket(BasketItem entry)
        {
            BasketList.Add(entry);
            SumOfAllItems += entry.Price;
            Console.WriteLine($"\n{entry.Name} has been added to your basket! Press any key to continue");
            Console.ReadKey();   
        }

        public void RemoveItemFromBasket(BasketItem entry)
        {
            
        }


        public void GenerateReceipt()
        {

        }

        
    }
}
