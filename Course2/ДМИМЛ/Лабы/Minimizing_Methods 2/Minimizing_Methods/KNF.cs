using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimizing_Methods
{
    class KNF : SwitchingTable
    {
        private int[][] SKNFTable;//совершенная ДНФ
        private int[][] CondencedKNFTable;//сокращенная ДНФ
        private int[][] implicantMatrixTable;
        private int[][] implicantTestingTable;
        private string[] implicantMatrixResult; // результат работы импликантной матрицы


        public KNF(int value) : base(value) { }
        public int[][] GetSKNF { get { return SKNFTable; } }
        public int[][] GetCondencedKNF { get { return CondencedKNFTable; } }
        public int[][] GetImplicantMatrix { get { return implicantMatrixTable; } }
        public int[][] GetImplicantTesting { get { return implicantTestingTable; } }
        public string[] GetImplicantMatrixResult { get { return implicantMatrixResult; } }

        public int SKNFDimension
        {
            get
            {
                int dimension = 0;
                for (int i = 0; i < BTable.Length; i++)
                    if (BTable[i] == 0)
                        dimension++;
                return dimension;
            }
        }

        public string GetString(int[][] array)
        {
            string s = "";
            bool show = true;
            for (int i = 0; i < array.Length; i++)
            {
                s += " (";
                for (int j = 0; j < 4; j++)
                {
                    if (array[i][j] == 0)
                        s += "X" + (j + 1) + "v";
                    if (array[i][j] == 1)
                        s += "X̄" + (j + 1) + "v";
                    if (array[i][j] == 5)
                    {
                        show = false;
                        break;
                    }

                }
                s = s.Remove(s.Length - 1);
                if (show == true)
                    s += ") ";
                show = true;
            }
            return s;
        }

        public string GetItem(int column, int[][] array)
        {
            string s = "";
            s += "(";
            for (int j = 0; j < 4; j++)
            {
                if (array[column][j] == 1)
                    s += "X̄" + (j + 1) + "v";
                if (array[column][j] == 0)
                    s += "X" + (j + 1) + "v";

            }
            s = s.Remove(s.Length - 1);
            s += ")";
            return s;
        }

        public void SKNF()//совершенная форма
        {
            SKNFTable = new int[SKNFDimension][];
            for (int i = 0; i < SKNFDimension; i++)
                SKNFTable[i] = new int[4];

            int k = 0;
            for (int i = 0; i < BTable.Length; i++)
            {
                if (BTable[i] == 0)
                {
                    for (int j = 0; j < 4; j++)
                        SKNFTable[k][j] = STable[i][j];
                    k++;
                }
            }
        }

        public void CondencedKNF()//сокращенная форма
        {
            CondencedKNFTable = new int[(int)((double)SKNFDimension / 2 * (SKNFDimension - 1))][];
            for (int i = 0; i < CondencedKNFTable.Length; i++)
                CondencedKNFTable[i] = new int[4];

            int k = 0;
            for (int i = 0; i < SKNFTable.Length - 1; i++)//склеивание и поглощение
            {
                for (int t = i + 1; t < SKNFTable.Length; t++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if ((SKNFTable[i][j] == SKNFTable[t][j]) && (SKNFTable[i][j] == 1))
                            CondencedKNFTable[k][j] = 1;
                        else if ((SKNFTable[i][j] == SKNFTable[t][j]) && (SKNFTable[i][j] == 0))
                            CondencedKNFTable[k][j] = 0;
                        else
                            CondencedKNFTable[k][j] = -1;
                    }
                    k++;
                }
            }

            for (int i = 0; i < CondencedKNFTable.Length; i++)
                for (int t = i + 1; t < CondencedKNFTable.Length; t++)
                    for (int j = 0; j < 4; j++)
                        if (CondencedKNFTable[i][j] == CondencedKNFTable[t][j])
                        {
                            if (j == 3)
                                for (int l = 0; l < 4; l++)
                                    CondencedKNFTable[t][l] = 5;
                        }
                        else break;


            int cmp = 0;
            for (int i = 0; i < CondencedKNFTable.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (CondencedKNFTable[i][j] == -1)
                        cmp++;
                }
                if (cmp == 4)
                {
                    for (int f = 0; f < 4; f++)
                    {
                        CondencedKNFTable[i][f] = 5;
                    }
                }
                cmp = 0;
            }

            int resizing = 0;
            for (int i = 0; i < CondencedKNFTable.Length - 1; i++)
            {
                if (CondencedKNFTable[i][1] == 5)
                {
                    for (int t = i + 1; t < CondencedKNFTable.Length; t++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            CondencedKNFTable[i][j] = CondencedKNFTable[t][j];
                        }
                    }
                    resizing++;
                }
            }
            Array.Resize(ref CondencedKNFTable, CondencedKNFTable.Length - resizing);
        }

        public void ImplicantMatrix()
        {
            implicantMatrixTable = new int[SKNFTable.Length][];
            for (int i = 0; i < implicantMatrixTable.Length; i++)
            {
                implicantMatrixTable[i] = new int[CondencedKNFTable.Length];
                Array.Clear(implicantMatrixTable[i], 0, implicantMatrixTable.Length);
            }

            bool included = false;
            for (int i = 0; i < implicantMatrixTable.Length; i++)//sknfTable.length
            {
                for (int k = 0; k < CondencedKNFTable.Length; k++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if ((SKNFTable[i][j] == CondencedKNFTable[k][j]) || (CondencedKNFTable[k][j] == -1))
                        {
                            included = true;
                            continue;
                        }
                        else if (CondencedKNFTable[k][j] != SKNFTable[i][j])
                        {
                            included = false;
                            break;
                        }
                    }
                    if (included == true)
                    {
                        implicantMatrixTable[i][k] = 1;
                        included = false;
                    }
                }



            }


            int[] container = new int[SKNFTable.Length];
            int n = 0;
            implicantMatrixResult = new string[(int)((double)CondencedKNFTable.Length / 2 * (CondencedKNFTable.Length - 1))];
           
            for (int t = 0; t < CondencedKNFTable.Length; t++)
            {
                for (int k = 1; k < CondencedKNFTable.Length - 1; k++)
                {
                    for (int f = 2; f < CondencedKNFTable.Length - 2; f++)
                    {
                        for (int i = 0; i < SKNFTable.Length; i++)
                        {
                            container[i] = implicantMatrixTable[i][t] + implicantMatrixTable[i][k] + implicantMatrixTable[i][f];
                        }

                        int count = 0;
                        for (int p = 0; p < container.Length; p++)
                        {
                            if (container[p] > 0)
                            {
                                count++;
                            }
                        }
                        if (implicantMatrixResult.Length > n)
                        {
                            if (count == container.Length)
                            {
                                implicantMatrixResult[n] =  GetItem(t, CondencedKNFTable) + "  " + GetItem(k, CondencedKNFTable) + GetItem(f, CondencedKNFTable);
                                n++;
                            }
                        }
                    }
                }
            }

            int resizing = 0;
            for (int i = 0; i < implicantMatrixResult.Length; i++)
            {
                if (implicantMatrixResult[i] == null)
                    resizing++;
            }
            Array.Resize(ref implicantMatrixResult, implicantMatrixResult.Length - resizing);
        }


          public void ImplicantTesting()
        {
            implicantTestingTable = new int[CondencedKNFTable.Length][];
            for (int i = 0; i < implicantTestingTable.Length; i++)
            {
                implicantTestingTable[i] = new int[4];
                for (int j = 0; j < 4; j++)
                {
                    implicantTestingTable[i][j] = 5;
                }
            }

            bool included = false;
            int k = 0;
            for (int i = 0; i < CondencedKNFTable.Length; i++)
            {
                for (int t = 0; t < CondencedKNFTable.Length; t++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (CondencedKNFTable[i][j] == CondencedKNFTable[t][j] || CondencedKNFTable[i][j] == -1 || CondencedKNFTable[t][j] == -1)
                            included = true;
                        else
                        {
                            included = false;
                            break;
                        }
                    }
                    if (included == false)
                    {
                        for (int j = 0; j < 4; j++ )
                            implicantTestingTable[k][j] = CondencedKNFTable[i][j];
                        k++;
                        break; 
                    }                        
                }
            }

            int resizing = 0;
            for (int i = 0; i < implicantTestingTable.Length; i++)
            {
                if (implicantTestingTable[i][1] == 5)
                    resizing++;
            }
            Array.Resize(ref implicantTestingTable, implicantTestingTable.Length - resizing);
        }
    }
}