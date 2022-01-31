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
    }
}