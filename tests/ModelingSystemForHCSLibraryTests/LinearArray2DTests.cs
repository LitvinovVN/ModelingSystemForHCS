using ModelingSystemForHCSLibrary.Arrays;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ModelingSystemForHCSLibraryTests
{    
    public class LinearArray2DTests
    {
        double[,] data = new double[,]
            { {  1,  2,  3,  4,  5,  6 },
              {  7,  8,  9, 10, 11, 12 },
              { 13, 14, 15, 16, 17, 18 } };

        /// <summary>
        /// Тест для проверки размерностей двумерного массива
        /// </summary>
        [Fact]
        public void InitByArrayShouldGetDimentions()
        {
            LinearArray2dRAM<double> array1 = new(data);
            Assert.Equal(3, array1.GetDimentions().N2);
            Assert.Equal(6, array1.GetDimentions().N1);
        }

        //[Fact]
        //public void InitByArrayShouldReturnNotNull()
        //{
        //    LinearArray2dRAM<double> array = new(data);

        //    // Тесты для массива array1
        //    Assert.NotNull(array);
        //    Assert.Equal(4, array.GetDimentions().X);
        //    Assert.Equal(2, array.GetDimentions().Y);
        //    Assert.Equal(3, array.GetDimentions().Z);

        //    var val = data[2, 0, 1];
        //    Assert.Equal(val, array.GetValue(1, 0, 2));
        //    array.SetValue(0, 1, 2, 33);
        //    Assert.Equal(33, array.GetValue(0, 1, 2));
        //}

        //[Fact]
        //public void CreatingByDimensionsShouldReturnNotNull()
        //{
        //    LinearArray3dRAM<double> array2 = new(2, 3, 4);

        //    // Тесты для массива array2
        //    Assert.Equal(2, array2.GetDimentions().X);
        //    Assert.Equal(3, array2.GetDimentions().Y);
        //    Assert.Equal(4, array2.GetDimentions().Z);
        //    Assert.Equal(0, array2.GetValue(0, 0, 2));
        //}
    }
}
