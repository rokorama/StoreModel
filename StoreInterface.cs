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
using System.Linq;

namespace StoreModel
{
    public class StoreInterface
    {
        private decimal UserBudget { get; set; }
        private bool UserIsAbleToPurchase { get; set; }
        private readonly string LineFormatting = "{0,-30}|  {1,-12}|  {2,-12}|  {3,-12}|  {4,-12}";

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
                    PrintAllVegetables(new PageDisplay(VegetableRepo.VegetableList, 1, 9));
                    break;
                case '2':
                    PrintAllMeats(new PageDisplay(MeatRepo.MeatList, 1, 9));
                    break;
                case '3':
                    PrintAllBeverages(new PageDisplay(BeverageRepo.BeverageList, 1, 9));
                    break;
                case '4':
                    PrintAllCandy(new PageDisplay(CandyRepo.CandyList, 1, 9));
                    break;
                case 'b':
                case 'B':
                    ShowBasket(new PageDisplay(Basket.Items, 1, 9));
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

        public void PrintAllVegetables(PageDisplay currentPage)
        {
            var inputOptions = new List<char>() {'b', 'B', ',', '.'};
            int entryCounter = 1;
            int totalPages = currentPage.CalculateTotalPages(VegetableRepo.VegetableList.Count);
            Console.Clear();
            Console.WriteLine($"VEGETABLES\tPage {currentPage.PageNumber} of {totalPages}\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, VegetableRepo.ProductKeys)+"\n");
            foreach (Vegetable entry in currentPage.VegetableItems)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " +  entry.ToString(LineFormatting));
                if (UserIsAbleToPurchase)
                    inputOptions.Add(Char.Parse(entryCounter.ToString()));
                entryCounter++;
            }
            if (!UserIsAbleToPurchase) 
                Console.WriteLine("\nAdding items to basket disabled due to insufficient funds. Sorry!");
            else
                Console.WriteLine("\nEnter the number of a product to add to basket, press , and . to navigate between pages or B to go back");
            char selection = InputParser.PromptCharFromUser(inputOptions);
            if (selection == 'b')
                HomeMenu();
            if (selection == ',')
                PrintAllVegetables(new PageDisplay(VegetableRepo.VegetableList, (currentPage.PageNumber > 1 ? currentPage.PageNumber-1: 1), 9));
            if (selection == '.')
                {
                PrintAllVegetables(new PageDisplay(VegetableRepo.VegetableList, (currentPage.PageNumber < totalPages ? currentPage.PageNumber+1 : totalPages)));
                } 
            else
                {
                int index = InputParser.GetIntFromChar(selection) - 1;
                var basketItem = new BasketItem(currentPage.VegetableItems[index].Name,
                                                currentPage.VegetableItems[index].Price);
                Basket.AddItemToBasket(basketItem);
                HomeMenu();
                }
        }
        
        public void PrintAllBeverages(PageDisplay currentPage)
        {
            var inputOptions = new List<char>() {'b', 'B', ',', '.'};
            int entryCounter = 1;
            int totalPages = currentPage.CalculateTotalPages(BeverageRepo.BeverageList.Count);
            Console.Clear();
            Console.WriteLine($"Beverages\tPage {currentPage.PageNumber} of {totalPages}\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, BeverageRepo.ProductKeys)+"\n");
            foreach (Beverage entry in currentPage.BeverageItems)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " +  entry.ToString(LineFormatting));
                if (UserIsAbleToPurchase)
                    inputOptions.Add(Char.Parse(entryCounter.ToString()));
                entryCounter++;
            }
            if (!UserIsAbleToPurchase) 
                Console.WriteLine("\nAdding items to basket disabled due to insufficient funds. Sorry!");
            else
                Console.WriteLine("\nEnter the number of a product to add to basket, press , and . to navigate between pages or B to go back");
            char selection = InputParser.PromptCharFromUser(inputOptions);
            if (selection == 'b')
                HomeMenu();
            if (selection == ',')
                PrintAllBeverages(new PageDisplay(BeverageRepo.BeverageList, (currentPage.PageNumber > 1 ? currentPage.PageNumber-1: 1), 9));
            if (selection == '.')
                PrintAllBeverages(new PageDisplay(BeverageRepo.BeverageList, (currentPage.PageNumber < totalPages ? currentPage.PageNumber+1 : totalPages)));
            else
                {
                int index = InputParser.GetIntFromChar(selection) - 1;
                var basketItem = new BasketItem(currentPage.BeverageItems[index].Name,
                                                currentPage.BeverageItems[index].Price);
                Basket.AddItemToBasket(basketItem);
                HomeMenu();
                }
            }

