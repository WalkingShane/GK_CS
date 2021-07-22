using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoDimensionalLib;

//Руслан Островский
namespace Task5
{
    //    а) Реализовать библиотеку с классом для работы с двумерным массивом. Реализовать конструктор, заполняющий массив случайными числами.
    //    Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство,
    //    возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод,
    //    возвращающий номер максимального элемента массива(через параметры, используя модификатор ref или out).
    //  * б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
    // ** в) Обработать возможные исключительные ситуации при работе с файлами.
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int m = 6;
            Array2D array = new Array2D(n, m, -100, 100);
            array.ShowArray();

            Console.WriteLine("Минимальное значение элементов массива: {0}.", array.Minimum);

            Console.WriteLine("Максимальное значение элементов массива: {0}.", array.Maximum);

            Console.WriteLine("Сумма значений всех элементов массива: {0}.", array.GetSumOfElements());

            int cap = new Random().Next(-1000, 1000);
            Console.WriteLine("Сумма значений всех элементов массива больших {0}: {1}.", cap, array.GetSumOfElements(cap));

            array.GetIndexOfMaximum(ref n, ref m);
            Console.WriteLine("Индексы элемента с максимальным значением: [{0}, {1}].", n + 1, m + 1);

            Array2D array2 = new Array2D("Data_old.txt");

            Console.WriteLine("Массив загруженный из файла.");
            array2.ShowArray();

            array.SaveArrayToFile(AppDomain.CurrentDomain.BaseDirectory + "Data.txt");

            Console.WriteLine("Минимальное значение элементов массива: {0}.", array2.Minimum);

            Console.WriteLine("Максимальное значение элементов массива: {0}.", array2.Maximum);

            Console.WriteLine("Сумма значений всех элементов массива: {0}.", array2.GetSumOfElements());

            cap = new Random().Next(-1000, 1000);
            Console.WriteLine("Сумма значений всех элементов массива больших {0}: {1}.", cap, array2.GetSumOfElements(cap));

            array2.GetIndexOfMaximum(ref n, ref m);
            Console.WriteLine("Индексы элемента с максимальным значением: [{0}, {1}].", n + 1, m + 1);

            Console.ReadKey();
        }
    }
}
