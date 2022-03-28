using System;
using System.Collections.Generic;
using System.Linq;
using StoreModel.Contexts;
using StoreModel.Models;


namespace StoreModel
{
    public class BeverageRepo
    {
        public List<Beverage> BeverageList;

        public BeverageRepo()
        {
            using var dbContext = new StoreItemContext();

            BeverageList = dbContext.BeverageItems.ToList();
        }
    }
}