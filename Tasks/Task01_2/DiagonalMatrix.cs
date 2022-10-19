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

        protected override T GetElement(int i, int j)
        {
            CheckRange(i, j, matrixElements.Length);
            return i == j ? matrixElements[i] : default;
        }

        protected override void SetElement(T value, int i, int j)
        {
            CheckRange(i, j, matrixElements.Length);
           if (i != j)
            {
                throw new ArgumentException();
            }
            matrixElements[i] = value;
        }
    }
}
