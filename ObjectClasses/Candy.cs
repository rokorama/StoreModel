using System;

namespace StoreModel
{
    public class Candy : Product
    {
        public int SugarPer100G { get; }

        public Candy(string name, decimal price, int sku, int weightGrams, int sugarPer100G) : base(name, price, sku, weightGrams)
        {
            SugarPer100G = sugarPer100G;
        }

        public override string ToString()
        {
            return $"{this.Name},{this.Price},{this.SKU},{this.WeightGrams},{this.SugarPer100G}";
        }

        public string ToString(string lineFormatting)
        {
            return String.Format(lineFormatting, this.Name,
                                                 this.Price,
                                                 this.SKU.ToString("D6"),
                                                 this.WeightGrams,
                                                 this.SugarPer100G);
        }
    }
}