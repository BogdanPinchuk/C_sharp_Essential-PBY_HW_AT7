using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створення набору тестових трикутників
            Triangle[] triangles = new Triangle[]
            {
                new Triangle(1, 2, 3),
                new Triangle(2, 4, 5),
                new Triangle(4, 4, 5),
                new Triangle(3, 3, 3),
                new Triangle(3, 4, 5)
            };

            // вивід даних
            for (int i = 0; i < triangles.Length; i++)
            {
                Console.WriteLine(triangles[i].ToString());
            }

            // delay
            Console.ReadKey(true);
        }
    }
}
