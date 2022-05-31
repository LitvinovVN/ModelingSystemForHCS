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
    public class LinearArray3dGPUTests
    {
        [Fact]
        public void TestLinearArray3dGPU()
        {
            ILinearArray3D<double> array1 = new LinearArray3dGPU<double>(2, 3, 4);
            array1.SetValue(0, 1, 2, 33);
            Assert.Equal(33, array1.GetValue(0, 1, 2));
            Assert.Equal(2, array1.GetDimentions().X);
            Assert.Equal(3, array1.GetDimentions().Y);
            Assert.Equal(4, array1.GetDimentions().Z);
        }

    }
}
