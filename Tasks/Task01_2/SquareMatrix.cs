using System;
using System.Collections.Generic;
using System.Text;

namespace Task01_2
{
    public class SquareMatrix<T>
    {
        private int _matrixSize;

        protected T[] matrixElements;

        public delegate void ElementChangedHandler(int i, int j, T oldValue);
        public event ElementChangedHandler Notify;

        public SquareMatrix(int size)
        {
            if(size <= 0)
            {
                throw new ArgumentException();
            }
            InitializeMatrixStorage(size);
        }   

        public T this[int i, int j]
        {
            get 
            {
                CheckRange(i, j, _matrixSize);
                return matrixElements[PositionInElementsStorage(i, j)];
            }
            set 
            {
                CheckRange(i, j, _matrixSize);
                var oldValue = matrixElements[PositionInElementsStorage(i, j)];
                matrixElements[PositionInElementsStorage(i, j)] = value;
                if (oldValue.Equals(value))
                    Notify?.Invoke(i, j, value);
            }
        }

        protected void CheckRange(int i, int j, int squareMatrixSize)
        {
            if (i <= 0 || j <= 0 || i > squareMatrixSize || j > squareMatrixSize)
            {
                throw new IndexOutOfRangeException();
            }
        }

        protected virtual void InitializeMatrixStorage(int size)
        {
            _matrixSize = (int)Math.Pow(size, 2);
            matrixElements = new T[(int)Math.Pow(_matrixSize, 2)];
        }

        protected virtual int PositionInElementsStorage(int i, int j)
        {
            return _matrixSize * (i - 1) + j;
        }
    }
}
