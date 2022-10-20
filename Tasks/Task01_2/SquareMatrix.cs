using System;
using System.Collections.Generic;
using System.Text;

namespace Task01_2
{
    public class SquareMatrix<T>
    {
        protected int matrixSize;
        protected T[] matrixElements;

        public delegate void ElementChangedHandler(int i, int j, T oldValue);
        public event ElementChangedHandler ElementChanged;

        public SquareMatrix(int size)
        {
            if(size <= 0)
            {
                throw new ArgumentException();
            }
            matrixSize = size;
            InitializeMatrixStorage();
        }   

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
