using System;

namespace Task01_2
{
    class Program
    {
        static void Main(string[] args)
        {
            void ElementChangedProcessor<T>(int i, int j, T value)
            {
                Console.WriteLine($"Function- i: {i}, j: {j}, old value: {value}");
            }


            var squreMatrix = new SquareMatrix<int>(6);
            var diagonalMatrix = new DiagonalMatrix<double>(6);

            //SqureMatrix
            squreMatrix[3, 5] = 7;
            squreMatrix.ElementChanged += (i, j, value) => Console.WriteLine($"Lambda- i: {i}, j: {j}, old value: {value}");
            squreMatrix.ElementChanged += ElementChangedProcessor;
            squreMatrix.ElementChanged += delegate (int i, int j, int value)
            {
                Console.WriteLine($"Anonymous method- i: {i}, j: {j}, old value: {value}");
            };
            squreMatrix[3, 5] = 9;

            //DiagonalMatrix
            diagonalMatrix[3, 3] = 7.6;
            diagonalMatrix.ElementChanged += (i, j, value) => Console.WriteLine($"Lambda- i: {i}, j: {j}, old value: {value}");
            diagonalMatrix.ElementChanged += ElementChangedProcessor;
            diagonalMatrix.ElementChanged += delegate (int i, int j, double value)
            {
                Console.WriteLine($"Anonymous method- i: {i}, j: {j}, old value: {value}");
            };
            diagonalMatrix[3, 3] = 9.4;
        }


    }
}
