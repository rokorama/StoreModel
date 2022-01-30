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

        public void PrintAllProducts()
        {
            string stringAligment = "{0,-20}|  {1,-10}|  {2,-10}|  {3,-15}|  {4,-15}";
            Console.WriteLine("VEGETABLES\n");
            Console.WriteLine(String.Format(stringAligment, ProductKeys)+"\n");
            foreach (Vegetable entry in VegetableList)
            {
                Console.WriteLine(String.Format(stringAligment, entry.Name,
                                                                entry.Price,
                                                                entry.SKU.ToString("D6"),
                                                                entry.WeightGrams,
                                                                entry.FibrePer100G));
            }
        }

    }
}
