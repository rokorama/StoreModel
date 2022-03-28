using System;

namespace StoreModel.Models
{
    public class Vegetable: Product
    {
        public int FibrePer100G { get; set; }

        public Vegetable(string name, decimal price, int sku, int weightGrams, int fibrePer100G) : base(name, price, sku, weightGrams)
        {
            FibrePer100G = fibrePer100G;
        }

        private Vegetable()
        {
            
        }

        public override string ToString()
        {
            return $"{this.Name},{this.Price},{this.SKU},{this.WeightGrams},{this.FibrePer100G}";
        }

        public string ToString(string lineFormatting)
        {
            return String.Format(lineFormatting, this.Name,
                                                 this.Price,
                                                 this.SKU.ToString("D6"),
                                                 this.WeightGrams,
                                                 this.FibrePer100G);
        }
    }
}