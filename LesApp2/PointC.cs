using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
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
        /// Аналіз по типу чи передана змінна є числом
        /// </summary>
        /// <param name="value">змінна для аналізу</param>
        /// <returns></returns>
        // http://qaru.site/questions/81099/c-how-to-determine-whether-a-type-is-a-number
        public static bool IsNumeric(object value)
        {
            // визначення коду типа
            int tc = (int)Type.GetTypeCode(value.GetType());

            // аналіз його позиції і виведення результату чи є змінна числом
            return 5 <= tc && tc <= 15;
        }
    }
}
