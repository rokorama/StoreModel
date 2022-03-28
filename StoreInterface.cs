using System;
using System.Collections.Generic;
using StoreModel.Models;


namespace StoreModel
{
    public class StoreInterface
    {
        private decimal UserBudget { get; set; }
        private bool UserIsAbleToPurchase { get; set; }
        private readonly string LineFormatting = "{0,-30}|  {1,-12}|  {2,-12}|  {3,-12}|  {4,-12}";

        private GenericRepository<Beverage>  BeverageRepo { get ; set ; }
        private GenericRepository<Candy> CandyRepo { get ; set ; }
        private GenericRepository<Meat> MeatRepo { get ; set ; }
        private GenericRepository<Vegetable> VegetableRepo { get ; set ; }
        private Basket Basket { get; set; }
        private InputParser InputParser { get; }
        
        public StoreInterface()
        {
            BeverageRepo = new GenericRepository<Beverage>();
            CandyRepo = new GenericRepository<Candy>();
            MeatRepo = new GenericRepository<Meat>();
            VegetableRepo = new GenericRepository<Vegetable>();
            Basket = new Basket();
            InputParser = new InputParser();
            StartInterface();
        }

        private void StartInterface()
        {
            Console.Clear();
            Console.WriteLine(String.Format("\n\n\tROKORAMA FAKE STORE INC.\n\n\tgithub.com/rokorama\n\n\n"));
            Console.WriteLine("To begin, please enter your budget below.\n");
            UserBudget = InputParser.PromptDecimalFromUser();
            UserIsAbleToPurchase = (UserBudget > 0);
            HomeMenu();
        }

        public void HomeMenu()
        {
            //acceptable values go here
            List<char> inputOptions = new List<char>() {'1','2','3','4','b','B','q','Q'};
            Console.Clear();
            if (!UserIsAbleToPurchase)
                Console.WriteLine("\n\nPLEASE NOTE - you may only view and not add items due to insufficient funds.");
            Console.WriteLine("\n\nEnter 1 to see the vegetable catalog");
            Console.WriteLine("      2 to see the meat catalog");
            Console.WriteLine("      3 to see the beverage catalog");
            Console.WriteLine("      4 to see the candy catalog");
            Console.WriteLine("\n\n Other options:\n");
            Console.WriteLine("B - go to shopping basket");
            Console.WriteLine("Q - quit");
            char selection = InputParser.PromptCharFromUser(inputOptions);
            if (selection == '1')
                PrintVegetablePage(new PageDisplay(VegetableRepo.Items, 1, 9));
            else if (selection == '2')
                PrintMeatPage(new PageDisplay(MeatRepo.Items, 1, 9));
            else if (selection == '3')
                PrintBeveragePage(new PageDisplay(BeverageRepo.Items, 1, 9));
            else if (selection == '4')
                PrintCandyPage(new PageDisplay(CandyRepo.Items, 1, 9));
            else if (selection == 'b' || selection == 'B')
                PrintBasketPage(new PageDisplay(Basket.BasketList, 1, 9));
            else if (selection == 'q' || selection == 'Q')
            {
                Console.Clear();
                Environment.Exit(0);
            }
        }

