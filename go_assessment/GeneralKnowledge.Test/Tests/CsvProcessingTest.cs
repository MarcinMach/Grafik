using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// CSV processing test
    /// </summary>
    public class CsvProcessingTest : ITest
    {
        public void Run()
        {
            // TODO: 
            // Create a domain model via POCO classes to store the data available in the CSV file below
            // Objects to be present in the domain model: Asset, Country and Mime type
            // Process the file in the most robust way possible
            // The use of 3rd party plugins is permitted
            try
            {
                var csvFile = Resources.AssetImport;
                var value = csvFile.Split('\n').ToList();
                List<Model> PocoModel = new List<Model>();
                foreach (var record in value.Skip(1))
                {
                    var recordArray = record.Split(',');
                    if(record.Count() >5)
                    PocoModel.Add(new Model(recordArray[0], recordArray[5], recordArray[2]));

                }
            }
            catch(Exception ex)
            {
                throw ex;
            }


            
        }
    }

    public class Model
    {
        public string Asset { get; set; }
        public string Country { get; set; }
        public string MimeType { get; set; }

        public Model()
        {

        }

        public Model(string asset, string country, string mimeType)
        {
            Asset = asset;
            Country = country;
            MimeType = mimeType;
        }
    }
        

}
