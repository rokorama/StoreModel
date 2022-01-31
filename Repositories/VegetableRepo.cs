using System;
using System.Linq;
using System.Collections.Generic;

namespace StoreModel
{
    public class VegetableRepo
    {
        private readonly string _VegetableDBLocation = "/Users/crisc/csharp/StoreModel/ProductDatabases/vegetables.csv";
        private readonly Tuple<string[], string[]> VegetableCSVData;
        public string[] ProductKeys;
        public List<Vegetable> VegetableList;

        public VegetableRepo()
        {
            var fileService = new FileReaderService();
            VegetableCSVData = fileService.ReadDatabase(_VegetableDBLocation);
            ProductKeys = VegetableCSVData.Item1;
            VegetableList = BuildVegetableList(VegetableCSVData.Item2);
        }


        public List<Vegetable> BuildVegetableList(string[] inputList)
        {
            var resultList = new List<Vegetable>();
            foreach (string item in inputList)
            {
                var splitItem = item.Split(",");
                var vegetableEntry = new Vegetable(splitItem[0],
                                     Convert.ToDecimal(splitItem[1]),
                                     Convert.ToInt32(splitItem[2]),
                                     Convert.ToInt32(splitItem[3]),
                                     Convert.ToInt32(splitItem[4]));
                resultList.Add(vegetableEntry);
            }
            return resultList;
        }
    }
}