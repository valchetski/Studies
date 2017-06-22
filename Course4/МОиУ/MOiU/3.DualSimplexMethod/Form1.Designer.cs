namespace _3.DualSimplexMethod
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.matrixAdataGridView = new System.Windows.Forms.DataGridView();
            this.vectorBdataGridView = new System.Windows.Forms.DataGridView();
            this.vectorCdataGridView = new System.Windows.Forms.DataGridView();
            this.A = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.jBdataGridView = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.columnsTextBox = new System.Windows.Forms.TextBox();
            this.rowsTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.reportRichTextBox = new System.Windows.Forms.RichTextBox();
            this.xResultDataGridView = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.yResultDataGridView = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.matrixAdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vectorBdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vectorCdataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jBdataGridView)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xResultDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yResultDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // matrixAdataGridView
            // 
            this.matrixAdataGridView.AllowUserToAddRows = false;
            this.matrixAdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.matrixAdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrixAdataGridView.ColumnHeadersVisible = false;
            this.matrixAdataGridView.Location = new System.Drawing.Point(24, 30);
            this.matrixAdataGridView.Name = "matrixAdataGridView";
            this.matrixAdataGridView.RowHeadersVisible = false;
            this.matrixAdataGridView.Size = new System.Drawing.Size(96, 150);
            this.matrixAdataGridView.TabIndex = 0;
            // 
            // vectorBdataGridView
            // 
            this.vectorBdataGridView.AllowUserToAddRows = false;
            this.vectorBdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.vectorBdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vectorBdataGridView.ColumnHeadersVisible = false;
            this.vectorBdataGridView.Location = new System.Drawing.Point(149, 30);
            this.vectorBdataGridView.Name = "vectorBdataGridView";
            this.vectorBdataGridView.RowHeadersVisible = false;
            this.vectorBdataGridView.Size = new System.Drawing.Size(48, 150);
            this.vectorBdataGridView.TabIndex = 1;
            // 
            // vectorCdataGridView
            // 
            this.vectorCdataGridView.AllowUserToAddRows = false;
            this.vectorCdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.vectorCdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vectorCdataGridView.ColumnHeadersVisible = false;
            this.vectorCdataGridView.Location = new System.Drawing.Point(235, 30);
            this.vectorCdataGridView.Name = "vectorCdataGridView";
            this.vectorCdataGridView.RowHeadersVisible = false;
            this.vectorCdataGridView.Size = new System.Drawing.Size(45, 150);
            this.vectorCdataGridView.TabIndex = 2;
            // 
            // A
            // 
            this.A.AutoSize = true;
            this.A.Location = new System.Drawing.Point(67, 14);
            this.A.Name = "A";
            this.A.Size = new System.Drawing.Size(14, 13);
            this.A.TabIndex = 3;
            this.A.Text = "A";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(168, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "b";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(252, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "c";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.jBdataGridView);
            this.panel1.Controls.Add(this.matrixAdataGridView);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.vectorBdataGridView);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.vectorCdataGridView);
            this.panel1.Controls.Add(this.A);
            this.panel1.Location = new System.Drawing.Point(223, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 191);
            this.panel1.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(321, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Jb";
            // 
            // jBdataGridView
            // 
            this.jBdataGridView.AllowUserToAddRows = false;
            this.jBdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.jBdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jBdataGridView.ColumnHeadersVisible = false;
            this.jBdataGridView.Location = new System.Drawing.Point(304, 30);
            this.jBdataGridView.Name = "jBdataGridView";
            this.jBdataGridView.RowHeadersVisible = false;
            this.jBdataGridView.Size = new System.Drawing.Size(49, 150);
            this.jBdataGridView.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.columnsTextBox);
            this.panel2.Controls.Add(this.rowsTextBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(13, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 190);
            this.panel2.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Решить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // columnsTextBox
            // 
            this.columnsTextBox.Location = new System.Drawing.Point(76, 46);
            this.columnsTextBox.Name = "columnsTextBox";
            this.columnsTextBox.Size = new System.Drawing.Size(100, 20);
            this.columnsTextBox.TabIndex = 3;
            this.columnsTextBox.TextChanged += new System.EventHandler(this.columnsTextBox_TextChanged);
            // 
            // rowsTextBox
            // 
            this.rowsTextBox.Location = new System.Drawing.Point(76, 10);
            this.rowsTextBox.Name = "rowsTextBox";
            this.rowsTextBox.Size = new System.Drawing.Size(100, 20);
            this.rowsTextBox.TabIndex = 2;
            this.rowsTextBox.TextChanged += new System.EventHandler(this.rowsTextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Стобцы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Строки";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.yResultDataGridView);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.xResultDataGridView);
            this.groupBox1.Controls.Add(this.reportRichTextBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 233);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 244);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Результат";
            // 
            // reportRichTextBox
            // 
            this.reportRichTextBox.Location = new System.Drawing.Point(234, 51);
            this.reportRichTextBox.Name = "reportRichTextBox";
            this.reportRichTextBox.Size = new System.Drawing.Size(332, 187);
            this.reportRichTextBox.TabIndex = 2;
            this.reportRichTextBox.Text = "";
            // 
            // xResultDataGridView
            // 
            this.xResultDataGridView.AllowUserToAddRows = false;
            this.xResultDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.xResultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xResultDataGridView.ColumnHeadersVisible = false;
            this.xResultDataGridView.Location = new System.Drawing.Point(18, 51);
            this.xResultDataGridView.Name = "xResultDataGridView";
            this.xResultDataGridView.RowHeadersVisible = false;
            this.xResultDataGridView.Size = new System.Drawing.Size(83, 187);
            this.xResultDataGridView.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "x";
            // 
            // yResultDataGridView
            // 
            this.yResultDataGridView.AllowUserToAddRows = false;
            this.yResultDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.yResultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.yResultDataGridView.ColumnHeadersVisible = false;
            this.yResultDataGridView.Location = new System.Drawing.Point(117, 51);
            this.yResultDataGridView.Name = "yResultDataGridView";
            this.yResultDataGridView.RowHeadersVisible = false;
            this.yResultDataGridView.Size = new System.Drawing.Size(83, 187);
            this.yResultDataGridView.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(12, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "y";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 489);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.matrixAdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vectorBdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vectorCdataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jBdataGridView)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xResultDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yResultDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView matrixAdataGridView;
        private System.Windows.Forms.DataGridView vectorBdataGridView;
        private System.Windows.Forms.DataGridView vectorCdataGridView;
        private System.Windows.Forms.Label A;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox columnsTextBox;
        private System.Windows.Forms.TextBox rowsTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView jBdataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView yResultDataGridView;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView xResultDataGridView;
        private System.Windows.Forms.RichTextBox reportRichTextBox;
    }
}

