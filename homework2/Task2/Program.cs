using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            int number;
            Console.WriteLine("Вводите числа, для окончания введите 0. После этого выведется сумма всех введенных нечетных положительных чисел.");
            do
            {
                if (int.TryParse(Console.ReadLine(), out number) && number > 0 && number % 2 != 0)
                    sum += number;
            }
            while (number != 0);
            Console.WriteLine($"Сумма введенных нечетных положительных чисел равна {sum}.");

            Console.ReadKey();
        }
        
    }
}
