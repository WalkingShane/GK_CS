using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Руслан Островский

namespace Task3
{
 //   * Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
 //         Например: badc являются перестановкой abcd.
    class Program
    {
        /// <summary>
        /// Определяет является ли одна строка инверсией другой строки.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns>true если является, иначе false</returns>
        static bool IsOneInversionOfAnother(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            for (int i = 0; i < str1.Length / 2; i++)
            {
                if (str1[i] != str2[str2.Length - i - 1])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Определяет является ли одна строка перестановкой другой строки.
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns>true если является, иначе false</returns>
        static bool IsOneTranspositionOfAnother(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;
            Dictionary<char, int> keys = new Dictionary<char, int>();
            foreach (char ch in str1)
            {
                if (keys.ContainsKey(ch))
                    keys[ch]++;
                else keys.Add(ch, 1);
            }
            foreach (char ch in str2)
            {
                if (keys.ContainsKey(ch) && keys[ch] > 0)
                    keys[ch]--;
                else return false;
            }

            

            return true;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Введите 2 строки для сравнения на инверсию:");
            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            Console.WriteLine(IsOneInversionOfAnother(str1, str2) ? "Строки являются инверсиями друг друга." : "Строки не являются инверсиями друг друга.");

            Console.WriteLine(IsOneTranspositionOfAnother(str1, str2) ? "Строки являются перестановкой друг друга." : "Строки не являются перестановкой друг друга.");

            Console.ReadKey();
        }
    }
}
