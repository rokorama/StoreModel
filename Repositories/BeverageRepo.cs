using System;
using System.Collections.Generic;

namespace StoreModel
{
    public class BeverageRepo
    {
        private readonly string _BeverageDBLocation = "/Users/crisc/csharp/StoreModel/ProductDatabases/beverages.csv";
        private readonly Tuple<string[], List<string[]>> BeverageCSVData;
        public string[] ProductKeys;
        public List<Beverage> BeverageList;

        public BeverageRepo()
        {
            var fileService = new FileReaderService();
            BeverageCSVData = fileService.ReadDatabase(_BeverageDBLocation);
            ProductKeys = BeverageCSVData.Item1;
            BeverageList = BuildBeverageList(BeverageCSVData.Item2);
        }

        public List<Beverage> BuildBeverageList(List<string[]> inputList)
        {
            var resultList = new List<Beverage>();
            foreach (string[] item in inputList)
            {
                var BeverageEntry = new Beverage(item[0],
                                     Convert.ToDecimal(item[1]),
                                     Convert.ToInt32(item[2]),
                                     Convert.ToInt32(item[3]),
                                     item[4]);
                resultList.Add(BeverageEntry);
            }
            return resultList;
        }
    }
}