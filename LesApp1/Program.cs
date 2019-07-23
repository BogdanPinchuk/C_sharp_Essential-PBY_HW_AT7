using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

// Зішлемося на попередню реалізацію
// 4 тема стартовий курс, 5 завдання додаткове про трикутники

namespace LesApp1
{
    class Program
    {
        static void Main()
        {
            // Enable Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створення набору тестових трикутників
            TriangleData[] triangles = new TriangleData[]
            {
                GetTriangle(1, 2, 3),
                GetTriangle(2, 4, 5),
                GetTriangle(4, 4, 5),
                GetTriangle(3, 3, 3),
                GetTriangle(3, 4, 5),
                GetTriangle(4, 4, 4 * Math.Sqrt(2))
            };

            // вивід даних
            for (int i = 0; i < triangles.Length; i++)
            {
                Show(triangles[i]);
            }

            // delay
            Console.ReadKey(true);

            // локальна функція
            void Show(TriangleData triangle)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(triangle.ToString());
                Console.ResetColor();
                triangle.ShowInfo();
            }
        }

        /// <summary>
        /// Створення екземпляра трикутника
        /// </summary>
        /// <param name="a">AB - сторона</param>
        /// <param name="b">BС - сторона</param>
        /// <param name="c">СA - сторона</param>
        /// <returns></returns>
        private static TriangleData GetTriangle(double a, double b, double c)
        {
            return new TriangleData(a, b, c);
        }

        /// <summary>
        /// Дані трикутника (вложена структура)
        /// </summary>
        struct TriangleData
        {
            /// <summary>
            /// Сторона трикутника AB
            /// </summary>
            public double AB { get; set; }
            /// <summary>
            /// Сторона трикутника BC
            /// </summary>
            public double BC { get; set; }
            /// <summary>
            /// Сторона трикутника CA
            /// </summary>
            public double CA { get; set; }
            /// <summary>
            /// Перевірка чи дана фігура є трикуником
            /// </summary>
            public bool IsTriangle { get { return IsTriangles(); } }
            /// <summary>
            ///  Перевірка чи трикутник є правильним/рівностороннім
            /// </summary>
            public bool IsEquilateralTriangle { get { return IsEquilateralTriangles(); } }
            /// <summary>
            /// Перевірка чи трикутник є рівнобедреним
            /// </summary>
            public bool IsIsoscelesTriangle { get { return IsIsoscelesTriangles(); } }
            /// <summary>
            /// Перевірка чи трикутник є прямокутним
            /// </summary>
            public bool IsRightTriangle { get { return IsRightTriangles(); } }

            /// <summary>
            /// Максимальна сторона трикутника
            /// </summary>
            private double MaxSide { get { return Math.Max(Math.Max(AB, BC), CA); } }

            public TriangleData(double a, double b, double c)
            {
                AB = a;
                BC = b;
                CA = c;

                //if (!IsTriangles())
                //{
                //    Console.WriteLine("\n\tЗадана фігура не є трикутником.");
                //}
            }

            /// <summary>
            /// Збереження даних (щоб не перестворювати новий екземпляр)
            /// </summary>
            /// <param name="a">AB - сторона</param>
            /// <param name="b">BС - сторона</param>
            /// <param name="c">СA - сторона</param>
            public void ChangeData(double a, double b, double c)
            {
                AB = a;
                BC = b;
                CA = c;

                //if (!IsTriangles())
                //{
                //    Console.WriteLine("\n\tЗадана фігура не є трикутником.");
                //}
            }

            /// <summary>
            /// Периметр трикутника
            /// </summary>
            public double Perimeter
            {
                get { return PerimeterOfTriangle(); }
            }
            /// <summary>
            /// Площа трикутника
            /// </summary>
            public double Square
            {
                get { return SquareOfTriangle(); }
            }

