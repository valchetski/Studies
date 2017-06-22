namespace MaximalLengthWay
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
            this.GraphdataGridView = new System.Windows.Forms.DataGridView();
            this.VerticiesCountTextBox = new System.Windows.Forms.TextBox();
            this.Verticieslabel = new System.Windows.Forms.Label();
            this.Solvebutton = new System.Windows.Forms.Button();
            this.GraphLabel = new System.Windows.Forms.Label();
            this.answerGroupBox.SuspendLayout();
            this.initialDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GraphdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // answerGroupBox
            // 
            this.answerGroupBox.Controls.Add(this.DetailedSolutionrichTextBox);
            this.answerGroupBox.Controls.Add(this.DetailedSolutionlabel);
            this.answerGroupBox.Location = new System.Drawing.Point(12, 308);
            this.answerGroupBox.Name = "answerGroupBox";
            this.answerGroupBox.Size = new System.Drawing.Size(825, 248);
            this.answerGroupBox.TabIndex = 49;
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
            this.initialDataGroupBox.Controls.Add(this.GraphdataGridView);
            this.initialDataGroupBox.Controls.Add(this.VerticiesCountTextBox);
            this.initialDataGroupBox.Controls.Add(this.Verticieslabel);
            this.initialDataGroupBox.Controls.Add(this.Solvebutton);
            this.initialDataGroupBox.Controls.Add(this.GraphLabel);
            this.initialDataGroupBox.Location = new System.Drawing.Point(12, 12);
            this.initialDataGroupBox.Name = "initialDataGroupBox";
            this.initialDataGroupBox.Size = new System.Drawing.Size(825, 290);
            this.initialDataGroupBox.TabIndex = 48;
            this.initialDataGroupBox.TabStop = false;
            this.initialDataGroupBox.Text = "Initial data";
            // 
            // GraphdataGridView
            // 
            this.GraphdataGridView.AllowUserToAddRows = false;
            this.GraphdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GraphdataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.GraphdataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.GraphdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GraphdataGridView.ColumnHeadersVisible = false;
            this.GraphdataGridView.Location = new System.Drawing.Point(9, 32);
            this.GraphdataGridView.Name = "GraphdataGridView";
            this.GraphdataGridView.RowHeadersVisible = false;
            this.GraphdataGridView.Size = new System.Drawing.Size(646, 248);
            this.GraphdataGridView.TabIndex = 54;
            // 
            // VerticiesCountTextBox
            // 
            this.VerticiesCountTextBox.Location = new System.Drawing.Point(718, 29);
            this.VerticiesCountTextBox.Name = "VerticiesCountTextBox";
            this.VerticiesCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.VerticiesCountTextBox.TabIndex = 47;
            this.VerticiesCountTextBox.TextChanged += new System.EventHandler(this.VerticiesCountTextBox_TextChanged);
            // 
            // Verticieslabel
            // 
            this.Verticieslabel.AutoSize = true;
            this.Verticieslabel.Location = new System.Drawing.Point(661, 32);
            this.Verticieslabel.Name = "Verticieslabel";
            this.Verticieslabel.Size = new System.Drawing.Size(50, 13);
            this.Verticieslabel.TabIndex = 46;
            this.Verticieslabel.Text = "Verticies:";
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
            // GraphLabel
            // 
            this.GraphLabel.AutoSize = true;
            this.GraphLabel.Location = new System.Drawing.Point(6, 16);
            this.GraphLabel.Name = "GraphLabel";
            this.GraphLabel.Size = new System.Drawing.Size(39, 13);
            this.GraphLabel.TabIndex = 48;
            this.GraphLabel.Text = "Graph:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 558);
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
            ((System.ComponentModel.ISupportInitialize)(this.GraphdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox answerGroupBox;
        private System.Windows.Forms.RichTextBox DetailedSolutionrichTextBox;
        private System.Windows.Forms.Label DetailedSolutionlabel;
        private System.Windows.Forms.GroupBox initialDataGroupBox;
        private System.Windows.Forms.DataGridView GraphdataGridView;
        private System.Windows.Forms.TextBox VerticiesCountTextBox;
        private System.Windows.Forms.Label Verticieslabel;
        private System.Windows.Forms.Button Solvebutton;
        private System.Windows.Forms.Label GraphLabel;
    }
}

