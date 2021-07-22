using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Руслан Островский

namespace Task1
{
    //    Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов,
    //    содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
    //      а) без использования регулярных выражений;
    //      б) ** с использованием регулярных выражений.
    class Program
    {
        /// <summary>
        /// Проверяет строку на соответствие: количество и тип символов.
        /// </summary>
        /// <param name="login">Строка для проверки</param>
        /// <returns></returns>
        public static bool CheckLogin(string login)
        {
            if (login.Length >= 2 && login.Length <= 10)
            {
                for (int i = 0; i < login.Length; i++)
                    if (!(login[i] >= 65 && login[i] <= 90 || login[i] >= 97 && login[i] <= 122 || login[i] >= 48 && login[i] <= 57))
                        return false;
            }
            else return false;
            return true;
        }

        /// <summary>
        /// Проверяет строку на соответствие шаблону, заданному регулярным выражением.
        /// </summary>
        /// <param name="login">Строка для проверки</param>
        /// <param name="pattern">Шаблон регулярного выражения</param>
        /// <returns></returns>
        public static bool CheckLoginRegular(string login, string pattern)
        {
            Regex regex = new Regex(pattern);
            if (regex.IsMatch(login))
                return true;
            else return false;
        }

        static void Main(string[] args)
        {
            string login;

            Console.WriteLine("Введите логин: ");
            login = Console.ReadLine();

            Console.WriteLine("Проверка без помощи регулярных выражений.");
            if (CheckLogin(login))
                Console.WriteLine("Логин принят.");
            else Console.WriteLine("Логин не соответствует требованиям.");

            string pattern = @"^[A-Za-z0-9]{2,10}$";

            Console.WriteLine("Введите логин: ");
            login = Console.ReadLine();
            Console.WriteLine("Проверка с помощью регулярного выражения.");
            if (CheckLoginRegular(login, pattern))
                Console.WriteLine("Логин принят.");
            else Console.WriteLine("Логин не соответствует требованиям.");

            Console.ReadKey();
        }
    }
}
