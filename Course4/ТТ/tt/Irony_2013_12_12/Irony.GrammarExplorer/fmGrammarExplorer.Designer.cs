namespace Irony.GrammarExplorer {
  partial class fmGrammarExplorer {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
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
    private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmGrammarExplorer));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabGrammar = new System.Windows.Forms.TabControl();
            this.pageTest = new System.Windows.Forms.TabPage();
            this.txtSource = new FastColoredTextBoxNS.FastColoredTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLocate = new System.Windows.Forms.Button();
            this.chkDisableHili = new System.Windows.Forms.CheckBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnFileOpen = new System.Windows.Forms.Button();
            this.btnParse = new System.Windows.Forms.Button();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.tabOutput = new System.Windows.Forms.TabControl();
            this.pageSyntaxTree = new System.Windows.Forms.TabPage();
            this.tvParseTree = new System.Windows.Forms.TreeView();
            this.pnlLang = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chkAutoRefresh = new System.Windows.Forms.CheckBox();
            this.btnManageGrammars = new System.Windows.Forms.Button();
            this.lblSearchError = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboGrammars = new System.Windows.Forms.ComboBox();
            this.menuGrammars = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.miRemoveAll = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.dlgSelectAssembly = new System.Windows.Forms.OpenFileDialog();
            this.splitBottom = new System.Windows.Forms.Splitter();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pageParserTrace = new System.Windows.Forms.TabPage();
            this.grpTokens = new System.Windows.Forms.GroupBox();
            this.lstTokens = new System.Windows.Forms.ListBox();
            this.pageParserOutput = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridCompileErrors = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpCompileInfo = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblParseErrorCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblParseTime = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSrcLineCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSrcTokenCount = new System.Windows.Forms.Label();
            this.tabBottom = new System.Windows.Forms.TabControl();
            this.IL = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tabGrammar.SuspendLayout();
            this.pageTest.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabOutput.SuspendLayout();
            this.pageSyntaxTree.SuspendLayout();
            this.pnlLang.SuspendLayout();
            this.menuGrammars.SuspendLayout();
            this.pageParserTrace.SuspendLayout();
            this.grpTokens.SuspendLayout();
            this.pageParserOutput.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompileErrors)).BeginInit();
            this.grpCompileInfo.SuspendLayout();
            this.tabBottom.SuspendLayout();
            this.IL.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabGrammar
            // 
            this.tabGrammar.Controls.Add(this.pageTest);
            this.tabGrammar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGrammar.Location = new System.Drawing.Point(0, 39);
            this.tabGrammar.Name = "tabGrammar";
            this.tabGrammar.SelectedIndex = 0;
            this.tabGrammar.Size = new System.Drawing.Size(1022, 371);
            this.tabGrammar.TabIndex = 0;
            // 
            // pageTest
            // 
            this.pageTest.Controls.Add(this.txtSource);
            this.pageTest.Controls.Add(this.panel1);
            this.pageTest.Controls.Add(this.splitter3);
            this.pageTest.Controls.Add(this.tabOutput);
            this.pageTest.Location = new System.Drawing.Point(4, 22);
            this.pageTest.Name = "pageTest";
            this.pageTest.Padding = new System.Windows.Forms.Padding(3);
            this.pageTest.Size = new System.Drawing.Size(1014, 345);
            this.pageTest.TabIndex = 4;
            this.pageTest.Text = "Test";
            this.pageTest.UseVisualStyleBackColor = true;
            // 
            // txtSource
            // 
            this.txtSource.AutoScrollMinSize = new System.Drawing.Size(25, 15);
            this.txtSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtSource.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSource.Location = new System.Drawing.Point(3, 33);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(652, 309);
            this.txtSource.TabIndex = 23;
            this.txtSource.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.txtSource_TextChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnLocate);
            this.panel1.Controls.Add(this.chkDisableHili);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.btnFileOpen);
            this.panel1.Controls.Add(this.btnParse);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(652, 30);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(506, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 22);
            this.button1.TabIndex = 11;
            this.button1.Text = "Run...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnLocate
            // 
            this.btnLocate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLocate.Location = new System.Drawing.Point(578, 3);
            this.btnLocate.Name = "btnLocate";
            this.btnLocate.Size = new System.Drawing.Size(65, 23);
            this.btnLocate.TabIndex = 10;
            this.btnLocate.Text = "Locate >>";
            this.toolTip.SetToolTip(this.btnLocate, "Locate the source position in parse/Ast tree. ");
            this.btnLocate.UseVisualStyleBackColor = true;
            this.btnLocate.Click += new System.EventHandler(this.btnLocate_Click);
            // 
            // chkDisableHili
            // 
            this.chkDisableHili.AutoSize = true;
            this.chkDisableHili.Location = new System.Drawing.Point(5, 7);
            this.chkDisableHili.Name = "chkDisableHili";
            this.chkDisableHili.Size = new System.Drawing.Size(150, 17);
            this.chkDisableHili.TabIndex = 9;
            this.chkDisableHili.Text = "Disable syntax highlighting";
            this.chkDisableHili.UseVisualStyleBackColor = true;
            this.chkDisableHili.Visible = false;
            this.chkDisableHili.CheckedChanged += new System.EventHandler(this.chkDisableHili_CheckedChanged);
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Location = new System.Drawing.Point(181, 4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(65, 23);
            this.btnRun.TabIndex = 7;
            this.btnRun.Text = "Run";
            this.toolTip.SetToolTip(this.btnRun, "Run the source sample");
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Visible = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnFileOpen
            // 
            this.btnFileOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFileOpen.Location = new System.Drawing.Point(362, 3);
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.Size = new System.Drawing.Size(65, 23);
            this.btnFileOpen.TabIndex = 6;
            this.btnFileOpen.Text = "Load ...";
            this.toolTip.SetToolTip(this.btnFileOpen, "Load a source sample...");
            this.btnFileOpen.UseVisualStyleBackColor = true;
            this.btnFileOpen.Visible = false;
            this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // btnParse
            // 
            this.btnParse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnParse.Location = new System.Drawing.Point(433, 3);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(67, 23);
            this.btnParse.TabIndex = 1;
            this.btnParse.Text = "Parse";
            this.toolTip.SetToolTip(this.btnParse, "Parse source sample");
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Visible = false;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter3.Location = new System.Drawing.Point(655, 3);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(6, 339);
            this.splitter3.TabIndex = 14;
            this.splitter3.TabStop = false;
            // 
            // tabOutput
            // 
            this.tabOutput.Controls.Add(this.pageSyntaxTree);
            this.tabOutput.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabOutput.Location = new System.Drawing.Point(661, 3);
            this.tabOutput.Name = "tabOutput";
            this.tabOutput.SelectedIndex = 0;
            this.tabOutput.Size = new System.Drawing.Size(350, 339);
            this.tabOutput.TabIndex = 13;
            // 
            // pageSyntaxTree
            // 
            this.pageSyntaxTree.Controls.Add(this.tvParseTree);
            this.pageSyntaxTree.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pageSyntaxTree.Location = new System.Drawing.Point(4, 22);
            this.pageSyntaxTree.Name = "pageSyntaxTree";
            this.pageSyntaxTree.Padding = new System.Windows.Forms.Padding(3);
            this.pageSyntaxTree.Size = new System.Drawing.Size(342, 313);
            this.pageSyntaxTree.TabIndex = 1;
            this.pageSyntaxTree.Text = "Parse Tree";
            this.pageSyntaxTree.UseVisualStyleBackColor = true;
            // 
            // tvParseTree
            // 
            this.tvParseTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvParseTree.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvParseTree.HideSelection = false;
            this.tvParseTree.Indent = 16;
            this.tvParseTree.Location = new System.Drawing.Point(3, 3);
            this.tvParseTree.Name = "tvParseTree";
            this.tvParseTree.Size = new System.Drawing.Size(336, 307);
            this.tvParseTree.TabIndex = 0;
            this.tvParseTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvParseTree_AfterSelect);
            // 
            // pnlLang
            // 
            this.pnlLang.Controls.Add(this.btnRefresh);
            this.pnlLang.Controls.Add(this.chkAutoRefresh);
            this.pnlLang.Controls.Add(this.btnManageGrammars);
            this.pnlLang.Controls.Add(this.lblSearchError);
            this.pnlLang.Controls.Add(this.btnSearch);
            this.pnlLang.Controls.Add(this.txtSearch);
            this.pnlLang.Controls.Add(this.label2);
            this.pnlLang.Controls.Add(this.cboGrammars);
            this.pnlLang.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLang.Location = new System.Drawing.Point(0, 0);
            this.pnlLang.Name = "pnlLang";
            this.pnlLang.Size = new System.Drawing.Size(1022, 39);
            this.pnlLang.TabIndex = 13;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Enabled = false;
            this.btnRefresh.Location = new System.Drawing.Point(339, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(56, 24);
            this.btnRefresh.TabIndex = 14;
            this.btnRefresh.Text = "Refresh";
            this.toolTip.SetToolTip(this.btnRefresh, "Reload grammar assembly and refresh the current grammar.\r\nUse Auto-refresh checkb" +
        "ox to do this automatically\r\nevery time the target assembly file is updated (rec" +
        "ompiled).");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chkAutoRefresh
            // 
            this.chkAutoRefresh.AutoSize = true;
            this.chkAutoRefresh.Checked = true;
            this.chkAutoRefresh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutoRefresh.Location = new System.Drawing.Point(401, 7);
            this.chkAutoRefresh.Name = "chkAutoRefresh";
            this.chkAutoRefresh.Size = new System.Drawing.Size(83, 17);
            this.chkAutoRefresh.TabIndex = 13;
            this.chkAutoRefresh.Text = "Auto-refresh";
            this.toolTip.SetToolTip(this.chkAutoRefresh, resources.GetString("chkAutoRefresh.ToolTip"));
            this.chkAutoRefresh.UseVisualStyleBackColor = true;
            this.chkAutoRefresh.Visible = false;
            // 
            // btnManageGrammars
            // 
            this.btnManageGrammars.Location = new System.Drawing.Point(306, 2);
            this.btnManageGrammars.Margin = new System.Windows.Forms.Padding(2);
            this.btnManageGrammars.Name = "btnManageGrammars";
            this.btnManageGrammars.Size = new System.Drawing.Size(28, 24);
            this.btnManageGrammars.TabIndex = 12;
            this.btnManageGrammars.Text = "...";
            this.btnManageGrammars.UseVisualStyleBackColor = true;
            this.btnManageGrammars.Click += new System.EventHandler(this.btnManageGrammars_Click);
            // 
            // lblSearchError
            // 
            this.lblSearchError.AutoSize = true;
            this.lblSearchError.ForeColor = System.Drawing.Color.Red;
            this.lblSearchError.Location = new System.Drawing.Point(731, 9);
            this.lblSearchError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSearchError.Name = "lblSearchError";
            this.lblSearchError.Size = new System.Drawing.Size(54, 13);
            this.lblSearchError.TabIndex = 11;
            this.lblSearchError.Text = "Not found";
            this.lblSearchError.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(672, 2);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(55, 24);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Find";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.AcceptsReturn = true;
            this.txtSearch.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::Irony.GrammarExplorer.Properties.Settings.Default, "SearchPattern", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtSearch.Location = new System.Drawing.Point(545, 4);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(123, 20);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.Text = global::Irony.GrammarExplorer.Properties.Settings.Default.SearchPattern;
            this.txtSearch.Visible = false;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Grammar:";
            this.label2.Visible = false;
            // 
            // cboGrammars
            // 
            this.cboGrammars.ContextMenuStrip = this.menuGrammars;
            this.cboGrammars.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrammars.FormattingEnabled = true;
            this.cboGrammars.Location = new System.Drawing.Point(67, 3);
            this.cboGrammars.Name = "cboGrammars";
            this.cboGrammars.Size = new System.Drawing.Size(234, 21);
            this.cboGrammars.TabIndex = 3;
            this.cboGrammars.SelectedIndexChanged += new System.EventHandler(this.cboGrammars_SelectedIndexChanged);
            // 
            // menuGrammars
            // 
            this.menuGrammars.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAdd,
            this.miRemove,
            this.miRemoveAll});
            this.menuGrammars.Name = "menuGrammars";
            this.menuGrammars.Size = new System.Drawing.Size(164, 70);
            this.menuGrammars.Opening += new System.ComponentModel.CancelEventHandler(this.menuGrammars_Opening);
            // 
            // miAdd
            // 
            this.miAdd.Name = "miAdd";
            this.miAdd.Size = new System.Drawing.Size(163, 22);
            this.miAdd.Text = "Add grammar...";
            this.miAdd.Click += new System.EventHandler(this.miAdd_Click);
            // 
            // miRemove
            // 
            this.miRemove.Name = "miRemove";
            this.miRemove.Size = new System.Drawing.Size(163, 22);
            this.miRemove.Text = "Remove selected";
            this.miRemove.Click += new System.EventHandler(this.miRemove_Click);
            // 
            // miRemoveAll
            // 
            this.miRemoveAll.Name = "miRemoveAll";
            this.miRemoveAll.Size = new System.Drawing.Size(163, 22);
            this.miRemoveAll.Text = "Remove all";
            this.miRemoveAll.Click += new System.EventHandler(this.miRemoveAll_Click);
            // 
            // dlgSelectAssembly
            // 
            this.dlgSelectAssembly.DefaultExt = "dll";
            this.dlgSelectAssembly.Filter = "DLL files|*.dll";
            this.dlgSelectAssembly.Title = "Select Grammar Assembly ";
            // 
            // splitBottom
            // 
            this.splitBottom.BackColor = System.Drawing.SystemColors.Control;
            this.splitBottom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitBottom.Location = new System.Drawing.Point(0, 410);
            this.splitBottom.Name = "splitBottom";
            this.splitBottom.Size = new System.Drawing.Size(1022, 6);
            this.splitBottom.TabIndex = 22;
            this.splitBottom.TabStop = false;
            // 
            // pageParserTrace
            // 
            this.pageParserTrace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pageParserTrace.Controls.Add(this.grpTokens);
            this.pageParserTrace.Location = new System.Drawing.Point(4, 22);
            this.pageParserTrace.Name = "pageParserTrace";
            this.pageParserTrace.Padding = new System.Windows.Forms.Padding(3);
            this.pageParserTrace.Size = new System.Drawing.Size(1014, 161);
            this.pageParserTrace.TabIndex = 3;
            this.pageParserTrace.Text = "Parser Trace";
            this.pageParserTrace.UseVisualStyleBackColor = true;
            // 
            // grpTokens
            // 
            this.grpTokens.Controls.Add(this.lstTokens);
            this.grpTokens.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpTokens.Location = new System.Drawing.Point(8, 3);
            this.grpTokens.Name = "grpTokens";
            this.grpTokens.Size = new System.Drawing.Size(1001, 153);
            this.grpTokens.TabIndex = 3;
            this.grpTokens.TabStop = false;
            this.grpTokens.Text = "Tokens";
            // 
            // lstTokens
            // 
            this.lstTokens.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTokens.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstTokens.FormattingEnabled = true;
            this.lstTokens.ItemHeight = 14;
            this.lstTokens.Location = new System.Drawing.Point(3, 16);
            this.lstTokens.Name = "lstTokens";
            this.lstTokens.Size = new System.Drawing.Size(995, 134);
            this.lstTokens.TabIndex = 2;
            this.lstTokens.Click += new System.EventHandler(this.lstTokens_Click);
            // 
            // pageParserOutput
            // 
            this.pageParserOutput.Controls.Add(this.groupBox1);
            this.pageParserOutput.Controls.Add(this.grpCompileInfo);
            this.pageParserOutput.Location = new System.Drawing.Point(4, 22);
            this.pageParserOutput.Name = "pageParserOutput";
            this.pageParserOutput.Padding = new System.Windows.Forms.Padding(3);
            this.pageParserOutput.Size = new System.Drawing.Size(1014, 161);
            this.pageParserOutput.TabIndex = 2;
            this.pageParserOutput.Text = "Parser Output";
            this.pageParserOutput.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridCompileErrors);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(158, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(853, 155);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compile Errors";
            // 
            // gridCompileErrors
            // 
            this.gridCompileErrors.AllowUserToAddRows = false;
            this.gridCompileErrors.AllowUserToDeleteRows = false;
            this.gridCompileErrors.ColumnHeadersHeight = 24;
            this.gridCompileErrors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridCompileErrors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn1});
            this.gridCompileErrors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridCompileErrors.Enabled = false;
            this.gridCompileErrors.Location = new System.Drawing.Point(3, 16);
            this.gridCompileErrors.MultiSelect = false;
            this.gridCompileErrors.Name = "gridCompileErrors";
            this.gridCompileErrors.RowHeadersVisible = false;
            this.gridCompileErrors.RowTemplate.Height = 24;
            this.gridCompileErrors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridCompileErrors.Size = new System.Drawing.Size(847, 136);
            this.gridCompileErrors.TabIndex = 2;
            this.gridCompileErrors.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridCompileErrors_CellDoubleClick);
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn3.HeaderText = "L, C";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.ToolTipText = "Double-click grid cell to locate in source code";
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn4.HeaderText = "Error Message";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 1000;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "State";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "Parser State";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Double-click grid cell to navigate to state details";
            this.dataGridViewTextBoxColumn1.Width = 71;
            // 
            // grpCompileInfo
            // 
            this.grpCompileInfo.Controls.Add(this.label12);
            this.grpCompileInfo.Controls.Add(this.lblParseErrorCount);
            this.grpCompileInfo.Controls.Add(this.label1);
            this.grpCompileInfo.Controls.Add(this.lblParseTime);
            this.grpCompileInfo.Controls.Add(this.label7);
            this.grpCompileInfo.Controls.Add(this.lblSrcLineCount);
            this.grpCompileInfo.Controls.Add(this.label3);
            this.grpCompileInfo.Controls.Add(this.lblSrcTokenCount);
            this.grpCompileInfo.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpCompileInfo.Location = new System.Drawing.Point(3, 3);
            this.grpCompileInfo.Name = "grpCompileInfo";
            this.grpCompileInfo.Size = new System.Drawing.Size(155, 155);
            this.grpCompileInfo.TabIndex = 5;
            this.grpCompileInfo.TabStop = false;
            this.grpCompileInfo.Text = "Statistics";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "Errors:";
            // 
            // lblParseErrorCount
            // 
            this.lblParseErrorCount.AutoSize = true;
            this.lblParseErrorCount.Location = new System.Drawing.Point(108, 81);
            this.lblParseErrorCount.Name = "lblParseErrorCount";
            this.lblParseErrorCount.Size = new System.Drawing.Size(13, 13);
            this.lblParseErrorCount.TabIndex = 18;
            this.lblParseErrorCount.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Parse Time, ms:";
            // 
            // lblParseTime
            // 
            this.lblParseTime.AutoSize = true;
            this.lblParseTime.Location = new System.Drawing.Point(108, 59);
            this.lblParseTime.Name = "lblParseTime";
            this.lblParseTime.Size = new System.Drawing.Size(13, 13);
            this.lblParseTime.TabIndex = 16;
            this.lblParseTime.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Lines:";
            // 
            // lblSrcLineCount
            // 
            this.lblSrcLineCount.AutoSize = true;
            this.lblSrcLineCount.Location = new System.Drawing.Point(108, 16);
            this.lblSrcLineCount.Name = "lblSrcLineCount";
            this.lblSrcLineCount.Size = new System.Drawing.Size(13, 13);
            this.lblSrcLineCount.TabIndex = 14;
            this.lblSrcLineCount.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tokens:";
            // 
            // lblSrcTokenCount
            // 
            this.lblSrcTokenCount.AutoSize = true;
            this.lblSrcTokenCount.Location = new System.Drawing.Point(108, 37);
            this.lblSrcTokenCount.Name = "lblSrcTokenCount";
            this.lblSrcTokenCount.Size = new System.Drawing.Size(13, 13);
            this.lblSrcTokenCount.TabIndex = 12;
            this.lblSrcTokenCount.Text = "0";
            // 
            // tabBottom
            // 
            this.tabBottom.Controls.Add(this.pageParserOutput);
            this.tabBottom.Controls.Add(this.pageParserTrace);
            this.tabBottom.Controls.Add(this.IL);
            this.tabBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabBottom.Location = new System.Drawing.Point(0, 416);
            this.tabBottom.Name = "tabBottom";
            this.tabBottom.SelectedIndex = 0;
            this.tabBottom.Size = new System.Drawing.Size(1022, 187);
            this.tabBottom.TabIndex = 0;
            // 
            // IL
            // 
            this.IL.Controls.Add(this.richTextBox1);
            this.IL.Location = new System.Drawing.Point(4, 22);
            this.IL.Name = "IL";
            this.IL.Padding = new System.Windows.Forms.Padding(3);
            this.IL.Size = new System.Drawing.Size(1014, 161);
            this.IL.TabIndex = 4;
            this.IL.Text = "IL";
            this.IL.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(9, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(995, 147);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // fmGrammarExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 603);
            this.Controls.Add(this.tabGrammar);
            this.Controls.Add(this.splitBottom);
            this.Controls.Add(this.pnlLang);
            this.Controls.Add(this.tabBottom);
            this.Name = "fmGrammarExplorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Irony Grammar Explorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmExploreGrammar_FormClosing);
            this.Load += new System.EventHandler(this.fmExploreGrammar_Load);
            this.tabGrammar.ResumeLayout(false);
            this.pageTest.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabOutput.ResumeLayout(false);
            this.pageSyntaxTree.ResumeLayout(false);
            this.pnlLang.ResumeLayout(false);
            this.pnlLang.PerformLayout();
            this.menuGrammars.ResumeLayout(false);
            this.pageParserTrace.ResumeLayout(false);
            this.grpTokens.ResumeLayout(false);
            this.pageParserOutput.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridCompileErrors)).EndInit();
            this.grpCompileInfo.ResumeLayout(false);
            this.grpCompileInfo.PerformLayout();
            this.tabBottom.ResumeLayout(false);
            this.IL.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabGrammar;
    private System.Windows.Forms.Panel pnlLang;
    private System.Windows.Forms.ComboBox cboGrammars;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TabPage pageTest;
    private System.Windows.Forms.Splitter splitter3;
    private System.Windows.Forms.TabControl tabOutput;
    private System.Windows.Forms.TabPage pageSyntaxTree;
    private System.Windows.Forms.TreeView tvParseTree;
    private System.Windows.Forms.OpenFileDialog dlgOpenFile;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.TextBox txtSearch;
    private System.Windows.Forms.Label lblSearchError;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button btnRun;
    private System.Windows.Forms.Button btnFileOpen;
	private System.Windows.Forms.Button btnParse;
    private System.Windows.Forms.Button btnManageGrammars;
    private System.Windows.Forms.ContextMenuStrip menuGrammars;
    private System.Windows.Forms.ToolStripMenuItem miAdd;
    private System.Windows.Forms.ToolStripMenuItem miRemove;
    private System.Windows.Forms.OpenFileDialog dlgSelectAssembly;
    private System.Windows.Forms.ToolStripMenuItem miRemoveAll;
    private System.Windows.Forms.Splitter splitBottom;
    private System.Windows.Forms.CheckBox chkDisableHili;
    private System.Windows.Forms.CheckBox chkAutoRefresh;
    private System.Windows.Forms.ToolTip toolTip;
    private System.Windows.Forms.Button btnLocate;
    private System.Windows.Forms.Button btnRefresh;
	private FastColoredTextBoxNS.FastColoredTextBox txtSource;
        private System.Windows.Forms.TabPage pageParserTrace;
        private System.Windows.Forms.GroupBox grpTokens;
        private System.Windows.Forms.ListBox lstTokens;
        private System.Windows.Forms.TabPage pageParserOutput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridCompileErrors;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.GroupBox grpCompileInfo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblParseErrorCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblParseTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSrcLineCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSrcTokenCount;
        private System.Windows.Forms.TabControl tabBottom;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage IL;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

