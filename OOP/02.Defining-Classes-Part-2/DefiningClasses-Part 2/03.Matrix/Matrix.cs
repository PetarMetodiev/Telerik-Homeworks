namespace Matrix
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Matrix<T> where T : struct, IComparable<T>, IConvertible
    {
        private T[,] matrix;
        private static readonly T minValue = (T)minValue.GetType().GetField("MinValue").GetValue(minValue);

        public Matrix(int rows, int cols)
        {
            this.MatrixHolder = new T[rows, cols];
        }

        public Matrix(int rows, int cols, T[,] matrix)
            : this(rows, cols)
        {
            this.MatrixHolder = matrix;
        }

        public T[,] MatrixHolder
        {
            get { return this.matrix; }
            private set { this.matrix = value; }
        }

        public T MinValue
        {
            get
            {
                return minValue;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                if (row >= 0 && row < this.MatrixHolder.GetLength(0) &&
                    col >= 0 && col < this.MatrixHolder.GetLength(1))
                {
                    return this.MatrixHolder[row, col];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index out of range.");
                }
            }

            set
            {
                if (row >= 0 && row < this.MatrixHolder.GetLength(0) &&
                    col >= 0 && col < this.MatrixHolder.GetLength(1))
                {
                    this.MatrixHolder[row, col] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index out of range.");
                }
            }
        }

        public static Matrix<T> operator +(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            int rowA = matrixA.MatrixHolder.GetLength(0);
            int colA = matrixA.MatrixHolder.GetLength(1);
            int rowB = matrixB.matrix.GetLength(0);
            int colB = matrixB.matrix.GetLength(1);
            if (rowA != rowB || colA != colB)
            {
                throw new ArgumentException("Cannot sum matrix of different size.");
            }
            else
            {
                Matrix<T> resultMatrix = new Matrix<T>(rowA, colA);
                Type type = typeof(T);
                for (int row = 0; row < rowA; row++)
                {
                    for (int col = 0; col < colA; col++)
                    {
                        double valueA = double.Parse(matrixA[row, col].ToString());
                        double valueB = double.Parse(matrixB[row, col].ToString());
                        object result = (object)(valueA + valueB);

                        resultMatrix[row, col] = (T)Convert.ChangeType(result, type);
                    }
                }

                return resultMatrix;
            }
        }

        public static Matrix<T> operator -(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            int rowA = matrixA.MatrixHolder.GetLength(0);
            int colA = matrixA.MatrixHolder.GetLength(1);
            int rowB = matrixB.matrix.GetLength(0);
            int colB = matrixB.matrix.GetLength(1);
            if (rowA != rowB || colA != colB)
            {
                throw new ArgumentException("Cannot subtract matrix of different size.");
            }
            else
            {
                Matrix<T> resultMatrix = new Matrix<T>(rowA, colA);
                Type type = typeof(T);
                for (int row = 0; row < rowA; row++)
                {
                    for (int col = 0; col < colA; col++)
                    {
                        double valueA = double.Parse(matrixA[row, col].ToString());
                        double valueB = double.Parse(matrixB[row, col].ToString());
                        object result = (object)(valueA + valueB);

                        resultMatrix[row, col] = (T)Convert.ChangeType(result, type);
                    }
                }

                return resultMatrix;
            }
        }

        public static Matrix<T> operator *(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            int rowA = matrixA.MatrixHolder.GetLength(0);
            int colA = matrixA.MatrixHolder.GetLength(1);
            int rowB = matrixB.matrix.GetLength(0);
            int colB = matrixB.matrix.GetLength(1);
            if (colA != rowB)
            {
                throw new ArgumentException("Cannot multiply matrix of wrong size. !st matrix cols must equal second matrix rows.");
            }
            else
            {
                Matrix<T> resultMatrix = new Matrix<T>(rowA, colB);
                Type type = typeof(T);
                for (int row = 0; row < rowA; row++)
                {
                    for (int col = 0; col < colB; col++)
                    {
                        for (int sumIndex = 0; sumIndex < colA; sumIndex++)
                        {
                            double valueA = double.Parse(matrixA[row, col].ToString());
                            double valueB = double.Parse(matrixB[row, col].ToString());
                            object result = (object)(valueA * valueB + (double.Parse(resultMatrix[row, col].ToString())));

                            resultMatrix[row, col] = (T)Convert.ChangeType(result, type);
                        }
                    }
                }

                return resultMatrix;
            }
        }

        public static bool operator true(Matrix<T> matrixToCheck)
        {
            Type type = typeof(T);

            for (int row = 0; row < matrixToCheck.MatrixHolder.GetLength(0); row++)
            {
                for (int col = 0; col < matrixToCheck.MatrixHolder.GetLength(1); col++)
                {
                    if (matrixToCheck[row, col].CompareTo((T)(Convert.ChangeType(((object)0), type))) == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> matrixToCheck)
        {
            Type type = typeof(T);

            for (int row = 0; row < matrixToCheck.MatrixHolder.GetLength(0); row++)
            {
                for (int col = 0; col < matrixToCheck.MatrixHolder.GetLength(1); col++)
                {
                    if (matrixToCheck[row, col].CompareTo((T)(Convert.ChangeType(((object)0), type))) == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(string.Format("Matrix {0}x{1}", this.MatrixHolder.GetLength(0), this.MatrixHolder.GetLength(1)));
            result.Append(Environment.NewLine);

            for (int row = 0; row < this.MatrixHolder.GetLength(0); row++)
            {
                result.Append("[");
                for (int col = 0; col < this.MatrixHolder.GetLength(1); col++)
                {
                    result.Append(string.Format("{0}, ", this[row, col]));
                }

                result.Remove(result.Length - 2, 2);
                result.Append("]");
                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }
    }
}