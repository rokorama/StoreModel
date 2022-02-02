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
        private List<BasketItem> BasketItems { get; set; }
        
        public StoreInterface()
        {
            VegetableRepo = new VegetableRepo();
            BeverageRepo = new BeverageRepo();
            CandyRepo = new CandyRepo();
            MeatRepo = new MeatRepo();
            BasketItems = new List<BasketItem>();
        }

        public char CheckForValidInputChar(List<char> acceptableValues)
        {
            bool validInput = false;
            char selection = ' ';

            while (!validInput)
            {
                Console.Write(">>> ");
                selection = Console.ReadKey().KeyChar;
                if (!acceptableValues.Contains(selection))
                    Console.WriteLine("\n\nSorry, invalid input. Please try again!");
                else
                    validInput = true;
            }
            return selection;
        }

        public void HomeMenu()
        {
            //acceptable values go here
            List<char> inputOptions = new List<char>() {'1','2','3','4','b','B','q','Q'};
            Console.Clear();
            Console.WriteLine(String.Format("\n\n\tSTORE INTERFACE THING\n\n\tcreated by @rokorama\n\n\n"));
            Console.WriteLine("Enter 1 to see the vegetable catalog");
            Console.WriteLine("      2 to see the meat catalog");
            Console.WriteLine("      3 to see the beverage catalog");
            Console.WriteLine("      4 to see the candy catalog");
            Console.Write(new string('-', Console.WindowWidth)); 
            Console.WriteLine("\nEnter B to see your shopping basket, or Q to quit");
            char selection = CheckForValidInputChar(inputOptions);
            switch (selection)
            {
                case '1': 
                    PrintAllVegetables();
                    break;
                case '2':
                    PrintAllMeats();
                    break;
                case '3':
                    PrintAllBeverages();
                    break;
                case '4':
                    PrintAllCandy();
                    break;
                case 'b':
                case 'B':
                    ShowBasket();
                    break;
                case 'q':
                case 'Q':
                    Console.Clear();
                    Environment.Exit(0);
                    break;
            }
                    
        }

        public void InsertItemIntoBasket(string itemName, decimal itemPrice, string category)
        {
            
        }
        
        public void PrintAllVegetables()
        {
            //implement 'n' and 'p' for next and previous entries
            var inputOptions = new List<char>() {'b', 'B'};
            for (int indexCounter = 0; indexCounter < VegetableRepo.VegetableList.Count-1; indexCounter++)
                inputOptions.Add(Char.Parse(indexCounter.ToString()));
            Console.Clear();
            int entryCounter = 1;
            Console.WriteLine("VEGETABLES\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, VegetableRepo.ProductKeys)+"\n");
            foreach (Vegetable entry in VegetableRepo.VegetableList)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " +  entry.ToString(LineFormatting));
                entryCounter++;
            }
            Console.WriteLine("\nEnter the number of a product to add to basket, or press B to go back");
            char selection = CheckForValidInputChar(inputOptions);
            if (selection == 'b')
                HomeMenu();
            // else {
                int index = Convert.ToInt32(Char.GetNumericValue(selection)) - 1;
                // try {
                    var basketItem = new BasketItem(VegetableRepo.VegetableList[index].Name,
                                                    VegetableRepo.VegetableList[index].Price);
                    BasketItems.Add(basketItem);
                    Console.WriteLine($"\n{basketItem.Name} has been added to your basket! Press any key to continue");
                    Console.ReadKey();
                    HomeMenu();
                //     }
                // catch {
                //     Console.WriteLine("\n\nInvalid input - index out of reach!");
                //     Console.WriteLine("Press any key to retry.");
                //     Console.ReadKey();
                //     PrintAllCandy();
                // }
            // }
        }
        public void PrintAllBeverages()
        {
            var inputOptions = new List<char>() {'1','2','3','4','5','6','7','8','9','b'};
            Console.Clear();
            int entryCounter = 1;
            Console.WriteLine("BEVERAGES\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, BeverageRepo.ProductKeys)+"\n");
            foreach (Beverage entry in BeverageRepo.BeverageList)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " +  entry.ToString(LineFormatting));
                entryCounter++;
            } 
            Console.WriteLine("\nEnter the number of a product to add to basket, or press B to go back");
            char selection = CheckForValidInputChar(inputOptions);
            if (selection == 'b')
                HomeMenu();
            else {
                int index = Convert.ToInt32(Char.GetNumericValue(selection)) - 1;
                try {
                    var basketItem = new BasketItem(BeverageRepo.BeverageList[index].Name,
                                                    BeverageRepo.BeverageList[index].Price);
                    BasketItems.Add(basketItem);
                    Console.WriteLine($"\n{basketItem.Name} has been added to your basket! Press any key to continue");
                    Console.ReadKey();
                    HomeMenu();
                    }
                catch {
                    Console.WriteLine("\n\nInvalid input - index out of reach!");
                    Console.WriteLine("Press any key to retry.");
                    Console.ReadKey();
                    PrintAllCandy();
                }
            }
        }
        public void PrintAllMeats()
        {
            var inputOptions = new List<char>() {'1','2','3','4','5','6','7','8','9','b'};
            Console.Clear();
            int entryCounter = 1;
            Console.WriteLine("MEAT\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, BeverageRepo.ProductKeys)+"\n");
            foreach (Meat entry in MeatRepo.MeatList)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " +  entry.ToString(LineFormatting));
                entryCounter++;
            } 
            Console.WriteLine("\nEnter the number of a product to add to basket, or press B to go back");
            char selection = CheckForValidInputChar(inputOptions);
            if (selection == 'b')
                HomeMenu();
            else {
                int index = Convert.ToInt32(Char.GetNumericValue(selection)) - 1;
                try {
                    var basketItem = new BasketItem(MeatRepo.MeatList[index].Name,
                                                    MeatRepo.MeatList[index].Price);
                    BasketItems.Add(basketItem);
                    Console.WriteLine($"\n{basketItem.Name} has been added to your basket! Press any key to continue");
                    Console.ReadKey();
                    HomeMenu();
                    }
                catch {
                    Console.WriteLine("\n\nInvalid input - index out of reach!");
                    Console.WriteLine("Press any key to retry.");
                    Console.ReadKey();
                    PrintAllCandy();
                }
            }
        }
        public void PrintAllCandy()
        {
            var inputOptions = new List<char>() {'1','2','3','4','5','6','7','8','9','b'};
            Console.Clear();
            int entryCounter = 1;
            Console.WriteLine("CANDY\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, BeverageRepo.ProductKeys)+"\n");
            foreach (Candy entry in CandyRepo.CandyList)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " + entry.ToString(LineFormatting));
                entryCounter++;
            }
            Console.WriteLine("\nEnter the number of a product to add to basket, or press B to go back");
            char selection = CheckForValidInputChar(inputOptions);
            if (selection == 'b')
                HomeMenu();
            else {
                int index = Convert.ToInt32(Char.GetNumericValue(selection)) - 1;
                try {
                    var basketItem = new BasketItem(CandyRepo.CandyList[index].Name,
                                                    CandyRepo.CandyList[index].Price);
                    BasketItems.Add(basketItem);
                    Console.WriteLine($"\n{basketItem.Name} has been added to your basket! Press any key to continue");
                    Console.ReadKey();
                    HomeMenu();
                    }
                catch {
                    Console.WriteLine("\n\nInvalid input - index out of reach!");
                    Console.WriteLine("Press any key to retry.");
                    Console.ReadKey();
                    PrintAllCandy();
                }
            }
        }

        
        public void ShowBasket()
        {
            var inputOptions = new List<char>() {'b'};
            Console.Clear();
            decimal amountPayable = 0;
            Console.WriteLine("YOUR SHOPPING BASKET:\n");
            foreach (BasketItem item in BasketItems)
            {
                Console.WriteLine($"  {item.Name}\t\t|{item.Price}");
                amountPayable += item.Price;
            }
            Console.WriteLine($"\n\tTotal amount: {amountPayable}");
            Console.WriteLine("\n\nPress C to proceed to checkout, or B to go back to the menu");
            char selection = CheckForValidInputChar(inputOptions);
            if (selection == 'b')
                HomeMenu();
        }

        public void CompleteTransaction()
        {

        }

        public void GenerateReceipt()
        {

        }
    }

}
