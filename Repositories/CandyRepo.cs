using System;
using System.Collections.Generic;

namespace StoreModel
{
    public class CandyRepo
    {
        private readonly string _CandyDBLocation = "/Users/crisc/csharp/StoreModel/ProductDatabases/candy.csv";
        private readonly Tuple<string[], List<string[]>> CandyCSVData;
        public string[] ProductKeys;
        public IList<Candy> CandyList;

        public CandyRepo()
        {
            var fileService = new FileReaderService();
            CandyCSVData = fileService.ReadDatabase(_CandyDBLocation);
            ProductKeys = CandyCSVData.Item1;
            CandyList = BuildCandyList(CandyCSVData.Item2);
        }

        public IList<Candy> BuildCandyList(List<string[]> inputList)
        {
            var resultList = new List<Candy>();
            foreach (string[] item in inputList)
            {
                var CandyEntry = new Candy(item[0],
                                     Convert.ToDecimal(item[1]),
                                     Convert.ToInt32(item[2]),
                                     Convert.ToInt32(item[3]),
                                     Convert.ToInt32(item[4]));
                resultList.Add(CandyEntry);
            }
            return resultList;
        }
    }
}