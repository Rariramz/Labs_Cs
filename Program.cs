using System;
using System.Text;
using System.Threading.Tasks;

namespace lab1_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                int ans = 0;
                Matrix matrix1, matrix2, matrix3;

                Matrix.ShowMenuOfMatrixOperations();            //Выбор опции
                while (ans == 0)
                {
                    try
                    {
                        Console.Write("Choose option, please. Enter a number 1-6\nOption #");
                        Console.ForegroundColor = ConsoleColor.Red;
                        ans = int.Parse(Console.ReadLine());
                        Console.ForegroundColor = ConsoleColor.White;
                        if (!(ans >= 1 && ans <= 6))
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Wrong input! Try again, please :)");
                    }
                }
                switch (ans)
                {
                    case 1:
                        {
                            matrix1 = new Matrix(true);
                            matrix1.FillMatrix();
                            matrix2 = new Matrix(true);
                            matrix2.FillMatrix();
                            matrix3 = matrix1 + matrix2;
                            break;
                        }
                    case 2:
                        {
                            matrix1 = new Matrix(true);
                            matrix1.FillMatrix();
                            matrix2 = new Matrix(true);
                            matrix2.FillMatrix();
                            matrix3 = matrix1 - matrix2;
                            break;
                        }
                    case 3:
                        {
                            matrix1 = new Matrix(true);
                            matrix1.FillMatrix();
                            matrix3 = Matrix.MatrixMultiplicationByNumber(matrix1);
                            break;
                        }
                    case 4:
                        {
                            matrix1 = new Matrix(true);
                            matrix1.FillMatrix();
                            matrix2 = new Matrix(true);
                            matrix2.FillMatrix();
                            matrix3 = matrix1 * matrix2;
                            break;
                        }
                    case 5:
                        {
                            matrix1 = new Matrix(true);
                            matrix1.FillMatrix();
                            matrix3 = Matrix.GetTransposeMatrix(matrix1);
                            break;
                        }
                    case 6:
                        Environment.Exit(0);
                        break;
                }
            }

        }
    }
}
