using System;

namespace StoreModel
{
    public class BasketItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public BasketItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }

}
