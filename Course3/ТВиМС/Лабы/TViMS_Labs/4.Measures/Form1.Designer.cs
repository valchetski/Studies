using Lab4.TableElements;

namespace Lab4
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.graphControl1 = new ZedGraph.ZedGraphControl();
            this.graphControl2 = new ZedGraph.ZedGraphControl();
            this.graphControl3 = new ZedGraph.ZedGraphControl();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupTableElementLab4BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupTableElementLab4BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "n = ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(50, 20);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(32, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "200";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 10);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 28);
            this.button1.TabIndex = 11;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 86);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(229, 284);
            this.dataGridView1.TabIndex = 12;
            // 
            // graphControl1
            // 
            this.graphControl1.Location = new System.Drawing.Point(369, 17);
            this.graphControl1.Name = "graphControl1";
            this.graphControl1.ScrollGrace = 0D;
            this.graphControl1.ScrollMaxX = 0D;
            this.graphControl1.ScrollMaxY = 0D;
            this.graphControl1.ScrollMaxY2 = 0D;
            this.graphControl1.ScrollMinX = 0D;
            this.graphControl1.ScrollMinY = 0D;
            this.graphControl1.ScrollMinY2 = 0D;
            this.graphControl1.Size = new System.Drawing.Size(476, 357);
            this.graphControl1.TabIndex = 14;
            // 
            // graphControl2
            // 
            this.graphControl2.Location = new System.Drawing.Point(297, 23);
            this.graphControl2.Name = "graphControl2";
            this.graphControl2.ScrollGrace = 0D;
            this.graphControl2.ScrollMaxX = 0D;
            this.graphControl2.ScrollMaxY = 0D;
            this.graphControl2.ScrollMaxY2 = 0D;
            this.graphControl2.ScrollMinX = 0D;
            this.graphControl2.ScrollMinY = 0D;
            this.graphControl2.ScrollMinY2 = 0D;
            this.graphControl2.Size = new System.Drawing.Size(549, 347);
            this.graphControl2.TabIndex = 13;
            // 
            // graphControl3
            // 
            this.graphControl3.Location = new System.Drawing.Point(312, 25);
            this.graphControl3.Name = "graphControl3";
            this.graphControl3.ScrollGrace = 0D;
            this.graphControl3.ScrollMaxX = 0D;
            this.graphControl3.ScrollMaxY = 0D;
            this.graphControl3.ScrollMaxY2 = 0D;
            this.graphControl3.ScrollMinX = 0D;
            this.graphControl3.ScrollMinY = 0D;
            this.graphControl3.ScrollMinY2 = 0D;
            this.graphControl3.Size = new System.Drawing.Size(536, 346);
            this.graphControl3.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 23);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Measure:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(141, 20);
            this.textBox4.Margin = new System.Windows.Forms.Padding(2);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(50, 20);
            this.textBox4.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(195, 23);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "k =";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(221, 20);
            this.textBox5.Margin = new System.Windows.Forms.Padding(2);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(32, 20);
            this.textBox5.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "n = ";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(49, 17);
            this.textBox6.Margin = new System.Windows.Forms.Padding(2);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(33, 20);
            this.textBox6.TabIndex = 20;
            this.textBox6.Text = "30";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(20, 86);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(318, 288);
            this.dataGridView2.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(207, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Measure:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(262, 17);
            this.textBox7.Margin = new System.Windows.Forms.Padding(2);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(76, 20);
            this.textBox7.TabIndex = 23;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(129, 17);
            this.textBox8.Margin = new System.Windows.Forms.Padding(2);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(74, 20);
            this.textBox8.TabIndex = 24;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(95, 20);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Dn =";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 27);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "n =";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(52, 25);
            this.textBox9.Margin = new System.Windows.Forms.Padding(2);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(39, 20);
            this.textBox9.TabIndex = 27;
            this.textBox9.Text = "50";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(23, 89);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.RowTemplate.Height = 24;
            this.dataGridView3.Size = new System.Drawing.Size(253, 282);
            this.dataGridView3.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(95, 28);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Measure:";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(150, 25);
            this.textBox10.Margin = new System.Windows.Forms.Padding(2);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(76, 20);
            this.textBox10.TabIndex = 30;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(876, 413);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.textBox5);
            this.tabPage1.Controls.Add(this.graphControl2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(868, 387);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pearson\'s measure";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.dataGridView2);
            this.tabPage2.Controls.Add(this.textBox8);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBox6);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.textBox7);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.graphControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(868, 387);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kolmogorov\'s measure";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.dataGridView3);
            this.tabPage3.Controls.Add(this.textBox10);
            this.tabPage3.Controls.Add(this.textBox9);
            this.tabPage3.Controls.Add(this.graphControl3);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(868, 387);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Mises\' measure";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "label1";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "label5";
            // 
            // groupTableElementLab4BindingSource
            // 
            this.groupTableElementLab4BindingSource.DataSource = typeof(Lab4.TableElements.GroupTableElement);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "label6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 469);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "4.Measures";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupTableElementLab4BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private ZedGraph.ZedGraphControl graphControl1;
        private ZedGraph.ZedGraphControl graphControl2;
        private ZedGraph.ZedGraphControl graphControl3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.BindingSource groupTableElementLab4BindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

