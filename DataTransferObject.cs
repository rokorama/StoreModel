using System;

namespace StoreModel
{
    public class DataTransferObject
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DataTransferObject()
        {
            this.Name = Name;
            this.Price = Price;
        }
    }

}
