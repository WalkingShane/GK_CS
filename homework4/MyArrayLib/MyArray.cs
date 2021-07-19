using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyArrayLib
{
    public class MyArray
    {

        private int[] arr;

        public int Sum
        {
            get
            {
                int sum = 0;
                for (int i = 0; i < arr.Length; i++)
                    sum += arr[i];
                return sum;
            }
        }


        public int MaxCount
        {
            get
            {
                int max = arr[0];
                int maxCount = 1;
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] > max)
                    {
                        max = arr[i];
                        maxCount = 1;
                    }
                    else if (arr[i] == max)
                        maxCount++;
                }
                return maxCount;
            }
        }

        public MyArray(int[] arr)
        {
            this.arr = arr;
        }

        /// <summary>
        /// Создает массив заданного размера и заполняет значения его элементов случайными значениями.
        /// </summary>
        /// <param name="count">Размер массива</param>
        public MyArray(int count)
        {
            Random random = new Random();

            arr = new int[count];

            for (int i = 0; i < count; i++)
            {
                arr[i] = random.Next(0, 50);
            }
        }
        /// <summary>
        /// Создает массив заданного размера и заполняет значения его элементов с заданным шагом от заданного начального значения.
        /// </summary>
        /// <param name="size">Размер массива</param>
        /// <param name="startNumber">Начальное значение первого элемента массива</param>
        /// <param name="step">Заданный шаг</param>
        public MyArray(int size, int startNumber, int step)
        {
            arr = new int[size];
            arr[0] = startNumber;
            for (int i = 1; i < size; i++)
                arr[i] = arr[i - 1] + step;
        }

        public void Print()
        {

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}\t");
            }
            Console.WriteLine();
        }

        public int GetElement(int index)
        {
            return arr[index];
        }

        public int this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }

        /// <summary>
        /// Возвращает массив с инфертированными знаками всех элементов.
        /// </summary>
        /// <returns>Массив с инвертированными знаками</returns>
        public MyArray Inverse()
        {
            int[] outputArray = new int[arr.Length];
            for (int i = 0; i < outputArray.Length; i++)
                outputArray[i] = -arr[i];
            return new MyArray(outputArray);
        }

        /// <summary>
        /// Умножает каждый элемент массива на множитель.
        /// </summary>
        /// <param name="multiplier">Множитель</param>
        public void Multi(int multiplier)
        {
            for (int i = 0; i < this.arr.Length; i++)
                this.arr[i] *= multiplier;
        }

    }
}
