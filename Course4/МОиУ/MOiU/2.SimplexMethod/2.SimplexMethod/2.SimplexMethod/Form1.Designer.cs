namespace _2.SimplexMethod
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
            this.label1 = new System.Windows.Forms.Label();
            this.MatrixAdataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.vectorCdataGridView = new System.Windows.Forms.DataGridView();
            this.vectorXdataGridView = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rowsTextBox = new System.Windows.Forms.TextBox();
            this.columnsTextBox = new System.Windows.Forms.TextBox();
            this.solveButton = new System.Windows.Forms.Button();
            this.resultDataGridView = new System.Windows.Forms.DataGridView();
            this.reportRichTextBox = new System.Windows.Forms.RichTextBox();
            this.equationDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.VectorBdataGridView = new System.Windows.Forms.DataGridView();
            this.conditionDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.MatrixAdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vectorCdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vectorXdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equationDataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VectorBdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(271, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A";
            // 
            // MatrixAdataGridView
            // 
            this.MatrixAdataGridView.AllowUserToAddRows = false;
            this.MatrixAdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MatrixAdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatrixAdataGridView.Location = new System.Drawing.Point(201, 63);
            this.MatrixAdataGridView.Name = "MatrixAdataGridView";
            this.MatrixAdataGridView.RowHeadersVisible = false;
            this.MatrixAdataGridView.Size = new System.Drawing.Size(235, 150);
            this.MatrixAdataGridView.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(595, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "c";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(508, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "x";
            // 
            // vectorCdataGridView
            // 
            this.vectorCdataGridView.AllowUserToAddRows = false;
            this.vectorCdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.vectorCdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vectorCdataGridView.Location = new System.Drawing.Point(563, 50);
            this.vectorCdataGridView.Name = "vectorCdataGridView";
            this.vectorCdataGridView.RowHeadersVisible = false;
            this.vectorCdataGridView.Size = new System.Drawing.Size(76, 150);
            this.vectorCdataGridView.TabIndex = 4;
            // 
            // vectorXdataGridView
            // 
            this.vectorXdataGridView.AllowUserToAddRows = false;
            this.vectorXdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.vectorXdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.vectorXdataGridView.Location = new System.Drawing.Point(473, 63);
            this.vectorXdataGridView.Name = "vectorXdataGridView";
            this.vectorXdataGridView.RowHeadersVisible = false;
            this.vectorXdataGridView.Size = new System.Drawing.Size(75, 150);
            this.vectorXdataGridView.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Строки";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Столбцы";
            // 
            // rowsTextBox
            // 
            this.rowsTextBox.Location = new System.Drawing.Point(74, 50);
            this.rowsTextBox.Name = "rowsTextBox";
            this.rowsTextBox.Size = new System.Drawing.Size(100, 20);
            this.rowsTextBox.TabIndex = 8;
            this.rowsTextBox.Text = "3";
            this.rowsTextBox.TextChanged += new System.EventHandler(this.rowsTextBox_TextChanged);
            // 
            // columnsTextBox
            // 
            this.columnsTextBox.Location = new System.Drawing.Point(74, 76);
            this.columnsTextBox.Name = "columnsTextBox";
            this.columnsTextBox.Size = new System.Drawing.Size(100, 20);
            this.columnsTextBox.TabIndex = 9;
            this.columnsTextBox.Text = "2";
            this.columnsTextBox.TextChanged += new System.EventHandler(this.columnsTextBox_TextChanged);
            // 
            // solveButton
            // 
            this.solveButton.Location = new System.Drawing.Point(62, 129);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(75, 23);
            this.solveButton.TabIndex = 10;
            this.solveButton.Text = "Решить";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // resultDataGridView
            // 
            this.resultDataGridView.AllowUserToAddRows = false;
            this.resultDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDataGridView.ColumnHeadersVisible = false;
            this.resultDataGridView.Location = new System.Drawing.Point(6, 19);
            this.resultDataGridView.Name = "resultDataGridView";
            this.resultDataGridView.RowHeadersVisible = false;
            this.resultDataGridView.Size = new System.Drawing.Size(169, 161);
            this.resultDataGridView.TabIndex = 12;
            // 
            // reportRichTextBox
            // 
            this.reportRichTextBox.Location = new System.Drawing.Point(201, 19);
            this.reportRichTextBox.Name = "reportRichTextBox";
            this.reportRichTextBox.Size = new System.Drawing.Size(444, 161);
            this.reportRichTextBox.TabIndex = 13;
            this.reportRichTextBox.Text = "";
            // 
            // equationDataGridView
            // 
            this.equationDataGridView.AllowUserToAddRows = false;
            this.equationDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.equationDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equationDataGridView.Location = new System.Drawing.Point(210, 50);
            this.equationDataGridView.Name = "equationDataGridView";
            this.equationDataGridView.RowHeadersVisible = false;
            this.equationDataGridView.Size = new System.Drawing.Size(153, 150);
            this.equationDataGridView.TabIndex = 14;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.VectorBdataGridView);
            this.groupBox1.Controls.Add(this.conditionDataGridView);
            this.groupBox1.Controls.Add(this.vectorCdataGridView);
            this.groupBox1.Controls.Add(this.equationDataGridView);
            this.groupBox1.Controls.Add(this.solveButton);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.columnsTextBox);
            this.groupBox1.Controls.Add(this.rowsTextBox);
            this.groupBox1.Location = new System.Drawing.Point(18, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(675, 264);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Исходные данные";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(468, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "b";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(286, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "A";
            // 
            // VectorBdataGridView
            // 
            this.VectorBdataGridView.AllowUserToAddRows = false;
            this.VectorBdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.VectorBdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VectorBdataGridView.Location = new System.Drawing.Point(435, 50);
            this.VectorBdataGridView.Name = "VectorBdataGridView";
            this.VectorBdataGridView.RowHeadersVisible = false;
            this.VectorBdataGridView.Size = new System.Drawing.Size(85, 150);
            this.VectorBdataGridView.TabIndex = 16;
            // 
            // conditionDataGridView
            // 
            this.conditionDataGridView.AllowUserToAddRows = false;
            this.conditionDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.conditionDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.conditionDataGridView.Location = new System.Drawing.Point(360, 50);
            this.conditionDataGridView.Name = "conditionDataGridView";
            this.conditionDataGridView.RowHeadersVisible = false;
            this.conditionDataGridView.Size = new System.Drawing.Size(76, 150);
            this.conditionDataGridView.TabIndex = 15;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.resultDataGridView);
            this.groupBox2.Controls.Add(this.reportRichTextBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 524);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(681, 197);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Результаты";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.MatrixAdataGridView);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.vectorXdataGridView);
            this.groupBox3.Location = new System.Drawing.Point(18, 294);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(675, 224);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Каноническая форма";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 733);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MatrixAdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vectorCdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vectorXdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equationDataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VectorBdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.conditionDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView MatrixAdataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView vectorCdataGridView;
        private System.Windows.Forms.DataGridView vectorXdataGridView;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox rowsTextBox;
        private System.Windows.Forms.TextBox columnsTextBox;
        private System.Windows.Forms.Button solveButton;
        private System.Windows.Forms.DataGridView resultDataGridView;
        private System.Windows.Forms.RichTextBox reportRichTextBox;
        private System.Windows.Forms.DataGridView equationDataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView conditionDataGridView;
        private System.Windows.Forms.DataGridView VectorBdataGridView;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}

