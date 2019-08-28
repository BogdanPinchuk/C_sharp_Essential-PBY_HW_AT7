using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp4
{
    /// <summary>
    /// 0D вимірні координати - користувач не задав ніяких вхідних даних
    /// </summary>
    /// <typeparam name="U">числовий тип</typeparam>
    interface I0Dim<U> { }

    /// <summary>
    /// 1D вимірні координати
    /// </summary>
    /// <typeparam name="U">числовий тип</typeparam>
    interface I1Dim<U> : I0Dim<U>
    {
        /// <summary>
        /// Координата по осі Ox
        /// </summary>
        U X { get; set; }
    }

    /// <summary>
    /// 2D вимірні координати
    /// </summary>
    /// <typeparam name="U">числовий тип</typeparam>
    interface I2Dim<U> : I1Dim<U>
    {
        /// <summary>
        /// Координата по осі Oy
        /// </summary>
        U Y { get; set; }
    }

    /// <summary>
    /// 3D вимірні координати
    /// </summary>
    /// <typeparam name="U">числовий тип</typeparam>
    interface I3Dim<U> : I2Dim<U>
    {
        /// <summary>
        /// Координата по осі Oz
        /// </summary>
        U Z { get; set; }
    }

    /// <summary>
    /// 4D вимірні координати
    /// </summary>
    /// <typeparam name="U">числовий тип</typeparam>
    interface I4Dim<U> : I3Dim<U>
    {
        /// <summary>
        /// Часова координата
        /// </summary>
        U T { get; set; }
    }
}
