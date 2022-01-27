using System;

namespace StoreModel
{
    public class Meat : Product
    {
        public int ProteinPer100G { get; }

        public Meat(string name, decimal price, int sku, int weightGrams, int proteinPer100G) : base(name, price, sku, weightGrams)
        {
            ProteinPer100G = proteinPer100G;
        }
    }
}
