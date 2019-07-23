using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 1. в умові не зазначена приорітетність типів
// трикутника, наприклад рівносторонній - завжди буде
// рівнобедреним, але навпаки ні
// також, рівнобедрений трикутник може бути прямокутним, 
// але не завжди прямокутний рівнобедреним
// 2. Що розуміється під іншим функціоналом?
// радіуси вписаного і описаного кола,
// висоти до сторін, медіани, бісестрисси, кути і т.д.???
// чи що ще має програма виконувати

namespace LesApp3
{
    /// <summary>
    /// Трикутник
    /// </summary>
    class Triangle
    {
        /// <summary>
        /// Структура трикутника
        /// </summary>
        readonly TriangleData triangle;

        /// <summary>
        /// Ініціалізація трикутника
        /// </summary>
        /// <param name="ab"></param>
        /// <param name="bc"></param>
        /// <param name="ca"></param>
        public Triangle(int ab, int bc, int ca)
        {
            triangle = new TriangleData(ab, bc, ca);
        }

        public override string ToString()
        {
            return triangle.ToString();
        }
    }

    /// <summary>
    /// Дані трикутника
    /// </summary>
    struct TriangleData
    {
        public enum TypeOfTriangle
        {
            /// <summary>
            /// Трикутник
            /// </summary>
            Triangle,
            /// <summary>
            /// правильний/рівносторонній
            /// </summary>
            EquilateralTriangle,
            /// <summary>
            /// рівнобедрений
            /// </summary>
            IsoscelesTriangle,
            /// <summary>
            /// прямокутний
            /// </summary>
            RightTriangle,
            /// <summary>
            /// Не трикутник
            /// </summary>
            NotTriangle
        }

        private int ab, bc, ca;
        private string typeTriangle;
        readonly int perimeter;
        readonly double area;

        /// <summary>
        /// Сторона трикутника AB
        /// </summary>
        public int AB { get { return ab; } }
        /// <summary>
        /// Сторона трикутника BC
        /// </summary>
        public int BC { get { return bc; } }
        /// <summary>
        /// Сторона трикутника CA
        /// </summary>
        public int CA { get { return ca; } }
        /// <summary>
        /// Тип трикутника
        /// </summary>
        public string TypeTriangle { get { return typeTriangle; } }

        public TriangleData(int ab, int bc, int ca)
        {
            this.ab = ab;
            this.bc = bc;
            this.ca = ca;
            this.typeTriangle = ConvertType(AnalizeTriangle(ab, bc, ca));
            this.perimeter = PerimeterOfTriangle(ab, bc, ca);
            this.area = SquareOfTriangle(ab, bc, ca);
        }

        /// <summary>
        /// Периметр трикутника
        /// </summary>
        /// <param name="ab"></param>
        /// <param name="bc"></param>
        /// <param name="ca"></param>
        /// <returns></returns>
        private static int PerimeterOfTriangle(int ab, int bc, int ca)
        {
            return ab + bc + ca;
        }

        /// <summary>
        /// Площа трикутника
        /// </summary>
        /// <returns></returns>
        private static double SquareOfTriangle(int ab, int bc, int ca)
        {
            // півпериметр
            double pp = PerimeterOfTriangle(ab, bc, ca) / 2.0;

            return Math.Sqrt(pp * (pp - ab) * (pp - bc) * (pp - ca));
        }

        /// <summary>
        /// Перевірка чи фігура є трикутником
        /// </summary>
        /// <returns></returns>
        private static bool IsTriangles(int ab, int bc, int ca)
        {
            // перш за все перевіряємо сторони,
            // сторони не можуть бути <= 0
            if (ab <= 0 || bc <= 0 || ca <= 0)
            {
                return false;
            }

            #region help
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
            #endregion

            // найбільша сторона
            int maxSide = Math.Max(ab, Math.Max(bc, ca));

            // інший підхід з іншою формулою
#if true
            if (maxSide < 0.5 * PerimeterOfTriangle(ab, bc, ca))
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
            if (SquareOfTriangle(ab, bc, ca) / maxSide - 1 <= 1)
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
        private static bool IsEquilateralTriangles(int ab, int bc, int ca)
        {
            // найбільша сторона
            int maxSide = Math.Max(ab, Math.Max(bc, ca));

            // якщо суму всіх сторін поділити на максимальну сторону
            // то в результаті, якщо трикутник правильний/рівносторонній
            // то ми повинні отримати "3"
            if (PerimeterOfTriangle(ab, bc, ca) / maxSide == 3)
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
        private static bool IsIsoscelesTriangles(int ab, int bc, int ca)
        {
            // якщо будь які 2-і із 3-х сторін трикутника рівні,
            // то трикутник є  рівнобедреним
            if ((ab == bc) || (ab == ca))
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
        private static bool IsRightTriangles(int ab, int bc, int ca)
        {
            // найбільша сторона
            int maxSide = Math.Max(ab, Math.Max(bc, ca));

            // необхідно скористатися теоремою Піфагора
            // AB^2 = BC^2 + CA^2 якщо вважати сторону AB - гіпотенузою
            // де максимальна сторона є гіпотенузою
            // необхідно привести до типу float так як виникають проблеми із точністю
            if ((float)((ab * ab + bc * bc + ca * ca) / (maxSide * maxSide)) == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Виведення типу трикутниинка в рядок
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string ConvertType(TypeOfTriangle type)
        {
            return type.ToString();
        }

        /// <summary>
        /// Аналіз типу трикутника
        /// </summary>
        /// <param name="ab"></param>
        /// <param name="bc"></param>
        /// <param name="ca"></param>
        /// <returns></returns>
        private static TypeOfTriangle AnalizeTriangle(int ab, int bc, int ca)
        {
            // припустимо наступну ієрархію типів трикутників
            // прямокутний
            // рівносторонній
            // рівнобедрений
            // трикутник
            // не трикутник

            if (IsRightTriangles(ab, bc, ca))
            {
                return TypeOfTriangle.RightTriangle;
            }
            else if (IsEquilateralTriangles(ab, bc, ca))
            {
                return TypeOfTriangle.EquilateralTriangle;
            }
            else if (IsIsoscelesTriangles(ab, bc, ca))
            {
                return TypeOfTriangle.IsoscelesTriangle;
            }
            else if (IsTriangles(ab, bc, ca))
            {
                return TypeOfTriangle.Triangle;
            }
            else
            {
                return TypeOfTriangle.NotTriangle;
            }
        }

        public override string ToString()
        {
            string s = string.Empty;

            if (IsTriangles(AB, BC, CA))
            {
                s = new StringBuilder()
                .Append($"\n\tТрикутник типу {typeTriangle}, ")
                .Append($"з периметром {perimeter:N2} і ")
                .Append($"площею {area:N2};")
                .ToString();
            }
            else
            {
                s = new StringBuilder()
                .Append($"\n\tЦе є {typeTriangle} ")
                .ToString();
            }

            return s;
        }

    }
}
