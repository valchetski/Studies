namespace labwork1
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
            this.components = new System.ComponentModel.Container();
            this.btnSolve = new System.Windows.Forms.Button();
            this.tbxN = new System.Windows.Forms.TextBox();
            this.zgcFunctions = new ZedGraph.ZedGraphControl();
            this.zgcInterval = new ZedGraph.ZedGraphControl();
            this.lblFunctions = new System.Windows.Forms.Label();
            this.zgcProbability = new ZedGraph.ZedGraphControl();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbxX = new System.Windows.Forms.ListBox();
            this.lbxY = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSolve
            // 
            this.btnSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSolve.Location = new System.Drawing.Point(296, 248);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(100, 29);
            this.btnSolve.TabIndex = 1;
            this.btnSolve.Text = "Решить";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // tbxN
            // 
            this.tbxN.Location = new System.Drawing.Point(296, 80);
            this.tbxN.Name = "tbxN";
            this.tbxN.Size = new System.Drawing.Size(100, 20);
            this.tbxN.TabIndex = 3;
            this.tbxN.Text = "100";
            // 
            // zgcFunctions
            // 
            this.zgcFunctions.Location = new System.Drawing.Point(12, 332);
            this.zgcFunctions.Name = "zgcFunctions";
            this.zgcFunctions.ScrollGrace = 0D;
            this.zgcFunctions.ScrollMaxX = 0D;
            this.zgcFunctions.ScrollMaxY = 0D;
            this.zgcFunctions.ScrollMaxY2 = 0D;
            this.zgcFunctions.ScrollMinX = 0D;
            this.zgcFunctions.ScrollMinY = 0D;
            this.zgcFunctions.ScrollMinY2 = 0D;
            this.zgcFunctions.Size = new System.Drawing.Size(400, 371);
            this.zgcFunctions.TabIndex = 4;
            // 
            // zgcInterval
            // 
            this.zgcInterval.Location = new System.Drawing.Point(471, 39);
            this.zgcInterval.Name = "zgcInterval";
            this.zgcInterval.ScrollGrace = 0D;
            this.zgcInterval.ScrollMaxX = 0D;
            this.zgcInterval.ScrollMaxY = 0D;
            this.zgcInterval.ScrollMaxY2 = 0D;
            this.zgcInterval.ScrollMinX = 0D;
            this.zgcInterval.ScrollMinY = 0D;
            this.zgcInterval.ScrollMinY2 = 0D;
            this.zgcInterval.Size = new System.Drawing.Size(431, 306);
            this.zgcInterval.TabIndex = 5;
            // 
            // lblFunctions
            // 
            this.lblFunctions.AutoSize = true;
            this.lblFunctions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFunctions.Location = new System.Drawing.Point(174, 297);
            this.lblFunctions.Name = "lblFunctions";
            this.lblFunctions.Size = new System.Drawing.Size(82, 20);
            this.lblFunctions.TabIndex = 7;
            this.lblFunctions.Text = "Функции";
            // 
            // zgcProbability
            // 
            this.zgcProbability.Location = new System.Drawing.Point(471, 397);
            this.zgcProbability.Name = "zgcProbability";
            this.zgcProbability.ScrollGrace = 0D;
            this.zgcProbability.ScrollMaxX = 0D;
            this.zgcProbability.ScrollMaxY = 0D;
            this.zgcProbability.ScrollMaxY2 = 0D;
            this.zgcProbability.ScrollMinX = 0D;
            this.zgcProbability.ScrollMinY = 0D;
            this.zgcProbability.ScrollMinY2 = 0D;
            this.zgcProbability.Size = new System.Drawing.Size(431, 306);
            this.zgcProbability.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(558, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Равноинтервальный метод";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(558, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(250, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Равновероятностный метод";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(292, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "N";
            // 
            // lbxX
            // 
            this.lbxX.FormattingEnabled = true;
            this.lbxX.Location = new System.Drawing.Point(12, 39);
            this.lbxX.Name = "lbxX";
            this.lbxX.Size = new System.Drawing.Size(120, 238);
            this.lbxX.TabIndex = 13;
            // 
            // lbxY
            // 
            this.lbxY.FormattingEnabled = true;
            this.lbxY.Location = new System.Drawing.Point(153, 39);
            this.lbxY.Name = "lbxY";
            this.lbxY.Size = new System.Drawing.Size(120, 238);
            this.lbxY.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(61, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(195, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Y";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 717);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbxY);
            this.Controls.Add(this.lbxX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.zgcProbability);
            this.Controls.Add(this.lblFunctions);
            this.Controls.Add(this.zgcInterval);
            this.Controls.Add(this.zgcFunctions);
            this.Controls.Add(this.tbxN);
            this.Controls.Add(this.btnSolve);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSolve;
		private System.Windows.Forms.TextBox tbxN;
		private ZedGraph.ZedGraphControl zgcFunctions;
		private ZedGraph.ZedGraphControl zgcInterval;
		private System.Windows.Forms.Label lblFunctions;
		private ZedGraph.ZedGraphControl zgcProbability;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lbxX;
		private System.Windows.Forms.ListBox lbxY;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
	}
}

