using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMIML_3
{
    class Matrix
    {

        public static int[,] mtr1 = {{0, 1, 0, 1}, {1, 0, 0, 1}, {0, 0, 1, 0}, {0, 0, 1, 0}};//матрица смеж. для G1
        public static int[,] mtr2 = { { 1, 1, 1, 1 }, { 0, 0, 0, 0 }, { 1, 1, 1, 1 }, { 1, 0, 0, 0 } };//матрица смеж. для G2
        public static void Combination()
        {
            var mtr3=new int[4,4];
            for(int i=0;i<4;i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mtr3[i, j] = mtr1[i, j];
                    if ((mtr1[i, j] == 1 && mtr2[i, j] == 0) || (mtr1[i, j] == 0 && mtr2[i, j] == 1))
                    {
                        mtr3[i, j] = 1;
                    }
                    
                    Console.Write(mtr3[i, j]);

                }
            Console.WriteLine();
            }
        }

        public static void Interfaction()
        {
            var mtr3 = new int[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mtr3[i, j] = mtr1[i, j];
                    if ((mtr1[i, j] == 1 && mtr2[i, j] == 0) || (mtr1[i, j] == 0 && mtr2[i, j] == 1))
                    {
                        mtr3[i, j] = 0;
                    }

                    Console.Write(mtr3[i, j]);

                }
                Console.WriteLine();
            }
        }


        public static int[,] Composition(int [,] mas1, int[,] mas2)
        {
            if (mas1.GetLength(1) != mas2.GetLength(0)) throw new Exception("Матрицы нельзя перемножить");
            int[,] r = new int[mtr1.GetLength(0), mas2.GetLength(1)];
            for (int i = 0; i < mas1.GetLength(0); i++)
            {
                for (int j = 0; j < mas2.GetLength(1); j++)
                {
                    for (int k = 0; k < mas2.GetLength(0); k++)
                    {
                        r[i, j] += mas1[i, k] * mas2[k, j];
                    }
                }
            }
            return r;
        }
        public static void Print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
       }

        public static void Multiplication()
        {
            var mtr6=new int[16,16];
            for(int i=0;i<4;i++)
                for (int j = 0; j < 4; j++)
                {
                    if (mtr1[i,j] == 0)
                    {
                        for (int k = i*4; k < i*4+4; k++)
                        {
                            for (int l = j*4; l < j*4+4; l++)
                            {
                                mtr6[k, l] = 0;
                            }
                        }
                    }
                    else
                    {
                        for (int k = i * 4; k < i * 4 + 4; k++)
                        {
                            for (int l = j * 4; l < j * 4 + 4; l++)
                            {
                                mtr6[k, l] = mtr2[k-i*4,l-j*4];
                            }
                        }
                    }
                }
            for(int i=0;i<16;i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write(mtr6[i,j]);
                    if ((j + 1) % 4 == 0)
                        Console.Write("|");
                }
                Console.WriteLine();
                if ((i + 1) % 4 == 0)
                {
                    Console.WriteLine("--------------------");
                }
            }

        }

        public static void Decart()
        {
            var mtr6 = new int[16, 16];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                {
                    if (mtr1[i, j] == 0 && i != j)
                    {
                        for (int k = i*4; k < i*4 + 4; k++)
                        {
                            for (int l = j*4; l < j*4 + 4; l++)
                            {
                                mtr6[k, l] = 0;
                            }
                        }
                    }
                    else
                    {
                        for (int k = i*4; k < i*4 + 4; k++)
                        {
                            for (int l = j*4; l < j*4 + 4; l++)
                            {
                                if ((k - i*4) == (l - j*4))
                                {
                                    mtr6[k, l] = 1;
                                }
                            }
                        }
                    }
                    if (i == j)
                    {
                        for (int k = i * 4; k < i * 4 + 4; k++)
                        {
                            for (int l = j * 4; l < j * 4 + 4; l++)
                            {
                                mtr6[k, l] = mtr2[k - i * 4, l - j * 4];
                            }
                        }
                    }
                }

            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.Write(mtr6[i, j]);
                    if((j+1)%4==0)
                        Console.Write("|");
                }
                Console.WriteLine();
                if ((i + 1)%4 == 0)
                {
                    Console.WriteLine("--------------------");
                }
            }
        }
    }

    }

