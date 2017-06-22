using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace diskretka1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();
            textBox1.Text = "33929";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            InitializeDataGridView();
            int a = 0, i = 16, j = 0;
            try
            {
                a = int.Parse(textBox1.Text);
                a = 13866;
            }
            catch (FormatException)
            {
                MessageBox.Show("Неправильный ввод", "Ошибка!");
                return;
            }
            if ((a > 65535) || (0 > a))
            {
                MessageBox.Show("Введите число от 0 до 65535");
                return;
            }
            string[] mas = new string[16];
            List<List<string>> list = new List<List<string>>();
            List<string> list1;
            //  int[] mas1 = new int[4];

            while (a > 0)
            {
                i--;
                mas[i] = (a % 2).ToString();
                a = a / 2;
            }
            for (j = 0; j < i; j++)
            {
                mas[j] = 0.ToString();
            }
            dataGridView1.Rows.Add(new string[] { "1", "*", "*", "*", "0", "1", "0", "0", "1", "0", "*", "0", "1", "*", "*", "1" });
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView2.Rows.Add(new string[] { "", "!x1!x2!x3!x4", "!x1x2!x3x4", "x1!x2!x3!x4", "x1x2!x3!x4", "x1x2x3x4"});
            dataGridView2.Rows.Add(new string[] { "x1x2", "", "", "", "+", "+"});
            dataGridView2.Rows.Add(new string[] { "!x!x2", "+", "", "", "", ""});
            dataGridView2.Rows.Add(new string[] { "x1!x4", "", "", "+", "+", "" });
            dataGridView2.Rows.Add(new string[] { "!x2!x4", "+", "", "+", "", ""});
            dataGridView2.Rows.Add(new string[] { "!x1!x3x4", "", "+", "", "", ""});
            dataGridView2.Rows.Add(new string[] { "x2!x3x4", "", "+", "", "", ""});
            dataGridView3.Rows.Add(new string[] { "", "!x1Ux2U!x3U!x4", "!x1Ux2Ux3U!x4", "!x1Ux2Ux3Ux4", "x1U!x2U!x3Ux4", "x1U!x2Ux3Ux4"});
            dataGridView3.Rows.Add(new string[] { "!x2Ux4", "", "", "", "+", "+"});
            dataGridView3.Rows.Add(new string[] { "!x1Ux3", "", "+", "+", "", ""});
            dataGridView3.Rows.Add(new string[] { "!x2Ux3", "", "", "", "", "+"});
            dataGridView3.Rows.Add(new string[] { "x3U!x4", "", "+", "", "", ""});
            dataGridView3.Rows.Add(new string[] { "!x1Ux2U!x4", "+", "+", "", "", ""});
            dataGridView3.Rows.Add(new string[] { "x1U!x3Ux4", "", "", "", "+", ""});
            textBox2.Text = "!x1!x2!x3!x4U!x1!x2!x3x4U!x1!x2x3!x4U!x1!x2x3x4U!x1x2!x3x4Ux1!x2!x3!x4Ux1!x2x3!x4Ux1x2!x3!x4Ux1x2!x3x4Ux1x2x3!x4Ux1x2x3x4";
            textBox3.Text="!x1!x2!x3!x4U!x1x2!x3x4Ux1!x2!x3!x4Ux1x2!x3!x4Ux1x2x3x4";
            textBox5.Text="(!x1Ux2U!x3U!x4)(!x1Ux2Ux3U!x4)(!x1Ux2Ux3Ux4)(x1U!x2U!x3Ux4)(x1U!x2Ux3Ux4)";
            textBox4.Text ="(!x1U!x2U!x3Ux4)(!x1U!x2Ux3U!x4)(!x1U!x2Ux3Ux4)(!x1Ux2U!x3U!x4)(!x1Ux2Ux3U!x4)(!x1Ux2Ux3Ux4)(x1U!x2U!x3Ux4)(x1U!x2Ux3U!x4)(x1U!x2Ux3Ux4)(x1Ux2U!x3Ux4)(x1Ux2Ux3U!x4)";
            textBox9.Text = "x1x2U!x1!x2Ux1!x4U!x2!x4U!x1!x3x4Ux2!x3x4";
            textBox8.Text = "(!x2Ux4)(!x1Ux3)(!x2Ux3)(x3U!x4)(!x1Ux2U!x4)(x1U!x3Ux4)";
            textBox6.Text = "x1x2U!x2!x4Ux2!x3x4";
            textBox7.Text = "(!x2Ux4)(!x1Ux3)(!x1Ux2U!x4)";


          /*  string s = "";
            int k = 0;

            for (i = 0; i < 16; i++)
            {
                if (int.Parse(mas[i]) == 1)
                {
                    k++;
                    list1 = new List<string>();
                    for (j = 1; j < 5; j++)
                    {
                        if (dataGridView1[i, j - 1].Value == "0")
                        {
                            s += "!x" + j.ToString();
                            list1.Add("!x" + j.ToString());
                        }
                        else
                        {
                            s += "x" + j.ToString();
                            list1.Add("x" + j.ToString());
                        }


                    }
                    s += "U";
                    list.Add(list1);

                }
            }
            textBox2.Text = s.Remove(s.Length - 1);
            //1        
            int number = 0;
            string y = "";
            int q = 4;
            bool v = false;
            List<int> t = new List<int>();
            while (q > 1)
            {
                t.Clear();
                List<List<string>> list2 = new List<List<string>>();

                foreach (var x in list)
                {
                    list1 = new List<string>();
                    foreach (var h in x)
                    {
                        list1.Add(h);
                    }
                    list2.Add(list1);
                }
                foreach (var z in list)
                {
                    if (z.Count() == q)

                        if (z != list[list.Count - 1])
                        {
                            i = list.IndexOf(z);
                            while (i + 1 < list.Count)
                            {
                                i++;
                                j = 0;
                                number = 0;
                                list1 = new List<string>();
                                v = false;
                                while (j < list[i].Count)
                                {
                                    if (z[j] != list[i][j])
                                    {
                                        if (z[j].IndexOf(list[i][j]) == 1 || list[i][j].IndexOf(z[j]) == 1)
                                            v = true;
                                        number++;
                                        y = list[i][j];
                                    }
                                    if (number > 1)
                                        break;
                                    j++;
                                    if (list[i].Count != q)
                                        break;
                                }
                                /*  if (number > 1)
                                  {
                                      foreach (var f in list[i])
                                          list1.Add(f);
                                      list2.Add(list1);
                                  }
                                if (number == 1)
                                    if (v)
                                    {
                                        foreach (var f in list[i])
                                            list1.Add(f);
                                        list1.Remove(y);
                                        list2.Add(list1);
                                        if (!t.Contains(list.IndexOf(z)))
                                            t.Add(list.IndexOf(z));
                                        if (!t.Contains(i))
                                            t.Add(i);
                                    }


                            }

                        }


                }
                t.Sort();
                int p = 0;
                foreach (var m in t)
                {
                    list2.Remove(list2[m - p++]);

                }

                list = list2;
                q--;
            }
            s = "";
            string str = "";
            foreach (var o in list)
            {

                foreach (var b in o)
                {
                    str += b;
                }
                str += "U";
                // var bn = s.IndexOf(str);
                if (s.IndexOf(str) < 0)
                    s += str;
                str = "";
            }
            //2
            textBox5.Text = s;
            s = "";

            for (i = 0; i < 16; i++)
            {
                if (int.Parse(mas[i]) == 0)
                {
                    s += "(";
                    for (j = 1; j < 5; j++)
                    {
                        if (dataGridView1[i, j - 1].Value == "0")
                            s += "!x" + j.ToString();
                        else s += "x" + j.ToString();
                        if (j != 4)
                            s += "U";
                    }
                    s += ") ";

                }
            }
            textBox3.Text = s.Remove(s.Length - 1);
*/

        }

        public void InitializeDataGridView()
        {
            // Populate the rows.
            string[] row1 = new string[] { "0", "0", "0", "0", "0", "0", "0", "0", "1", "1", "1", "1", "1", "1", "1", "1" };
            string[] row2 = new string[] { "0", "0", "0", "0", "1", "1", "1", "1", "0", "0", "0", "0", "1", "1", "1", "1" };
            string[] row3 = new string[] { "0", "0", "1", "1", "0", "0", "1", "1", "0", "0", "1", "1", "0", "0", "1", "1" };
            string[] row4 = new string[] { "0", "1", "0", "1", "0", "1", "0", "1", "0", "1", "0", "1", "0", "1", "0", "1" };
            object[] rows = new object[] { row1, row2, row3, row4 };

            foreach (string[] rowArray in rows)
            {
                dataGridView1.Rows.Add(rowArray);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             dataGridView1.Rows.Clear();
            InitializeDataGridView();
            int a = 0, i = 16, j = 0;
            try
            {
                a = int.Parse(textBox1.Text);
                a = 13866;
            }
            catch (FormatException)
            {
                MessageBox.Show("Неправильный ввод", "Ошибка!");
                return;
            }
            if ((a > 65535) || (0 > a))
            {
                MessageBox.Show("Введите число от 0 до 65535");
                return;
            }
            string[] mas = new string[16];
            List<List<string>> list = new List<List<string>>();
            List<string> list1;
            //  int[] mas1 = new int[4];

            while (a > 0)
            {
                i--;
                mas[i] = (a % 2).ToString();
                a = a / 2;
            }
            for (j = 0; j < i; j++)
            {
                mas[j] = 0.ToString();
            }
            dataGridView1.Rows.Add(new string[] { "0", "*", "*", "*", "1", "0", "1", "1", "0", "1", "*", "1", "0", "*", "*", "0" });
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView3.Rows.Add(new string[] { "", "!x1U!x2U!x3U!x4", "!x1Ux2U!x3Ux4", "x1U!x2U!x3U!x4", "x1Ux2U!x3U!x4", "x1Ux2Ux3Ux4"});
            dataGridView3.Rows.Add(new string[] { "x1Ux2", "", "", "", "+", "+"});
            dataGridView3.Rows.Add(new string[] { "!xU!x2", "+", "", "", "", ""});
            dataGridView3.Rows.Add(new string[] { "x1U!x4", "", "", "+", "+", "" });
            dataGridView3.Rows.Add(new string[] { "!x2U!x4", "+", "", "+", "", ""});
            dataGridView3.Rows.Add(new string[] { "!x1U!x3Ux4", "", "+", "", "", ""});
            dataGridView3.Rows.Add(new string[] { "x2U!x3Ux4", "", "+", "", "", ""});
            dataGridView2.Rows.Add(new string[] { "", "!x1x2!x3!x4", "!x1x2x3!x4", "!x1x2x3x4", "x1!x2!x3x4", "x1!x2x3x4"});
            dataGridView2.Rows.Add(new string[] { "!x2x4", "", "", "", "+", "+"});
            dataGridView2.Rows.Add(new string[] { "!x1x3", "", "+", "+", "", ""});
            dataGridView2.Rows.Add(new string[] { "!x2x3", "", "", "", "", "+"});
            dataGridView2.Rows.Add(new string[] { "x3!x4", "", "+", "", "", ""});
            dataGridView2.Rows.Add(new string[] { "!x1x2!x4", "+", "+", "", "", ""});
            dataGridView2.Rows.Add(new string[] { "x1!x3x4", "", "", "", "+", ""});
            textBox4.Text = "(!x1u!x2U!x3U!x4)(!x1U!x2U!x3Ux4)(!x1U!x2Ux3U!x4)(!x1U!x2Ux3Ux4)(!x1Ux2U!x3Ux4)(x1U!x2U!x3U!x4)(x1U!x2Ux3U!x4)(x1Ux2U!x3U!x4)(x1Ux2U!x3Ux4)(x1Ux2Ux3U!x4)(x1Ux2Ux3Ux4)";
            textBox5.Text="(!x1U!x2U!x3U!x4)(!x1Ux2U!x3Ux4)(x1U!x2U!x3U!x4)(x1Ux2U!x3U!x4)(x1Ux2Ux3Ux4)";
            textBox3.Text="!x1x2!x3!x4U!x1x2x3!x4U!x1x2x3x4Ux1!x2!x3x4Ux1!x2x3x4";
            textBox2.Text ="!x1!x2!x3x4U!x1!x2x3!x4U!x1!x2x3x4U!x1x2!x3!x4U!x1x2x3!x4U!x1x2x3x4Ux1!x2!x3x4Ux1!x2x3!x4Ux1!x2x3x4Ux1x2!x3x4Ux1x2x3!x4";
            textBox8.Text = "(x1Ux2)(!x1U!x2)(x1U!x4)(!x2U!x4)(!x1U!x3Ux4)(x2U!x3Ux4)";
            textBox9.Text = "!x2x4U!x1x3U!x2x3Ux3!x4U!x1x2!x4Ux1!x3x4";
            textBox7.Text = "(x1Ux2)(!x2U!x4)(x2U!x3Ux4)";
            textBox6.Text = "!x2x4U!x1x3U!x1x2!x4";


          /*  string s = "";
            int k = 0;

            for (i = 0; i < 16; i++)
            {
                if (int.Parse(mas[i]) == 1)
                {
                    k++;
                    list1 = new List<string>();
                    for (j = 1; j < 5; j++)
                    {
                        if (dataGridView1[i, j - 1].Value == "0")
                        {
                            s += "!x" + j.ToString();
                            list1.Add("!x" + j.ToString());
                        }
                        else
                        {
                            s += "x" + j.ToString();
                            list1.Add("x" + j.ToString());
                        }


                    }
                    s += "U";
                    list.Add(list1);

                }
            }
            textBox2.Text = s.Remove(s.Length - 1);
            //1        
            int number = 0;
            string y = "";
            int q = 4;
            bool v = false;
            List<int> t = new List<int>();
            while (q > 1)
            {
                t.Clear();
                List<List<string>> list2 = new List<List<string>>();

                foreach (var x in list)
                {
                    list1 = new List<string>();
                    foreach (var h in x)
                    {
                        list1.Add(h);
                    }
                    list2.Add(list1);
                }
                foreach (var z in list)
                {
                    if (z.Count() == q)

                        if (z != list[list.Count - 1])
                        {
                            i = list.IndexOf(z);
                            while (i + 1 < list.Count)
                            {
                                i++;
                                j = 0;
                                number = 0;
                                list1 = new List<string>();
                                v = false;
                                while (j < list[i].Count)
                                {
                                    if (z[j] != list[i][j])
                                    {
                                        if (z[j].IndexOf(list[i][j]) == 1 || list[i][j].IndexOf(z[j]) == 1)
                                            v = true;
                                        number++;
                                        y = list[i][j];
                                    }
                                    if (number > 1)
                                        break;
                                    j++;
                                    if (list[i].Count != q)
                                        break;
                                }
                                /*  if (number > 1)
                                  {
                                      foreach (var f in list[i])
                                          list1.Add(f);
                                      list2.Add(list1);
                                  }
                                if (number == 1)
                                    if (v)
                                    {
                                        foreach (var f in list[i])
                                            list1.Add(f);
                                        list1.Remove(y);
                                        list2.Add(list1);
                                        if (!t.Contains(list.IndexOf(z)))
                                            t.Add(list.IndexOf(z));
                                        if (!t.Contains(i))
                                            t.Add(i);
                                    }


                            }

                        }


                }
                t.Sort();
                int p = 0;
                foreach (var m in t)
                {
                    list2.Remove(list2[m - p++]);

                }

                list = list2;
                q--;
            }
            s = "";
            string str = "";
            foreach (var o in list)
            {

                foreach (var b in o)
                {
                    str += b;
                }
                str += "U";
                // var bn = s.IndexOf(str);
                if (s.IndexOf(str) < 0)
                    s += str;
                str = "";
            }
            //2
            textBox5.Text = s;
            s = "";

            for (i = 0; i < 16; i++)
            {
                if (int.Parse(mas[i]) == 0)
                {
                    s += "(";
                    for (j = 1; j < 5; j++)
                    {
                        if (dataGridView1[i, j - 1].Value == "0")
                            s += "!x" + j.ToString();
                        else s += "x" + j.ToString();
                        if (j != 4)
                            s += "U";
                    }
                    s += ") ";

                }
            }
            textBox3.Text = s.Remove(s.Length - 1);
*/

        }

    }
}

