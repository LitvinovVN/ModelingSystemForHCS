using ModelingSystemForHCSLibrary.Enums;
using ModelingSystemForHCSLibrary.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingSystemForHCSLibrary.Arrays
{
    /// <summary>
    /// Класс для работы с массивом 3D в оперативной памяти RAM
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinearArray3dRAM<T> : ILinearArray3D<T>
    {
        T[,,] _linearArray;

        public LinearArray3dRAM(T[,,] linearArray)
        {
            _linearArray = linearArray;
        }

        public LinearArray3dRAM(int nx, int ny, int nz)
        {
            _linearArray = new T[nz, ny, nx];
        }

        /// <summary>
        /// Возвращает размерность трёхмерного массива
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Data3D<int> GetDimentions()
        {
            Data3D<int> dimentions = new();
            dimentions.Z = _linearArray.GetUpperBound(0) + 1;
            dimentions.Y = _linearArray.GetUpperBound(1) + 1; ;
            dimentions.X = _linearArray.GetUpperBound(2) + 1; ;
            return dimentions;
        }

        /// <summary>
        /// Возвращает элемент трёхмерного массива по заданным координатам
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <returns></returns>
        public T GetValue(int X, int Y, int Z)
        {
            return _linearArray[Z, Y, X];
        }

        /// <summary>
        /// Записывает в элемент массива с заданными координатами значение value
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="Z"></param>
        /// <param name="value"></param>
        public void SetValue(int X, int Y, int Z, T value)
        {
            _linearArray[Z, Y, X]=value;
        }

        
    }
}
