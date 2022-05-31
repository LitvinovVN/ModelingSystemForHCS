using ModelingSystemForHCSLibrary.Enums;
using ModelingSystemForHCSLibrary.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingSystemForHCSLibrary.Arrays
{
    public class LinearArray2dRAM<T> : ILinearArray2D<T>
    {
        T[,] _linearArray;
        PlaneName _planeName;

        public LinearArray2dRAM(T[,] linearArray)
        {
            _linearArray = linearArray;
        }

        public LinearArray2dRAM(int n1, int n2, PlaneName planeName = PlaneName.XY)
        {
            _linearArray = new T[n2, n1];
            _planeName = planeName;
        }

        /// <summary>
        /// Возвращает название плоскости
        /// </summary>
        public PlaneName PlaneName { get { return _planeName; } }        

        /// <summary>
        /// Возвращает размерность двумерного массива
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Data2D<int> GetDimentions()
        {
            Data2D<int> dimentions = new();
            dimentions.N2 = _linearArray.GetUpperBound(0) + 1;
            dimentions.N1 = _linearArray.GetUpperBound(1) + 1; ;
            return dimentions;
        }

        /// <summary>
        /// Возвращает элемент двумерного массива по заданным координатам
        /// </summary>
        /// <param name="N1"></param>
        /// <param name="N2"></param>
        /// <returns></returns>
        public T GetValue(int N1, int N2)
        {
            return _linearArray[N2, N1];
        }

        /// <summary>
        /// Записывает в элемент массива с заданными координатами значение value
        /// </summary>
        /// <param name="N1"></param>
        /// <param name="N2"></param>
        /// <param name="value"></param>
        public void SetValue(int N1, int N2, T value)
        {
            _linearArray[N2, N1] = value;
        }


    }
}
