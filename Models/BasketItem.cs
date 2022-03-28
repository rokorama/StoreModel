using System;

namespace StoreModel.Models
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

        public override string  ToString()
        {
            return $"{Name},{Price}";
        }
    }

}
