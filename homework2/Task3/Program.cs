using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
 //   Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
 //   Предусмотреть методы сложения, вычитания, умножения и деления дробей.
 //   Написать программу, демонстрирующую все разработанные элементы класса.
 //   Добавить свойства типа int для доступа к числителю и знаменателю;
 //   Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
 //   ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
 //   *** Добавить упрощение дробей.

    class Fraction
    {
        /// <summary>
        /// Числитель дробного числа
        /// </summary>
        private int numerator;

        /// <summary>
        /// Знаменатель дробного числа
        /// </summary>
        private int denominator;
        
        public int Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public int Denominator
        {
            get { return denominator; }
            set 
            {
                if (value != 0)
                    denominator = value;
                else throw new ArgumentException(nameof(value), "Знаменатель не может быть равен 0.");
            }
        }
        /// <summary>
        /// Стандартный конструктор дробного числа.
        /// </summary>
        /// <param name="numerator">Числитель</param>
        /// <param name="denominator">Знаменатель</param>
        public Fraction(int numerator, int denominator)
        {
            if (denominator != 0)
            {
                this.numerator = numerator;
                this.denominator = denominator;
            }
            else throw new ArgumentException(nameof(denominator), "Знаменатель не может быть равен 0.");
        }

        public Fraction(int intNumber)
        {
            numerator = intNumber;
            denominator = 1;
        }

        public Fraction() {        }

        public static Fraction operator +(Fraction number)
        {
            return number;
        }

        public static Fraction operator -(Fraction number)
        {
            return new Fraction(-number.numerator, number.denominator);
        }

        public static Fraction operator +(Fraction number1, Fraction number2)
        {
            return new Fraction(number1.numerator * number2.denominator + number2.numerator * number1.denominator, number1.denominator * number2.denominator);
        }

        public static Fraction operator -(Fraction number1, Fraction number2)
        {
            return number1 + (-number2);
        }

        public static Fraction operator *(Fraction number1, Fraction number2)
        {
            return new Fraction(number1.numerator * number2.numerator, number1.denominator * number2.denominator);
        }

        public static Fraction operator /(Fraction number1, Fraction number2)
        {
            if (number2.denominator != 0)
                return number1 * (new Fraction(number2.denominator, number2.numerator));
            else
                throw new DivideByZeroException();
        }

        public static explicit operator Fraction(int intNumber)
        {
            return new Fraction(intNumber);
        }

        public Fraction Simplify()
        {
            if (denominator < 0)
            {
                numerator *= -1;
                denominator *= -1;
            }
            
            for (int i = 2; i <= (Math.Abs(numerator) <= Math.Abs(denominator) ? Math.Abs(numerator) : Math.Abs(denominator)); i++)
            {
                if (numerator % i == 0 && denominator % i == 0)
                {
                    numerator /= i;
                    denominator /= i;
                    i--;
                }
            }
            
            return this;
        }

        public override string ToString()
        {
            return $"[{numerator} / {denominator}]";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Fraction(5, 4);
            var b = new Fraction(1, 2);
            var c = new Fraction(10);

            var d = new Fraction();
            d.Numerator = 20;
            d.Denominator = 3;

            Console.WriteLine($"-{a} = {-a}");
            Console.WriteLine($"{a} + {b} = {a + b}");
            Console.WriteLine($"{a} - {b} = {a - b}");
            Console.WriteLine($"{a} * {b} = {a * b}");
            Console.WriteLine($"{a} / {b} = {a / b}");

            Console.WriteLine("******************************************************************************************");
            Console.WriteLine($"-{c} = {-c}");
            Console.WriteLine($"{a} + {c} = {a + c}");
            Console.WriteLine($"{a} - {c} = {a - c}");
            Console.WriteLine($"{a} * {c} = {a * c}");
            Console.WriteLine($"{a} / {c} = {a / c}");

            Console.WriteLine("******************************************************************************************");
            Console.WriteLine($"-{d} = {-d}");
            Console.WriteLine($"{b} + {d} = {b + d}");
            Console.WriteLine($"{b} - {d} = {b - d}");
            Console.WriteLine($"{d} * {d} = {b * d}");
            Console.WriteLine($"{b} / {d} = {b / d}");

            Console.WriteLine("******************************************************************************************");
            Console.WriteLine($"{a} + 6 = {a + (Fraction)6}");
            Console.WriteLine($"{b} - 4 = {b - (Fraction)4}");
            Console.WriteLine($"{c} * 2 = {c * (Fraction)2}");
            Console.WriteLine($"{d} / 10 = {d / (Fraction)10}");

            var e = new Fraction(5, 10);
            var f = new Fraction(27, -9);
            var g = new Fraction(16, 64);
            Console.WriteLine("**************************Упрощение дробей************************************************");
            Console.Write($"{e} = "); Console.WriteLine(e.Simplify());
            Console.Write($"{f} = "); Console.WriteLine(f.Simplify());
            Console.Write($"{g} = "); Console.WriteLine(g.Simplify());

            Console.ReadKey();
        }
    }
}
