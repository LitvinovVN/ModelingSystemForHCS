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
        /// Возвращает размерность объекта по заданной оси
        /// </summary>
        /// <param name="axis"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int GetDimention(Axis axis)
        {
            var dimentions = GetDimentions();
            var n1 = dimentions.N1;
            var n2 = dimentions.N2;
            switch (axis)
            {
                case Axis.Ox:
                    if (PlaneName == PlaneName.XY)
                    {
                        return n1;
                    }
                    if (PlaneName == PlaneName.XZ)
                    {
                        return n1;
                    }
                    break;
                case Axis.Oy:
                    if (PlaneName == PlaneName.XY)
                    {
                        return n2;
                    }
                    if (PlaneName == PlaneName.YZ)
                    {
                        return n1;
                    }
                    break;
                case Axis.Oz:
                    if (PlaneName == PlaneName.XZ)
                    {
                        return n2;
                    }
                    if (PlaneName == PlaneName.YZ)
                    {
                        return n2;
                    }
                    break;
            }
            return 0;
        }

        
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

        /// <summary>
        /// Возвращает количество элементов двумерного массива
        /// </summary>
        /// <returns></returns>
        long GetNumElements()
        {
            var Dim = GetDimentions();
            long NumElements = Dim.N1 * Dim.N2;
            return NumElements;
        }

        /// <summary>
        /// Возвращает размер объекта в Mb
        /// </summary>
        /// <returns></returns>
        unsafe double GetDataSizeInMb<T>() where T : unmanaged
        {
            var dataSizeInMb = (double)GetNumElements() * sizeof(T) / 1024 / 1024;
            return dataSizeInMb;
        }
    }
}
