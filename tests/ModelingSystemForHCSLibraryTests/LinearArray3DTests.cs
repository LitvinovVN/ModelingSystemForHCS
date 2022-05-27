using ModelingSystemForHCSLibrary.Arrays;
using ModelingSystemForHCSLibrary.Grid;
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
            Assert.Equal(2, array1.GetDimentions().X);
            Assert.Equal(2, array1.GetDimentions().Y);
            Assert.Equal(3, array1.GetDimentions().Z);

            var val = data[1,0,2];
            Assert.Equal(val, array1.GetValue(1,0,2));
            array1.SetValue(0, 1, 2, 33);
            Assert.Equal(33, array1.GetValue(0,1,2));

        }
    }
}
