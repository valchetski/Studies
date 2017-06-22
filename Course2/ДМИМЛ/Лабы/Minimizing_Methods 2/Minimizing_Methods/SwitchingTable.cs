using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minimizing_Methods
{
    class SwitchingTable
    {
        private static int[][] switchingTable = new int[16][];
        private int[] binaryTable = new int[16];
       
        public int[] BTable
        {
            get { return binaryTable;  }
        }

        public int[][] STable
        {
            get { return switchingTable; }
        }

        public SwitchingTable(int value)
        {
            for (int i = 0; i < switchingTable.Length; i++)
            {
                switchingTable[i] = new int[4];
                Array.Clear(switchingTable[i], 0, switchingTable[i].Length);
            }

            for (int i = 1; i < switchingTable.Length; i += 2)
            {
                switchingTable[i][3] = 1;
            }

            for (int i = 2; i < switchingTable.Length; i += 4)
            {
                switchingTable[i][2] = 1;
                switchingTable[i + 1][2] = 1;
            }

            for (int i = 4; i < switchingTable.Length; i += 8)
            {
                switchingTable[i][1] = 1;
                switchingTable[i + 1][1] = 1;
                switchingTable[i + 2][1] = 1;
                switchingTable[i + 3][1] = 1;
            }

            for (int i = 8; i < switchingTable.Length; i++)
            {
                switchingTable[i][0] = 1;
            }
            
            Array.Clear(binaryTable, 0, binaryTable.Length);
            int j = binaryTable.Length - 1;
            int modulo = 0;
            int quotient = value;
            while (quotient != 0)
            {
                modulo = quotient % 2;
                binaryTable[j] = modulo;
                j--;
                quotient /= 2;
            }           
        }
    }
}
