namespace MaximalFlowTask
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
            this.VerticiesCountTextBox = new System.Windows.Forms.TextBox();
            this.CapacityLabel = new System.Windows.Forms.Label();
            this.Verticieslabel = new System.Windows.Forms.Label();
            this.FlowLabel = new System.Windows.Forms.Label();
            this.Solvebutton = new System.Windows.Forms.Button();
            this.FlowDataGridView = new System.Windows.Forms.DataGridView();
            this.EdgesCountTextBox = new System.Windows.Forms.TextBox();
            this.CapacityDataGridView = new System.Windows.Forms.DataGridView();
            this.EdgesLabel = new System.Windows.Forms.Label();
            this.Tolabel = new System.Windows.Forms.Label();
            this.FromLabel = new System.Windows.Forms.Label();
            this.FromVerticiesDataGridView = new System.Windows.Forms.DataGridView();
            this.ToVerticiesDataGridView = new System.Windows.Forms.DataGridView();
            this.answerGroupBox.SuspendLayout();
            this.initialDataGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlowDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CapacityDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromVerticiesDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToVerticiesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // answerGroupBox
            // 
            this.answerGroupBox.Controls.Add(this.DetailedSolutionrichTextBox);
            this.answerGroupBox.Controls.Add(this.DetailedSolutionlabel);
            this.answerGroupBox.Location = new System.Drawing.Point(380, 17);
            this.answerGroupBox.Name = "answerGroupBox";
            this.answerGroupBox.Size = new System.Drawing.Size(746, 499);
            this.answerGroupBox.TabIndex = 47;
            this.answerGroupBox.TabStop = false;
            this.answerGroupBox.Text = "Solution";
            // 
            // DetailedSolutionrichTextBox
            // 
            this.DetailedSolutionrichTextBox.Location = new System.Drawing.Point(29, 35);
            this.DetailedSolutionrichTextBox.Name = "DetailedSolutionrichTextBox";
            this.DetailedSolutionrichTextBox.ReadOnly = true;
            this.DetailedSolutionrichTextBox.Size = new System.Drawing.Size(706, 458);
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
            this.initialDataGroupBox.Controls.Add(this.VerticiesCountTextBox);
            this.initialDataGroupBox.Controls.Add(this.CapacityLabel);
            this.initialDataGroupBox.Controls.Add(this.Verticieslabel);
            this.initialDataGroupBox.Controls.Add(this.FlowLabel);
            this.initialDataGroupBox.Controls.Add(this.Solvebutton);
            this.initialDataGroupBox.Controls.Add(this.FlowDataGridView);
            this.initialDataGroupBox.Controls.Add(this.EdgesCountTextBox);
            this.initialDataGroupBox.Controls.Add(this.CapacityDataGridView);
            this.initialDataGroupBox.Controls.Add(this.EdgesLabel);
            this.initialDataGroupBox.Controls.Add(this.Tolabel);
            this.initialDataGroupBox.Controls.Add(this.FromLabel);
            this.initialDataGroupBox.Controls.Add(this.FromVerticiesDataGridView);
            this.initialDataGroupBox.Controls.Add(this.ToVerticiesDataGridView);
            this.initialDataGroupBox.Location = new System.Drawing.Point(12, 9);
            this.initialDataGroupBox.Name = "initialDataGroupBox";
            this.initialDataGroupBox.Size = new System.Drawing.Size(352, 507);
            this.initialDataGroupBox.TabIndex = 46;
            this.initialDataGroupBox.TabStop = false;
            this.initialDataGroupBox.Text = "Initial data";
            // 
            // VerticiesCountTextBox
            // 
            this.VerticiesCountTextBox.Location = new System.Drawing.Point(67, 449);
            this.VerticiesCountTextBox.Name = "VerticiesCountTextBox";
            this.VerticiesCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.VerticiesCountTextBox.TabIndex = 47;
            this.VerticiesCountTextBox.TextChanged += new System.EventHandler(this.VerticiesCountTextBox_TextChanged);
            // 
            // CapacityLabel
            // 
            this.CapacityLabel.AutoSize = true;
            this.CapacityLabel.Location = new System.Drawing.Point(270, 14);
            this.CapacityLabel.Name = "CapacityLabel";
            this.CapacityLabel.Size = new System.Drawing.Size(51, 13);
            this.CapacityLabel.TabIndex = 54;
            this.CapacityLabel.Text = "Capacity:";
            // 
            // Verticieslabel
            // 
            this.Verticieslabel.AutoSize = true;
            this.Verticieslabel.Location = new System.Drawing.Point(10, 452);
            this.Verticieslabel.Name = "Verticieslabel";
            this.Verticieslabel.Size = new System.Drawing.Size(50, 13);
            this.Verticieslabel.TabIndex = 46;
            this.Verticieslabel.Text = "Verticies:";
            // 
            // FlowLabel
            // 
            this.FlowLabel.AutoSize = true;
            this.FlowLabel.Location = new System.Drawing.Point(184, 15);
            this.FlowLabel.Name = "FlowLabel";
            this.FlowLabel.Size = new System.Drawing.Size(32, 13);
            this.FlowLabel.TabIndex = 53;
            this.FlowLabel.Text = "Flow:";
            // 
            // Solvebutton
            // 
            this.Solvebutton.Location = new System.Drawing.Point(201, 452);
            this.Solvebutton.Name = "Solvebutton";
            this.Solvebutton.Size = new System.Drawing.Size(100, 37);
            this.Solvebutton.TabIndex = 44;
            this.Solvebutton.Text = "Solve";
            this.Solvebutton.UseVisualStyleBackColor = true;
            this.Solvebutton.Click += new System.EventHandler(this.Solvebutton_Click);
            // 
            // FlowDataGridView
            // 
            this.FlowDataGridView.AllowUserToAddRows = false;
            this.FlowDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FlowDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.FlowDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.FlowDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FlowDataGridView.ColumnHeadersVisible = false;
            this.FlowDataGridView.Location = new System.Drawing.Point(184, 36);
            this.FlowDataGridView.Name = "FlowDataGridView";
            this.FlowDataGridView.RowHeadersVisible = false;
            this.FlowDataGridView.Size = new System.Drawing.Size(70, 384);
            this.FlowDataGridView.TabIndex = 52;
            // 
            // EdgesCountTextBox
            // 
            this.EdgesCountTextBox.Location = new System.Drawing.Point(67, 473);
            this.EdgesCountTextBox.Name = "EdgesCountTextBox";
            this.EdgesCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.EdgesCountTextBox.TabIndex = 43;
            this.EdgesCountTextBox.TextChanged += new System.EventHandler(this.EdgesCountTextBox_TextChanged);
            // 
            // CapacityDataGridView
            // 
            this.CapacityDataGridView.AllowUserToAddRows = false;
            this.CapacityDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CapacityDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.CapacityDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.CapacityDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CapacityDataGridView.ColumnHeadersVisible = false;
            this.CapacityDataGridView.Location = new System.Drawing.Point(270, 36);
            this.CapacityDataGridView.Name = "CapacityDataGridView";
            this.CapacityDataGridView.RowHeadersVisible = false;
            this.CapacityDataGridView.Size = new System.Drawing.Size(70, 384);
            this.CapacityDataGridView.TabIndex = 51;
            // 
            // EdgesLabel
            // 
            this.EdgesLabel.AutoSize = true;
            this.EdgesLabel.Location = new System.Drawing.Point(10, 476);
            this.EdgesLabel.Name = "EdgesLabel";
            this.EdgesLabel.Size = new System.Drawing.Size(40, 13);
            this.EdgesLabel.TabIndex = 42;
            this.EdgesLabel.Text = "Edges:";
            // 
            // Tolabel
            // 
            this.Tolabel.AutoSize = true;
            this.Tolabel.Location = new System.Drawing.Point(94, 16);
            this.Tolabel.Name = "Tolabel";
            this.Tolabel.Size = new System.Drawing.Size(23, 13);
            this.Tolabel.TabIndex = 49;
            this.Tolabel.Text = "To:";
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(6, 16);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(33, 13);
            this.FromLabel.TabIndex = 48;
            this.FromLabel.Text = "From:";
            // 
            // FromVerticiesDataGridView
            // 
            this.FromVerticiesDataGridView.AllowUserToAddRows = false;
            this.FromVerticiesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FromVerticiesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.FromVerticiesDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.FromVerticiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FromVerticiesDataGridView.ColumnHeadersVisible = false;
            this.FromVerticiesDataGridView.Location = new System.Drawing.Point(9, 36);
            this.FromVerticiesDataGridView.Name = "FromVerticiesDataGridView";
            this.FromVerticiesDataGridView.RowHeadersVisible = false;
            this.FromVerticiesDataGridView.Size = new System.Drawing.Size(70, 384);
            this.FromVerticiesDataGridView.TabIndex = 45;
            // 
            // ToVerticiesDataGridView
            // 
            this.ToVerticiesDataGridView.AllowUserToAddRows = false;
            this.ToVerticiesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ToVerticiesDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.ToVerticiesDataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ToVerticiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ToVerticiesDataGridView.ColumnHeadersVisible = false;
            this.ToVerticiesDataGridView.Location = new System.Drawing.Point(97, 36);
            this.ToVerticiesDataGridView.Name = "ToVerticiesDataGridView";
            this.ToVerticiesDataGridView.RowHeadersVisible = false;
            this.ToVerticiesDataGridView.Size = new System.Drawing.Size(70, 384);
            this.ToVerticiesDataGridView.TabIndex = 44;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 521);
            this.Controls.Add(this.answerGroupBox);
            this.Controls.Add(this.initialDataGroupBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.answerGroupBox.ResumeLayout(false);
            this.answerGroupBox.PerformLayout();
            this.initialDataGroupBox.ResumeLayout(false);
            this.initialDataGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FlowDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CapacityDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FromVerticiesDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ToVerticiesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox answerGroupBox;
        private System.Windows.Forms.RichTextBox DetailedSolutionrichTextBox;
        private System.Windows.Forms.Label DetailedSolutionlabel;
        private System.Windows.Forms.GroupBox initialDataGroupBox;
        private System.Windows.Forms.TextBox VerticiesCountTextBox;
        private System.Windows.Forms.Label CapacityLabel;
        private System.Windows.Forms.Label Verticieslabel;
        private System.Windows.Forms.Label FlowLabel;
        private System.Windows.Forms.Button Solvebutton;
        private System.Windows.Forms.DataGridView FlowDataGridView;
        private System.Windows.Forms.TextBox EdgesCountTextBox;
        private System.Windows.Forms.DataGridView CapacityDataGridView;
        private System.Windows.Forms.Label EdgesLabel;
        private System.Windows.Forms.Label Tolabel;
        private System.Windows.Forms.Label FromLabel;
        private System.Windows.Forms.DataGridView FromVerticiesDataGridView;
        private System.Windows.Forms.DataGridView ToVerticiesDataGridView;
    }
}

