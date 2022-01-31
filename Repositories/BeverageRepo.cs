using System;
using System.Collections.Generic;

namespace StoreModel
{
    public class BeverageRepo
    {
        private readonly string _BeverageDBLocation = "/Users/crisc/csharp/StoreModel/ProductDatabases/beverages.csv";
        private readonly Tuple<string[], string[]> BeverageCSVData;
        public string[] ProductKeys;
        public List<Beverage> BeverageList;

        public BeverageRepo()
        {
            var fileService = new FileReaderService();
            BeverageCSVData = fileService.ReadDatabase(_BeverageDBLocation);
            ProductKeys = BeverageCSVData.Item1;
            BeverageList = BuildBeverageList(BeverageCSVData.Item2);
        }

        public List<Beverage> BuildBeverageList(string[] inputList)
        {
            var resultList = new List<Beverage>();
            foreach (string item in inputList)
            {
                var splitItem = item.Split(",");
                var BeverageEntry = new Beverage(splitItem[0],
                                     Convert.ToDecimal(splitItem[1]),
                                     Convert.ToInt32(splitItem[2]),
                                     Convert.ToInt32(splitItem[3]),
                                     splitItem[4]);
                resultList.Add(BeverageEntry);
            }
            return resultList;
        }
    }
}