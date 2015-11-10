using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public class DiagonalMatrix<T> : SymmetricMatrix<T>
    {
        public DiagonalMatrix(int columns)
            : base(columns) { }

        public DiagonalMatrix(params T[] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            matrix = new T[array.Length, array.Length];
            for (int i = 0; i < array.Length; i++)
                matrix[i, i] = array[i];
        }

        public DiagonalMatrix(T[,] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (array.GetLength(0) != array.GetLength(1))
                throw new ArgumentException("This matrix is not square.");
            for (int i = 1; i < array.GetLength(0); i++)
                for (int j = i + 1; j < array.GetLength(1); j++)
                    if (!array[i, j].Equals(default(T)) || !array[j, i].Equals(default(T)))
                        throw new ArgumentException();
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
                    throw new ArgumentException("index outside the matrix.");
                if (i != j)
                    matrix[i, j] = default(T);
                else
                {
                    matrix[i, j] = value;
                    MatrixEventArgs<T> arg = new MatrixEventArgs<T>(i, j, value);
                    OnNewElement(arg);
                }
            }
        }
    }
}