            /// <summary>
            /// Перевірка чи фігура є трикутником
            /// </summary>
            /// <returns></returns>
            private bool IsTriangles()
            {
                // перш за все перевіряємо сторони,
                // сторони не можуть бути <= 0
                if (AB <= 0 || BC <= 0 || CA <= 0)
                {
                    return false;
                }

                // якщо максимальна із сторін менша від
                // суми двох інших то ця фігура є трикутником
                // щоб не робити велику кількість перевірок
                // простіше вивести формулу
                // P - периметр трикутника 
                // S - сума всіх сторін
                // S = AB + BC + CA
                // припустимо, що AB - є максимальною стороною
                // тоді згідно овизначення
                // AB < BC + CA
                // 2 * AB < AB + BC + CA
                // 2 * AB < P
                // припустивши, що P = S, що сума всіх сторін це периметр
                // 2 * max(AB, BC, CA) < S
                // max(AB, BC, CA) < 0.5 * S - (також помітний так званий півпериметр)

                // інший підхід з іншою формулою
#if true
                if (MaxSide < 0.5 * PerimeterOfTriangle())
                {
                    return true;
                }
                else
                {
                    return false;
                }
#endif
                #region Previous Variant
#if false
                if (SquareOfTriangle() / MaxSide - 1 <= 1)
                {
                    return false;
                }
                else
                {
                    return true;
                } 
#endif
                #endregion

            }

            /// <summary>
            /// Перевірка чи трикутник є правильним/рівностороннім
            /// </summary>
            /// <returns></returns>
            private bool IsEquilateralTriangles()
            {
                // якщо суму всіх сторін поділити на максимальну сторону
                // то в результаті, якщо трикутник правильний/рівносторонній
                // то ми повинні отримати "3"
                if (PerimeterOfTriangle() / MaxSide == 3)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            /// <summary>
            /// Перевірка чи трикутник є рівнобедреним
            /// </summary>
            /// <returns></returns>
            private bool IsIsoscelesTriangles()
            {
                // якщо будь які 2-і із 3-х сторін трикутника рівні,
                // то трикутник є  рівнобедреним
                if ((AB == BC) || (AB == CA))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Перевірка чи трикутник є прямокутним
            /// </summary>
            /// <returns></returns>
            private bool IsRightTriangles()
            {
                // необхідно скористатися теоремою Піфагора
                // AB^2 = BC^2 + CA^2 якщо вважати сторону AB - гіпотенузою
                // де максимальна сторона є гіпотенузою
                // необхідно привести до типу float так як виникають проблеми із точністю
                if ((float)((AB * AB + BC * BC + CA * CA) / (MaxSide * MaxSide)) == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            /// <summary>
            /// Периметр трикутника
            /// </summary>
            /// <returns></returns>
            private double PerimeterOfTriangle()
            {
                return AB + BC + CA;
            }
            /// <summary>
            /// Площа трикутника
            /// </summary>
            /// <returns></returns>
            private double SquareOfTriangle()
            {
                // півпериметр
                double pp = PerimeterOfTriangle() / 2;

                return Math.Sqrt(pp * (pp - AB) * (pp - BC) * (pp - CA));
            }

            public override string ToString()
            {
                return new StringBuilder()
                .Append("\n\tВведені дані для трикутника:\n\n")
                .Append($"\t\tAB = {AB}\n")
                .Append($"\t\tBC = {BC}\n")
                .Append($"\t\tCA = {CA}\n")
                .ToString();
            }

            /// <summary>
            /// Аналіз трикутника
            /// </summary>
            public void ShowInfo()
            {
                Console.Write("Чи є дана фігура трикутником: ");
                Console.WriteLine(IsTriangle);

                Console.Write("Чи трикутник є рівнобедреним: ");
                Console.WriteLine(IsIsoscelesTriangle);

                Console.Write("Чи трикутник є правильним/рівностороннім: ");
                Console.WriteLine(IsEquilateralTriangle);

                Console.Write("Чи трикутник є прямокутним: ");
                Console.WriteLine(IsRightTriangle);

                Console.Write("Периметр трикутника: ");
                Console.WriteLine($"{Perimeter:N2}");

                Console.Write("Площа трикутника: ");
                Console.WriteLine($"{Square:N2}");
            }
        }
    }
}
