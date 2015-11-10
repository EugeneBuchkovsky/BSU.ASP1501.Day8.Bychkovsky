using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public static class Addition
    {
        public static SquareMatrix<T> Add<T>(this SquareMatrix<T> left, SquareMatrix<T> rigth, Func<T, T, T> addition)
        {
            if (left == null || rigth == null || addition == null)
                throw new ArgumentNullException();
            if (left.GetWidth() != rigth.GetWidth())
                throw new InvalidOperationException("Matrix have different dimensions");

            for (int i = 0; i < left.GetWidth(); i++)
                for (int j = 0; j < left.GetWidth(); j++)
                    left[i, j] = addition(left[i, j], rigth[i, j]);

            return left;
        }
    }
}
