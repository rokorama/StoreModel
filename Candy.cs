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
    }
}