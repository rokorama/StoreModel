using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.FileIO;

namespace StoreModel
{
    public class FileReaderService
    {
        public FileReaderService()
        {
        }

        public Tuple<string[], List<string[]>> ReadDatabase(string fileLocation)
        {
            TextFieldParser parser = new TextFieldParser(fileLocation);
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");

            var headers = parser.ReadFields();
            var entries = new List<string[]>();
            while (!parser.EndOfData)
            {
                var entry = parser.ReadFields();
                entries.Add(entry);
            } 
            parser.Close();
            var result = Tuple.Create(headers, entries);
            return result;
        }

    }
}