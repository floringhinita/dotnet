using System;
using System.IO;
using System.Xml.Serialization;
using prob5.Core;

namespace prob5
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessDate bd = new BusinessDate(DateTime.Today);

            XmlSerializer xs = new XmlSerializer(typeof(BusinessDate));

            StringWriter ms = new StringWriter();
           
            xs.Serialize(ms, bd);

            Console.WriteLine(ms.ToString());

            Clock clock = new Clock();

            Console.WriteLine(clock.Today.ToString("m"));

        }
    }
}
