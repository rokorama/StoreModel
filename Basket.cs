using System;
using System.Collections.Generic;

namespace StoreModel
{
    public class Basket
    {
        public List<BasketItem> Items { get; set; }

        public Basket()
        {
            Items = new List<BasketItem>();
        }

        public void AddItemToBasket(BasketItem entry)
        {
            Items.Add(entry);
        }
        
    }
}
