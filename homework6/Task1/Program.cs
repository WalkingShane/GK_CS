using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Руслан Островский

namespace Task1
{
    //Изменить программу вывода таблицы функции так, чтобы можно было
    //передавать функции типа double (double, double).
    //Продемонстрировать работу на функции с функцией a* x^2 и
    //функцией a* sin(x).

    public delegate double Fun(double x, double param);
    
    class Program
    {
        public static void Table(Fun F, double x, double param, double xLimit)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= xLimit)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, param));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        public static double MyFunc1(double x, double param)
        {
            return param * x * x;
        }

        public static double MyFunc2(double x, double param)
        {
            return param * Math.Sin(x);
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            double x0 = -5; //начальное значение аргумента функции
            double a = Math.Round(random.NextDouble() * random.Next(-100, 100), 2); //значение параметра вызываемых функций
            double xLimit = 5; //конечное значение аргумента функции

            Console.WriteLine($"Таблица функции {a} * x^2:");
            
            Table(new Fun(MyFunc1), x0, a, xLimit);//стандартный метод


            Console.WriteLine($"Таблица функции {a} * sin(x):");

            Table(MyFunc2, x0, a, xLimit);//с упрощением


            Console.WriteLine($"Таблица функции sqrt(|{a} * tan(x)|):");

            Table(delegate (double x, double param) { return Math.Sqrt(Math.Abs(param * Math.Tan(x))); }, x0, a, xLimit); //анонимный метод

            Console.ReadKey();
        }
    }
}
