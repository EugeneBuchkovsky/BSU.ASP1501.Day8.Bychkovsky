using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public class MatrixTemplate<T>
    {
        public event EventHandler<MatrixEventArgs<T>> newElement;

        public virtual void OnNewElement(MatrixEventArgs<T> e)
        {
            EventHandler<MatrixEventArgs<T>> handler = newElement;
            if (handler != null)
                handler(this, e);
        }
    }
}
