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
    public class ILinearArray3DTests
    {
        double[,,] data = new double[,,] {
                { { 1,  2,  3,   4 },  { 5,  6,  7,  8 } },
                { { 9,  10, 11, 12 },  { 13, 14, 15, 16 } } ,
                { { 17, 18, 19, 20 },  { 21, 22, 23, 24 } } };

        /// <summary>
        /// Тест для проверки содержимого массива на Null
        /// </summary>
        [Fact]        
        public void TestNotNull()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);                      
            Assert.NotNull(array1);            
        }

        /// <summary>
        /// Тест для проверки размерностей трёхмерного массива
        /// </summary>
        [Fact]
        public void TestGetDimentionsArray1()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            Assert.Equal(4, array1.GetDimentions().X);
            Assert.Equal(2, array1.GetDimentions().Y);
            Assert.Equal(3, array1.GetDimentions().Z);
        }

        /// <summary>
        /// Тест для проверки значения элемента трёхмерного массива по заданным координатам
        /// </summary>
        [Fact]
        public void TestGetValue()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var val = data[2, 0, 1];
            Assert.Equal(val, array1.GetValue(1, 0, 2));            
        }


        /// <summary>
        /// Тест для проверки записи значения элемента трёхмерного массива по заданным координатам
        /// </summary>
        [Fact]
        public void TestSetValue()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            array1.SetValue(0, 1, 2, 33);
            Assert.Equal(33, array1.GetValue(0, 1, 2));
        }

        /// <summary>
        /// Тест для проверки работы конструктора с параметрами
        /// размерностей трёхмерного массива и вычисления
        /// количества элементов трёхмерного массива
        /// </summary>
        [Fact]
        public void TestCreateNewArrayGetNumElements()
        {
            ILinearArray3D<double> array2 = new LinearArray3dRAM<double>(2, 5, 6);
            Assert.Equal(60, array2.GetNumElements());            
        }

        /// <summary>
        /// Тест для проверки работы конструктора с параметрами
        /// размерностей трёхмерного массива, проверки размерностей
        /// трёхмерного массива и проверки содержимого созданного массива
        /// </summary>
        [Fact]
        public void TestCreateNewArrayGetDimentionsGetValue()
        {
            ILinearArray3D<double> array2 = new LinearArray3dRAM<double>(2, 5, 6);
            Assert.Equal(2, array2.GetDimentions().X);
            Assert.Equal(5, array2.GetDimentions().Y);
            Assert.Equal(6, array2.GetDimentions().Z);
            Assert.Equal(0, array2.GetValue(0, 0, 2));
        }

        /// <summary>
        /// Тест для проверки работы конструктора с параметрами
        /// размерностей трёхмерного массива, проверки вычисления объёма
        /// выделямой памяти под трёхмерный массив выбранного типа
        /// </summary>
        [Fact]
        public void TestILinearArray3D()
        {
            ILinearArray3D<double> array3 = new LinearArray3dRAM<double>(100, 100, 50);
            Assert.Equal(3.814697265625, array3.GetDataSizeInMb<double>(), 12);
        }

        /// <summary>
        /// Тест для среза слоя-плоскости XOY при Z=0
        /// </summary>
        [Fact]
        public void TestGetSlicePlaneNameXY_Z0()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData); 
            var arrayFact = array1.GetSlice(PlaneName.XY, 0);

            for (int j=0; j<arrayExpected.GetDimentions().N2; j++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, j), arrayFact.GetValue(i,j));
                }
            }
        }

        /// <summary>
        /// Тест для среза слоя-плоскости XOY при Z=1
        /// </summary>
        [Fact]
        public void TestGetSlicePlaneNameXY_Z1()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);
            var arrayFact = array1.GetSlice(PlaneName.XY, 1);

            for (int j = 0; j < arrayExpected.GetDimentions().N2; j++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, j), arrayFact.GetValue(i, j));
                }
            }
        }

        /// <summary>
        /// Тест для среза слоя-плоскости XOY при Z=2
        /// </summary>
        [Fact]
        public void TestGetSlicePlaneNameXY_Z2()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 17, 18, 19, 20 }, { 21, 22, 23, 24 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);
            var arrayFact = array1.GetSlice(PlaneName.XY, 2);

            for (int j = 0; j < arrayExpected.GetDimentions().N2; j++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, j), arrayFact.GetValue(i, j));
                }
            }
        }

        /// <summary>
        /// Тест для среза слоя-плоскости XOZ при Y=0
        /// </summary>
        [Fact]
        public void TestGetSlicePlaneNameXZ_Y0()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 1, 2, 3, 4 }, { 9, 10, 11, 12 }, { 17, 18, 19, 20 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);
            var arrayFact = array1.GetSlice(PlaneName.XZ, 0);

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, k), arrayFact.GetValue(i, k));
                }
            }
        }

        /// <summary>
        /// Тест для среза слоя-плоскости XOZ при Y=1
        /// </summary>
        [Fact]
        public void TestGetSlicePlaneNameXZ_Y1()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 5, 6, 7, 8 }, { 13, 14, 15, 16 }, { 21, 22, 23, 24 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);
            var arrayFact = array1.GetSlice(PlaneName.XZ, 1);

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, k), arrayFact.GetValue(i, k));
                }
            }
        }

        /// <summary>
        /// Тест для среза слоя-плоскости YOZ при X=0
        /// </summary>
        [Fact]
        public void TestGetSlicePlaneNameYZ_X0()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 1, 5 }, { 9, 13 }, { 17, 21 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);
            var arrayFact = array1.GetSlice(PlaneName.YZ, 0);

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int j = 0; j < arrayExpected.GetDimentions().N1; j++)
                {
                    Assert.Equal(arrayExpected.GetValue(j, k), arrayFact.GetValue(j, k));
                }
            }
        }

        /// <summary>
        /// Тест для среза слоя-плоскости YOZ при X=2
        /// </summary>
        [Fact]
        public void TestGetSlicePlaneNameYZ_X2()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 3, 7 }, { 11, 15 }, { 19, 23 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);
            var arrayFact = array1.GetSlice(PlaneName.YZ, 2);

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int j = 0; j < arrayExpected.GetDimentions().N1; j++)
                {
                    Assert.Equal(arrayExpected.GetValue(j, k), arrayFact.GetValue(j, k));
                }
            }
        }

        /// <summary>
        /// Тест для среза слоя-плоскости YOZ при X=3
        /// </summary>
        [Fact]
        public void TestGetSlicePlaneNameYZ_X3()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 4, 8 }, { 12, 16 }, { 20, 24 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);
            var arrayFact = array1.GetSlice(PlaneName.YZ, 3);

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int j = 0; j < arrayExpected.GetDimentions().N1; j++)
                {
                    Assert.Equal(arrayExpected.GetValue(j, k), arrayFact.GetValue(j, k));
                }
            }
        }

        /// <summary>
        /// Тест для проверки генерирования исключения при несоответствии размерностей
        /// </summary>
        [Fact]
        public void TestSetSliceException()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 11, 22, 33 }, { 55, 66, 77 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);
                        
            Assert.Throws<Exception>(() => array1.SetSlice(PlaneName.XY, 0, arrayExpected));
        }

        /// <summary>
        /// Тест для установки среза слоя-плоскости XOY при Z=0
        /// </summary>
        [Fact]
        public void TestSetSlicePlaneNameXY_Z0()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 11, 22, 33, 44 }, { 55, 66, 77, 88 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);

            array1.SetSlice(PlaneName.XY, 0, arrayExpected);
            var arrayFact = array1.GetSlice(PlaneName.XY, 0);

            for (int j = 0; j < arrayExpected.GetDimentions().N2; j++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, j), arrayFact.GetValue(i, j));
                }
            }
        }

        /// <summary>
        /// Тест для установки среза слоя-плоскости XOY при Z=1
        /// </summary>
        [Fact]
        public void TestSetSlicePlaneNameXY_Z1()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 99, 100, 111, 122 }, { 133, 144, 155, 166 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);

            array1.SetSlice(PlaneName.XY, 1, arrayExpected);
            var arrayFact = array1.GetSlice(PlaneName.XY, 1);

            for (int j = 0; j < arrayExpected.GetDimentions().N2; j++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, j), arrayFact.GetValue(i, j));
                }
            }
        }

        /// <summary>
        /// Тест для установки среза слоя-плоскости XOY при Z=2
        /// </summary>
        [Fact]
        public void TestSetSlicePlaneNameXY_Z2()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 177, 188, 199, 200 }, { 211, 222, 233, 244 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);

            array1.SetSlice(PlaneName.XY, 2, arrayExpected);
            var arrayFact = array1.GetSlice(PlaneName.XY, 2);

            for (int j = 0; j < arrayExpected.GetDimentions().N2; j++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, j), arrayFact.GetValue(i, j));
                }
            }
        }

        /// <summary>
        /// Тест для установки среза слоя-плоскости XOZ при Y=0
        /// </summary>
        [Fact]
        public void TestSetSlicePlaneNameXZ_Y0()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 11, 22, 33, 44 }, { 99, 100, 111, 122 }, { 177, 188, 199, 200 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);

            array1.SetSlice(PlaneName.XZ, 0, arrayExpected);
            var arrayFact = array1.GetSlice(PlaneName.XZ, 0);

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, k), arrayFact.GetValue(i, k));
                }
            }
        }

        /// <summary>
        /// Тест для установки среза слоя-плоскости XOZ при Y=1
        /// </summary>
        [Fact]
        public void TestSetSlicePlaneNameXZ_Y1()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 55, 66, 77, 88 }, { 133, 144, 155, 166 }, { 211, 222, 233, 244 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);

            array1.SetSlice(PlaneName.XZ, 1, arrayExpected);
            var arrayFact = array1.GetSlice(PlaneName.XZ, 1);

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, k), arrayFact.GetValue(i, k));
                }
            }
        }

        /// <summary>
        /// Тест для установки среза слоя-плоскости YOZ при X=0
        /// </summary>
        [Fact]
        public void TestSetSlicePlaneNameYZ_X0()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 11, 55 }, { 99, 133 }, { 177, 211 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);

            array1.SetSlice(PlaneName.YZ, 0, arrayExpected);
            var arrayFact = array1.GetSlice(PlaneName.YZ, 0);

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int j = 0; j < arrayExpected.GetDimentions().N1; j++)
                {
                    Assert.Equal(arrayExpected.GetValue(j, k), arrayFact.GetValue(j, k));
                }
            }
        }

        /// <summary>
        /// Тест для установки среза слоя-плоскости YOZ при X=2
        /// </summary>
        [Fact]
        public void TestSetSlicePlaneNameYZ_X2()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 33, 77 }, { 111, 155 }, { 199, 233 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);

            array1.SetSlice(PlaneName.YZ, 2, arrayExpected);
            var arrayFact = array1.GetSlice(PlaneName.YZ, 2);

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int j = 0; j < arrayExpected.GetDimentions().N1; j++)
                {
                    Assert.Equal(arrayExpected.GetValue(j, k), arrayFact.GetValue(j, k));
                }
            }
        }

        /// <summary>
        /// Тест для установки среза слоя-плоскости YOZ при X=3
        /// </summary>
        [Fact]
        public void TestSetSlicePlaneNameYZ_X3()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 44, 88 }, { 122, 166 }, { 200, 244 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);

            array1.SetSlice(PlaneName.YZ, 3, arrayExpected);
            var arrayFact = array1.GetSlice(PlaneName.YZ, 3);

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int j = 0; j < arrayExpected.GetDimentions().N1; j++)
                {
                    Assert.Equal(arrayExpected.GetValue(j, k), arrayFact.GetValue(j, k));
                }
            }
        }

        /// <summary>
        /// Тест для проверки считывания первого среза-плоскости XOY
        /// </summary>
        [Fact]
        public void TestGetSliceXYFirst()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);

            array1.SetSlice(PlaneName.XY, 0, arrayExpected);
            var arrayFact = array1.GetSliceXYFirst();

            for (int j = 0; j < arrayExpected.GetDimentions().N2; j++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, j), arrayFact.GetValue(i, j));
                }
            }
        }

        /// <summary>
        /// Тест для проверки считывания последнего среза слоя-плоскости XOY
        /// </summary>
        [Fact]
        public void TestGetSliceXYLast()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 17, 18, 19, 20 }, { 21, 22, 23, 24 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);

            array1.SetSlice(PlaneName.XY, 1, arrayExpected);
            var arrayFact = array1.GetSliceXYLast();

            for (int j = 0; j < arrayExpected.GetDimentions().N2; j++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, j), arrayFact.GetValue(i, j));
                }
            }
        }

        /// <summary>
        /// Тест для проверки считывания первого среза-плоскости XOZ
        /// </summary>
        [Fact]
        public void TestGetSliceXZFirst()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 1, 2, 3, 4 }, { 9, 10, 11, 12 }, { 17, 18, 19, 20 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);
            var arrayFact = array1.GetSliceXZFirst();

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, k), arrayFact.GetValue(i, k));
                }
            }
        }

        /// <summary>
        /// Тест для проверки считывания последнего среза слоя-плоскости XOZ
        /// </summary>
        [Fact]
        public void TestGetSliceXZLast()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 5, 6, 7, 8 }, { 13, 14, 15, 16 }, { 21, 22, 23, 24 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);
            var arrayFact = array1.GetSliceXZLast();

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, k), arrayFact.GetValue(i, k));
                }
            }
        }

        /// <summary>
        /// Тест для проверки считывания первого среза-плоскости YOZ
        /// </summary>
        [Fact]
        public void TestGetSliceYZFirst()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 1, 5 }, { 9, 13 }, { 17, 21 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);
            var arrayFact = array1.GetSliceYZFirst();

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int j = 0; j < arrayExpected.GetDimentions().N1; j++)
                {
                    Assert.Equal(arrayExpected.GetValue(j, k), arrayFact.GetValue(j, k));
                }
            }
        }

        /// <summary>
        /// Тест для проверки считывания последнего среза слоя-плоскости YOZ
        /// </summary>
        [Fact]
        public void TestGetSliceYZLast()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 4, 8 }, { 12, 16 }, { 20, 24 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);
            var arrayFact = array1.GetSliceYZLast();

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int j = 0; j < arrayExpected.GetDimentions().N1; j++)
                {
                    Assert.Equal(arrayExpected.GetValue(j, k), arrayFact.GetValue(j, k));
                }
            }
        }

        /// <summary>
        /// Тест для установки первого среза слоя-плоскости XOY
        /// </summary>
        [Fact]
        public void TestSetSliceXYFirst()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 11, 22, 33, 44 }, { 55, 66, 77, 88 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);

            array1.SetSliceXYFirst(arrayExpected);
            var arrayFact = array1.GetSliceXYFirst();

            for (int j = 0; j < arrayExpected.GetDimentions().N2; j++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, j), arrayFact.GetValue(i, j));
                }
            }
        }

        /// <summary>
        /// Тест для установки последнего среза слоя-плоскости XOY
        /// </summary>
        [Fact]
        public void TestSetSliceXYLast()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 177, 188, 199, 200 }, { 211, 222, 233, 244 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);

            array1.SetSliceXYLast(arrayExpected);
            var arrayFact = array1.GetSliceXYLast();

            for (int j = 0; j < arrayExpected.GetDimentions().N2; j++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, j), arrayFact.GetValue(i, j));
                }
            }
        }

        /// <summary>
        /// Тест для установки первого среза слоя-плоскости XOZ
        /// </summary>
        [Fact]
        public void TestSetSliceXZFirst()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 11, 22, 33, 44 }, { 99, 100, 111, 122 }, { 177, 188, 199, 200 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);

            array1.SetSliceXZFirst(arrayExpected);
            var arrayFact = array1.GetSliceXZFirst();

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, k), arrayFact.GetValue(i, k));
                }
            }
        }

        /// <summary>
        /// Тест для установки последнего среза слоя-плоскости XOZ
        /// </summary>
        [Fact]
        public void TestSetSliceXZLast()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 55, 66, 77, 88 }, { 133, 144, 155, 166 }, { 211, 222, 233, 244 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);

            array1.SetSliceXZLast(arrayExpected);
            var arrayFact = array1.GetSliceXZLast();

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int i = 0; i < arrayExpected.GetDimentions().N1; i++)
                {
                    Assert.Equal(arrayExpected.GetValue(i, k), arrayFact.GetValue(i, k));
                }
            }
        }

        /// <summary>
        /// Тест для установки первого среза слоя-плоскости YOZ
        /// </summary>
        [Fact]
        public void TestSetSliceYZFirst()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 11, 55 }, { 99, 133 }, { 177, 211 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);

            array1.SetSliceYZFirst(arrayExpected);
            var arrayFact = array1.GetSliceYZFirst();

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int j = 0; j < arrayExpected.GetDimentions().N1; j++)
                {
                    Assert.Equal(arrayExpected.GetValue(j, k), arrayFact.GetValue(j, k));
                }
            }
        }

        /// <summary>
        /// Тест для установки последнего среза слоя-плоскости YOZ
        /// </summary>
        [Fact]
        public void TestSetSliceYZLast()
        {
            ILinearArray3D<double> array1 = new LinearArray3dRAM<double>(data);
            var sliceData = new double[,] { { 44, 88 }, { 122, 166 }, { 200, 244 } };
            var arrayExpected = new LinearArray2dRAM<double>(sliceData);

            array1.SetSliceYZLast(arrayExpected);
            var arrayFact = array1.GetSliceYZLast();

            for (int k = 0; k < arrayExpected.GetDimentions().N2; k++)
            {
                for (int j = 0; j < arrayExpected.GetDimentions().N1; j++)
                {
                    Assert.Equal(arrayExpected.GetValue(j, k), arrayFact.GetValue(j, k));
                }
            }
        }

    }
}
