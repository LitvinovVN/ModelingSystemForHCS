using ModelingSystemForHCSLibrary.Arrays;
using ModelingSystemForHCSLibrary.Enums;
using ModelingSystemForHCSLibrary.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ModelingSystemForHCSLibraryTests
{
    public class ILinearArray2DTests
    {
        double[,] data = new double[,]
            { {  1,  2,  3,  4,  5,  6 },
              {  7,  8,  9, 10, 11, 12 },
              { 13, 14, 15, 16, 17, 18 } };

        /// <summary>
        /// Тест для проверки содержимого массива на Null
        /// </summary>
        [Fact]        
        public void TestNotNull()
        {
            ILinearArray2D<double> array1 = new LinearArray2dRAM<double>(data);                      
            Assert.NotNull(array1);            
        }

        /// <summary>
        /// Тест для проверки размерностей двумерного массива
        /// </summary>
        [Fact]
        public void TestGetDimentionsArray1()
        {
            ILinearArray2D<double> array1 = new LinearArray2dRAM<double>(data);
            Assert.Equal(6, array1.GetDimentions().N1);
            Assert.Equal(3, array1.GetDimentions().N2);
        }

        /// <summary>
        /// Тест для проверки значения элемента двумерного массива по заданным координатам
        /// </summary>
        [Fact]
        public void TestGetValue()
        {
            ILinearArray2D<double> array1 = new LinearArray2dRAM<double>(data);
            var val = data[2, 4];
            Assert.Equal(val, array1.GetValue(4, 2));            
        }


        /// <summary>
        /// Тест для проверки записи значения элемента двумерного массива по заданным координатам
        /// </summary>
        [Fact]
        public void TestSetValue()
        {
            ILinearArray2D<double> array1 = new LinearArray2dRAM<double>(data);
            array1.SetValue(1, 2, 33);
            Assert.Equal(33, array1.GetValue(1, 2));
        }

        /// <summary>
        /// Тест для проверки работы конструктора с параметрами
        /// размерностей двумерного массива и вычисления
        /// количества элементов двумерного массива
        /// </summary>
        [Fact]
        public void TestCreateNewArrayGetNumElements()
        {
            ILinearArray2D<double> array2 = new LinearArray2dRAM<double>(2, 5);
            Assert.Equal(10, array2.GetNumElements());            
        }

        /// <summary>
        /// Тест для проверки работы конструктора с параметрами
        /// размерностей двумерного массива, проверки размерностей
        /// двумерного массива и проверки содержимого созданного массива
        /// </summary>
        [Fact]
        public void TestCreateNewArrayGetDimentionsGetValue()
        {
            ILinearArray2D<double> array2 = new LinearArray2dRAM<double>(2, 5);
            Assert.Equal(2, array2.GetDimentions().N1);
            Assert.Equal(5, array2.GetDimentions().N2);
            Assert.Equal(0, array2.GetValue(0, 2));
        }

        /// <summary>
        /// Тест для проверки работы конструктора с параметрами
        /// размерностей двумерного массива, проверки вычисления объёма
        /// выделямой памяти под двумерный массив выбранного типа
        /// </summary>
        [Fact]
        public void TestILinearArray2D()
        {
            ILinearArray2D<double> array3 = new LinearArray2dRAM<double>(100, 50);
            Assert.Equal(0.038146972656, array3.GetDataSizeInMb<double>(), 12);
        }

        /// <summary>
        /// Тест для проверки размерностеё двумерного массива
        /// для плоскости (по умолчанию) XOY
        /// </summary>
        [Fact]
        public void TestGetDimentionAxis()
        {
            ILinearArray2D<double> array = new LinearArray2dRAM<double>(2, 5);
            Assert.Equal(2, array.GetDimention(Axis.Ox));
            Assert.Equal(5, array.GetDimention(Axis.Oy));
            Assert.Equal(0, array.GetDimention(Axis.Oz));
        }

        /// <summary>
        /// Тест для проверки размерностеё двумерного массива
        /// для плоскости XOZ
        /// </summary>
        [Fact]
        public void TestGetDimentionAxisPlaneXOZ()
        {
            ILinearArray2D<double> array = new LinearArray2dRAM<double>(2, 5, PlaneName.XZ);
            Assert.Equal(2, array.GetDimention(Axis.Ox));
            Assert.Equal(0, array.GetDimention(Axis.Oy));
            Assert.Equal(5, array.GetDimention(Axis.Oz));
        }

        /// <summary>
        /// Тест для проверки размерностеё двумерного массива
        /// для плоскости YZ
        /// </summary>
        [Fact]
        public void TestGetDimentionAxisPlaneYOZ()
        {
            ILinearArray2D<double> array = new LinearArray2dRAM<double>(2, 5, PlaneName.YZ);
            Assert.Equal(0, array.GetDimention(Axis.Ox));
            Assert.Equal(2, array.GetDimention(Axis.Oy));
            Assert.Equal(5, array.GetDimention(Axis.Oz));
        }
    }
}
