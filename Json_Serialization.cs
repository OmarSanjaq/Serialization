using Newtonsoft.Json;
using System;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace JsonSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var e1 = new Employee
            {
                Id = 100,
                Fname = "Omar",
                Lname = "Sanjaq",
                Benefits = { "Pension", "Health Insurence" }
            };

            var jsonContent = SerializeJsonStringUSingNewtonSoftJson(e1);
            Console.WriteLine("===Content Json using Soft===");
            Console.WriteLine(jsonContent);

            var e2 = DeSerializeJsonStringUSingNewtonSoftJson(jsonContent);

            Console.WriteLine("===Content Json using Json.Net===");

            var JsonContent2 = SerializeJsonStringUSingJSONNET(e1);
            var e3 = DeSerializeJsonStringUSingJSONNET(JsonContent2);
            Console.WriteLine(JsonContent2);
            Console.ReadKey();
        }

        static string SerializeJsonStringUSingNewtonSoftJson(Employee employee)
        {
            var result = "";
            result = JsonConvert.SerializeObject(employee, Newtonsoft.Json.Formatting.Indented);
            return result;
        }


        /// 
        static Employee DeSerializeJsonStringUSingNewtonSoftJson(string jsonContent)
        {
            Employee employee = null;
            employee = JsonConvert.DeserializeObject<Employee>(jsonContent);
            return employee;
        }


        /// ===========================================  Usnig Json.net
        static string SerializeJsonStringUSingJSONNET(Employee employee)
        {
            var result = "";
            result = System.Text.Json.JsonSerializer.Serialize(employee,
                new JsonSerializerOptions {WriteIndented =true});
            return result;
        }


        /// 
        static Employee DeSerializeJsonStringUSingJSONNET(string jsonContent)
        {
            Employee employee = null;
            employee = JsonConvert.DeserializeObject<Employee>(jsonContent);
            return employee;
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