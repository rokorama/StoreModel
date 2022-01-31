using System;
using System.Collections.Generic;

namespace StoreModel
{
    public class CandyRepo
    {
        private readonly string _CandyDBLocation = "/Users/crisc/csharp/StoreModel/ProductDatabases/candy.csv";
         private readonly Tuple<string[], string[]> CandyCSVData;
        public string[] ProductKeys;
        public List<Candy> CandyList;

        public CandyRepo()
        {
            var fileService = new FileReaderService();
            CandyCSVData = fileService.ReadDatabase(_CandyDBLocation);
            ProductKeys = CandyCSVData.Item1;
            CandyList = BuildCandyList(CandyCSVData.Item2);
        }

        public List<Candy> BuildCandyList(string[] inputList)
        {
            var resultList = new List<Candy>();
            foreach (string item in inputList)
            {
                var splitItem = item.Split(",");
                var CandyEntry = new Candy(splitItem[0],
                                     Convert.ToDecimal(splitItem[1]),
                                     Convert.ToInt32(splitItem[2]),
                                     Convert.ToInt32(splitItem[3]),
                                     Convert.ToInt32(splitItem[4]));
                resultList.Add(CandyEntry);
            }
            return resultList;
        }

        public void PrintAllProducts()
        {
            string stringAligment = "{0,-20}|  {1,-10}|  {2,-10}|  {3,-15}|  {4,-15}";
            Console.WriteLine("CANDY\n");
            Console.WriteLine(String.Format(stringAligment, ProductKeys)+"\n");
            foreach (Candy entry in CandyList)
            {
                Console.WriteLine(String.Format(stringAligment, entry.Name,
                                                                entry.Price,
                                                                entry.SKU,
                                                                entry.WeightGrams,
                                                                entry.SugarPer100G));
            }
        }
    }
}