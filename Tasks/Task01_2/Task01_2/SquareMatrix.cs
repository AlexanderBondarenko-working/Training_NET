using System;
using System.Collections.Generic;
using System.Text;

namespace Task01_2
{
    /// <summary>
    /// This class represents a square matrix.
    /// </summary>
    public class SquareMatrix<T>
    {
        protected int matrixSize;
        protected T[] matrixElements;

        public delegate void ElementChangedHandler(int i, int j, T oldValue);
        /// <summary>
        /// Occurs when the value of a matrix cell is changed.
        /// </summary>
        public event ElementChangedHandler ElementChanged;

        /// <param name="size">Sets the value of the square matrix</param>
        /// <exception cref="ArgumentException">Occurs when the matrix size is negative or less than 0</exception>
        public SquareMatrix(int size)
        {
            if(size <= 0)
            {
                throw new ArgumentException();
            }
            matrixSize = size;
            InitializeMatrixStorage();
        }

        /// <summary>
        /// Sets or returns a value in the matrix according to the indexes.
        /// </summary>
        /// <param name="i">Row</param>
        /// <param name="j">Column</param>
        /// <returns>Element of matrix or default value</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        /// <exception cref="ArgumentException">When it is impossible to set a value for this index</exception>
        public T this[int i, int j]
        {
            get 
            {
                CheckRange(i, j, matrixSize);
                return matrixElements[PositionInElementsStorage(i, j)];
            }
            set 
            {
                CheckRange(i, j, matrixSize);
                var oldValue = matrixElements[PositionInElementsStorage(i, j)];
                matrixElements[PositionInElementsStorage(i, j)] = value;
                if (!oldValue.Equals(value))
                    ElementChanged?.Invoke(i, j, value);
            }
        }

        protected void CheckRange(int i, int j, int squareMatrixSize)
        {
            if (i <= 0 || j <= 0 || i > squareMatrixSize || j > squareMatrixSize)
            {
                throw new IndexOutOfRangeException();
            }
        }

        protected virtual void InitializeMatrixStorage()
        {
            matrixElements = new T[(int)Math.Pow(matrixSize, 2)];
        }

        protected virtual int PositionInElementsStorage(int i, int j)
        {
            return matrixSize * (i - 1) + j;
        }
    }
}
