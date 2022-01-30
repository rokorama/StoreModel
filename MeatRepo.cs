using System;
using System.Collections.Generic;

namespace StoreModel
{
    public class MeatRepo
    {
        private readonly string _MeatDBLocation = "/Users/crisc/csharp/StoreModel/ProductDatabases/meats.csv";
         private readonly Tuple<string[], string[]> MeatCSVData;
        public string[] ProductKeys;
        public List<Meat> MeatList;

        public MeatRepo()
        {
            var fileService = new FileReaderService();
            MeatCSVData = fileService.ReadDatabase(_MeatDBLocation);
            ProductKeys = MeatCSVData.Item1;
            MeatList = BuildMeatList(MeatCSVData.Item2);
        }

        public List<Meat> BuildMeatList(string[] inputList)
        {
            var resultList = new List<Meat>();
            foreach (string item in inputList)
            {
                var splitItem = item.Split(",");
                var MeatEntry = new Meat(splitItem[0],
                                     Convert.ToDecimal(splitItem[1]),
                                     Convert.ToInt32(splitItem[2]),
                                     Convert.ToInt32(splitItem[3]),
                                     Convert.ToInt32(splitItem[4]));
                resultList.Add(MeatEntry);
            }
            return resultList;
        }

        public void PrintAllProducts()
        {
            string stringAligment = "{0,-20}|  {1,-10}|  {2,-10}|  {3,-15}|  {4,-15}";
            Console.WriteLine("MeatS\n");
            Console.WriteLine(String.Format(stringAligment, ProductKeys)+"\n");
            foreach (Meat entry in MeatList)
            {
                Console.WriteLine(String.Format(stringAligment, entry.Name,
                                                                entry.Price,
                                                                entry.SKU,
                                                                entry.WeightGrams,
                                                                entry.ProteinPer100G));
            }
        }
    }
}