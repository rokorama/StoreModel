using System;
using System.Linq;
using System.Collections.Generic;
using StoreModel.Models;


namespace StoreModel
{
    public class VegetableRepo
    {
        private readonly string _VegetableDBLocation = "/Users/crisc/csharp/StoreModel/ProductDatabases/vegetables.csv";
        private readonly Tuple<string[], List<string[]>> VegetableCSVData;
        public string[] ProductKeys;
        public List<Vegetable> VegetableList;

        public VegetableRepo()
        {
            var fileService = new FileReaderService();
            VegetableCSVData = fileService.ReadDatabase(_VegetableDBLocation);
            ProductKeys = VegetableCSVData.Item1;
            VegetableList = BuildVegetableList(VegetableCSVData.Item2);
        }

        public List<Vegetable> BuildVegetableList(List<string[]> inputList)
        {
            var resultList = new List<Vegetable>();
            foreach (string[] item in inputList)
            {
                var vegetableEntry = new Vegetable(item[0],
                                     Convert.ToDecimal(item[1]),
                                     Convert.ToInt32(item[2]),
                                     Convert.ToInt32(item[3]),
                                     Convert.ToInt32(item[4]));
                resultList.Add(vegetableEntry);
            }
            return resultList;
        }
    }
}