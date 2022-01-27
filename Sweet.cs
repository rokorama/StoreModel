using System;

namespace StoreModel
{
    public class Sweet : Product
    {
        public int SugarPer100G { get; }

        public Sweet(string name, decimal price, int sku, int weightGrams, int sugarPer100G) : base(name, price, sku, weightGrams)
        {
            SugarPer100G = sugarPer100G;
        }
    }

}
