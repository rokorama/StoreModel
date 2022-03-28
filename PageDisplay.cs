using System;
using System.Collections.Generic;
using System.Linq;
using StoreModel.Models;


namespace StoreModel
{
    public class PageDisplay
    {
        public int PageNumber { get; private set; }
        public int PageSize { get; set; } 
        public List<Vegetable> VegetableItems { get; set; }
        public List<Beverage> BeverageItems { get; set; }
        public List<Meat> MeatItems { get; set; }
        public List<Candy> CandyItems { get; set; }
        public List<BasketItem> BasketItems { get; set; }

        public PageDisplay(List<Vegetable> sourceList, int pageNumber, int pageSize = 9)
        {
            VegetableItems = sourceList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        
        public PageDisplay(List<Beverage> sourceList, int pageNumber, int pageSize = 9)
        {
            BeverageItems = sourceList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public PageDisplay(List<Meat> sourceList, int pageNumber, int pageSize = 9)
        {
            MeatItems = sourceList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
        public PageDisplay(List<Candy> sourceList, int pageNumber, int pageSize = 9)
        {
            CandyItems = sourceList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public PageDisplay(List<BasketItem> sourceList, int pageNumber, int pageSize = 9)
        {
            BasketItems = sourceList.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            PageNumber = pageNumber;
            PageSize = pageSize;
        }        


        public List<Vegetable> GetPage(List<Vegetable> list, int pageNumber, int pageSize = 9)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Beverage> GetPage(List<Beverage> list, int pageNumber, int pageSize = 9)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Meat> GetPage(List<Meat> list, int pageNumber, int pageSize = 9)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Candy> GetPage(List<Candy> list, int pageNumber, int pageSize = 9)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }        

        public List<BasketItem> GetPage(List<BasketItem> list, int pageNumber, int pageSize = 9)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }      

        public int CalculateTotalPages(int totalItems, int pageSize = 9)
        {
            return (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
        }

        // public 

    }
}
