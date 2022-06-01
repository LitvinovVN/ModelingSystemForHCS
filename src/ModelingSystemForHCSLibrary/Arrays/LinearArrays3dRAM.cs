using ModelingSystemForHCSLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingSystemForHCSLibrary.Arrays
{

    /// <summary>
    /// Реализует хранение объектов класса LinearArray3D с доступом к данным по имени массива данных modelDataName
    /// </summary>
    public class LinearArrays3dRAM<T> : ILinearArrays3D<T>
    {
        Dictionary<ModelDataName, LinearArray3dRAM<T>> data=new();

        /// <summary>
        /// Создает трёхмерный массив указанной размерности с именем modelDataName
        /// </summary>
        /// <param name="modelDataName"></param>
        /// <param name="nx"></param>
        /// <param name="ny"></param>
        /// <param name="nz"></param>
        public void Create(ModelDataName modelDataName, int nx, int ny, int nz)
        {
            LinearArray3dRAM<T> linearArray3D = new(nx, ny, nz);
            data.Add(modelDataName, linearArray3D);            
        }

        /// <summary>
        /// Возвращает трёхмерный массив с именем modelDataName
        /// </summary>
        /// <param name="modelDataName"></param>
        /// <returns></returns>
        public ILinearArray3D<T> Get(ModelDataName modelDataName)
        {
            return data[modelDataName];
        }
                
        /// <summary>
        /// Возвращает список наименований modelDataName
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<ModelDataName> GetModelDataNames()
        {
            return data.Keys;
        }

        /// <summary>
        /// Удаляет трёхмерный массив с именем modelDataName
        /// </summary>
        /// <param name="modelDataName"></param>
        public void Remove(ModelDataName modelDataName)
        {
            data.Remove(modelDataName);
        }
    }
}
