using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

//Руслан Островский

namespace Task1
{
    //С помощью рефлексии выведите все свойства структуры DateTime.
    class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(System.DateTime);
            PropertyInfo[] propertyInfos = type.GetProperties();
            Console.WriteLine("Все свойства типа '{0}':\n", type);
            Console.WriteLine("{0, -15}{1, -1}", "Тип свойства", "Имя свойства");
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Console.WriteLine("{0, -15}{1, -1}", propertyInfo.PropertyType.Name, propertyInfo.Name);
            }

            Console.ReadKey();
        }
    }
}
