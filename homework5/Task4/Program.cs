using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    //    * Задача ЕГЭ.
    //      На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
    //      В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:

    //          <Фамилия> <Имя> <оценки>,
    //              где<Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не более чем из 15 символов,
    //              <оценки> — через пробел три целых числа, соответствующие оценкам по пятибалльной системе.
    //              <Фамилия> и<Имя>, а также<Имя> и<оценки> разделены одним пробелом.

    //      Пример входной строки:
    //          Иванов Петр 4 5 3
    //      Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трёх худших по среднему баллу учеников.
    //      Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.

    /// <summary>
    /// Структурированные данные ученика по результатам экзаменов
    /// </summary>
    public struct PupilGPA
    {
        private string surname;
        private string name;
        private int point1, point2, point3;

        public string Surname { get { return surname; } }
        public string Name { get { return name; } }

        public double GPA
        {
            get { return (double)(point1 + point2 + point3) / 3; }
        }

        /// <summary>
        /// Конструтор обрабатывает строку из файла, отформатированную по образцу из задания.
        /// </summary>
        /// <param name="line"></param>
        public PupilGPA(string line)
        {
            string[] substrings = line.Split(' ');
            surname = substrings[0];
            name = substrings[1];
            point1 = int.Parse(substrings[2]);
            point2 = int.Parse(substrings[3]);
            point3 = int.Parse(substrings[4]);
        }

        public override string ToString()
        {
            return $"{surname} {name} {GPA : 0.00}";
        }
    }
    class Program
    {
        private static Random random = new Random();
        private static string surnamesInputFile = AppDomain.CurrentDomain.BaseDirectory + "RusSurnames.txt";
        private static string namesInputFile = AppDomain.CurrentDomain.BaseDirectory + "MaleNames.txt";

        /// <summary>
        /// Генерирует рандомный список для задания.
        /// </summary>
        /// <param name="outputFileName">Имя файла для записи рандомного списка</param>
        static void GenerateRandomList(string outputFileName)
        {
            int n = random.Next(10, 101);

            #region Выгрузка имен из файла namesInputFile
            List<string> namesList = new List<string>();
            StreamReader streamReader = new StreamReader(namesInputFile);
            while (!streamReader.EndOfStream)
                namesList.Add(streamReader.ReadLine());
            streamReader.Close();
            #endregion

            #region Выгрузка фамилий из файла surnamesInputFile
            List<string> surnamesList = new List<string>();
            streamReader = new StreamReader(surnamesInputFile);
            while (!streamReader.EndOfStream)
                surnamesList.Add(streamReader.ReadLine());
            streamReader.Close();
            #endregion

            StreamWriter streamWriter = new StreamWriter(outputFileName);
            streamWriter.Write(n);
            for (int i = 0; i < n; i++)
            {
                streamWriter.WriteLine();
                streamWriter.Write("{0} {1} {2} {3} {4}", surnamesList[random.Next(surnamesList.Count)], namesList[random.Next(namesList.Count)], random.Next(1, 6), random.Next(1, 6), random.Next(1, 6));
            }

            streamWriter.Close();
        }

        static PupilGPA[] ReadListFromFile(string inputFileName)
        {
            StreamReader streamReader = new StreamReader(inputFileName);

            int n = int.Parse(streamReader.ReadLine());
            PupilGPA[] list = new PupilGPA[n];
            for (int i = 0; i < n; i++)
                list[i] = new PupilGPA(streamReader.ReadLine());

            return list;
        }

        static void SortPupils(ref PupilGPA[] pupils)
        {
            for (int i = 0; i < pupils.Length; i++)
            {
                for (int j = i; j < pupils.Length; j++)
                    if (pupils[j].GPA < pupils[i].GPA)
                    {
                        PupilGPA buff = pupils[i];
                        pupils[i] = pupils[j];
                        pupils[j] = buff;
                    }
            }
        }

        static void ShowTheWorst(PupilGPA[] pupils)
        {
            SortPupils(ref pupils);
            int k = 3;
            int i = 0;
            while (k > 0 && i < pupils.Length)
            {
                Console.WriteLine(pupils[i]);
                if (pupils[i].GPA != pupils[i + 1].GPA)
                    k--;
                i++;
            }
        }

        static void Main(string[] args)
        {
            string fileName = "list.txt";

            GenerateRandomList(fileName);

            PupilGPA[] pupils = ReadListFromFile(fileName);

            foreach (PupilGPA pupil in pupils)
            {
                Console.WriteLine(pupil);
            }

            SortPupils(ref pupils);
            Console.WriteLine(("").PadRight(50, '/'));

            foreach (PupilGPA pupil in pupils)
            {
                Console.WriteLine(pupil);
            }

            Console.WriteLine(("").PadRight(50, '/'));
            Console.WriteLine("Худшие ученики (3 самых худших средних балла):");

            ShowTheWorst(pupils);

            Console.ReadKey();
        }
    }
}
