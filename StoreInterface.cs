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

        public VegetableRepo VegetableRepo { get ; private set ; }
        // Possible with setter?
        public BeverageRepo BeverageRepo;
        public CandyRepo CandyRepo;
        public MeatRepo MeatRepo;
        
        public StoreInterface()
        {
            // Console.WriteLine("Please enter your budget:");
            // UserBudget = Convert.ToDecimal(Console.ReadLine());
            // UserIsAbleToPurchase = (UserBudget > 0) ? true : false;
            VegetableRepo = new VegetableRepo();
        }

        public void ShowHomeMenu()
        {
            Console.Clear();
            Console.WriteLine(String.Format("{0,5}{1,-30}",UserBudget,DateTime.Now));
        }
        
        public void ShowProductsInCategory()
        {
            Console.WriteLine(UserBudget);
            Console.WriteLine(UserIsAbleToPurchase);
        }

        public void PrintVegetable(Vegetable entry, string lineFormatting)
        {
            Console.WriteLine(String.Format(lineFormatting, entry.Name,
                                                                    entry.Price,
                                                                    entry.SKU.ToString("D6"),
                                                                    entry.WeightGrams,
                                                                    entry.FibrePer100G));
        }

        public void PrintAllVegetables()
        {
            Console.WriteLine("VEGETABLES\n");
            Console.WriteLine(String.Format(LineFormatting, VegetableRepo.ProductKeys)+"\n");
            foreach (Vegetable entry in VegetableRepo.VegetableList)
            {
                PrintVegetable(entry, LineFormatting);
            } 
        }

        public void PrintAllBeverages(BeverageRepo bevRepo, string lineFormatting)
        {
            Console.WriteLine("VEGETABLES\n");
            Console.WriteLine(String.Format(lineFormatting, bevRepo.ProductKeys)+"\n");
            foreach (Beverage entry in bevRepo.BeverageList)
            {
                Console.WriteLine(String.Format(lineFormatting, entry.Name,
                                                                    entry.Price,
                                                                    entry.SKU.ToString("D6"),
                                                                    entry.WeightGrams,
                                                                    entry.Container));
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
