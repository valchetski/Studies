namespace TravellingSalesmanProblem
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
            this.answerGroupBox = new System.Windows.Forms.GroupBox();
            this.DetailedSolutionrichTextBox = new System.Windows.Forms.RichTextBox();
            this.DetailedSolutionlabel = new System.Windows.Forms.Label();
            this.initialDataGroupBox = new System.Windows.Forms.GroupBox();
            this.CostdataGridView = new System.Windows.Forms.DataGridView();
            this.NTextBox = new System.Windows.Forms.TextBox();
            this.Nlabel = new System.Windows.Forms.Label();
            this.Solvebutton = new System.Windows.Forms.Button();
            this.CostLabel = new System.Windows.Forms.Label();
            this.answerGroupBox.SuspendLayout();
            this.initialDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CostdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // answerGroupBox
            // 
            this.answerGroupBox.Controls.Add(this.DetailedSolutionrichTextBox);
            this.answerGroupBox.Controls.Add(this.DetailedSolutionlabel);
            this.answerGroupBox.Location = new System.Drawing.Point(3, 298);
            this.answerGroupBox.Name = "answerGroupBox";
            this.answerGroupBox.Size = new System.Drawing.Size(825, 248);
            this.answerGroupBox.TabIndex = 53;
            this.answerGroupBox.TabStop = false;
            this.answerGroupBox.Text = "Solution";
            // 
            // DetailedSolutionrichTextBox
            // 
            this.DetailedSolutionrichTextBox.Location = new System.Drawing.Point(29, 35);
            this.DetailedSolutionrichTextBox.Name = "DetailedSolutionrichTextBox";
            this.DetailedSolutionrichTextBox.ReadOnly = true;
            this.DetailedSolutionrichTextBox.Size = new System.Drawing.Size(789, 207);
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
            // initialDataGroupBox
            // 
            this.initialDataGroupBox.Controls.Add(this.CostdataGridView);
            this.initialDataGroupBox.Controls.Add(this.NTextBox);
            this.initialDataGroupBox.Controls.Add(this.Nlabel);
            this.initialDataGroupBox.Controls.Add(this.Solvebutton);
            this.initialDataGroupBox.Controls.Add(this.CostLabel);
            this.initialDataGroupBox.Location = new System.Drawing.Point(3, 2);
            this.initialDataGroupBox.Name = "initialDataGroupBox";
            this.initialDataGroupBox.Size = new System.Drawing.Size(825, 290);
            this.initialDataGroupBox.TabIndex = 52;
            this.initialDataGroupBox.TabStop = false;
            this.initialDataGroupBox.Text = "Initial data";
            // 
            // CostdataGridView
            // 
            this.CostdataGridView.AllowUserToAddRows = false;
            this.CostdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CostdataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.CostdataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.CostdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CostdataGridView.ColumnHeadersVisible = false;
            this.CostdataGridView.Location = new System.Drawing.Point(9, 32);
            this.CostdataGridView.Name = "CostdataGridView";
            this.CostdataGridView.RowHeadersVisible = false;
            this.CostdataGridView.Size = new System.Drawing.Size(679, 248);
            this.CostdataGridView.TabIndex = 54;
            // 
            // NTextBox
            // 
            this.NTextBox.Location = new System.Drawing.Point(718, 29);
            this.NTextBox.Name = "NTextBox";
            this.NTextBox.Size = new System.Drawing.Size(100, 20);
            this.NTextBox.TabIndex = 47;
            this.NTextBox.TextChanged += new System.EventHandler(this.NTextBox_TextChanged);
            // 
            // Nlabel
            // 
            this.Nlabel.AutoSize = true;
            this.Nlabel.Location = new System.Drawing.Point(694, 32);
            this.Nlabel.Name = "Nlabel";
            this.Nlabel.Size = new System.Drawing.Size(18, 13);
            this.Nlabel.TabIndex = 46;
            this.Nlabel.Text = "N:";
            // 
            // Solvebutton
            // 
            this.Solvebutton.Location = new System.Drawing.Point(718, 55);
            this.Solvebutton.Name = "Solvebutton";
            this.Solvebutton.Size = new System.Drawing.Size(100, 37);
            this.Solvebutton.TabIndex = 44;
            this.Solvebutton.Text = "Solve";
            this.Solvebutton.UseVisualStyleBackColor = true;
            this.Solvebutton.Click += new System.EventHandler(this.Solvebutton_Click);
            // 
            // CostLabel
            // 
            this.CostLabel.AutoSize = true;
            this.CostLabel.Location = new System.Drawing.Point(6, 16);
            this.CostLabel.Name = "CostLabel";
            this.CostLabel.Size = new System.Drawing.Size(31, 13);
            this.CostLabel.TabIndex = 48;
            this.CostLabel.Text = "Cost:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 550);
            this.Controls.Add(this.answerGroupBox);
            this.Controls.Add(this.initialDataGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.answerGroupBox.ResumeLayout(false);
            this.answerGroupBox.PerformLayout();
            this.initialDataGroupBox.ResumeLayout(false);
            this.initialDataGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CostdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox answerGroupBox;
        private System.Windows.Forms.RichTextBox DetailedSolutionrichTextBox;
        private System.Windows.Forms.Label DetailedSolutionlabel;
        private System.Windows.Forms.GroupBox initialDataGroupBox;
        private System.Windows.Forms.DataGridView CostdataGridView;
        private System.Windows.Forms.TextBox NTextBox;
        private System.Windows.Forms.Label Nlabel;
        private System.Windows.Forms.Button Solvebutton;
        private System.Windows.Forms.Label CostLabel;
    }
}

