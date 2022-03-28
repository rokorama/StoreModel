using System;

namespace StoreModel.Models
{
    public class Beverage : Product
    {
        public string Container { get; set; }

        public Beverage(string name, decimal price, int sku, int weightGrams, string container) : base(name, price, sku, weightGrams)
        {
            Container = container;
        }

        private Beverage()
        {

        }

        public override string ToString()
        {
            return $"{this.Name},{this.Price},{this.SKU},{this.WeightGrams},{this.Container}";
        }

        public string ToString(string lineFormatting)
        {
            return String.Format(lineFormatting, this.Name,
                                                 this.Price,
                                                 this.SKU.ToString("D6"),
                                                 this.WeightGrams,
                                                 this.Container);
        }
    }
}