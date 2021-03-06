using System;

namespace StoreModel.Models
{
    public class Meat : Product
    {
        public int ProteinPer100G { get; set; }

        public Meat(string name, decimal price, int sku, int weightGrams, int proteinPer100G) : base(name, price, sku, weightGrams)
        {
            ProteinPer100G = proteinPer100G;
        }

        private Meat()
        {
            
        }

        public override string ToString()
        {
            return $"{this.Name},{this.Price},{this.SKU},{this.WeightGrams},{this.ProteinPer100G}";
        }

        public string ToString(string lineFormatting)
        {
            return String.Format(lineFormatting, this.Name,
                                                 this.Price,
                                                 this.SKU.ToString("D6"),
                                                 this.WeightGrams,
                                                 this.ProteinPer100G);
        }
    }
}
