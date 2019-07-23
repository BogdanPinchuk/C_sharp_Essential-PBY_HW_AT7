using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    /// <summary>
    /// Точка
    /// </summary>
    struct Point
    {
        /// <summary>
        /// Точка P(x, y)
        /// </summary>
        private I2Dim<double> points;

        /// <summary>
        /// Точка P(x, y)
        /// </summary>
        public I2Dim<double> Points
        {
            get { return points; }
            set { points = value; }
        }

        /// <summary>
        /// Ініціалізація точки
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Point(double x, double y)
        {
            points = new PointS<double>(x, y);
        }

    }
}
