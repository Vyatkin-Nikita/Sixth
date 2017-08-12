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
        static int a1, a2, a3;//Первые элементы последовательности
        static int N;//Число N
        static int E;//Число Е
        static int count = 0;//Счётчик количества элементов, такие что | ак  – ак–1 | > E
        static int VvodProverka(int mogr = 0, int bogr = 0)//Проверка вводимых с клавиатуры чисел, mogr и bogr - минимально и максимально возможные значения числа
        {
            bool ok;
            int n;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok) { Console.WriteLine("Ошибка. Неверный формат данных. Повторите ввод."); continue; }
                if ((n < mogr) && (bogr < mogr)) { Console.WriteLine("Ошибка. Число должно быть больше или равно {0} . Повторите ввод.", mogr); ok = false; continue; }
                if ((n < mogr) && (mogr != 0) || ((n > bogr) && (bogr != 0))) { Console.WriteLine("Ошибка. Число должно находится в пределах от {0} до {1} . Повторите ввод.", mogr, bogr); ok = false; }

            } while (!ok);
            Console.WriteLine();
            return n;
        }
        static void CreateNewNumber(int a1, int a2, int a3)
        {
            int ak = a3 + 2 * a2 * a1;

            if (Math.Abs(ak - a3) > E) { count++; Console.Write("-"); Console.ForegroundColor = ConsoleColor.DarkGreen; Console.Write(ak); Console.ResetColor(); }
            else Console.Write("-"+ak);

            if (count < N) CreateNewNumber(a2, a3, ak);
        }
        static void MainFunction()
        {
            a1 = 0;
            a2 = 0;
            a3 = 0;
            N = 5;
            E = 3;

            Console.Write(a1+"-");
            if (Math.Abs(a2 - a1) > E) { count++; Console.ForegroundColor = ConsoleColor.DarkGreen; Console.Write(a2); Console.ResetColor(); }
            else { Console.Write(a2);}
            Console.Write("-");
            if (Math.Abs(a3 - a2) > E) { count++; Console.ForegroundColor = ConsoleColor.DarkGreen; Console.Write(a3); Console.ResetColor(); }
            else { Console.Write(a3); }

            CreateNewNumber(a1, a2, a3);
        } 
        static void Main(string[] args)
        {
            MainFunction();
            Console.ReadLine();
        }

    }
}
