using System;

namespace StoreModel
{
    public class Beverage : Product
    {
        public string Container { get; }

        public Beverage(string name, decimal price, int sku, int weightGrams, string container) : base(name, price, sku, weightGrams)
        {
            Container = container;
        }

        public override string ToString()
        {
            return $"{this.Name},{this.Price},{this.SKU},{this.WeightGrams},{this.Container}";
        }

        public string ToString(string lineFormatting)
        {
            return String.Format(lineFormatting, this.Name,
                                                 this.Price,
                                                 this.SKU,
                                                 this.WeightGrams,
                                                 this.Container);
        }
    }
}