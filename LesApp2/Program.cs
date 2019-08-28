using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// ручна реалізація ініціалізації властивостей структури

namespace LesApp2
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            #region help
            // додатково створено керування відображенням властивостей,
            // що визначають n-вимірність
            I2Dim<double> pointC = new PointC<double>(1, 2);
            I2Dim<int> pointS = new PointS<int>(1, 2);
            // інтерфейс обмежує видимість певних вимірів,
            // що не дає доступ при написанні коду, але видно
            // ці змінні при відладці (отладке)
            #endregion

            // випадкові числа
            Random rnd = new Random();

            // створення фігури
            Figure figure = new Figure();

            Console.WriteLine("До створення точок:");

            Console.WriteLine(figure.ToString());

            Console.WriteLine("\nДодавання точок:");
                       
            // задання координат і виведення назви фігури
            for (int i = 0; i < 7; i++)
            {
                figure.Add(new Point(rnd.NextDouble(), rnd.NextDouble()));
                Console.WriteLine(figure.ToString());
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + new string('#', 80));
            Console.ResetColor();

            Console.WriteLine("\nВидалення точок:");

            for (int i = 5; i >= -1; i--)
            {
                figure.Remove(i);
                Console.WriteLine(figure.ToString());
            }

            // delay
            Console.ReadKey();
        }
    }
}
