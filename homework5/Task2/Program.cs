using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Руслан Островский

namespace Task2
{
//    Разработать статический класс Message, содержащий следующие статические методы для обработки текста:
//      а) Вывести только те слова сообщения, которые содержат не более n букв.
//      б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
//      в) Найти самое длинное слово сообщения.
//      г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
    
    public static class Message
    {
        /// <summary>
        /// Разделители слов, которые могут быть использованы в сообщении.
        /// </summary>
        static char[] delimiters = {' ', ',', ';', '.', '-', '!', '?', ':'};


        /// <summary>
        /// Выводит на экран слова из сообщения, длина которых меньше n.
        /// </summary>
        /// <param name="message">Сообщение для обработки</param>
        /// <param name="n">Величина ограничения длины слов</param>
        public static void ShowWordsLessN(string message, int n)
        {
            string[] words = message.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
            {
                if(words[i].Length <= n)
                Console.WriteLine(words[i]);
            }
        }

        /// <summary>
        /// Удаляет из исходного сообщения слова оканчивающиеся на символ ending.
        /// </summary>
        /// <param name="message">Сообщение для обработки, передается по ссылке</param>
        /// <param name="ending">Заданный символ</param>
        /// <returns></returns>
        public static void DeleteWordsEndChar(ref string message, char ending)
        {
            string pattern = (@"[А-Яа-я]{1,}" + ending + @"\b");
            Regex regex = new Regex(pattern);

            message = regex.Replace(message, "");
        }

        /// <summary>
        /// Находит самое (либо одно из них) длинное слово из сообщения.
        /// </summary>
        /// <param name="message">Сообщение для обработки</param>
        /// <returns>Одно из самых длинных слов</returns>
        public static string FindTheLongestWord(string message)
        {
            List<string> words = new List<string>(message.Split(delimiters, StringSplitOptions.RemoveEmptyEntries));

            int max = 0;
            string longestWord = "";
            foreach (string str in words)
            {
                if (str.Length > max)
                {
                    longestWord = str;
                    max = str.Length;
                }
            }

            return longestWord;
        }
        /// <summary>
        /// Формирует строку, состоящую из самых длинных слов сообщения, с помощью StringBuilder
        /// </summary>
        /// <param name="message">Сообщение для обработки</param>
        /// <returns>Сформированную строку типа StringBuilder</returns>
        public static StringBuilder BuildStringOfTheBiggestWords(string message)
        {
            List<string> words = new List<string>(message.Split(delimiters, StringSplitOptions.RemoveEmptyEntries));

            int max = FindTheLongestWord(message).Length;
            StringBuilder builder = new StringBuilder(max * words.Count);

            foreach (string str in words)
                if (str.Length == max)
                    builder.Append(str);

            return builder;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            string message = "ель повар селедка рыба бумага козел арбуз волк апельсин банан ярь якорь тыква поверье ресторан";
            Console.WriteLine("Дано сообщение:");
            Console.WriteLine(message);
            Console.WriteLine("****************************************************************************\n");

            int n = random.Next(1, 10);
            Console.WriteLine("Вывод слов длиной не больше {0}", n);
            Message.ShowWordsLessN(message, n);
            Console.WriteLine("****************************************************************************\n");

            Console.WriteLine("Самое длинное слово сообщения: " + Message.FindTheLongestWord(message));
            Console.WriteLine("****************************************************************************\n");


            Console.WriteLine("Строка из самых длинных слов сообщения, сформированная с помощью StringBuilder:");
            Console.WriteLine(Message.BuildStringOfTheBiggestWords(message));
            Console.WriteLine("****************************************************************************\n");

            char symbol = (char)random.Next(1072, 1103);
            Console.WriteLine("Удаление слов, оканчивающихся на символ '{0}', из сообщения:", symbol);
            Message.DeleteWordsEndChar(ref message, symbol);
            Console.WriteLine(message);

            Console.ReadKey();
        }
    }
}
