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
using System.Collections;
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
        private Basket Basket { get; set; }
        private InputParser InputParser { get; }
        
        public StoreInterface()
        {
            VegetableRepo = new VegetableRepo();
            BeverageRepo = new BeverageRepo();
            CandyRepo = new CandyRepo();
            MeatRepo = new MeatRepo();
            Basket = new Basket();
            InputParser = new InputParser();
            // UserBudget = PromptUserForBudget();
            UserIsAbleToPurchase = (UserBudget > 0);
            StartInterface();
        }

        private void StartInterface()
        {
            Console.Clear();
            Console.WriteLine(String.Format("\n\n\tSTORE INTERFACE THING\n\n\tcreated by @rokorama\n\n\n"));
            Console.WriteLine("To begin, please enter your budget below.\n");
            UserBudget = InputParser.PromptDecimalFromUser();
            UserIsAbleToPurchase = (UserBudget > 0);
            HomeMenu();
        }

        public void HomeMenu()
        {
            //acceptable values go here
            List<char> inputOptions = new List<char>() {'1','2','3','4','b','B','c','C','q','Q'};
            Console.Clear();
            if (!UserIsAbleToPurchase)
                Console.WriteLine("\n\nPLEASE NOTE - you may only view and not add items due to insufficient funds.");
            Console.WriteLine("\n\nEnter 1 to see the vegetable catalog");
            Console.WriteLine("      2 to see the meat catalog");
            Console.WriteLine("      3 to see the beverage catalog");
            Console.WriteLine("      4 to see the candy catalog");
            Console.WriteLine("\n\n Other options:\n");
            Console.WriteLine("B - go to shopping basket");
            Console.WriteLine("C - change budget");
            Console.WriteLine("Q - quit");
            char selection = InputParser.PromptCharFromUser(inputOptions);
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
                case 'c':
                case 'C':
                    // ChangeBudget();
                    break;
                case 'q':
                case 'Q':
                    Console.Clear();
                    Environment.Exit(0);
                    break;
            }
        }

        public void PrintAllVegetables()
        {
            //implement 'n' and 'p' for next and previous entries
            var inputOptions = new List<char>() {'b', 'B'};
            if (UserIsAbleToPurchase)
            {
                ICollection collection = VegetableRepo.VegetableList as ICollection;
                inputOptions.AddRange(InputParser.AddRangeOfAcceptableValues(collection.Count));
            }
            Console.Clear();
            int entryCounter = 1;
            Console.WriteLine("VEGETABLES\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, VegetableRepo.ProductKeys)+"\n");
            foreach (Vegetable entry in VegetableRepo.VegetableList)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " +  entry.ToString(LineFormatting));
                entryCounter++;
            }
            if (!UserIsAbleToPurchase) 
                Console.WriteLine("Adding items to basket disabled due to insufficient funds. Sorry!");
            else
                Console.WriteLine("\nEnter the number of a product to add to basket, or press B to go back");
            char selection = InputParser.PromptCharFromUser(inputOptions);
            if (selection == 'b')
                HomeMenu();
            else
            {
                int index = InputParser.GetIntFromChar(selection) - 1;
                var basketItem = new BasketItem(VegetableRepo.VegetableList[index].Name,
                                                VegetableRepo.VegetableList[index].Price);
                Basket.AddItemToBasket(basketItem);
                HomeMenu();
            }
        }
    

        public void PrintAllBeverages()
        {
            var inputOptions = new List<char>() {'b', 'B'};
            if (UserIsAbleToPurchase)
            {
                ICollection collection = BeverageRepo.BeverageList as ICollection;
                inputOptions.AddRange(InputParser.AddRangeOfAcceptableValues(collection.Count));
            }
            Console.Clear();
            int entryCounter = 1;
            Console.WriteLine("BEVERAGES\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, BeverageRepo.ProductKeys)+"\n");
            foreach (Beverage entry in BeverageRepo.BeverageList)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " +  entry.ToString(LineFormatting));
                entryCounter++;
            } 
            if (!UserIsAbleToPurchase) 
                Console.WriteLine("Adding items to basket disabled due to insufficient funds. Sorry!");
            else
                Console.WriteLine("\nEnter the number of a product to add to basket, or press B to go back");
            char selection = InputParser.PromptCharFromUser(inputOptions);
            if (selection == 'b')
                HomeMenu();
            else
            {
                int index = InputParser.GetIntFromChar(selection) - 1;
                var basketItem = new BasketItem(BeverageRepo.BeverageList[index].Name,
                                                BeverageRepo.BeverageList[index].Price);
                Basket.AddItemToBasket(basketItem);
                HomeMenu();
            }
        }

        public void PrintAllMeats()
        {
            var inputOptions = new List<char>() {'b', 'B'};
            if (UserIsAbleToPurchase)
            {
                ICollection collection = MeatRepo.MeatList as ICollection;
                inputOptions.AddRange(InputParser.AddRangeOfAcceptableValues(collection.Count));
            }
            Console.Clear();
            int entryCounter = 1;
            Console.WriteLine("MEAT\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, MeatRepo.ProductKeys)+"\n");
            foreach (Meat entry in MeatRepo.MeatList)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " +  entry.ToString(LineFormatting));
                entryCounter++;
            }
            if (!UserIsAbleToPurchase) 
                Console.WriteLine("Adding items to basket disabled due to insufficient funds. Sorry!");
            else
                Console.WriteLine("\nEnter the number of a product to add to basket, or press B to go back");
            char selection = InputParser.PromptCharFromUser(inputOptions);
            if (selection == 'b')
                HomeMenu();
            else
            {
                int index = InputParser.GetIntFromChar(selection) - 1;
                var basketItem = new BasketItem(MeatRepo.MeatList[index].Name,
                                                MeatRepo.MeatList[index].Price);
                Basket.AddItemToBasket(basketItem);
                HomeMenu();
            }
        }
        
        public void PrintAllCandy()
        {
            var inputOptions = new List<char>() {'b', 'B'};
            if (UserIsAbleToPurchase)
            {
                ICollection collection = CandyRepo.CandyList as ICollection;
                inputOptions.AddRange(InputParser.AddRangeOfAcceptableValues(collection.Count));
            }
            Console.Clear();
            int entryCounter = 1;
            Console.WriteLine("CANDY\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, CandyRepo.ProductKeys)+"\n");
            foreach (Candy entry in CandyRepo.CandyList)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " + entry.ToString(LineFormatting));
                entryCounter++;
            }
            if (!UserIsAbleToPurchase) 
                Console.WriteLine("Adding items to basket disabled due to insufficient funds. You can hit B to go back.");
            else
                Console.WriteLine("\nEnter the number of a product to add to basket, or press B to go back");
            char selection = InputParser.PromptCharFromUser(inputOptions);
            if (selection == 'b')
                HomeMenu();
            else
            {
                int index = InputParser.GetIntFromChar(selection) - 1;
                var basketItem = new BasketItem(CandyRepo.CandyList[index].Name,
                                                CandyRepo.CandyList[index].Price);
                Basket.AddItemToBasket(basketItem);
                HomeMenu();
            }
        }

        public void ShowBasket()
        {
            var inputOptions = new List<char>() {'b','B','c','C','r','R'};
            Basket.PrintItemsInBasket();
            Console.WriteLine($"Your allocated budget: {UserBudget}");
            Console.WriteLine("\nPress C to proceed to checkout, or B to go back to the menu");
            char selection = InputParser.PromptCharFromUser(inputOptions);
            switch (selection)
            {
                case 'b':
                case 'B':
                    HomeMenu();
                    break;
                case 'c':
                case 'C':
                    Checkout(UserBudget);
                    break;
                case 'r':
                case 'R':
                    Console.WriteLine("Please enter number of the item you wish to remove:");
                    break;
            }
        }
               
        public void Checkout(decimal userBudget)
        {
            bool totalWithinBudget = (userBudget - Basket.SumOfAllItems >= 0);

            Console.WriteLine("\n\nCHECKOUT\n\n");
            Console.WriteLine("\tAll items total: " + Basket.SumOfAllItems);
            Console.WriteLine("\n\tYour budget:   " + userBudget);
            if (totalWithinBudget)
            {
                Console.Clear();
                Console.WriteLine("\n\n\tThank you for your order!");
                Console.WriteLine("\n\n\tPlease hit any key to continue");
                InputParser.PromptForAnyKey();
            }
            else
            {
                Console.WriteLine("Sorry, insufficient funds! Please check your basket and try again");
            }

            // Console.WriteLine("\n\nEnter your email address if you wish to receive an invoice, or hit Enter to skip:");
            // Console.Write(">>> ");
            var emailInput = Console.ReadLine();
            // Console.WriteLine()
            // if (String.IsNullOrEmpty(emailInput))
        }

    }

}
