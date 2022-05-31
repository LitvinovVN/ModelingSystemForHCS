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
    public class LinearArray3dRAMTests
    {
        double[,,] data = new double[,,] {
                { { 1,  2,  3,   4 },  { 5,  6,  7,  8 } },
                { { 9,  10, 11, 12 },  { 13, 14, 15, 16 } } ,
                { { 17, 18, 19, 20 },  { 21, 22, 23, 24 } } };
        
        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void InitByArrayShouldReturnNotNull()
        {
            LinearArray3dRAM<double> array = new(data);            
            
            // Тесты для массива array1
            Assert.NotNull(array);
            Assert.Equal(4, array.GetDimentions().X);
            Assert.Equal(2, array.GetDimentions().Y);
            Assert.Equal(3, array.GetDimentions().Z);

            var val = data[2,0,1];
            Assert.Equal(val, array.GetValue(1,0,2));
            array.SetValue(0, 1, 2, 33);
            Assert.Equal(33, array.GetValue(0,1,2));            
        }

        [Fact]
        public void CreatingByDimensionsShouldReturnNotNull()
        {           
            LinearArray3dRAM<double> array2 = new(2, 3, 4);                       

            // Тесты для массива array2
            Assert.Equal(2, array2.GetDimentions().X);
            Assert.Equal(3, array2.GetDimentions().Y);
            Assert.Equal(4, array2.GetDimentions().Z);
            Assert.Equal(0, array2.GetValue(0, 0, 2));
        }

    }
}
