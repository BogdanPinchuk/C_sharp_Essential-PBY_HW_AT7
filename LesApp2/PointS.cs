using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    /// <summary>
    /// Точка (реалізація через структуру)
    /// </summary>
    /// <typeparam name="U">Числовий тип</typeparam>
    struct PointS<U> : I4Dim<U>
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
        public PointS(params U[] xyzt)
            : this()
        {
            // так як в структурі на відміну від класу
            // не можна присвоїти значення свойствам через рефлексію
            // то необхідно це зробити вручну
            switch (xyzt.Length)
            {
                case 4:
                    T = xyzt[3];
                    goto case 3;
                case 3:
                    Z = xyzt[2];
                    goto case 2;
                case 2:
                    Y = xyzt[1];
                    goto case 1;
                case 1:
                    X = xyzt[0];
                    break;
            }

            // інші дані не мають значення, або згодяться для 
            // майбутнього розширення структури
            // перевага цього конструктора, що він заміняє всі 4
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
