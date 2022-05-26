using ModelingSystemForHCSLibrary.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ModelingSystemForHCSLibraryTests
{
    public class LinearArray3DTests
    {
        [Fact]
        public void Test1()
        {
            var data = new double[,,] { { { 1, 2, 3 }, { 4, 5, 6 } }, { { 7, 8, 9 }, { 10, 11, 12 } } };
            LinearArray3D<double> array1 = new(data);
            
            Assert.NotNull(array1);
            Assert.InRange(3,6,3);
            

        }
    }
}
