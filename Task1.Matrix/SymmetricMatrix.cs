using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {

        public SymmetricMatrix()
            : base() { }


        public SymmetricMatrix(int columns)
            : base(columns) { }

        public SymmetricMatrix(T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.GetLength(0) != array.GetLength(1))
                throw new ArgumentException("This matrix is not square.");
            for (int i = 1; i < array.GetLength(0); i++)
                for (int j = i+1; j < array.GetLength(1); j++)
                    if (!array[i, j].Equals(array[j, i]))
                        throw new ArgumentException("Matrix isn't symmetric!");
            matrix = (T[,])array.Clone();
        }

        public override T this[int i, int j]
        {
            get
            {
                if ((i < 0) || (j < 0) || (i > matrix.Length) || (j > matrix.Length))
                    throw new ArgumentException("Index outside the matrix.");
                return matrix[i, j];
            }
            set
            {
                if ((i < 0) || (j < 0) || (i > matrix.Length) || (j > matrix.Length))
                    throw new ArgumentException("Index outside the matrix.");
                matrix[i, j] = value;
                MatrixEventArgs<T> arg = new MatrixEventArgs<T>(i, j, value);
                OnNewElement(arg);
                if (i != j)
                {
                    matrix[j, i] = value;
                    MatrixEventArgs<T> arg1 = new MatrixEventArgs<T>(j, i, value);
                    OnNewElement(arg1);
                }
            }
        }
    }
}
