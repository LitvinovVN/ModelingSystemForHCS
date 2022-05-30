using ModelingSystemForHCSLibrary.Enums;
using ModelingSystemForHCSLibrary.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingSystemForHCSLibrary.Arrays
{
    public interface ILinearArray2D<T>
    {
        /// <summary>
        /// Возвращает название плоскости
        /// </summary>
        PlaneName PlaneName { get; }

        /// <summary>
        /// Возвращает размерность двумерного массива
        /// </summary>
        /// <returns></returns>
        Data2D<int> GetDimentions();

        /// <summary>
        /// Возвращает элемент двумерного массива по заданным координатам
        /// </summary>
        /// <param name="N1"></param>
        /// <param name="N2"></param>
        /// <returns></returns>
        T GetValue(int N1, int N2);

        /// <summary>
        /// Записывает в элемент массива с заданными координатами значение value
        /// </summary>
        /// <param name="N1"></param>
        /// <param name="N2"></param>
        /// <param name="value"></param>
        void SetValue(int N1, int N2, T value);
    }
}
