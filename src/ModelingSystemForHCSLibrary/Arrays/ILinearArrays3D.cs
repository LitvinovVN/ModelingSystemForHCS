using ModelingSystemForHCSLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingSystemForHCSLibrary.Arrays
{
    public interface ILinearArrays3D<T>
    {
        /// <summary>
        /// Создает трёхмерный массив указанной размерности с именем modelDataName
        /// </summary>
        /// <param name="modelDataName"></param>
        /// <param name="nx"></param>
        /// <param name="ny"></param>
        /// <param name="nz"></param>
        void Create(ModelDataName modelDataName, int nx, int ny, int nz);

        /// <summary>
        /// Возвращает трёхмерный массив с именем modelDataName
        /// </summary>
        /// <param name="modelDataName"></param>
        /// <returns></returns>
        ILinearArray3D<T> Get(ModelDataName modelDataName);

        /// <summary>
        /// Возвращает список наименований modelDataName
        /// </summary>
        /// <returns></returns>
        IEnumerable<ModelDataName> GetModelDataNames();

        /// <summary>
        /// Удаляет трёхмерный массив с именем modelDataName
        /// </summary>
        /// <param name="modelDataName"></param>
        void Remove(ModelDataName modelDataName);

        /// <summary>
        /// Вычисляет объём памяти в указанных единицах измерения
        /// </summary>
        /// <param name="dataMeasurementUnit"></param>
        /// <returns></returns>
        double GetDataSize<T>(DataMeasurementUnit dataMeasurementUnit) where T : unmanaged
        {
            double dataSize = 0;
            var modelDataNames = GetModelDataNames();
            foreach (var modelDataName in modelDataNames)
            {
                var modelData = Get(modelDataName);
                dataSize += modelData.GetDataSize<T>(dataMeasurementUnit);
            }
            return dataSize;
        }
    }
}
