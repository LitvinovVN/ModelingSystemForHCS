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
    public class LinearArrays3D
    {
        Dictionary<ModelDataName, LinearArray3D<double>> data=new();
    }
}
