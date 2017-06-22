namespace ResourceAllocation
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
            this.SolveButton = new System.Windows.Forms.Button();
            this.InitialDataGridView = new System.Windows.Forms.DataGridView();
            this.ProcessesTextBox = new System.Windows.Forms.TextBox();
            this.CapacityTextBox = new System.Windows.Forms.TextBox();
            this.Processeslabel = new System.Windows.Forms.Label();
            this.Capacitylabel = new System.Windows.Forms.Label();
            this.initialDataGroupBox = new System.Windows.Forms.GroupBox();
            this.answerGroupBox = new System.Windows.Forms.GroupBox();
            this.DetailedSolutionrichTextBox = new System.Windows.Forms.RichTextBox();
            this.DetailedSolutionlabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.InitialDataGridView)).BeginInit();
            this.initialDataGroupBox.SuspendLayout();
            this.answerGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // SolveButton
            // 
            this.SolveButton.Location = new System.Drawing.Point(776, 78);
            this.SolveButton.Name = "SolveButton";
            this.SolveButton.Size = new System.Drawing.Size(100, 41);
            this.SolveButton.TabIndex = 21;
            this.SolveButton.Text = "Solve";
            this.SolveButton.UseVisualStyleBackColor = true;
            this.SolveButton.Click += new System.EventHandler(this.SolveButton_Click);
            // 
            // InitialDataGridView
            // 
            this.InitialDataGridView.AllowUserToAddRows = false;
            this.InitialDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.InitialDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.InitialDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.InitialDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InitialDataGridView.Location = new System.Drawing.Point(17, 16);
            this.InitialDataGridView.Name = "InitialDataGridView";
            this.InitialDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.InitialDataGridView.Size = new System.Drawing.Size(640, 215);
            this.InitialDataGridView.TabIndex = 20;
            // 
            // ProcessesTextBox
            // 
            this.ProcessesTextBox.Location = new System.Drawing.Point(777, 22);
            this.ProcessesTextBox.Name = "ProcessesTextBox";
            this.ProcessesTextBox.Size = new System.Drawing.Size(100, 20);
            this.ProcessesTextBox.TabIndex = 18;
            this.ProcessesTextBox.TextChanged += new System.EventHandler(this.ProcessesTextBox_TextChanged);
            // 
            // CapacityTextBox
            // 
            this.CapacityTextBox.Location = new System.Drawing.Point(777, 48);
            this.CapacityTextBox.Name = "CapacityTextBox";
            this.CapacityTextBox.Size = new System.Drawing.Size(100, 20);
            this.CapacityTextBox.TabIndex = 17;
            this.CapacityTextBox.TextChanged += new System.EventHandler(this.CapacityTextBox_TextChanged);
            // 
            // Processeslabel
            // 
            this.Processeslabel.AutoSize = true;
            this.Processeslabel.Location = new System.Drawing.Point(695, 25);
            this.Processeslabel.Name = "Processeslabel";
            this.Processeslabel.Size = new System.Drawing.Size(76, 13);
            this.Processeslabel.TabIndex = 16;
            this.Processeslabel.Text = "Processes (N):";
            // 
            // Capacitylabel
            // 
            this.Capacitylabel.AutoSize = true;
            this.Capacitylabel.Location = new System.Drawing.Point(704, 48);
            this.Capacitylabel.Name = "Capacitylabel";
            this.Capacitylabel.Size = new System.Drawing.Size(67, 13);
            this.Capacitylabel.TabIndex = 15;
            this.Capacitylabel.Text = "Capacity (C):";
            // 
            // initialDataGroupBox
            // 
            this.initialDataGroupBox.Controls.Add(this.InitialDataGridView);
            this.initialDataGroupBox.Controls.Add(this.SolveButton);
            this.initialDataGroupBox.Controls.Add(this.Capacitylabel);
            this.initialDataGroupBox.Controls.Add(this.ProcessesTextBox);
            this.initialDataGroupBox.Controls.Add(this.Processeslabel);
            this.initialDataGroupBox.Controls.Add(this.CapacityTextBox);
            this.initialDataGroupBox.Location = new System.Drawing.Point(4, 4);
            this.initialDataGroupBox.Name = "initialDataGroupBox";
            this.initialDataGroupBox.Size = new System.Drawing.Size(884, 245);
            this.initialDataGroupBox.TabIndex = 38;
            this.initialDataGroupBox.TabStop = false;
            this.initialDataGroupBox.Text = "Initial data";
            // 
            // answerGroupBox
            // 
            this.answerGroupBox.Controls.Add(this.DetailedSolutionrichTextBox);
            this.answerGroupBox.Controls.Add(this.DetailedSolutionlabel);
            this.answerGroupBox.Location = new System.Drawing.Point(4, 255);
            this.answerGroupBox.Name = "answerGroupBox";
            this.answerGroupBox.Size = new System.Drawing.Size(884, 245);
            this.answerGroupBox.TabIndex = 43;
            this.answerGroupBox.TabStop = false;
            this.answerGroupBox.Text = "Solution";
            // 
            // DetailedSolutionrichTextBox
            // 
            this.DetailedSolutionrichTextBox.Location = new System.Drawing.Point(29, 35);
            this.DetailedSolutionrichTextBox.Name = "DetailedSolutionrichTextBox";
            this.DetailedSolutionrichTextBox.ReadOnly = true;
            this.DetailedSolutionrichTextBox.Size = new System.Drawing.Size(847, 195);
            this.DetailedSolutionrichTextBox.TabIndex = 33;
            this.DetailedSolutionrichTextBox.Text = "";
            // 
            // DetailedSolutionlabel
            // 
            this.DetailedSolutionlabel.AutoSize = true;
            this.DetailedSolutionlabel.Location = new System.Drawing.Point(26, 19);
            this.DetailedSolutionlabel.Name = "DetailedSolutionlabel";
            this.DetailedSolutionlabel.Size = new System.Drawing.Size(88, 13);
            this.DetailedSolutionlabel.TabIndex = 34;
            this.DetailedSolutionlabel.Text = "Detailed solution:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 505);
            this.Controls.Add(this.answerGroupBox);
            this.Controls.Add(this.initialDataGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.InitialDataGridView)).EndInit();
            this.initialDataGroupBox.ResumeLayout(false);
            this.initialDataGroupBox.PerformLayout();
            this.answerGroupBox.ResumeLayout(false);
            this.answerGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SolveButton;
        private System.Windows.Forms.DataGridView InitialDataGridView;
        private System.Windows.Forms.TextBox ProcessesTextBox;
        private System.Windows.Forms.TextBox CapacityTextBox;
        private System.Windows.Forms.Label Processeslabel;
        private System.Windows.Forms.Label Capacitylabel;
        private System.Windows.Forms.GroupBox initialDataGroupBox;
        private System.Windows.Forms.GroupBox answerGroupBox;
        private System.Windows.Forms.RichTextBox DetailedSolutionrichTextBox;
        private System.Windows.Forms.Label DetailedSolutionlabel;
    }
}

