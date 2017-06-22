namespace _1lab
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
            this.matrixSizeTextBox = new System.Windows.Forms.TextBox();
            this.MatrixCdataGridView = new System.Windows.Forms.DataGridView();
            this.SolveButton = new System.Windows.Forms.Button();
            this.resultTextBox = new System.Windows.Forms.RichTextBox();
            this.inverseMatrixCdataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MatrixCdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inverseMatrixCdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // matrixSizeTextBox
            // 
            this.matrixSizeTextBox.Location = new System.Drawing.Point(12, 9);
            this.matrixSizeTextBox.Name = "matrixSizeTextBox";
            this.matrixSizeTextBox.Size = new System.Drawing.Size(100, 20);
            this.matrixSizeTextBox.TabIndex = 0;
            this.matrixSizeTextBox.Text = "3";
            this.matrixSizeTextBox.TextChanged += new System.EventHandler(this.matrixSizeTextBox_TextChanged);
            // 
            // MatrixCdataGridView
            // 
            this.MatrixCdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.MatrixCdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MatrixCdataGridView.Location = new System.Drawing.Point(12, 70);
            this.MatrixCdataGridView.Name = "MatrixCdataGridView";
            this.MatrixCdataGridView.Size = new System.Drawing.Size(192, 166);
            this.MatrixCdataGridView.TabIndex = 1;
            // 
            // SolveButton
            // 
            this.SolveButton.Location = new System.Drawing.Point(129, 7);
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(75, 23);
            this.SolveButton.TabIndex = 2;
            this.SolveButton.Text = "Решить";
            this.SolveButton.UseVisualStyleBackColor = true;
            this.SolveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // resultTextBox
            // 
            this.resultTextBox.Location = new System.Drawing.Point(242, 70);
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(233, 375);
            this.resultTextBox.TabIndex = 3;
            this.resultTextBox.Text = "";
            // 
            // inverseMatrixCdataGridView
            // 
            this.inverseMatrixCdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.inverseMatrixCdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inverseMatrixCdataGridView.Location = new System.Drawing.Point(12, 279);
            this.inverseMatrixCdataGridView.Name = "inverseMatrixCdataGridView";
            this.inverseMatrixCdataGridView.Size = new System.Drawing.Size(192, 166);
            this.inverseMatrixCdataGridView.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Исходная матрица";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Обратная матрица";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Подробное решение";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 457);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inverseMatrixCdataGridView);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.SolveButton);
            this.Controls.Add(this.MatrixCdataGridView);
            this.Controls.Add(this.matrixSizeTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.MatrixCdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inverseMatrixCdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox matrixSizeTextBox;
        private System.Windows.Forms.DataGridView MatrixCdataGridView;
        private System.Windows.Forms.Button SolveButton;
        private System.Windows.Forms.RichTextBox resultTextBox;
        private System.Windows.Forms.DataGridView inverseMatrixCdataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

