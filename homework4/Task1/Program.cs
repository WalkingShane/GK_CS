using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    //Руслан Островский
    //Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
    //Заполнить случайными числами. Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3.
    //В данной задаче под парой подразумевается два подряд идущих элемента массива.
    //Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
    class Program
    {
        /// <summary>
        /// Находит в массиве целых чисел такие пары из подряд идущих элементов, только один из которых кратен 3.
        /// </summary>
        /// <param name="arr"></param>
        /// <returns>Количество пар</returns>
        public static int FindPairs(int[] arr)
        {
            int n = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] % 3 == 0 ^ arr[i-1] % 3 == 0)
                    n++;
            }
            return n;
        }

        static void Main(string[] args)
        {
            Random random = new Random();

            int[] arr = new int[20];
            Console.WriteLine("Дан массив из 20 случайных элементов:");
            for (int i = 0; i < 20; i++)
            {
                arr[i] = random.Next(-10000, 10000);
                Console.Write("\t{0}", arr[i]);
                if ((i + 1) % 5 == 0)
                    Console.WriteLine();
            }
            Console.WriteLine("\nКоличество пар: {0}", FindPairs(arr));

            Console.ReadKey();
        }
    }
}
