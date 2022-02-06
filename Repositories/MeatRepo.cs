using System;
using System.Collections.Generic;

namespace StoreModel
{
    public class MeatRepo
    {
        private readonly string _MeatDBLocation = "/Users/crisc/csharp/StoreModel/ProductDatabases/meats.csv";
         private readonly Tuple<string[], List<string[]>> MeatCSVData;
        public string[] ProductKeys;
        public IList<Meat> MeatList;

        public MeatRepo()
        {
            var fileService = new FileReaderService();
            MeatCSVData = fileService.ReadDatabase(_MeatDBLocation);
            ProductKeys = MeatCSVData.Item1;
            MeatList = BuildMeatList(MeatCSVData.Item2);
        }

        public IList<Meat> BuildMeatList(List<string[]> inputList)
        {
            var resultList = new List<Meat>();
            foreach (string[] item in inputList)
            {
                var MeatEntry = new Meat(item[0],
                                     Convert.ToDecimal(item[1]),
                                     Convert.ToInt32(item[2]),
                                     Convert.ToInt32(item[3]),
                                     Convert.ToInt32(item[4]));
                resultList.Add(MeatEntry);
            }
            return resultList;
        }
    }
}