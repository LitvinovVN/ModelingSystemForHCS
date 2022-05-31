using ILGPU;
using ILGPU.Runtime;
using ModelingSystemForHCSLibrary.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingSystemForHCSLibrary.Arrays
{
    /// <summary>
    /// Класс для работы с массивом 3D в памяти GPU
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public class LinearArray3dGPU<T> : ILinearArray3D<T>, IDisposable where T : unmanaged
    {
        Context _context;
        Accelerator _accelerator;
        MemoryBuffer3D<T,Stride3D.DenseXY> _buffer;
        public LinearArray3dGPU(int X, int Y, int Z)
        {
            _context = Context.CreateDefault();
            _accelerator = _context.Devices[1].CreateAccelerator(_context);

            _buffer = _accelerator.Allocate3DDenseXY<T>(new LongIndex3D(X, Y, Z));
            _buffer.MemSetToZero();            
        }

        public LinearArray3dGPU(T[,,] array)
            : this(array.GetLength(2), array.GetLength(1), array.GetLength(0))
        {
            for(int k = 0; k < array.GetLength(0); k++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    for(int i = 0; i < array.GetLength(2); i++)
                    {
                        SetValue(i, j, k, array[k, j, i]);
                    }
                }
            }
        }

        ~LinearArray3dGPU()
        {
            Dispose();
        }

        public void Dispose()
        {
            _buffer.Dispose();
            _accelerator.Dispose();
            _context.Dispose();
        }

        public Data3D<int> GetDimentions()
        {
            var dim = new Data3D<int>();
            dim.X = (int)_buffer.Extent.X;
            dim.Y = (int)_buffer.Extent.Y;
            dim.Z = (int)_buffer.Extent.Z;
            return dim;
        }

        public T GetValue(int X, int Y, int Z)
        {
            var subView = _buffer.View.SubView(new Index3D(X,Y,Z),new Index3D(1,1,1));            
            var arr = subView.GetAsArray3D();
            var value = arr[0, 0, 0];
            return value;
        }

        public void SetValue(int X, int Y, int Z, T value)
        {
            var view = _buffer.View;
            var subView = view.SubView(new Index3D(X, Y, Z), new Index3D(1, 1, 1));
            var arr = new T[,,] { { { value } } };
            subView.CopyFromCPU(arr);
        }
    }
}
