using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public class SquareMatrix<T> : MatrixTemplate<T>
    {
        //T[,] matrix;

        public SquareMatrix()
        {
            matrix = null;
        }

        public SquareMatrix(int columns)
        {
            if (columns < 1)
                throw new ArgumentException("Size can not be negative or zero");
            this.matrix = new T[columns, columns];
        }

        public SquareMatrix(T[,] array)
        {
            if (array.GetLength(0) != array.GetLength(1))
                throw new ArgumentException("This matrix is not square.");
            this.matrix = (T[,])array.Clone();
        }



        public override T GetValue(int i, int j)
        {
            return this.matrix[i, j];
        }

        public override void SetValue(int i, int j, T value)
        {
            this.matrix[i, j] = value;
        }
    }
}
