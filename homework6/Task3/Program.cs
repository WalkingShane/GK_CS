using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Руслан Островский

namespace Task3
{
    //    Переделать программу Пример использования коллекций для решения следующих задач:
    //      а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
    //      б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив);
    //      в) отсортировать список по возрасту студента;
    //      г) * отсортировать список по курсу и возрасту студента;
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;
        // Создаем конструктор
        public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }

        public override string ToString()
        {
            return $"|{lastName, -15}|{firstName, -10}|{university, -10}|{faculty, -15}|{department, -20}|{course, -5}|{age, -5}|{group, -3}|{city, 15}|";
        }
    }

    class Program
    {

        public static bool ReadStudentsDataFromFile(string fileName, out List<Student> list)
        {
            list = new List<Student>();                             // Создаем список студентов
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("При считывании файла возникла ошибка.");
                    return false;
                }
            }
            sr.Close();
            return true;
        }
        static int NameSort(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
        {

            return String.Compare(st1.firstName, st2.firstName);          // Сравниваем две строки
        }

        static int AgeSort(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
        {

            return st1.age - st2.age;          // Сравниваем две числа
        }

        static void Main(string[] args)
        {
            List<Student> list;                             
            DateTime dt = DateTime.Now;

            if (ReadStudentsDataFromFile("students.csv", out list))
            {
                int seniorMen = 0;
                Dictionary<int, int> numberCourseStudents = new Dictionary<int, int>();

                list.Sort(new Comparison<Student>(AgeSort));
                Console.WriteLine("Всего студентов: " + list.Count);

                foreach (var v in list)
                {
                    Console.WriteLine(v);
                    if (v.course == 5 || v.course == 6) seniorMen++;
                    if (v.age < 21 && v.age > 17)
                        if (numberCourseStudents.ContainsKey(v.course))
                            numberCourseStudents[v.course]++;
                        else numberCourseStudents.Add(v.course, 1);
                }
                Console.WriteLine();
                Console.WriteLine("Количество студентов на 5 и 6 курсах равно {0}", seniorMen);
                Console.WriteLine("Количество студентов от 18 до 20 лет на курсах:");
                foreach (var v in numberCourseStudents)
                    Console.WriteLine($"На {v.Key} курсе - {v.Value} студент(а).");
            }

            Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();
        }
    }

}
