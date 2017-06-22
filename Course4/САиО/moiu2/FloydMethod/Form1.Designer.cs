namespace FloydMethod
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
            this.DdataGridView = new System.Windows.Forms.DataGridView();
            this.NTextBox = new System.Windows.Forms.TextBox();
            this.Nlabel = new System.Windows.Forms.Label();
            this.Solvebutton = new System.Windows.Forms.Button();
            this.DLabel = new System.Windows.Forms.Label();
            this.finishVertexTextBox = new System.Windows.Forms.TextBox();
            this.finishVertexLabel = new System.Windows.Forms.Label();
            this.startVertexTextBox = new System.Windows.Forms.TextBox();
            this.startVertexLabel = new System.Windows.Forms.Label();
            this.answerGroupBox.SuspendLayout();
            this.initialDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // answerGroupBox
            // 
            this.answerGroupBox.Controls.Add(this.DetailedSolutionrichTextBox);
            this.answerGroupBox.Controls.Add(this.DetailedSolutionlabel);
            this.answerGroupBox.Location = new System.Drawing.Point(3, 296);
            this.answerGroupBox.Name = "answerGroupBox";
            this.answerGroupBox.Size = new System.Drawing.Size(858, 248);
            this.answerGroupBox.TabIndex = 53;
            this.answerGroupBox.TabStop = false;
            this.answerGroupBox.Text = "Solution";
            // 
            // DetailedSolutionrichTextBox
            // 
            this.DetailedSolutionrichTextBox.Location = new System.Drawing.Point(29, 35);
            this.DetailedSolutionrichTextBox.Name = "DetailedSolutionrichTextBox";
            this.DetailedSolutionrichTextBox.ReadOnly = true;
            this.DetailedSolutionrichTextBox.Size = new System.Drawing.Size(822, 207);
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
            this.initialDataGroupBox.Controls.Add(this.finishVertexTextBox);
            this.initialDataGroupBox.Controls.Add(this.finishVertexLabel);
            this.initialDataGroupBox.Controls.Add(this.startVertexTextBox);
            this.initialDataGroupBox.Controls.Add(this.startVertexLabel);
            this.initialDataGroupBox.Controls.Add(this.DdataGridView);
            this.initialDataGroupBox.Controls.Add(this.NTextBox);
            this.initialDataGroupBox.Controls.Add(this.Nlabel);
            this.initialDataGroupBox.Controls.Add(this.Solvebutton);
            this.initialDataGroupBox.Controls.Add(this.DLabel);
            this.initialDataGroupBox.Location = new System.Drawing.Point(3, 0);
            this.initialDataGroupBox.Name = "initialDataGroupBox";
            this.initialDataGroupBox.Size = new System.Drawing.Size(858, 290);
            this.initialDataGroupBox.TabIndex = 52;
            this.initialDataGroupBox.TabStop = false;
            this.initialDataGroupBox.Text = "Initial data";
            // 
            // DdataGridView
            // 
            this.DdataGridView.AllowUserToAddRows = false;
            this.DdataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DdataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DdataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.DdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DdataGridView.ColumnHeadersVisible = false;
            this.DdataGridView.Location = new System.Drawing.Point(9, 32);
            this.DdataGridView.Name = "DdataGridView";
            this.DdataGridView.RowHeadersVisible = false;
            this.DdataGridView.Size = new System.Drawing.Size(679, 248);
            this.DdataGridView.TabIndex = 54;
            // 
            // NTextBox
            // 
            this.NTextBox.Location = new System.Drawing.Point(751, 32);
            this.NTextBox.Name = "NTextBox";
            this.NTextBox.Size = new System.Drawing.Size(100, 20);
            this.NTextBox.TabIndex = 47;
            this.NTextBox.TextChanged += new System.EventHandler(this.NTextBox_TextChanged);
            // 
            // Nlabel
            // 
            this.Nlabel.AutoSize = true;
            this.Nlabel.Location = new System.Drawing.Point(727, 35);
            this.Nlabel.Name = "Nlabel";
            this.Nlabel.Size = new System.Drawing.Size(18, 13);
            this.Nlabel.TabIndex = 46;
            this.Nlabel.Text = "N:";
            // 
            // Solvebutton
            // 
            this.Solvebutton.Location = new System.Drawing.Point(751, 110);
            this.Solvebutton.Name = "Solvebutton";
            this.Solvebutton.Size = new System.Drawing.Size(100, 37);
            this.Solvebutton.TabIndex = 44;
            this.Solvebutton.Text = "Solve";
            this.Solvebutton.UseVisualStyleBackColor = true;
            this.Solvebutton.Click += new System.EventHandler(this.Solvebutton_Click);
            // 
            // DLabel
            // 
            this.DLabel.AutoSize = true;
            this.DLabel.Location = new System.Drawing.Point(6, 16);
            this.DLabel.Name = "DLabel";
            this.DLabel.Size = new System.Drawing.Size(18, 13);
            this.DLabel.TabIndex = 48;
            this.DLabel.Text = "D:";
            // 
            // finishVertexTextBox
            // 
            this.finishVertexTextBox.Location = new System.Drawing.Point(764, 84);
            this.finishVertexTextBox.Name = "finishVertexTextBox";
            this.finishVertexTextBox.Size = new System.Drawing.Size(87, 20);
            this.finishVertexTextBox.TabIndex = 60;
            this.finishVertexTextBox.TextChanged += new System.EventHandler(this.finishVertexTextBox_TextChanged);
            // 
            // finishVertexLabel
            // 
            this.finishVertexLabel.AutoSize = true;
            this.finishVertexLabel.Location = new System.Drawing.Point(694, 87);
            this.finishVertexLabel.Name = "finishVertexLabel";
            this.finishVertexLabel.Size = new System.Drawing.Size(69, 13);
            this.finishVertexLabel.TabIndex = 59;
            this.finishVertexLabel.Text = "Finish vertex:";
            // 
            // startVertexTextBox
            // 
            this.startVertexTextBox.Location = new System.Drawing.Point(764, 58);
            this.startVertexTextBox.Name = "startVertexTextBox";
            this.startVertexTextBox.Size = new System.Drawing.Size(87, 20);
            this.startVertexTextBox.TabIndex = 58;
            this.startVertexTextBox.TextChanged += new System.EventHandler(this.startVertexTextBox_TextChanged);
            // 
            // startVertexLabel
            // 
            this.startVertexLabel.AutoSize = true;
            this.startVertexLabel.Location = new System.Drawing.Point(694, 61);
            this.startVertexLabel.Name = "startVertexLabel";
            this.startVertexLabel.Size = new System.Drawing.Size(64, 13);
            this.startVertexLabel.TabIndex = 57;
            this.startVertexLabel.Text = "Start vertex:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 545);
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
            ((System.ComponentModel.ISupportInitialize)(this.DdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox answerGroupBox;
        private System.Windows.Forms.RichTextBox DetailedSolutionrichTextBox;
        private System.Windows.Forms.Label DetailedSolutionlabel;
        private System.Windows.Forms.GroupBox initialDataGroupBox;
        private System.Windows.Forms.DataGridView DdataGridView;
        private System.Windows.Forms.TextBox NTextBox;
        private System.Windows.Forms.Label Nlabel;
        private System.Windows.Forms.Button Solvebutton;
        private System.Windows.Forms.Label DLabel;
        private System.Windows.Forms.TextBox finishVertexTextBox;
        private System.Windows.Forms.Label finishVertexLabel;
        private System.Windows.Forms.TextBox startVertexTextBox;
        private System.Windows.Forms.Label startVertexLabel;
    }
}

