using System;

namespace StoreModel
{
    public class Vegetable: Product
    {
        public int FibrePer100G { get; }

        public Vegetable(string name, decimal price, int sku, int weightGrams, int fibrePer100G) : base(name, price, sku, weightGrams)
        {
            FibrePer100G = fibrePer100G;
        }
    }
}