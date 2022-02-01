// Veikimo principai:
// Įsijungus programą nurodote kiek turi pinigų. 
// Jeigu pinigų yra daugiau nei 0 tada vartotojas gali pirkti prekes, jei pinigų neturi tada gali jas tik peržiūrėti.
// Programoje turi būti galima išspausdinti kiekvienos prekės repozitorijos sąrašą individualiai(pvz.: pamatyti visas mėsos prekes)
// Pasirenkant kokias prekes norit pirkti, jos įdedamos į pirkinių krepšelį.
// Pirkinių krepšelį taip pat turi būti galimybė peržiūrėti.(prekes su kainom ir galutinę viso krepšelio kainą)
// Apsisprendus pirkti turi būti patikrinama ar užtenka pinigų.
// Jeigu pinigų užtenka tada sudaromas kvitas, į kurį įeina krepšelio informacija,galutinė kaina ir laikas kada buvo nupirkta.
// Kvitas išsiunčiamas nurodytu el. paštu (Labiau advanced dalis, palieku ją patiems išsaiškinti kaip tai padaryti P.S. tai nėra taip baisu kaip gali pasirodyt)

using System;
using System.Collections.Generic;

namespace StoreModel
{
    public class StoreInterface
    {
        private decimal UserBudget { get; set; }
        private bool UserIsAbleToPurchase { get; set; }
        private readonly string LineFormatting = "{0,-20}|  {1,-10}|  {2,-10}|  {3,-15}|  {4,-15}";

        //figure out if these need to be public

        public VegetableRepo VegetableRepo { get ; private set ; }
        public BeverageRepo BeverageRepo { get ; private set ; }
        public CandyRepo CandyRepo { get ; private set ; }
        public MeatRepo MeatRepo { get ; private set ; }
        private List<DataTransferObject> TransferData { get; set; }
        
        public StoreInterface()
        {
            // Console.WriteLine("Please enter your budget:");
            // UserBudget = Convert.ToDecimal(Console.ReadLine());
            // UserIsAbleToPurchase = (UserBudget > 0) ? true : false;
            VegetableRepo = new VegetableRepo();
            BeverageRepo = new BeverageRepo();
            CandyRepo = new CandyRepo();
            MeatRepo = new MeatRepo();
            TransferData = new List<DataTransferObject>();
        }

        public void ShowHomeMenu()
        {
            Console.Clear();
        }
        
        public void ShowProductsInCategory()
        {
            
        }

        public void PrintAllVegetables()
        {
            int entryCounter = 1;
            Console.WriteLine("VEGETABLES\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, VegetableRepo.ProductKeys)+"\n");
            foreach (Vegetable entry in VegetableRepo.VegetableList)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " +  entry.ToString(LineFormatting));
                entryCounter++;
            }
            Console.WriteLine("\nEnter the number of a product to add to basket, or press B to go back");
            Console.WriteLine(">>> ");
            // var choice = Convert.ToInt32(Console.Read());
            int choice = 2;
            var selectionToBasket = new DataTransferObject();
            selectionToBasket.Name = VegetableRepo.VegetableList[choice-1].Name;
            selectionToBasket.Price = VegetableRepo.VegetableList[choice-1].Price;
            TransferData.Add(selectionToBasket);

        }
        public void PrintAllBeverages()
        {
            int entryCounter = 1;
            Console.WriteLine("BEVERAGES\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, BeverageRepo.ProductKeys)+"\n");
            foreach (Beverage entry in BeverageRepo.BeverageList)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " +  entry.ToString(LineFormatting));
                entryCounter++;

            } 
        }
        public void PrintAllMeats()
        {
            int entryCounter = 1;
            Console.WriteLine("MEAT\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, BeverageRepo.ProductKeys)+"\n");
            foreach (Meat entry in MeatRepo.MeatList)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " +  entry.ToString(LineFormatting));
                entryCounter++;
            } 
        }
        public void PrintAllCandy()
        {
            int entryCounter = 1;
            Console.WriteLine("CANDY\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, BeverageRepo.ProductKeys)+"\n");
            foreach (Candy entry in CandyRepo.CandyList)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " + entry.ToString(LineFormatting));
                entryCounter++;
            } 
        }

        
        public void ShowBasket()
        {
        }

        public void CompleteTransaction()
        {

        }

        public void GenerateReceipt()
        {

        }
    }

}
