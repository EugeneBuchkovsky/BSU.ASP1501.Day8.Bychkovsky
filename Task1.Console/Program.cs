using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Matrix;
using System;

namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            int[,] intmas = new int[5, 5] { { 1, 2, 3, 4, 5 }, 
                                            { 5, 4, 3, 2, 1 }, 
                                            { 6, 7, 8, 9, 0 }, 
                                            { 0, 9, 8, 7, 6 }, 
                                            { 1, 3, 5, 7, 9 } }; 

            SquareMatrix<int> matr = new SquareMatrix<int>(intmas);
            System.Console.WriteLine(matr.ToString());
            matr.newElement += Change;
            matr[1, 3] = 100;
            System.Threading.Thread.Sleep(1000);
            System.Console.WriteLine(matr.ToString());

            int[,] intmass11 = new int[3, 3] { { 1, 1, 1},
                                              { 1, 1, 1},
                                              { 1, 1, 1} };

            int[,] intmass12 = new int[3, 3] { { 4, 5, 6},
                                              { 12, 3, 4},
                                              { 3, -6, 1} };

            SquareMatrix<int> arrarar1 = new SquareMatrix<int>(intmass11);
            System.Console.WriteLine(arrarar1.ToString());
            SquareMatrix<int> arrarar2 = new SquareMatrix<int>(intmass12);
            System.Console.WriteLine(arrarar2.ToString());
            arrarar1.Add(arrarar2, (a,b) => a+b);

            System.Console.WriteLine(arrarar1.ToString());

            DiagonalMatrix<int> dm = new DiagonalMatrix<int>(5,4,3,2,1);
            System.Console.WriteLine(dm.ToString());
            DiagonalMatrix<int> dm1 = new DiagonalMatrix<int>(-5,-4,-2,-2,-1);
            System.Console.WriteLine(dm1.ToString());
            System.Console.WriteLine(dm.Add(dm1, (a,b) => a+b).ToString());

            //SymmetricMatrix<bool> def = new SymmetricMatrix<bool>(5);

            //System.Console.WriteLine(def.ToString());

            System.Console.ReadLine();
        }

        static void Change(object sender, MatrixEventArgs<int> e)
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Element [{0}, {1}] was changed, now element[{0}, {1}] = {2}", e.i, e.j, e.value);
            System.Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
