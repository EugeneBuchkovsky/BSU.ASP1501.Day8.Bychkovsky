using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public class SquareMatrix<T> : MatrixTemplate<T>
    {
        protected T[,] matrix;

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

        public int GetWidth()
        {
            return matrix.GetLength(0);
        }

        public virtual T this[int i, int j]
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
                matrix[i,j] = value;
                MatrixEventArgs<T> arg = new MatrixEventArgs<T>(i,j,value);
                OnNewElement(arg);
            }
        }

        public string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < this.matrix.GetLength(0); i++)
            {
                for (int j = 0; j < this.matrix.GetLength(1); j++)
                    result.Append(matrix[i, j] + " ");
                result.Append("\n");
            }
            return result.ToString();
        }
    }
}
