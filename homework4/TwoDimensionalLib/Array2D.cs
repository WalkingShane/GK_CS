using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Руслан Островский
namespace TwoDimensionalLib
{
    //    а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами.
    //    Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство,
    //    возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод,
    //    возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out).
    //  * б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    // ** в) Обработать возможные исключительные ситуации при работе с файлами.
    public class Array2D
    {
        private int[,] array;

        public int Minimum
        {
            get
            {
                int min = array[0, 0];
                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        if (array[i, j] < min)
                            min = array[i, j];
                return min;
            }
        }

        public int Maximum
        {
            get
            {
                int max = array[0, 0];
                for (int i = 0; i < array.GetLength(0); i++)
                    for (int j = 0; j < array.GetLength(1); j++)
                        if (array[i, j] > max)
                            max = array[i, j];
                return max;
            }
        }

        /// <summary>
        /// Создает экземпляр класса Array2D - двумерный массив. Заполняет элементы случайными значениями.
        /// </summary>
        /// <param name="size1">Число строк в массиве</param>
        /// <param name="size2">Число рядов в массиве</param>
        /// <param name="min">Минимально возможное случайное значение</param>
        /// <param name="max">Максимально возможное случайное значение</param>
        public Array2D(int size1, int size2, int min, int max)
        {
            Random random = new Random();
            array = new int[size1, size2];
            for (int i = 0; i < size1; i++)
                for (int j = 0; j < size2; j++)
                    array[i, j] = random.Next(min, max);

        }

        /// <summary>
        /// Создает экземпляр класса Array2D - двумерный массив. Значения элементов считывает из входного файла.
        /// </summary>
        /// <param name="inputFileName">Имя файла</param>
        public Array2D(string inputFileName)
        {
            int n = 0;
            string[] lines = new string[10];
            string[] buf;


            if (File.Exists(inputFileName))
            {
                StreamReader reader = new StreamReader(inputFileName);
                while (!reader.EndOfStream)
                {
                    lines[n] = reader.ReadLine();
                    n++;
                    if (n >= lines.Length)
                    {
                        buf = lines;
                        lines = new string[lines.Length * 2];
                        buf.CopyTo(lines, 0);
                    }
                }
                reader.Close();
            }
            else throw new FileNotFoundException($"Не найден файл с таким именем: '{inputFileName}'.");

            int m = lines[0].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            array = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] raws = lines[i].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < m; j++)
                {
                    if (!int.TryParse(raws[j], out array[i, j]))
                        throw new IOException($"Не удалось парсировать данные из файла в строке {i}.");
                }
            }
        }

        /// <summary>
        /// Сохраняет значения элементов массива в файл по заданному пути.
        /// </summary>
        /// <param name="outputFileName">Путь для сохранения файла.</param>
        public void SaveArrayToFile(string outputFileName)
        {
            if (!File.Exists(outputFileName))
                File.Create(outputFileName);
            else
            {
                File.Delete(outputFileName.Insert(outputFileName.Length - 4, "_old"));
                File.Copy(outputFileName, outputFileName.Insert(outputFileName.Length - 4, "_old"));
            }
            StreamWriter writer = new StreamWriter(outputFileName);
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    writer.Write("{0}\t", array[i, j]);
                writer.WriteLine();
            }
            Console.WriteLine($"Данные сохранены в {outputFileName}");
            writer.Close();
        }

        public void ShowArray()
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write("{0}\t", array[i, j]);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Вычисляет сумму всех элементов массива.
        /// </summary>
        /// <returns>Сумма элементов</returns>
        public int GetSumOfElements()
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    sum += array[i, j];

            return sum;
        }

        /// <summary>
        /// Вычисляет сумму всех элементов массива, значение которых больше заданной планки.
        /// </summary>
        /// <param name="cap">Заданная планка</param>
        /// <returns>Сумма элементов больших cap.</returns>
        public int GetSumOfElements(int cap)
        {
            int sum = 0;
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (array[i, j] > cap)
                        sum += array[i, j];

            return sum;
        }

        public void GetIndexOfMaximum(ref int index1, ref int index2)
        {
            int max = array[0, 0];
            for (int i = 0; i < array.GetLength(0); i++)
                for (int j = 0; j < array.GetLength(1); j++)
                    if (array[i, j] > max)
                    {
                        max = array[i, j];
                        index1 = i;
                        index2 = j;
                    }
        }


    }
}
