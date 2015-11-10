using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public sealed class MatrixEventArgs<T> : EventArgs
    {
            public int i { get; set; }
            public int j { get; set; }
            public T value { get; set; }

            public MatrixEventArgs(int i, int j, T value)
            {
                this.i = i;
                this.j = j;
                this.value = value;
            }
    }
}
