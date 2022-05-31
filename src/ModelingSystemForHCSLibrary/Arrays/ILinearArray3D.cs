using ModelingSystemForHCSLibrary.Enums;
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

        /// <summary>
        /// Возвращает двумерный массив по указанной плоскости planName
        /// и номеру среза sliceNumber
        /// </summary>
        /// <param name="planName"></param>
        /// <param name="sliceNumber"></param>
        /// <returns></returns>
        public LinearArray2dRAM<T> GetSlice(PlaneName planeName, int sliceNumber)
        {
            int n1 = 0;
            int n2 = 0;


            switch (planeName)
            {
                case PlaneName.XY:
                    {
                        n1 = GetDimentions().X;
                        n2 = GetDimentions().Y;
                    }
                    break;
                case PlaneName.XZ:
                    {
                        n1 = GetDimentions().X;
                        n2 = GetDimentions().Z;
                    }
                    break;
                case PlaneName.YZ:
                    {
                        n1 = GetDimentions().Y;
                        n2 = GetDimentions().Z;
                    }
                    break;
            }

            LinearArray2dRAM<T> array = new(n1, n2);

            if (planeName == PlaneName.XY)
            {
                for (int j = 0; j < n2; j++)
                {
                    for (int i = 0; i < n1; i++)
                    {
                        var value = GetValue(i, j, sliceNumber);
                        array.SetValue(i,j,value);
                    }                        
                }                    
            }

            if (planeName == PlaneName.XZ)
            {
                for (int k = 0; k < n2; k++)
                {
                    for (int i = 0; i < n1; i++)
                    {
                        var value = GetValue(i, sliceNumber, k);
                        array.SetValue(i, k, value);
                    }
                }
            }

            if (planeName == PlaneName.YZ)
            {
                for (int k = 0; k < n2; k++)
                {
                    for (int j = 0; j < n1; j++)
                    {
                        var value = GetValue(sliceNumber, j, k);
                        array.SetValue(j, k, value);
                    }
                }
            }

            return array;
        }

    }
}
