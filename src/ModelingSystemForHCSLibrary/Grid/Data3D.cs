using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingSystemForHCSLibrary.Grid
{
    /// <summary>
    /// Данные в трёхмерной декартовой системе координат
    /// </summary>
    /// <typeparam name="T"></typeparam>
    
    public class Data3D<T>
    {
        public T X { get; set; }
        public T Y { get; set; }
        public T Z { get; set; }
    }
}
