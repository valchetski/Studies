using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minimizing_Methods
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Text = ""; label2.Width = 50;
            label3.Text = ""; label3.Width = 50;            
            label4.Text = ""; label4.Width = 50;
            label5.Text = ""; label5.Width = 50;
            label6.Text = ""; label6.Width = 50;
            label7.Text = ""; label7.Width = 50;
            label18.Text = ""; label19.Text = ""; label20.Text = ""; label21.Text = "";
            label22.Text = ""; label23.Text = ""; label24.Text = ""; label25.Text = "";
            label26.Text = ""; label27.Text = ""; label28.Text = ""; label29.Text = "";
            label30.Text = ""; label31.Text = ""; label32.Text = ""; label33.Text = "";
            label34.Text = "";
            label35.Text = "";
            dataGridView1.RowCount = 4;
            dataGridView1.ColumnCount = 16;         
            dataGridView1.Height = 115;
            dataGridView1.Width = 400;
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value;
            int value2;
            value = 52703;
            value2 = 33929;
            dataGridView1.Rows[0].HeaderCell.Value = "x1";
            dataGridView1.Rows[1].HeaderCell.Value = "x2";
            dataGridView1.Rows[2].HeaderCell.Value = "x3";
            dataGridView1.Rows[3].HeaderCell.Value = "x4";     
                       
            DNF dnf = new DNF(value);
            DNF dnf2=new DNF(value2);
            for (int i = 0; i < dnf.STable.Length; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    dataGridView1.Rows[j].Cells[i].Value = dnf.STable[i][j];
                }
                dataGridView1.Columns[i].Name = dnf.BTable[i].ToString();
            }
            dataGridView1.Rows[3].Cells[0].Value = '*';
            dataGridView1.Rows[3].Cells[5].Value = '*';
            dataGridView1.Rows[3].Cells[7].Value = '*';
            dataGridView1.Rows[3].Cells[14].Value = '*';

            //----------------------------------
            dnf.SDNF();
            dnf.CondencedDNF();
            dnf.ImplicantMatrix();
            dnf.ImplicantTesting();
            dnf2.SDNF();
            dnf2.CondencedDNF();
            dnf2.ImplicantMatrix();
            dnf2.ImplicantTesting();   
            label2.Text = "Совершенная ДНФ = " + dnf.GetString(dnf.GetSDNF);
            label3.Text = "Сокращенная СДНФ = " + dnf.GetString(dnf.GetCondencedDNF);
            label36.Text = "Совершенная ДНФ = " + dnf2.GetString(dnf2.GetSDNF);
            label37.Text = "Сокращенная СДНФ = " + dnf2.GetString(dnf2.GetCondencedDNF);
            dataGridView2.ColumnCount = dnf.SDNFDimension;
            dataGridView2.RowCount = dnf.GetCondencedDNF.Length;
            for (int i = 0; i < dnf.SDNFDimension; i++)
                dataGridView2.Columns[i].Name = dnf.GetItem(i, dnf.GetSDNF);
            for (int i = 0; i < dnf.GetCondencedDNF.Length; i++)
                dataGridView2.Rows[i].HeaderCell.Value = dnf.GetItem(i, dnf.GetCondencedDNF);
            for (int i = 0; i < dnf.GetImplicantMatrix.Length; i++)
            {
                for (int j = 0; j < dnf.GetImplicantMatrix[i].Length; j++)
                {
                    if (dnf.GetImplicantMatrix[i][j] == 1)
                        dataGridView2.Rows[j].Cells[i].Value = "*";
                }
            }
            label6.Text = "Тупиковая ДНФ = " + dnf.GetString(dnf.GetImplicantTesting);
            string s = "";
            for (int i = 0; i < dnf.GetImplicantMatrixResult.Length; i++)
            {
                s += dnf.GetImplicantMatrixResult[i] + "\n";
            }
            label34.Text = s;
            //---------------------------------------------------------------------
            dataGridView4.ColumnCount = dnf2.SDNFDimension;
            dataGridView4.RowCount = dnf2.GetCondencedDNF.Length;
            for (int i = 0; i < dnf2.SDNFDimension; i++)
                dataGridView4.Columns[i].Name = dnf2.GetItem(i, dnf2.GetSDNF);
            for (int i = 0; i < dnf2.GetCondencedDNF.Length; i++)
                dataGridView4.Rows[i].HeaderCell.Value = dnf2.GetItem(i, dnf2.GetCondencedDNF);
            for (int i = 0; i < dnf2.GetImplicantMatrix.Length; i++)
            {
                for (int j = 0; j < dnf2.GetImplicantMatrix[i].Length; j++)
                {
                    if (dnf2.GetImplicantMatrix[i][j] == 1)
                        dataGridView4.Rows[j].Cells[i].Value = "*";
                }
            }
            label39.Text = "Тупиковая ДНФ = " + dnf2.GetString(dnf.GetImplicantTesting);
            string t = "";
            for (int i = 0; i < dnf2.GetImplicantMatrixResult.Length; i++)
            {
                t += dnf2.GetImplicantMatrixResult[i] + "\n";
            }
            label41.Text = t;
            //---------------------------------------------------------------------------
            KNF knf = new KNF(value);
            KNF knf2=new KNF(value2);
            knf.SKNF();
            knf.CondencedKNF();       
            knf.ImplicantMatrix();
            knf.ImplicantTesting();
            knf2.SKNF();
            knf2.CondencedKNF();
            knf2.ImplicantMatrix();
            knf2.ImplicantTesting();
            label4.Text = "Совершенная КНФ = " + knf.GetString(knf.GetSKNF);
            label5.Text = "Сокращенная КНФ = " + knf.GetString(knf.GetCondencedKNF);
            label1.Text = "Совершенная КНФ = " + knf2.GetString(knf2.GetSKNF);
            label38.Text = "Сокращенная КНФ = " + knf2.GetString(knf2.GetCondencedKNF);
            dataGridView3.ColumnCount = knf.SKNFDimension;
            dataGridView3.RowCount = knf.GetCondencedKNF.Length;
            for (int i = 0; i < knf.SKNFDimension; i++)
                dataGridView3.Columns[i].Name = knf.GetItem(i, knf.GetSKNF);
            for (int i = 0; i < knf.GetCondencedKNF.Length; i++)
                dataGridView3.Rows[i].HeaderCell.Value = knf.GetItem(i, knf.GetCondencedKNF);

            for (int i = 0; i < knf.GetImplicantMatrix.Length; i++)
            {
                for (int j = 0; j < knf.GetImplicantMatrix[i].Length; j++)
                {
                    if (knf.GetImplicantMatrix[i][j] == 1)
                        dataGridView3.Rows[j].Cells[i].Value = "*";
                }
            }
            label7.Text = "Тупиковая КНФ = " + knf.GetString(knf.GetImplicantTesting);
             s = "";
            for (int i = 0; i < knf.GetImplicantMatrixResult.Length; i++)
            {
                s += knf.GetImplicantMatrixResult[i] + "\n";
            }
            label35.Text = s;
            //------------------------
            dataGridView5.ColumnCount = knf2.SKNFDimension;
            dataGridView5.RowCount = knf2.GetCondencedKNF.Length;
            for (int i = 0; i < knf2.SKNFDimension; i++)
                dataGridView5.Columns[i].Name = knf2.GetItem(i, knf2.GetSKNF);
            for (int i = 0; i < knf2.GetCondencedKNF.Length; i++)
                dataGridView5.Rows[i].HeaderCell.Value = knf2.GetItem(i, knf2.GetCondencedKNF);

            for (int i = 0; i < knf2.GetImplicantMatrix.Length; i++)
            {
                for (int j = 0; j < knf2.GetImplicantMatrix[i].Length; j++)
                {
                    if (knf2.GetImplicantMatrix[i][j] == 1)
                        dataGridView5.Rows[j].Cells[i].Value = "*";
                }
            }
            label40.Text = "Тупиковая КНФ = " + knf2.GetString(knf2.GetImplicantTesting);
            s = "";
            for (int i = 0; i < knf2.GetImplicantMatrixResult.Length; i++)
            {
                s += knf2.GetImplicantMatrixResult[i] + "\n";
            }

            label42.Text = s;
            //--------------------------------------
            label18.Text = dnf.BTable[12].ToString(); label19.Text = dnf.BTable[13].ToString(); label20.Text = dnf.BTable[9].ToString(); label21.Text = dnf.BTable[8].ToString();
            label22.Text = dnf.BTable[14].ToString(); label23.Text = dnf.BTable[15].ToString(); label24.Text = dnf.BTable[11].ToString(); label25.Text = dnf.BTable[10].ToString();
            label26.Text = dnf.BTable[6].ToString(); label27.Text = dnf.BTable[7].ToString(); label28.Text = dnf.BTable[3].ToString(); label29.Text = dnf.BTable[2].ToString();
            label30.Text = dnf.BTable[4].ToString(); label31.Text = dnf.BTable[5].ToString(); label32.Text = dnf.BTable[1].ToString(); label33.Text = dnf.BTable[0].ToString();
        }                                                              

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }     
    }
}
