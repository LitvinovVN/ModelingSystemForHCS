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
        public void TestLinearArray3dRAM()
        {
            var data = new double[,,] { { { 1, 2, 3 }, { 4, 5, 6 } }, { { 7, 8, 9 }, { 10, 11, 12 } } };
            LinearArray3dRAM<double> array1 = new(data);
            LinearArray3dRAM<double> array2 = new(2, 3, 4);
            
            // Тесты для массива array1
            Assert.NotNull(array1);
            Assert.Equal(2, array1.GetDimentions().X);
            Assert.Equal(2, array1.GetDimentions().Y);
            Assert.Equal(3, array1.GetDimentions().Z);

            var val = data[1,0,2];
            Assert.Equal(val, array1.GetValue(1,0,2));
            array1.SetValue(0, 1, 2, 33);
            Assert.Equal(33, array1.GetValue(0,1,2));

            // Тесты для массива array2
            Assert.Equal(2, array2.GetDimentions().X);
            Assert.Equal(3, array2.GetDimentions().Y);
            Assert.Equal(4, array2.GetDimentions().Z);
            Assert.Equal(0, array2.GetValue(0, 0, 2));
        }

        [Fact]
        public void TestILinearArray3D()
        {
            var data = new double[,,] { { { 1, 2, 3 }, { 4, 5, 6 } }, { { 7, 8, 9 }, { 10, 11, 12 } } };
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            ILinearArray3D<double> array2 = new LinearArray3dRAM<double>(2, 3, 4);
            ILinearArray3D<double> array3 = new LinearArray3dRAM<double>(100, 100, 50);
            Assert.Equal(24, array2.GetNumElements());
            Assert.Equal(3.814697265625, array3.GetDataSizeInMb<double>(),12);

            // Тесты для массива array1
            Assert.NotNull(array1);
            Assert.Equal(2, array1.GetDimentions().X);
            Assert.Equal(2, array1.GetDimentions().Y);
            Assert.Equal(3, array1.GetDimentions().Z);

            var val = data[1, 0, 2];
            Assert.Equal(val, array1.GetValue(1, 0, 2));
            array1.SetValue(0, 1, 2, 33);
            Assert.Equal(33, array1.GetValue(0, 1, 2));

            // Тесты для массива array2
            Assert.Equal(2, array2.GetDimentions().X);
            Assert.Equal(3, array2.GetDimentions().Y);
            Assert.Equal(4, array2.GetDimentions().Z);
            Assert.Equal(0, array2.GetValue(0, 0, 2));

        }

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
