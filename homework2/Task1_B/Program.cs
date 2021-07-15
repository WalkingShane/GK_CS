using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_B
{
    class Complex
    {

        #region Private Fields

        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        double re;

        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        double im;

        #endregion

        #region Public Properties

        public double Re
        {
            get
            {
                return re;
            }
            set
            {
                re = value;
            }
        }

        public double Im
        {
            get
            {
                return im;
            }
            set
            {
                if (value == 0)
                {
                    throw new Exception("Недопустимое значение мнимой части комплексного числа.");
                }

                im = value;
            }
        }

        #endregion


        public Complex()
        {
            re = 5;
            im = 5;
        }

        public Complex(double re, double im)
        {

            if (im == 0)
            {
                throw new Exception("Недопустимое значение мнимой части комплексного числа.");
            }

            this.re = re;
            this.im = im;
        }


        public Complex Plus(Complex other)
        {
            //Complex res = new Complex(re + other.re, im + other.im);
            //return res;

            return new Complex(re + other.re, im + other.im);
        }

        public Complex Minus(Complex other)
        {
            return new Complex(re - other.re, im - other.im);
        }

        public Complex Multiply(Complex other)
        {
            return new Complex(re * other.re - im * other.im, im * other.re + re * other.im);
        }


        public override string ToString()
        {
            if (re == 0 && im == 0)
                return "0";

            if (im == 0)
                return $"{re}";

            if (re == 0)
            {
                if (im > 0) return im != 1 ? $"{im}i" : $"i";
                if (im < 0) return im != -1 ? $"{im}i" : $"-i";
            }

            if (im > 0) return im != 1 ? $"{re} + {im}i" : $"{re} + i";
            else return im != -1 ? $"{re} - {-im}i" : $"{re} - i";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Complex complex01 = new Complex(3, 2);

            Complex complex02 = new Complex(-7, 3);
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("*****************************************************************************************");
                Console.WriteLine($"Даны два комплексных числа {complex01} и {complex02}. Какие действия вы хотите с ними проделать?\nСложить -> нажмите '+'\nВычесть -> нажмите '-'\nУмножить -> нажмите '*'\nДля выхода нажмите любьую другую клавишу.");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Add:
                        Console.WriteLine("\n_________________________________________________________________________________________________");
                        Console.WriteLine($"Сумма комплексных чисел равна {complex01.Plus(complex02)}");
                        Console.WriteLine("Нажмите любую кнопку чтобы продолжить...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.Subtract:
                        Console.WriteLine("\n_________________________________________________________________________________________________");
                        Console.WriteLine($"Разность комплексных чисел равна {complex01.Minus(complex02)}");
                        Console.WriteLine("Нажмите любую кнопку чтобы продолжить...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.Multiply:
                        Console.WriteLine("\n_________________________________________________________________________________________________");
                        Console.WriteLine($"Произведение комплексных чисел равно {complex01.Multiply(complex02)}");
                        Console.WriteLine("Нажмите любую кнопку чтобы продолжить...");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("\nЗавершение работы.");
                        exit = true;
                        break;
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
