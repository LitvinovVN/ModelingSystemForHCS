using ModelingSystemForHCSLibrary.Enums;
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

        

    }
}
