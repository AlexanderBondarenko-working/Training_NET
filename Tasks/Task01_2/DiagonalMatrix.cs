using System;
using System.Collections.Generic;
using System.Text;

namespace Task01_2
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(int size) : base(size) { }

        protected override void InitializeMatrixStorage(int size)
        {
            matrixElements = new T[size];
        }

        protected override int PositionInElementsStorage(int i, int j)
        {
            if (i != j)
            {
                throw new ArgumentException();
            }
            return i;
        }
    }
}
