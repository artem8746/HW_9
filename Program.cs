using System.Diagnostics.CodeAnalysis;

namespace HW_9
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var person = new Person
            {
                Id = 1,
                Name = "Artem",
                Gender = "helicopter",
                Address = "hidden"
            };

            Console.Write("Enter the name of property: ");
            
            var propName = Console.ReadLine();

            GetPropertyValue(person, propName);

            Console.Write("Enter new property value: ");

            object propValue = Console.ReadLine();

            SetPropertyValue(person, propName, propValue);

            GetPropertyValue(person, propName);
        }

        public static void GetPropertyValue(object obj, string propName)
        {
            var type = obj.GetType();
            
            if(propName != null)
            {
                var prop = type.GetProperty(propName);

                if(prop != null) 
                {
                    Console.WriteLine($"PropName - {propName} : {prop.GetValue(obj)}");
                }
            }
        }

        public static void SetPropertyValue(object obj, string propName, object propValue)
        {
            var type = obj.GetType();

            if(propName != null) 
            {
                var prop = type.GetProperty(propName);

                if (propValue != null)
                    prop.SetValue(obj, propValue);
            }
        }
    }
}