        public void PrintVegetablePage(PageDisplay currentPage)
        {
            var inputOptions = new List<char>() {'b', 'B', ',', '.'};
            int entryCounter = 1;
            int totalPages = currentPage.CalculateTotalPages(VegetableRepo.Items.Count);
            Console.Clear();
            Console.WriteLine($"VEGETABLES\tPage {currentPage.PageNumber} of {totalPages}\n");
            // Console.WriteLine("##  | " + String.Format(LineFormatting, VegetableRepo.ProductKeys)+"\n");
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
            if (selection == 'b' || selection == 'B')
                HomeMenu();
            if (selection == ',')
                PrintVegetablePage(new PageDisplay(VegetableRepo.Items, (currentPage.PageNumber > 1 ? currentPage.PageNumber-1: 1), 9));
            if (selection == '.')
                {
                PrintVegetablePage(new PageDisplay(VegetableRepo.Items, (currentPage.PageNumber < totalPages ? currentPage.PageNumber+1 : totalPages)));
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
        
        public void PrintBeveragePage(PageDisplay currentPage)
        {
            var inputOptions = new List<char>() {'b', 'B', ',', '.'};
            int entryCounter = 1;
            int totalPages = currentPage.CalculateTotalPages(BeverageRepo.Items.Count);
            Console.Clear();
            Console.WriteLine($"BEVERAGES\tPage {currentPage.PageNumber} of {totalPages}\n");
            Console.WriteLine("##  | " + String.Format(LineFormatting, new string[] {}+"\n"));
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
            if (selection == 'b' || selection == 'B')
                HomeMenu();
            if (selection == ',')
                PrintBeveragePage(new PageDisplay(BeverageRepo.Items, (currentPage.PageNumber > 1 ? currentPage.PageNumber-1: 1), 9));
            if (selection == '.')
                PrintBeveragePage(new PageDisplay(BeverageRepo.Items, (currentPage.PageNumber < totalPages ? currentPage.PageNumber+1 : totalPages)));
            else
                {
                int index = InputParser.GetIntFromChar(selection) - 1;
                var basketItem = new BasketItem(currentPage.BeverageItems[index].Name,
                                                currentPage.BeverageItems[index].Price);
                Basket.AddItemToBasket(basketItem);
                HomeMenu();
                }
        }

         public void PrintMeatPage(PageDisplay currentPage)
        {
            var inputOptions = new List<char>() {'b', 'B', ',', '.'};
            int entryCounter = 1;
            int totalPages = currentPage.CalculateTotalPages(MeatRepo.Items.Count);
            Console.Clear();
            Console.WriteLine($"MEAT\tPage {currentPage.PageNumber} of {totalPages}\n");
            // Console.WriteLine("##  | " + String.Format(LineFormatting, MeatRepo.ProductKeys)+"\n");
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
            if (selection == 'b' || selection == 'B')
                HomeMenu();
            if (selection == ',')
                PrintMeatPage(new PageDisplay(MeatRepo.Items, (currentPage.PageNumber > 1 ? currentPage.PageNumber-1: 1), 9));
            if (selection == '.')
                PrintMeatPage(new PageDisplay(MeatRepo.Items, (currentPage.PageNumber < totalPages ? currentPage.PageNumber+1 : totalPages)));
            else
                {
                int index = InputParser.GetIntFromChar(selection) - 1;
                var basketItem = new BasketItem(currentPage.MeatItems[index].Name,
                                                currentPage.MeatItems[index].Price);
                Basket.AddItemToBasket(basketItem);
                HomeMenu();
                }
        }
        
        public void PrintCandyPage(PageDisplay currentPage)
        {
            var inputOptions = new List<char>() {'b', 'B', ',', '.'};
            int entryCounter = 1;
            int totalPages = currentPage.CalculateTotalPages(CandyRepo.Items.Count);
            Console.Clear();
            Console.WriteLine($"CANDY\tPage {currentPage.PageNumber} of {totalPages}\n");
            // Console.WriteLine("##  | " + String.Format(LineFormatting, CandyRepo.ProductKeys)+"\n");
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
            if (selection == 'b' || selection == 'B')
                HomeMenu();
            if (selection == ',')
                PrintCandyPage(new PageDisplay(CandyRepo.Items, (currentPage.PageNumber > 1 ? currentPage.PageNumber-1: 1), 9));
            if (selection == '.')
                PrintCandyPage(new PageDisplay(CandyRepo.Items, (currentPage.PageNumber < totalPages ? currentPage.PageNumber+1 : totalPages)));
            else
                {
                int index = InputParser.GetIntFromChar(selection) - 1;
                var basketItem = new BasketItem(currentPage.CandyItems[index].Name,
                                                currentPage.CandyItems[index].Price);
                Basket.AddItemToBasket(basketItem);
                HomeMenu();
                }
        }

        public void PrintBasketPage(PageDisplay currentPage)
        {
            var inputOptions = new List<char>() {'b','B','c','C',',','.'};
            int entryCounter = 1;
            int totalPages = currentPage.CalculateTotalPages(Basket.BasketList.Count);
            Console.Clear();
            Console.WriteLine($"YOUR BASKET\tPage {currentPage.PageNumber} of {totalPages}\n");
            Console.WriteLine(String.Format("{0,-30}|{1,12}","Item","Price") + "\n");
            foreach (BasketItem entry in currentPage.BasketItems)
            {
                Console.WriteLine(entryCounter.ToString("D2") + "  | " +  String.Format("{0,-30}|{1,12}",entry.ToString().Split(",")));
                entryCounter++;
            }
            Console.WriteLine($"\nAll items total: {Basket.PriceOfAllItems}");
            Console.WriteLine($"\nYour allocated budget: {UserBudget}");
            Console.WriteLine("\nPress C to proceed to checkout, or B to go back to the menu");
            char selection = InputParser.PromptCharFromUser(inputOptions);
            if (selection == 'b' || selection == 'B')
                HomeMenu();
            if (selection == 'c' || selection == 'C')
                Checkout(UserBudget);
            if (selection == ',')
                PrintBasketPage(new PageDisplay(Basket.BasketList, (currentPage.PageNumber > 1 ? currentPage.PageNumber-1: 1), 9));
            if (selection == '.')
                PrintBasketPage(new PageDisplay(Basket.BasketList, (currentPage.PageNumber < totalPages ? currentPage.PageNumber+1 : totalPages))); 
        }
               
        public void Checkout(decimal userBudget)
        {
            bool totalWithinBudget = (userBudget - Basket.PriceOfAllItems >= 0);

            Console.WriteLine("\n\nCHECKOUT\n\n");
            Console.WriteLine("\tAll items total: " + Basket.PriceOfAllItems);
            Console.WriteLine("\n\tYour budget:   " + userBudget);
            if (totalWithinBudget)
            {
                Console.Clear();
                Console.WriteLine("\n\n\tThank you for your order!");
                Console.WriteLine("\n\n\tPlease hit any key to quit application.");
                InputParser.PromptForAnyKey();
            }
            else
            {
                Console.WriteLine("\n\n\tSorry, insufficient funds!");
                Console.WriteLine("\n\n\tHit any key to go back");
                InputParser.PromptForAnyKey();
                PrintBasketPage(new PageDisplay(Basket.BasketList, 1, 9));
            }

            // Console.WriteLine("\n\nEnter your email address if you wish to receive an invoice, or hit Enter to skip:");
            // Console.Write(">>> ");
            // Console.WriteLine()
            // if (String.IsNullOrEmpty(emailInput))
        }
    }
}