using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sixth
{
    /*В программу вводятся а1, а2, а3, N, E. Строится последовательность чисел ак = ак–1 + 2 * ак-2  * ак–3.
      Программа находит первые ее N элементов, такие что | ак  – ак–1 | > E,
      печатает последовательность, выделяет искомые элементы и их номера.
    */
    class Program
    {
        static double a1, a2, a3;//Первые элементы последовательности
        static int N;//Число N
        static double E;//Число Е
        static int[] NumberList;//Массив, в котором хранятся номера чисел, соответствующих условию
        static int CountNum = 0;//Cчётчик количества элементов в последовательности
        static int count = 0;//Счётчик количества элементов, такие что | ак  – ак–1 | > E
        static double Check()//Проверка вводимых с клавиатуры данных (данные должны быть действительными числами)
        {
            bool ok;
            double n;//искомое число
            do
            {
                ok = double.TryParse(Console.ReadLine(), out n);
                if (!ok) { Console.WriteLine("Ошибка. Неверный формат данных. Повторите ввод."); }

            } while (!ok);//если введённые данные - не число, то новая итерация цикла
            return n;
        }
        static void CreateNewNumber(double a1, double a2, double a3)//Создание нового элемента последовательности (рекурсия)
        {

            double ak = a3 + 2 * a2 * a1;//Новый элемент последовательности ("самый правый")
            CountNum++;

            if (Math.Abs(ak - a3) > E)//Если число соответствует условиям - оно печатается зелёным, а его номер записывается в массив, если нет - то печатается белым цветом
            {
                NumberList[count] = CountNum; count++; Console.Write("-");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(ak); Console.ResetColor();
            }
            else Console.Write("-" + ak);

            if (count < N) CreateNewNumber(a2, a3, ak);//Если количество чисел, соответствующих условию меньше N, то новый этап рекурсии
        }
        static void MainFunction()//Ввод начальных данных и вызов рекурсии
        {
            Console.WriteLine("Введите а1");
            a1 = Check();
            Console.WriteLine("Введите а2");
            a2 = Check();
            Console.WriteLine("Введите а3");
            a3 = Check();

            if (a1 == 0 && a2 == 0 && a3 == 0) { Console.WriteLine("При таких начальных числах в последовательности не будет ни одного числа, удовлетворяющего условию. Попробуйте задать другие данные."); MainFunction(); }

            Console.WriteLine("Введите N");
            //Ввод проверка N (N должно быть больше 0)
            bool ok;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out N);
                if (!ok) { Console.WriteLine("Ошибка. Неверный формат данных. Повторите ввод."); continue; }
                if (N < 1) { Console.WriteLine("Ошибка. Число должно быть больше 0. Повторите ввод."); ok = false; }

            } while (!ok);
            NumberList = new int[N];

            Console.WriteLine("Введите E");
            //Ввод проверка Е (Е должно быть больше или равно 0)
            do
            {
                ok = double.TryParse(Console.ReadLine(), out E);
                if (!ok) { Console.WriteLine("Ошибка. Неверный формат данных. Повторите ввод."); continue; }
                if (E < 0) { Console.WriteLine("Ошибка. Число должно быть больше или равно 0. Повторите ввод."); ok = false; }

            } while (!ok);
            Console.WriteLine();

            //Проверка второго и третьего изначального числа на соответствие условию
            CountNum = 2;
            Console.Write(a1 + "-");
            if (Math.Abs(a2 - a1) > E)
            {
                NumberList[count] = CountNum; count++;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(a2); Console.ResetColor();
            }
            else { Console.Write(a2); }

            CountNum++;
            Console.Write("-");
            if (Math.Abs(a3 - a2) > E)
            {
                NumberList[count] = CountNum; count++;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write(a3); Console.ResetColor();
            }
            else { Console.Write(a3); }

            if (count<N)
            CreateNewNumber(a1, a2, a3);//Вывоз рекурсии

            //Вывод номеров выделенных чисел
            Console.WriteLine("\n\nНомера чисел, которые соответствуют условию: | ак  – ак–1 | > {0}",E);
            for (int i = 0; i < NumberList.Length-1; i++)
            {
                Console.Write(NumberList[i] + ", ");
            }
            Console.Write(NumberList[NumberList.Length-1]);
        }
        static void Main(string[] args)
        {
            MainFunction();
            Console.ReadLine();
        }

    }
}
