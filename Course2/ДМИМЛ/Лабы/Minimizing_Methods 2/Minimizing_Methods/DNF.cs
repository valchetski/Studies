using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Minimizing_Methods
{
    class DNF : SwitchingTable
    {
        private int[][] SDNFTable;//совершенная ДНФ
        private int[][] CondencedDNFTable;//сокращенная ДНФ
        private int[][] implicantMatrixTable; //импликантная матрица
        private int[][] implicantTestingTable;
        private string[] implicantMatrixResult; // результат работы импликантной матрицы

        public DNF(int value) : base(value) { }
        public int[][] GetSDNF { get { return SDNFTable; } }
        public int[][] GetCondencedDNF { get { return CondencedDNFTable; } }
        public int[][] GetImplicantMatrix { get { return implicantMatrixTable; } }
        public int[][] GetImplicantTesting { get { return implicantTestingTable; } }
        public string[] GetImplicantMatrixResult { get { return implicantMatrixResult; } }

        public int SDNFDimension
        {
            get
            {
                int SDNFDimension = 0;
                for (int i = 0; i < BTable.Length; i++)
                    if (BTable[i] == 1)
                        SDNFDimension++;
                return SDNFDimension;
            }
        }

        public string GetString(int[][] array)// представить в виде строки
        {

            string s = "";
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (array[i][j] == 1)
                        s += "X" + (j + 1);
                    if (array[i][j] == 0)
                        s += "X̄" + (j + 1);
                }
                s += " v ";
            }
            s = s.Remove(s.Length - 2);
            return s;
        }

        public string GetItem(int column, int[][] array)
        {
            string s = "";
            for (int j = 0; j < 4; j++)
            {
                if (array[column][j] == 1)
                    s += "X" + (j + 1);
                if (CondencedDNFTable[column][j] == 0)
                    s += "X̄" + (j + 1);
            }
            return s;
        }

        public int[][] SDNF()//совершенная форма
        {
            SDNFTable = new int[SDNFDimension][];
            for (int i = 0; i < SDNFDimension; i++)
                SDNFTable[i] = new int[4];

            int k = 0;
            for (int i = 0; i < BTable.Length; i++)
            {
                if (BTable[i] == 1)
                {
                    for (int j = 0; j < 4; j++)
                        SDNFTable[k][j] = STable[i][j];
                    k++;
                }
            }
            return SDNFTable;
        }

        public int[][] CondencedDNF()//сокращенная форма
        {
            CondencedDNFTable = new int[(int)((double)SDNFDimension / 2 * (SDNFDimension - 1))][];
            for (int i = 0; i < CondencedDNFTable.Length; i++)
                CondencedDNFTable[i] = new int[4];

            int k = 0;
            for (int i = 0; i < SDNFTable.Length - 1; i++)
                for (int t = i + 1; t < SDNFTable.Length; t++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if ((SDNFTable[i][j] == SDNFTable[t][j]) && (SDNFTable[i][j] == 1))
                            CondencedDNFTable[k][j] = 1;
                        else if ((SDNFTable[i][j] == SDNFTable[t][j]) && (SDNFTable[i][j] == 0))
                            CondencedDNFTable[k][j] = 0;
                        else
                            CondencedDNFTable[k][j] = -1;
                    }
                    k++;
                }

            for (int i = 0; i < CondencedDNFTable.Length; i++)
                for (int t = i + 1; t < CondencedDNFTable.Length; t++)
                    for (int j = 0; j < 4; j++)
                        if (CondencedDNFTable[i][j] == CondencedDNFTable[t][j])
                        {
                            if (j == 3)
                                for (int l = 0; l < 4; l++)
                                    CondencedDNFTable[t][l] = 5;
                        }
                        else break;

            int cmp = 0;
            for (int i = 0; i < CondencedDNFTable.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (CondencedDNFTable[i][j] == -1)
                        cmp++;
                }
                if (cmp == 4)
                {
                    for (int f = 0; f < 4; f++)
                    {
                        CondencedDNFTable[i][f] = 5;
                    }                   
                }
                cmp = 0;
            }

            int resizing = 0;
            for (int i = 0; i < CondencedDNFTable.Length - 1; i++)
            {
                if (CondencedDNFTable[i][1] == 5)
                {
                    for (int t = i + 1; t < CondencedDNFTable.Length; t++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            CondencedDNFTable[i][j] = CondencedDNFTable[t][j];
                        }
                    }
                    resizing++;
                }
            }
            Array.Resize(ref CondencedDNFTable, CondencedDNFTable.Length - resizing);
            return CondencedDNFTable;
        }

        public void ImplicantMatrix()
        {
            implicantMatrixTable = new int[SDNFTable.Length][];
            for (int i = 0; i < implicantMatrixTable.Length; i++)
            {
                implicantMatrixTable[i] = new int[CondencedDNFTable.Length];
                Array.Clear(implicantMatrixTable[i], 0, implicantMatrixTable[i].Length);
            }

            bool included = false;
            for (int i = 0; i < implicantMatrixTable.Length; i++)//sdnfTable.length
            {
                for (int k = 0; k < CondencedDNFTable.Length; k++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if ((SDNFTable[i][j] == CondencedDNFTable[k][j]) || (CondencedDNFTable[k][j] == -1))
                        {
                            included = true;
                            continue;
                        }
                        else if (CondencedDNFTable[k][j] != SDNFTable[i][j])
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

            int[] container = new int[SDNFTable.Length];
            int n = 0;
            implicantMatrixResult = new string[(int)((double)CondencedDNFTable.Length / 2 * (CondencedDNFTable.Length - 1))];

            for (int t = 0; t < CondencedDNFTable.Length; t++)
            {
                for (int k = 1; k < CondencedDNFTable.Length - 1; k++)
                {
                    for (int f = 2; f < CondencedDNFTable.Length - 2; f++)
                    {
                        for (int i = 0; i < SDNFTable.Length; i++)
                        {
                            container[i] = implicantMatrixTable[i][t] + implicantMatrixTable[i][k] + implicantMatrixTable[i][f];
                        }

                        int count = 0;
                        for (int p = 0; p < container.Length; p++)
                        {
                            if (container[p] > 0)                           
                                count++;                          
                        }

                        if (implicantMatrixResult.Length > n)
                        {
                            if (count == container.Length)
                            {
                                implicantMatrixResult[n] = GetItem(t, CondencedDNFTable) + " v " + GetItem(k, CondencedDNFTable) + " v " + GetItem(f, CondencedDNFTable);
                                n++;
                            }
                        }
                        else break;
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
            implicantTestingTable = new int[CondencedDNFTable.Length][];
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
            for (int i = 0; i < CondencedDNFTable.Length; i++)
            {
                for (int t = 0; t < CondencedDNFTable.Length; t++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (CondencedDNFTable[i][j] == CondencedDNFTable[t][j] || CondencedDNFTable[i][j] == -1 || CondencedDNFTable[t][j] == -1)
                            included = true;
                        else
                        {
                            included = false;
                            break;
                        }
                    }
                    if (included == false)
                    {
                        for (int j = 0; j < 4; j++)
                            implicantTestingTable[k][j] = CondencedDNFTable[i][j];
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

        public void VeitchDiagrams()
        {

        }
    }
}