         public void PrintAllMeats(PageDisplay currentPage)
        {
            var inputOptions = new List<char>() {'b', 'B', ',', '.'};
            int entryCounter = 1;
            int totalPages = currentPage.CalculateTotalPages(MeatRepo.MeatList.Count);
            Console.Clear();
            Console.WriteLine($"Meats\tPage {currentPage.PageNumber} of {totalPages}\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, MeatRepo.ProductKeys)+"\n");
            foreach (Meat entry in currentPage.MeatItems)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " +  entry.ToString(LineFormatting));
                if (UserIsAbleToPurchase)
                    inputOptions.Add(Char.Parse(entryCounter.ToString()));
                entryCounter++;
            }
            if (!UserIsAbleToPurchase) 
                Console.WriteLine("\nAdding items to basket disabled due to insufficient funds. Sorry!");
            else
                Console.WriteLine("\nEnter the number of a product to add to basket, press , and . to navigate between pages or B to go back");
            char selection = InputParser.PromptCharFromUser(inputOptions);
            if (selection == 'b')
                HomeMenu();
            if (selection == ',')
                PrintAllMeats(new PageDisplay(MeatRepo.MeatList, (currentPage.PageNumber > 1 ? currentPage.PageNumber-1: 1), 9));
            if (selection == '.')
                PrintAllMeats(new PageDisplay(MeatRepo.MeatList, (currentPage.PageNumber < totalPages ? currentPage.PageNumber+1 : totalPages)));
            else
                {
                int index = InputParser.GetIntFromChar(selection) - 1;
                var basketItem = new BasketItem(currentPage.MeatItems[index].Name,
                                                currentPage.MeatItems[index].Price);
                Basket.AddItemToBasket(basketItem);
                HomeMenu();
                }
            }
        
        public void PrintAllCandy(PageDisplay currentPage)
        {
            var inputOptions = new List<char>() {'b', 'B', ',', '.'};
            int entryCounter = 1;
            int totalPages = currentPage.CalculateTotalPages(CandyRepo.CandyList.Count);
            Console.Clear();
            Console.WriteLine($"Candy\tPage {currentPage.PageNumber} of {totalPages}\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, CandyRepo.ProductKeys)+"\n");
            foreach (Candy entry in currentPage.CandyItems)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " +  entry.ToString(LineFormatting));
                if (UserIsAbleToPurchase)
                    inputOptions.Add(Char.Parse(entryCounter.ToString()));
                entryCounter++;
            }
            if (!UserIsAbleToPurchase) 
                Console.WriteLine("\nAdding items to basket disabled due to insufficient funds. Sorry!");
            else
                Console.WriteLine("\nEnter the number of a product to add to basket, press , and . to navigate between pages or B to go back");
            char selection = InputParser.PromptCharFromUser(inputOptions);
            if (selection == 'b')
                HomeMenu();
            if (selection == ',')
                PrintAllCandy(new PageDisplay(CandyRepo.CandyList, (currentPage.PageNumber > 1 ? currentPage.PageNumber-1: 1), 9));
            if (selection == '.')
                PrintAllCandy(new PageDisplay(CandyRepo.CandyList, (currentPage.PageNumber < totalPages ? currentPage.PageNumber+1 : totalPages)));
            else
                {
                int index = InputParser.GetIntFromChar(selection) - 1;
                var basketItem = new BasketItem(currentPage.CandyItems[index].Name,
                                                currentPage.CandyItems[index].Price);
                Basket.AddItemToBasket(basketItem);
                HomeMenu();
                }
            }

        public void ShowBasket(PageDisplay currentPage)
        {
            var inputOptions = new List<char>() {'b','B','c','C','r','R'};
            int entryCounter = 1;
            int totalPages = currentPage.CalculateTotalPages(CandyRepo.CandyList.Count);
            Console.Clear();
            Console.WriteLine($"Candy\tPage {currentPage.PageNumber} of {totalPages}\n");
            Console.WriteLine(String.Format("{0,-30}|{1,12}","Item","Price") + "\n");
            foreach (BasketItem entry in currentPage.BasketItems)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " +  String.Format("{0,-30}|{1,12}",entry.ToString().Split(",")));
                entryCounter++;
            }
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
                Console.WriteLine("\n\n\tSorry, insufficient funds! Please check your basket and try again");

            // Console.WriteLine("\n\nEnter your email address if you wish to receive an invoice, or hit Enter to skip:");
            // Console.Write(">>> ");
            var emailInput = Console.ReadLine();
            // Console.WriteLine()
            // if (String.IsNullOrEmpty(emailInput))
        }
    }
}