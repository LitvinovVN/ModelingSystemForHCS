using ModelingSystemForHCSLibrary.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingSystemForHCSLibrary.Arrays
{
    public interface ILinearArray3D<T>
    {
        /// <summary>
        /// Возвращает размерность трёхмерного массива
        /// </summary>
        /// <returns></returns>
        Data3D<int> GetDimentions();

        /// <summary>
        /// Возвращает элемент трёхмерного массива по заданным координатам
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        T GetValue(int X, int Y, int Z);

        /// <summary>
        /// Записывает в элемент массива с заданными координатами значение value
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <param name="value"></param>
        void SetValue(int X, int Y, int Z, T value);

        /// <summary>
        /// Возвращает количество элементов трёхмерного массива
        /// </summary>
        /// <returns></returns>
        long GetNumElements()
        {
            var Dim = GetDimentions();
            long NumElements = Dim.X * Dim.Y * Dim.Z;
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
