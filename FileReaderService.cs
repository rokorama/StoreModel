using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace StoreModel
{
    public class FileReaderService
    {
        public FileReaderService()
        {
        }

        public Tuple<string[], string[]> ReadDatabase(string fileLocation)
        {
            var allLines = File.ReadAllLines(fileLocation);
            //store CSV headers in a separate array
            var headers = allLines[0].Split(",").ToArray();
            var entry = allLines.Skip(1).ToArray();
            var result = Tuple.Create(headers, entry);
            return result;
        }

    }
}