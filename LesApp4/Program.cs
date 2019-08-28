using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// спроба автоматичної ініціалізації властивостей структури
// через клас получається
// через структури - ні

namespace LesApp4
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            #region Тестування відображення/(доступу до) координат точок
            // додатково створено керування відображенням властивостей,
            // що визначають n-вимірність
            I2Dim<double> testC = new PointC<double>(1, 2);
            I2Dim<int> testS = new PointS<int>(1, 2);
            // інтерфейс обмежує видимість певних вимірів,
            // що не дає доступ при написанні коду, але видно
            // ці змінні при відладці (отладке) 
            #endregion


            Console.WriteLine("\n\tЗадання точки через class:");
            I4Dim<int> pointC = new PointC<int>(1, 2, 3, 4);
            Console.WriteLine("\n\t" + pointC.ToString());

            Console.WriteLine("\n" + new string('#', 10));

            Console.WriteLine("\n\tЗадання точки через struct:");
            I4Dim<int> pointS = new PointS<int>(5, 6, 7, 8);
            Console.WriteLine("\n\t" + pointS.ToString());

            // delay
            Console.ReadKey();
        }
    }
}
