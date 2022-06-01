using ModelingSystemForHCSLibrary.Arrays;
using ModelingSystemForHCSLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ModelingSystemForHCSLibraryTests
{
    public class LinearArrays3D_RAM_Tests
    {
        /// <summary>
        /// Запрос несуществующего элемента генерирует исключение KeyNotFoundException
        /// </summary>
        [Fact]
        public void TestGetNotExistElementThrowsException()
        {
            LinearArrays3dRAM<double> data = new();            
            Assert.Throws<KeyNotFoundException>(() => data.Get(ModelDataName.U));
        }

        /// <summary>
        /// Создаёт трёхмерный массив
        /// </summary>
        [Fact]
        public void TestCreate()
        {
            LinearArrays3dRAM<double> data = new();
            data.Create(ModelDataName.U, 2, 3, 4);

            var array = data.Get(ModelDataName.U);
            Assert.NotNull(array);
            Assert.Equal(2, array.GetDimentions().X);
            Assert.Equal(3, array.GetDimentions().Y);
            Assert.Equal(4, array.GetDimentions().Z);
        }

        /// <summary>
        /// Проверка метода GetModelDataNames, возвращающего список наименований моделей данных
        /// </summary>
        [Fact]
        public void TestGetModelDataNames()
        {
            LinearArrays3dRAM<double> data = new();
            data.Create(ModelDataName.U, 2, 3, 4);
            data.Create(ModelDataName.V, 5, 6, 7);
            data.Create(ModelDataName.W, 8, 9, 10);

            var modelDataNames = data.GetModelDataNames();

            Assert.Equal(3, modelDataNames.Count());
            Assert.Contains(ModelDataName.U, modelDataNames);
            Assert.Contains(ModelDataName.V, modelDataNames);
            Assert.Contains(ModelDataName.W, modelDataNames);
            Assert.DoesNotContain(ModelDataName.C0, modelDataNames);
        }

        /// <summary>
        /// Удаляет трёхмерный массив
        /// </summary>
        [Fact]
        public void TestRemove()
        {
            LinearArrays3dRAM<double> data = new();
            data.Create(ModelDataName.U, 2, 3, 4);
            data.Remove(ModelDataName.U);
            Assert.Empty(data.GetModelDataNames());
        }

    }
}
