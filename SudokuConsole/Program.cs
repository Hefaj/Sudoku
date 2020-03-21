using System;

namespace SudokuConsole
{
    class Program
    {
        static int[,] matrix = new int[,]
        {
            { 0,0,0,0,8,0,0,0,0},
            { 7,3,0,0,9,0,5,0,1},
            { 0,8,2,0,0,0,0,7,0},

            { 0,0,0,0,0,0,0,5,0},
            { 0,6,9,7,0,0,8,0,2},
            { 0,7,0,0,0,0,6,0,0},

            { 0,0,0,0,4,0,1,0,0},
            { 0,0,0,0,0,0,0,4,6},
            { 5,0,4,0,3,1,0,0,0}
        };

        static void Print()
        {
            Console.WriteLine("*************************");
            for (int i = 0; i < 9; i++)
            {
                if (i != 0 && i % 3 == 0) Console.WriteLine("--------------------");
                for (int j = 0; j < 9; j++)
                {
                    if (j != 0 && j % 3 == 0) Console.Write("|");
                    Console.Write(matrix[i, j].ToString() + " ");
                }
                Console.WriteLine();
            }
        }

        static bool Check(int y, int x, int n)
        {
            for (int i = 0; i < 9; i++)
                if (matrix[y,i] == n) return false;

            for (int i = 0; i < 9; i++)
                if (matrix[i, x] == n) return false;

            int _x = (x / 3) * 3;
            int _y = (y / 3) * 3;

            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    if (matrix[_y+i,_x+j] == n) return false;

            return true;
        }

        static void FindAns()
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (matrix[y, x] == 0)
                    {
                        for (int n = 1; n < 10; n++)
                        {
                            if (Check(y, x, n))
                            {
                                matrix[y, x] = n;
                                FindAns();
                                matrix[y, x] = 0;
                            }
                        }
                        return;
                    }
                }
            }
            Print();
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            Print();
            FindAns();
        }
    }
}
