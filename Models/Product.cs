using System;
using System.ComponentModel.DataAnnotations;

namespace StoreModel.Models

{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SKU { get; set; }
        public int WeightGrams { get; set; }

        protected Product(string name, decimal price, int sku, int weightGrams)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            SKU = sku;
            WeightGrams = weightGrams;
        }

        protected Product()
        {

        }

    }
}
