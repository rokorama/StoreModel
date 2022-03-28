using System;

namespace StoreModel
{
    public class Invoice
    {
        public readonly string ItemFormatting = "{0,-30}|  {1,-12}";
        public Basket PurchasedItems;
        public DateTime TimeOfPurchase;
        public Invoice(Basket purchasedItems, DateTime timeOfPurchase)
        {
            PurchasedItems = purchasedItems;
            TimeOfPurchase = timeOfPurchase;
        }

        public void GenerateInvoice()
        {
            Console.WriteLine("<h1>Thank you for shopping at Rokorama Fake Store Inc.!");
            Console.WriteLine("\n\nYour order details:\n");
            foreach(var item in PurchasedItems.BasketList)
            {
                Console.WriteLine(String.Format(ItemFormatting,item.Name,item.Price));
            }
            Console.WriteLine($"\n<strong>Amount paid: {PurchasedItems.PriceOfAllItems}</strong>");
            Console.WriteLine($"VAT (21%): {PurchasedItems.PriceOfAllItems * 0.21M}");

                   
        }
    }
}
