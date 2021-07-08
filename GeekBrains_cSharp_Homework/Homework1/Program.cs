using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1
{
    //Руслан Островский
    class Program
    {
        static double VectorLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        static void Main(string[] args)
        {
            #region Task1 (Анкета)

            /*
            1. Написать программу «Анкета». Последовательно задаются вопросы (имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку:
                а) используя склеивание;
                б) используя форматированный вывод;
                в) используя вывод со знаком $.
            */
            string name, surname;
            int age, height, weight;

            Console.Write("Введите ваше имя: ");
            name = Console.ReadLine();
            Console.Write("Введите вашу фамилию: ");
            surname = Console.ReadLine();
            Console.Write("Введите ваш возраст: ");
            age = Int32.Parse(Console.ReadLine());
            Console.Write("Введите ваш рост (см): ");
            height = Int32.Parse(Console.ReadLine());
            Console.Write("Введите ваш вес (кг): ");
            weight = Int32.Parse(Console.ReadLine());

            Console.WriteLine("а)(склеивание)\nВаши данные: " + name + " " + surname + ", возраст - " + age + ", рост - " + height + "см, масса - " + weight + "кг.");
            Console.WriteLine("б)(форматированный вывод)\nВаши данные: {0} {1}, возраст - {2}, рост - {3}см, масса - {4}кг.", name, surname, age, height, weight);
            Console.WriteLine($"в)(вывод со знаком $)\nВаши данные: {name} {surname}, возраст - {age}, рост - {height}см, масса - {weight}кг.");

            Console.ReadKey();
            #endregion

            #region Task2 (ИМТ)
            /*
            Ввести вес и рост человека. Рассчитать и вывести индекс массы тела (ИМТ) по формуле I=m/(h*h); где m — масса тела в килограммах, h — рост в метрах.
            */
            Console.Write("Введите ваш вес (кг): ");
            double weight2 = Double.Parse(Console.ReadLine());
            Console.Write("Введите ваш рост (см): ");
            double height2 = Double.Parse(Console.ReadLine());

            Console.WriteLine("Ваш индекс массы тела равен {0: 0.00}", weight2 / (height2 * height2 / 10000));
            Console.ReadKey();
            #endregion

            #region Task3 (Расстояние между точками)
            /*
             а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r=Math.Sqrt(Math.Pow(x2-x1,2)+Math.Pow(y2-y1,2). Вывести результат, используя спецификатор формата .2f (с двумя знаками после запятой);
             б) *Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода.
            */
            Console.Write("Введите кооринаты первой точки:\nx = ");
            double x1 = Double.Parse(Console.ReadLine());
            Console.Write("y = ");
            double y1 = Double.Parse(Console.ReadLine());

            Console.Write("Введите кооринаты второй точки:\nx = ");
            double x2 = Double.Parse(Console.ReadLine());
            Console.Write("y = ");
            double y2 = Double.Parse(Console.ReadLine());

            double r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            Console.WriteLine("а)Расстояние между точками равно {0: 0.00}", r);
            Console.WriteLine("б)Расстояние между точками равно {0: 0.00}", VectorLength(x1, y1, x2, y2));

            Console.ReadKey();

            #endregion

            #region Task4 (обмен)
            /*
            Написать программу обмена значениями двух переменных типа int без использования вспомогательных методов.
                а) с использованием третьей переменной;
                б) *без использования третьей переменной.
            */
            int a = 5;
            int b = 400;
            Console.WriteLine($"Переменная a = {a}, переменная b = {b}.\nВЖУХ!\n");

            int buff = a;
            a = b;
            b = buff;
            Console.WriteLine($"Переменная a = {a}, переменная b = {b}.\nВЖУХ! А теперь обратно безиспользования третьей переменной\n");

            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"Переменная a = {a}, переменная b = {b}");

            Console.ReadKey();

            #endregion

            #region Task5 (обо мне)
            /*
            а) Написать программу, которая выводит на экран ваше имя, фамилию и город проживания.
            б) Сделать задание, только вывод организовать в центре экрана.
            в) *Сделать задание б с использованием собственных методов (например, Print(string ms, int x,int y).
            */

            Console.WriteLine("Руслан Островский, Зеленоград");

            Console.ReadKey();

            #endregion
        }
    }
}
