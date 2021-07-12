using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    //Руслан Островский
    class Program
    {
        /// <summary>
        /// Находит минимум из трех чисел
        /// </summary>
        /// <param name="number1"></param>
        /// <param name="number2"></param>
        /// <param name="number3"></param>
        /// <returns></returns>
        private static int FindTheMinNumber(int number1, int number2, int number3)
        {
            if (number1 <= number2 && number1 <= number3)
                return number1;
            else if (number2 <= number1 && number2 <= number3)
                return number2;
            else return number3;
        }

        /// <summary>
        /// Считает количество цифр в числе
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static int CountNumberOfDigits(int number)
        {
            int digits = 1;
            while (number / 10 != 0)
            {
                digits++;
                number /= 10;
            }
            return digits;
        }
        /// <summary>
        /// Возвращает true, если login и password верные.
        /// </summary>
        /// <param name="login">Логин для авторизации</param>
        /// <param name="password">Пароль для авторизации</param>
        /// <returns></returns>
        private static bool IsAuthorizationCorrect(string login, string password)
        {
            if (login == "root" && password == "GeekBrains")
                return true;
            else return false;
        }

        private static int CountSumOfDigits(int number)
        {
            int sumOfDigits = 0;
            do
            {
                sumOfDigits += number % 10;
                number /= 10;
            }
            while (number != 0);
            return sumOfDigits;
        }
        static void Main(string[] args)
        {
            Random random = new Random();

            #region Task1
            //Написать метод, возвращающий минимальное из трёх чисел.

            int a = random.Next(-100, 100);
            int b = random.Next(-100, 100);
            int c = random.Next(-100, 100);

            Console.WriteLine("Даны 3 числа: {0}, {1}, {2}\nМинимальное среди них: {3}", a, b, c, FindTheMinNumber(a, b, c));

            Console.ReadKey();
            #endregion

            #region Task2
            //Написать метод подсчета количества цифр числа.
            Console.WriteLine("\n**************************************************************************");

            int d = random.Next(int.MinValue, int.MaxValue);

            Console.WriteLine("Дано число: {0}\nКоличество цифр в числе: {1}", d, CountNumberOfDigits(d));

            Console.ReadKey();
            #endregion

            #region Task3
            //С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел.
            Console.WriteLine("\n**************************************************************************");

            Console.WriteLine("Вводите целые числа, для вывода суммы всех ранее введенных нечетных положительных чисел - введите 0");

            int readNumber;
            int sumOfCorrectNumbers = 0; 
            do
            {
                if (int.TryParse(Console.ReadLine(), out readNumber) && readNumber > 0 && readNumber % 2 == 1)
                    sumOfCorrectNumbers += readNumber;
            }
            while (readNumber != 0);

            Console.WriteLine("Сумма = " + sumOfCorrectNumbers);

            Console.ReadKey();
            #endregion

            #region Task4
            //Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль.
            //На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains).
            //Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
            //С помощью цикла do while ограничить ввод пароля тремя попытками.
            Console.WriteLine("\n**************************************************************************");

            string loginTry;
            string passwordTry;
            int numberOfTries = 3;
            Console.WriteLine("Для дальнейших действий вам необходимо пройти авторизацию.");
            do
            {
                Console.Write("Введите логин: ");
                loginTry = Console.ReadLine();
                Console.Write("Введите пароль: ");
                passwordTry = Console.ReadLine();
                numberOfTries--;
                if (IsAuthorizationCorrect(loginTry, passwordTry))
                {
                    Console.WriteLine("Доступ разрешен.");
                    break;
                }
                else
                    Console.WriteLine("Неверно введены логин или пароль. Количество оставшихся попыток: {0}.", numberOfTries);
            }
            while (numberOfTries > 0);

            Console.ReadKey();
            #endregion

            #region Task5
            //а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или всё в норме.
            //б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса.
            Console.WriteLine("\n**************************************************************************");

            Console.Write("Введите ваш вес (кг): ");
            double weight = Double.Parse(Console.ReadLine());
            Console.Write("Введите ваш рост (см): ");
            double height = Double.Parse(Console.ReadLine());
            double imt = weight / (height * height / 10000);
            if (imt <  18.5)
                Console.WriteLine("Ваш индекс массы тела равен {0: 0.00}, это ниже нормы. Вам необходимо набрать {1: 0.00кг}", imt, 18.5 * (height * height / 10000) - weight);
            else if (imt > 25)
                Console.WriteLine("Ваш индекс массы тела равен {0: 0.00}, это выше нормы. Вам необходимо сбросить {1: 0.00кг}", imt, weight - 25 * (height * height / 10000));
            else
                Console.WriteLine("Ваш индекс массы тела равен {0: 0.00}, в пределах нормы. Так держать!", imt);

            Console.ReadKey();
            #endregion

            #region Task6
            //*Написать программу подсчета количества «хороших» чисел в диапазоне от 1 до 1 000 000 000.
            //«Хорошим» называется число, которое делится на сумму своих цифр.
            //Реализовать подсчёт времени выполнения программы, используя структуру DateTime.
            Console.WriteLine("\n**************************************************************************");

            int numberOfGoodNumbers = 0;
            DateTime beginTime = DateTime.Now;
            for (int i = 1; i <= 1000000000; i++)
            {
                if (i % CountSumOfDigits(i) == 0)
                {
                    numberOfGoodNumbers++;
                }
            }
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Хороших чисел в заданном диапазоне: {0}.", numberOfGoodNumbers);
            Console.WriteLine("Время выполнения подсчета: {0}мс", (endTime - beginTime).TotalMilliseconds);

            Console.ReadKey();
            #endregion
        }
    }
}
