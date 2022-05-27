using ModelingSystemForHCSLibrary.Enums;
using ModelingSystemForHCSLibrary.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingSystemForHCSLibrary.Arrays
{
    public class LinearArray3D<T>
    {
        T[,,] _linearArray;

        public LinearArray3D(T[,,] linearArray)
        {
            _linearArray = linearArray;
        }

        /// <summary>
        /// Возвращает размерность трёхмерного массива
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Data3D<int> GetDimentions()
        {
            Data3D<int> dimentions = new();
            dimentions.X = _linearArray.GetUpperBound(0) + 1;
            dimentions.Y = _linearArray.GetUpperBound(1) + 1; ;
            dimentions.Z = _linearArray.GetUpperBound(2) + 1; ;
            return dimentions;
        }

        public T GetValue(int X, int Y, int Z)
        {
            return _linearArray[X, Y, Z];
        }

        public void SetValue(int X, int Y, int Z, T value)
        {
            _linearArray[X, Y, Z]=value;
        }
    }
}
