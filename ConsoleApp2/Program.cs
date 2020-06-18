using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\test\test.txt";      //путь к исходному файлу
            string writePath = @"C:\test\res.txt";  //путь к результирующему файлу
            int[] numarray = new int[10];             //массив значений
            int len = 0;                            //длинна массива
            int required_weight = 0;                //искомый вес
            int res = 0;                            //результирующий индекс

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
            {
                int i = 0;
                string firstline;
                string line;
                if ((firstline = sr.ReadLine()) != null)    //считываем первую строку
                {
                    string[] words = firstline.Split(' ');
                    required_weight = int.Parse(words[0]);  //вытаскиваем из первой строки искомый вес
                    len = int.Parse(words[1]);              //вытаскиваем из первой строки длинну
                    numarray = new int[len];                //инициализируем массив
                    while ((line = sr.ReadLine()) != null)
                    {
                        numarray[i] = int.Parse(line);      //запись чисел в массив
                        i++;
                    }
                }
            }
            if (len == 0) res = -1;
            else
            {
                res = BinarySearch(numarray, required_weight, 0, len);//поиск за минимальное кол-во взешиваний
            }
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    sw.WriteLine(res + 1);                  //вывод результата в текстовый файл
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //стандартный бинарный поиск
        static int BinarySearch(int[] array, int searchedValue, int first, int last)
        {
            if (first > last)
            {
                return -1;
            }
            int middle = (first + last) / 2;
            int middleValue = array[middle];
            if (middleValue == searchedValue)
            {
                return middle;
            }
            else
            {
                if (middleValue > searchedValue)
                {
                    return BinarySearch(array, searchedValue, first, middle - 1);
                }
                else
                {
                    return BinarySearch(array, searchedValue, middle + 1, last);
                }
            }
        }
    }
}
