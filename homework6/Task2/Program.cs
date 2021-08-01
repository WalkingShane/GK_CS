using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Руслан Островский

namespace Task2
{
    //    Модифицировать программу нахождения минимума функции так,
    //    чтобы можно было передавать функцию в виде делегата.
    //          а) Сделать меню с различными функциями и представить пользователю
    //          выбор, для какой функции и на каком отрезке находить минимум.
    //          Использовать массив(или список) делегатов, в котором хранятся
    //          различные функции.
    //          б) * Переделать функцию Load, чтобы она возвращала массив
    //          считанных значений. Пусть она возвращает минимум через
    //          параметр(с использованием модификатора out).

    public delegate double Fun(double x);
    class Program
    {
        private static Dictionary<string, Fun> funs = new Dictionary<string, Fun>
            {
                { "x^2 - 50x + 10", delegate (double x) { return x * x - 50 * x + 10; } },
                { "3x^2 - 7",       delegate (double x) { return 3 * x * x - 7; } },
                { "sin(x) + 15",    delegate (double x) { return Math.Sin(x) + 15; } },
                { "|x + 3| - 2",    delegate (double x) { return Math.Abs(x + 3) - 2; } },
                { "sqrt(x-5) + 4",  delegate (double x) { return Math.Sqrt(x - 5) + 4; } },
                { "x",  delegate (double x) { return x; } }
            };

        public static Dictionary<string, Fun> Funs { get{ return funs; } }

        /// <summary>
        /// Сохраняет значения функции в бинарный файл.
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="F">Делегат функции для вычисления значений</param>
        /// <param name="a">Левая граница отрезка оси аргументов</param>
        /// <param name="b">Правая граница отрезка оси аргументов</param>
        /// <param name="h">Шаг вычислений</param>
        public static void SaveFunc(string fileName, Fun F, double a, double b, double h)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(F(x));
                x += h;// x=x+h;
            }
            bw.Close();
            fs.Close();
        }

        /// <summary>
        /// Отрывает меню выбора функции и задания границ отрезка.
        /// </summary>
        /// <param name="a">"Левая" граница отрезка</param>
        /// <param name="b">"Правая" граница отрезка</param>
        /// <returns>Выбранную пользователем функцию</returns>
        public static Fun ChooseFromMenu(out double a, out double b)
        {
            bool aFine, bFine;
            do
            {
                Console.WriteLine("Укажите отрезок для поиска минимума функции, введя пограничные значения отрезка:");
                aFine = double.TryParse(Console.ReadLine(), out a);
                bFine = double.TryParse(Console.ReadLine(), out b);

            } while (!aFine && !bFine && a >= b);

            Console.WriteLine("Список функций:");
            List<string> functions = new List<string>(funs.Keys); 
            foreach (string str in functions)
            {
                Console.WriteLine(functions.IndexOf(str) + " - " + str);
            }
            int choice;
            
            do
            {
                Console.WriteLine();
                Console.Write("Введите индекс функции для которой необходимо найти минимум: ");
            } while (int.TryParse(Console.ReadLine(), out choice) && !(choice >= 0 && choice < functions.Count));

            return funs[functions.ElementAt(choice)];
        }

        /// <summary>
        /// Загружает значения функции из файла.
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        /// <param name="min">Ссылка на значение переменной для хранения минимума функции</param>
        /// <returns>Массив значений функции, выгруженный из файла</returns>
        public static double[] Load(string fileName, out double min)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            min = double.MaxValue;
            double d;
            double[] valuesFromFile = new double[fs.Length / sizeof(double)];
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                valuesFromFile[i] = d;
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return valuesFromFile;
        }
        static void Main(string[] args)
        {
            double min = 0;
            SaveFunc("data.bin", ChooseFromMenu(out double a, out double b), a, b, 0.1);
            double[] tableFunc = Load("data.bin", out min);
            Console.WriteLine("Значения функции в заданном отрезке:");
            for (int i = 0; i < tableFunc.Length; i++)
                Console.WriteLine(tableFunc[i]);
            Console.WriteLine("Минимум функции: {0}", min);

            Console.ReadKey();
        }
    }

}
