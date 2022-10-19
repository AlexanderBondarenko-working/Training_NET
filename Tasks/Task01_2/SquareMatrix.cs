using System;
using System.Collections.Generic;
using System.Text;

namespace Task01_2
{
    public class SquareMatrix<T>
    {
        private int _matrixSize;

        protected T[] matrixElements;

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
            get => GetElement(i, j);
            set => SetElement(value, i, j);
        }

        protected void CheckRange(int i, int j, int squareMatrixSize)
        {
            if (i <= 0 || j <= 0 || i > _matrixSize || j > _matrixSize)
            {
                throw new IndexOutOfRangeException();
            }
        }

        protected virtual void InitializeMatrixStorage(int size)
        {
            _matrixSize = (int)Math.Pow(size, 2);
            matrixElements = new T[(int)Math.Pow(_matrixSize, 2)];
        }

        protected virtual T GetElement(int i, int j)
        {
            CheckRange(i, j, _matrixSize);
            return matrixElements[_matrixSize * (i - 1) + j];
        }

        protected virtual void SetElement(T value, int i, int j)
        {
            CheckRange(i, j, _matrixSize);
            matrixElements[_matrixSize * (i - 1) + j] = value; 
        }
    }
}
