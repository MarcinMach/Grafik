using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// This test evaluates the 
    /// </summary>
public class XmlReadingTest : ITest
    {
        public string Name { get { return "XML Reading Test"; } }



        public void Run()
        {
            var xmlData = Resources.SamplePoints;
            XDocument doc = XDocument.Parse(xmlData);
            var results = new List<Parameters>();


            foreach (XElement el in doc.Root.Elements())
            {
                foreach (XAttribute attr in el.Attributes())
                {
                    foreach (XElement element in el.Elements())
                    {
                        var result = new Parameters();
                        result.Name = element.Attribute("name").Value;
                        result.Value = double.Parse(element.Value, CultureInfo.InvariantCulture);
                        results.Add(result);
                    }
                }
                
            }
            var grupedResults = results.GroupBy(z => z.Name).Select(x => x.ToList()).ToList();
            Console.WriteLine("parameter  LOW  AVG  MAX");
            foreach(var item in grupedResults)
            {
              var name = item.FirstOrDefault().Name;                
              var avg = Math.Round(item.Sum(x => x.Value)/item.Count(),2);
              var min = item.Min(x=>x.Value).ToString();
              var max = item.Max(x => x.Value);
              Console.WriteLine("{0} {1} {2} {3}",name, min, avg, max);
            }

            PrintOverview(xmlData);
        }

        private void PrintOverview(string xml)
        {
        }
    }

    public class Parameters
    {
        public double Value { get; set; }
        public string Name { get; set; }
    
}
