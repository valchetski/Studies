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
            this.label1 = new System.Windows.Forms.Label();
            this.lbxX = new System.Windows.Forms.ListBox();
            this.lbxY = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbxFe = new System.Windows.Forms.ListBox();
            this.lbxFt = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSolve
            // 
            this.btnSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSolve.Location = new System.Drawing.Point(166, 22);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(122, 33);
            this.btnSolve.TabIndex = 1;
            this.btnSolve.Text = "Построить";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // tbxN
            // 
            this.tbxN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbxN.Location = new System.Drawing.Point(60, 24);
            this.tbxN.Multiline = true;
            this.tbxN.Name = "tbxN";
            this.tbxN.Size = new System.Drawing.Size(100, 30);
            this.tbxN.TabIndex = 3;
            this.tbxN.Text = "100";
            // 
            // zgcFunctions
            // 
            this.zgcFunctions.Location = new System.Drawing.Point(283, 96);
            this.zgcFunctions.Name = "zgcFunctions";
            this.zgcFunctions.ScrollGrace = 0D;
            this.zgcFunctions.ScrollMaxX = 0D;
            this.zgcFunctions.ScrollMaxY = 0D;
            this.zgcFunctions.ScrollMaxY2 = 0D;
            this.zgcFunctions.ScrollMinX = 0D;
            this.zgcFunctions.ScrollMinY = 0D;
            this.zgcFunctions.ScrollMinY2 = 0D;
            this.zgcFunctions.Size = new System.Drawing.Size(682, 402);
            this.zgcFunctions.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "N =";
            // 
            // lbxX
            // 
            this.lbxX.FormattingEnabled = true;
            this.lbxX.Location = new System.Drawing.Point(12, 96);
            this.lbxX.Name = "lbxX";
            this.lbxX.Size = new System.Drawing.Size(120, 186);
            this.lbxX.TabIndex = 13;
            // 
            // lbxY
            // 
            this.lbxY.FormattingEnabled = true;
            this.lbxY.Location = new System.Drawing.Point(153, 96);
            this.lbxY.Name = "lbxY";
            this.lbxY.Size = new System.Drawing.Size(120, 186);
            this.lbxY.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(61, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "X";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(195, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Y";
            // 
            // lbxFe
            // 
            this.lbxFe.FormattingEnabled = true;
            this.lbxFe.Location = new System.Drawing.Point(153, 330);
            this.lbxFe.Name = "lbxFe";
            this.lbxFe.Size = new System.Drawing.Size(120, 225);
            this.lbxFe.TabIndex = 17;
            // 
            // lbxFt
            // 
            this.lbxFt.FormattingEnabled = true;
            this.lbxFt.Location = new System.Drawing.Point(12, 329);
            this.lbxFt.Name = "lbxFt";
            this.lbxFt.Size = new System.Drawing.Size(120, 225);
            this.lbxFt.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(195, 301);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Fe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(56, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Ft";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 564);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbxFt);
            this.Controls.Add(this.lbxFe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbxY);
            this.Controls.Add(this.lbxX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zgcFunctions);
            this.Controls.Add(this.tbxN);
            this.Controls.Add(this.btnSolve);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSolve;
		private System.Windows.Forms.TextBox tbxN;
        private ZedGraph.ZedGraphControl zgcFunctions;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox lbxX;
		private System.Windows.Forms.ListBox lbxY;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox lbxFe;
        private System.Windows.Forms.ListBox lbxFt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
	}
}

