using ModelingSystemForHCSLibrary.Arrays;
using ModelingSystemForHCSLibrary.Grid;
using Xunit;

namespace ModelingSystemForHCSLibraryTests
{
    public class Grid3DFragmentTests
    {
        [Fact]
        public void Test1()
        {
            Grid3DFragment fragment1 = new(2,3,4);

            Data3D<int> dimentions = fragment1.GetDimentions();

            Assert.NotNull(fragment1);
            Assert.NotNull(fragment1.NodeNumber);
            Assert.Equal(2, dimentions.X);
            Assert.Equal(3, dimentions.Y);
            Assert.Equal(4, dimentions.Z);
        }

        
    }
}