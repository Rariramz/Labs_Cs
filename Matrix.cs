using System;
using System.Text;
using System.Threading.Tasks;

namespace lab1_Csharp
{
    public class Matrix
    {
        private int rows, cols;
        private int[,] array;

        public Matrix()
        {
        }
        public Matrix(bool temp)
        {
            int rows = 0, cols = 0;

            while (rows <= 0)                 //Ввод числа строк и столбцов матрицы с проверкой на положительное число
            {
                try
                {
                    Console.Write("\nEnter the number of rows of the matrix\nrows = ");
                    rows = int.Parse(Console.ReadLine());
                    if (rows <= 0)
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong input! Try again, please :)");
                }
            }
            while (cols <= 0)
            {
                try
                {
                    Console.Write("Enter the number of colomns of the matrix\ncolomns = ");
                    cols = int.Parse(Console.ReadLine());
                    if (cols <= 0)
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong input! Try again, please :)");
                }
            }
            this.rows = rows;
            this.cols = cols;
            array = new int[rows, cols];
        }
        public Matrix(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            array = new int[rows, cols];
        }
        //public Matrix(int[,] array)
        //{
        //    this.array = array;
        //    rows = array.GetLength(0);
        //    cols = array.GetLength(1);
        //}
        public int this[int i, int j]
        {
            get
            {
                return array[i, j];
            }
            set
            {
                array[i, j] = value;
            }
        }

        public void FillMatrix()
        {
            bool matrixIsFull = false;

            Console.WriteLine("Enter matrix elements");                 //Ввод элементов матрицы с проверкой на числа
            while (!matrixIsFull)
            {
                try
                {
                    string s;
                    string[] arr;
                    int i = 0, j = 0, k = 0, n = 0;

                    while (n < rows * cols)
                    {
                        k = 0;
                        s = Console.ReadLine();
                        arr = s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        while (k < arr.Length && i < rows)
                        {
                            if (j < cols)
                            {
                                array[i, j++] = int.Parse(arr[k++]);
                                n++;
                            }
                            else
                            {
                                j = 0;
                                i++;
                            }
                        }
                    }
                    matrixIsFull = true;
                }
                    catch (Exception)
                {
                    matrixIsFull = false;
                    Console.WriteLine("Wrong input! Try again, please :)");
                }
            }
        }
        public static void ShowMenuOfMatrixOperations()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\n-----------------------------------MATRIX CALCULATOR:-----------------------------------");
            Console.WriteLine("1. Matrix addition");
            Console.WriteLine("2. Matrix subtraction");
            Console.WriteLine("3. Multiplication of a matrix by a number");
            Console.WriteLine("4. Matrix multiplication");
            Console.WriteLine("5. Matrix transpose");
            Console.WriteLine("6. Exit");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2)        //Сложение матриц
        {
            Console.Clear();
            Matrix matrix3 = new Matrix(matrix1.rows, matrix2.cols);
            try
            {
                if (matrix1.rows != matrix2.rows || matrix1.cols != matrix2.cols)
                {
                    throw new Exception();
                }

                for (int i = 0; i < matrix1.rows; i++)
                {
                    for (int j = 0; j < matrix1.cols; j++)
                    {
                        matrix3[i, j] = matrix1[i, j] + matrix2[i, j];
                    }
                }
                Console.WriteLine("The result of adding matrices");
                matrix1.PrintMatrix();
                Console.WriteLine("   and matrix");
                matrix2.PrintMatrix();
                Console.WriteLine("     is matrix");
                matrix3.PrintMatrix();
            }
            catch (Exception)
            {
                Console.WriteLine("\nThese matrices cannot be added :(");
            }
            return matrix3;
        }
        public static Matrix operator -(Matrix matrix1, Matrix matrix2)           //Вычитание матриц
        {
            Console.Clear();
            Matrix matrix3 = new Matrix(matrix1.rows, matrix2.cols);
            try
            {
                if (matrix1.rows != matrix2.rows || matrix1.cols != matrix2.cols)
                {
                    throw new Exception();
                }

                for (int i = 0; i < matrix1.rows; i++)
                {
                    for (int j = 0; j < matrix1.cols; j++)
                    {
                        matrix3[i, j] = matrix1[i, j] - matrix2[i, j];
                    }
                }
                Console.WriteLine("The result of substracting from matrix");
                matrix1.PrintMatrix();
                Console.WriteLine("   of matrix");
                matrix2.PrintMatrix();
                Console.WriteLine("     is matrix");
                matrix3.PrintMatrix();
            }
            catch (Exception)
            {
                Console.WriteLine("\nThese matrices cannot be substract :(");
            }
            return matrix3;
        }
        public static Matrix operator *(Matrix matrix1, Matrix matrix2)           //Перемножение матриц
        {
            Console.Clear();
            Matrix matrix3 = new Matrix(matrix1.rows, matrix2.cols);
            try
            {
                if (matrix1.cols != matrix2.rows)
                {
                    throw new Exception();
                }

                for (int i = 0; i < matrix1.rows; i++)
                {
                    for (int k = 0; k < matrix2.cols; k++)
                    {
                        for (int j = 0; j < matrix1.cols; j++)
                        {
                            matrix3[i, k] += matrix1[i, j] * matrix2[j, k];
                        }
                    }
                }
                Console.WriteLine("The result of multiplying matrix");
                matrix1.PrintMatrix();
                Console.WriteLine("   and matrix");
                matrix2.PrintMatrix();
                Console.WriteLine("     is matrix");
                matrix3.PrintMatrix();
            }
            catch (Exception)
            {
                Console.WriteLine("\nThese matrices cannot be multiplied :(");
            }
            return matrix3;
        }
        public static Matrix MatrixMultiplicationByNumber(Matrix matrix1)           //Произведение матрицы на число
        {
            Console.Clear();
            int k = 99999999;

            while (k == 99999999)
            {
                try
                {
                    Console.Write("\nEnter the number by which you want to multiply the matrix\nk = ");
                    k = int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong input! Try again, please :)");
                }
            }

            Matrix matrix3 = new Matrix(matrix1.rows, matrix1.cols);

            for (int i = 0; i < matrix1.rows; i++)
            {
                for (int j = 0; j < matrix1.cols; j++)
                {
                    matrix3[i, j] = matrix1[i, j] * k;
                }
            }
            Console.WriteLine("The result of multiplying matrix");
            matrix1.PrintMatrix();
            Console.WriteLine("   by a nummber {0}", k);
            Console.WriteLine("     is matrix");
            matrix3.PrintMatrix();
            return matrix3;
        }
        public static Matrix GetTransposeMatrix(Matrix matrix1)           //Транспонирование квадратной матрицы
        {
            Console.Clear();
            Matrix matrix3 = new Matrix(matrix1.cols, matrix1.rows);

            try
            {
                if (matrix1.rows != matrix1.cols)
                {
                    throw new Exception();
                }
                for (int i = 0; i < matrix1.rows; i++)
                {
                    for (int j = 0; j < matrix1.cols; j++)
                    {
                        matrix3[i, j] = matrix1[j, i];
                    }
                }
                Console.WriteLine("The result of transposing matrix");
                matrix1.PrintMatrix();
                Console.WriteLine("     is matrix");
                matrix3.PrintMatrix();
            }
            catch (Exception)
            {
                Console.WriteLine("This function is available only for square matrices :(");
            }
            return matrix3;
        }
        public void PrintMatrix()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < rows; i++)
            {
                Console.Write("          ");
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        ~Matrix()
        {
        }
    }
}
