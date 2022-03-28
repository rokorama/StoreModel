using System;

namespace StoreModel.Models
{
    public class Candy : Product
    {
        public int SugarPer100G { get; set; }

        public Candy(string name, decimal price, int sku, int weightGrams, int sugarPer100G) : base(name, price, sku, weightGrams)
        {
            SugarPer100G = sugarPer100G;
        }

        private Candy()
        {
            
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