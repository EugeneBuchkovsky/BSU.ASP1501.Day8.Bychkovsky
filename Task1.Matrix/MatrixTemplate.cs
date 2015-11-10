using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public abstract class MatrixTemplate<T>
    {
        public event EventHandler<MatrixEventArgs<T>> newElement;

        protected T[,] matrix;

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
                return GetValue(i, j);
            }
            set
            {
                if ((i < 0) || (j < 0) || (i > matrix.Length) || (j > matrix.Length))
                    throw new ArgumentException("index outside the matrix.");
                SetValue(i, j, value);
                MatrixEventArgs<T> arg = new MatrixEventArgs<T>(i, j, value);
                OnNewElement(arg);
            }
        }

        public abstract T GetValue(int i, int j);

        public abstract void SetValue(int i, int j, T value);

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

        public virtual void OnNewElement(MatrixEventArgs<T> e)
        {
            EventHandler<MatrixEventArgs<T>> handler = newElement;
            if (handler != null)
                handler(this, e);
        }
    }
}
