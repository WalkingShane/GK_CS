using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    //Руслан Островский
    //Дан целочисленный массив из 20 элементов. Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно.
    //Заполнить случайными числами. Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3.
    //В данной задаче под парой подразумевается два подряд идущих элемента массива.
    //Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2.
    //
    //Реализуйте задачу 1 в виде статического класса StaticClass;
    //  а) Класс должен содержать статический метод, который принимает на вход массив и решает задачу 1;
    //  б) Добавьте статический метод для считывания массива из текстового файла. Метод должен возвращать массив целых чисел;
    //  в)* Добавьте обработку ситуации отсутствия файла на диске.

    static class StaticClass
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
                if (arr[i] % 3 == 0 ^ arr[i - 1] % 3 == 0)
                    n++;
            }
            return n;
        }
        /// <summary>
        /// Считывает строки из файла и парсирует их в массив целых чисел.
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <returns>Массив целых чисел</returns>
        public static int[] ReadArrayFromFile(string fileName)
        {
            int[] arrInput = new int[100];
            int n = 0;
            if (File.Exists(fileName))
            {
                StreamReader streamReader = new StreamReader(fileName);
                while (!streamReader.EndOfStream)
                {
                    string line = streamReader.ReadLine();
                    if (int.TryParse(line, out arrInput[n]))
                    {
                        Console.WriteLine(arrInput[n]);
                        n++;
                    }
                        
                    else throw new IOException($"Не удалось парсировать строку {n + 1} из файла в целое число.");
                }    
            }
            else
            {
                throw new FileNotFoundException($"Не найдено файла с таким именем \"{fileName}\".");
            }

            int[] arrOutput = new int[n];
            Array.Copy(arrInput, arrOutput, n);

            return arrOutput;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nКоличество пар: {0}", StaticClass.FindPairs(StaticClass.ReadArrayFromFile(AppDomain.CurrentDomain.BaseDirectory + "TextFile1.txt")));

            Console.ReadKey();
        }
    }
}
