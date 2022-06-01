using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingSystemForHCSLibrary.Grid
{
    public class Data2D<T>
    {
        public Data2D()
        {

        }
        
        public Data2D(T n1, T n2)
        {
            N1 = n1;
            N2 = n2;
        }

        public T N1 { get; set; }
        public T N2 { get; set; }
    }
}
