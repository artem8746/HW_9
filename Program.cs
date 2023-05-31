﻿using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

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
            //создание объекта класса

            //Console.Write("Enter the name of property: ");

            //var propName = Console.ReadLine();

            //GetPropertyValue(person, propName);

            //Console.Write("Enter new property value: ");

            //object propValue = Console.ReadLine();

            //SetPropertyValue(person, propName, propValue);

            //Console.WriteLine($"PrintObj: ");

            //Console.WriteLine(SerializeObject(person));

            var str = SerializeObject(person);

            var obj = Deserealize(str, typeof(Person));

            var obj2 = Deserealize<Person>(str);
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
        //метод, который получает значение свойства по имени

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
        //метод, который задает значение по имени свойства

        public static string SerializeObject(object obj)
        {
            string objInfo = string.Empty;

            Type type = obj.GetType();

            var propertiesInfo = type.GetProperties();

            foreach(var property in propertiesInfo)
            {
                objInfo += $"<{property.Name}> : <{property.GetValue(obj)}>\n";
            }

            return objInfo;
        }
        //метод, который сереализует объект в строку

        public static object Deserealize(string str, Type type)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            str = str.Replace("<", "").Replace(">", "");

            dict = str
                .Split("\n")
                .Select(x => x.Split(":"))
                .Where(x => x.Length > 1)
                .ToDictionary(x => x[0].Trim(), x => (object)(x[1].Trim()));

            var obj = Activator.CreateInstance(type);

            var propertiesInfo = type.GetProperties();

            foreach(var property in propertiesInfo)
            {
                var propName = property.Name;

                if(dict.Keys.Contains(propName))
                {
                    property.SetValue(obj, Convert.ChangeType(dict[propName], property.PropertyType));
                }
            }

            return obj;
        }
        //метод, который создает объект и делает противоположное действие методу SerializeObject

        public static T Deserealize<T> (string str) 
        {
            return (T)Deserealize(str, typeof(T));
        }
        //тот же метод что и Deserealize, но с типом Generic 
    }
}