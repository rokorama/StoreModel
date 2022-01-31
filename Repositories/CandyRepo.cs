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
    }
}