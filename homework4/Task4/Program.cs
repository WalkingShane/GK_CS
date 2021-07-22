using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Руслан Островский

namespace Task4
{
    //Решить задачу с логинами из урока 2, только логины и пароли считать из файла в массив. Создайте структуру Account, содержащую Login и Password.
    //Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль.
    //На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains).
    //Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает.
    //С помощью цикла do while ограничить ввод пароля тремя попытками.

    public struct Account
    {
        private string login;
        private string password;

        public Account(string lgn, string pswd)
        {
            login = lgn;
            password = pswd;
        }

        public string Login
        {
            get
            {
                return login;
            }

        }
        public string Password
        {
            get
            {
                return password;
            }
        }


    }

    class Program
    {
        public static Account[] ReadAccountsFromFile(string fileName)
        {
            string[] lines = new string[100];
            int n = 0;
            if (File.Exists(fileName))
            {
                StreamReader streamReader = new StreamReader(fileName);
                while (!streamReader.EndOfStream)
                {
                    lines[n] = streamReader.ReadLine();
                    n++;
                }
            }
            else throw new FileNotFoundException($"Не найден файл '{fileName}'.");

            Account[] accounts = new Account[n / 2];

            for (int i = 0; i < n; i += 2)
            {
                accounts[i / 2] = new Account(lines[i], lines[i + 1]);
            }

            return accounts;
        }

        public static bool Authorization(Account[] accounts)
        {
            int tries = 3;
            string lgnTry, pswdTry;
            Console.WriteLine("Необходимо пройти авторизацию в системе.");
            while (tries > 0)
            {
                Console.WriteLine("Количество оставшихся попыток - {0}.", tries);
                Console.Write("Введите логин:");
                lgnTry = Console.ReadLine();
                Console.Write("\nВведите пароль:");
                pswdTry = Console.ReadLine();

                for (int i = 0; i < accounts.Length; i++)
                    if (lgnTry == accounts[i].Login && pswdTry == accounts[i].Password)
                    {
                        Console.WriteLine("Доступ разрешен.");
                        return true;
                    }

                tries--;
                Console.WriteLine("Логин и/или пароль введены неправильно.");

            }
            Console.WriteLine("Доступ запрещен.");

            return false;
        }

        static void Main(string[] args)
        {
            string fileName = AppDomain.CurrentDomain.BaseDirectory + "accounts.txt";

            Account[] accounts = ReadAccountsFromFile(fileName);


            if (Authorization(accounts))
            {
                Console.WriteLine("Добро пожаловать.");
            }
            else Console.WriteLine("Выход.");


            Console.ReadKey();
        }
    }
}
