using System;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace XMLSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var e1 = new Employee {
                Id = 100,
                Fname = "Omar",
                Lname = "Sanjaq",
                Benefits = {"Pension" , "Health Insurence"}
            };

            var xmlContent = SerielizeToXmlString(e1);
            Console.WriteLine(xmlContent);
            Console.ReadKey();
        }

        private static string SerielizeToXmlString(Employee e1)
        {
            var result = "";

            var xmlSerializer = new XmlSerializer(e1.GetType());

            using(var sw=new StringWriter())
            {
                using(var xr=XmlWriter.Create(sw, new XmlWriterSettings {Indent = true }))
                {
                    xmlSerializer.Serialize(xr, e1);
                    result = sw.ToString();
                }
            }
            return result;
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public List<string> Benefits { get; set; } = new List<string>();
    }
}