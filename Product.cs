using System;

namespace StoreModel
{
    public class Product
    {
        public string Name { get; }
        public decimal Price { get; }
        public int SKU { get; }
        public int WeightGrams { get; }

        protected Product(string name, decimal price, int sku, int weightGrams)
        {
            Name = name;
            Price = price;
            SKU = sku;
            WeightGrams = weightGrams;
        }

        public Product()
        {

        }

    }
}
