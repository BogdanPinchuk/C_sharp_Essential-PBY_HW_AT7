using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LesApp4
{
    /// <summary>
    /// Точка (реалізація через клас)
    /// </summary>
    /// <typeparam name="U">Числовий тип</typeparam>
    class PointC<U> : I4Dim<U>
    {
        /// <summary>
        /// Координата по осі Ox
        /// </summary>
        public U X { get; set; }
        /// <summary>
        /// Координата по осі Oy
        /// </summary>
        public U Y { get; set; }
        /// <summary>
        /// Координата по осі Oz
        /// </summary>
        public U Z { get; set; }
        /// <summary>
        /// Часова координата
        /// </summary>
        public U T { get; set; }

        /// <summary>
        /// Координата по осям Ox, Oy, Oz і часова координата
        /// </summary>
        /// <param name="xyzt"></param>
        public PointC(params U[] xyzt)
        {
            #region help
            // рефлексія https://metanit.com/sharp/tutorial/14.1.php
            // присвоєння значень http://www.cyberforum.ru/csharp-beginners/thread1690045.html
            #endregion
            // отримуємо всі свойства
            var proper = typeof(PointC<U>).GetProperties();

            // присвоюємо значення свойствам
            // обмеження на 4 так як тільки 4 виміра максимально
            for (int i = 0; i < Math.Min(4, xyzt.Length); i++)
            {
                proper[i].SetValue(this, xyzt[i]);
            }
        }

        /// <summary>
        /// Відображення інформації про точки
        /// </summary>
        /// <returns></returns>
        public override string ToString()
            => $"P({X}, {Y}, {Z}, {T})";
    }
}
