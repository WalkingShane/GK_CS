using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1_A
{
    struct Complex
    {
        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        public double re;

        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        public double im;


        public Complex Plus(Complex other)
        {
            Complex res;

            res.re = re + other.re;
            res.im = im + other.im;

            return res;

        }

        public Complex Minus(Complex other)
        {
            Complex res;

            res.re = re - other.re;
            res.im = im - other.im;

            return res;
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
            
            if (im > 0) return im != 1 ? $"{re} + {im}i" : $"{re} + i" ;
            else return im != -1 ? $"{re} - {-im}i" : $"{re} - i";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Complex complex01;
            complex01.re = 3;
            complex01.im = 2;

            Complex complex02;
            complex02.re = 3;
            complex02.im = 2;

            Console.WriteLine($"Сумма комплексных чисел {complex01} и {complex02} равна {complex01.Plus(complex02)}");
            Console.WriteLine($"Разность комплексных чисел {complex01} и {complex02} равна {complex01.Minus(complex02)}");

            Console.ReadKey();
        }
    }
}
