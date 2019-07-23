using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    /// <summary>
    /// Фігура
    /// </summary>
    class Figure
    {
        /// <summary>
        /// Перерахунок типів фігур
        /// </summary>
        public enum TypeFigure
        {
            /// <summary>
            /// пусто
            /// </summary>
            Empty,
            /// <summary>
            /// точка
            /// </summary>
            Dot,
            /// <summary>
            /// лінія / відрізок
            /// </summary>
            Line,
            /// <summary>
            /// трикутник
            /// </summary>
            Triangle,
            /// <summary>
            /// 4-кутник
            /// </summary>
            Quadrangle,
            /// <summary>
            /// 5-кутник
            /// </summary>
            Pentagon,
            /// <summary>
            /// 6-кутник
            /// </summary>
            Hexagon
        }

        /// <summary>
        /// Масив точок
        /// </summary>
        private Point[] points = new Point[6];
        /// <summary>
        /// Тип фігури
        /// </summary>
        private string figureName;
        /// <summary>
        /// кількість точок
        /// </summary>
        private int count;

        /// <summary>
        /// Кількість точок
        /// </summary>
        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        /// <summary>
        /// Назва фігури
        /// </summary>
        public string FigureName
        {
            get
            {
                figureName = Enum.GetValues(typeof(TypeFigure))
                    .Cast<TypeFigure>().ToArray()[Count]
                    .ToString();
                return figureName;
            }
        }

        /// <summary>
        /// Індексатор доступу до точок
        /// </summary>
        /// <param name="index">індекс</param>
        /// <returns></returns>
        public Point this[int index]
        {
            get
            {
                if (0 <= index && index < Count)
                {
                    return points[index];
                }
                else
                {
                    Console.WriteLine("\n\tВихід за межі діапазону.");
                    return new Point(); // пуста точка
                }
            }
            set
            {
                if (0 <= index && index < Count)
                {
                    points[index] = value;
                }
                else
                {
                    Console.WriteLine("\n\tВихід за межі діапазону.");
                }
            }
        }

        /// <summary>
        /// Додавання елемнтів масиву
        /// </summary>
        /// <param name="value">Масив вхідних значень</param>
        public void AddRange(params Point[] value)
        {
            // щоб даремно не виконувати лишні операції,
            // то краще перевірити чи щось було передано
            if (value.Length < 1 ||
                Count + value.Length > 6)
            {
                Console.WriteLine("\n\tВихід за межі діапазону або нічого не передається.");
                return;
            }

            // присвоєння значень
            for (int i = 0; i < Math.Min(6, value.Length); i++)
            {
                points[Count] = value[i];
                Count++;
            }
        }

        /// <summary>
        /// Додавання одного елемента
        /// </summary>
        /// <param name="value">вхідне значення</param>
        public void Add(Point value)
        {
            AddRange(value);
        }

        /// <summary>
        /// Видалення точки
        /// </summary>
        /// <param name="index">індекс точки яку потрібно видалити</param>
        public void Remove(int index)
        {
            // замість видалення можна скористатися 
            // змінною Count як прапором доступу до даних
            // тобто щоб не зміювати розиміри масива, можна просто
            // скопіювати дані вліво (до меншого індексу) а count
            // зменшити на відповідне число, після якого, якщо і будуть
            // числа їх вважатимемо доступними для перезапису

            // перевірка на правилість введених даних
            if (0 <= index && index < Count)
            {
                // зміщення точок
                for (int i = index; i < Count - 1; i++)
                {
                    points[i] = points[i + 1];
                }
                // установка прапора
                Count--;
            }
            else
            {
                Console.WriteLine("\n\tВихід за межі діапазону.");
            }
        }

        /// <summary>
        /// Вивід інформації про фігуру
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return new StringBuilder()
                .Append($"\n\tФігура: {FigureName}")
                .ToString();
        }
    }
}
