using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public class SymmetricMatrix<T> : MatrixTemplate<T>
    {

        public SymmetricMatrix()
            : base() { }


        public SymmetricMatrix(int columns)
        {
            this.matrix = new T[columns, columns]; 
        }

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

        public override T GetValue(int i, int j)
        {
            return this.matrix[i, j];
        }

        public override void SetValue(int i, int j, T value)
        {
            if (i != j)
            {
                this.matrix[j, i] = value;
            }
            this.matrix[i, j] = value;
            MatrixEventArgs<T> arg = new MatrixEventArgs<T>(j, i, value);
            OnNewElement(arg);
        }
    }
}
