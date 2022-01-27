using System;

namespace StoreModel
{
    public class Beverage : Product
    {
        public int Mililitres { get; }

        public Beverage(string name, decimal price, int sku, int weightGrams, int mililitres) : base(name, price, sku, weightGrams)
        {
            Mililitres = mililitres;
        }
    }
}