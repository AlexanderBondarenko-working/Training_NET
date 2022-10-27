using System;
using System.Collections.Generic;
using System.Text;

namespace Task01_2
{
    /// <summary>
    /// This class represents a diagonal matrix.
    /// </summary>
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(int size) : base(size) { }

        protected override void AllocateMemory()
        {
            _matrixElements = new T[_matrixSize];
        }

        protected override T GetMatrixElement(int i, int j)
        {
            return i == j ? _matrixElements[i] : default;
        }

        protected override void SetMatrixElement(int i, int j, T value)
        {
            if (i != j)
            {
                throw new ArgumentException();
            }
            _matrixElements[i] = value;
        }
    }
}
