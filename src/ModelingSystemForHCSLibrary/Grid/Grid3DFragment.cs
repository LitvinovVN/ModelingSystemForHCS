using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingSystemForHCSLibrary.Grid
{
    /// <summary>
    /// Трехмерный фрагмент расчетной сетки
    /// </summary>
    public class Grid3DFragment
    {
        /// <summary>
        /// Количество узлов в фрагменте
        /// </summary>
        public Data3D<int> NodeNumber { get; set; } = new();

        public Grid3DFragment(int x, int y, int z)
        {
            NodeNumber.X = x;
            NodeNumber.Y = y;
            NodeNumber.Z = z;
        }

        /// <summary>
        /// Возвращает размерность фрагмента расчётной сетки
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Data3D<int> GetDimentions()
        {
            Data3D<int> dimentions = new();
            dimentions.X = NodeNumber.X;
            dimentions.Y = NodeNumber.Y;
            dimentions.Z = NodeNumber.Z;
            return dimentions;
        }
    }
}
