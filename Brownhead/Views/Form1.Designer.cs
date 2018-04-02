namespace Brownhead
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sidePanel = new System.Windows.Forms.Panel();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.asyncCancelButton = new System.Windows.Forms.Button();
            this.clearingButton = new System.Windows.Forms.Button();
            this.testingButton = new System.Windows.Forms.Button();
            this.calculatePriceButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TimerPanel = new System.Windows.Forms.Panel();
            this.timerLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.StandardErrorPanel = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label9 = new System.Windows.Forms.Label();
            this.outputDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.stepsTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.trialsTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tenorTextbox = new System.Windows.Forms.TextBox();
            this.sigTextBox = new System.Windows.Forms.TextBox();
            this.rTextBox = new System.Windows.Forms.TextBox();
            this.kTextBox = new System.Windows.Forms.TextBox();
            this.sTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.sidePanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.TimerPanel.SuspendLayout();
            this.StandardErrorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // sidePanel
            // 
            this.sidePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(181)))));
            this.sidePanel.Controls.Add(this.menuPanel);
            this.sidePanel.Controls.Add(this.button1);
            this.sidePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidePanel.Location = new System.Drawing.Point(0, 0);
            this.sidePanel.Name = "sidePanel";
            this.sidePanel.Size = new System.Drawing.Size(217, 602);
            this.sidePanel.TabIndex = 0;
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(127)))), ((int)(((byte)(160)))));
            this.menuPanel.Location = new System.Drawing.Point(0, 81);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(16, 84);
            this.menuPanel.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(12, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(199, 81);
            this.button1.TabIndex = 1;
            this.button1.Text = " Price a Trade";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(93, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(291, 43);
            this.label1.TabIndex = 2;
            this.label1.Text = "Habana Trading";
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(127)))), ((int)(((byte)(160)))));
            this.headerPanel.Controls.Add(this.pictureBox1);
            this.headerPanel.Controls.Add(this.label1);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(217, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(860, 91);
            this.headerPanel.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(220, 91);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 511);
            this.panel1.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.White;
            this.groupBox4.Controls.Add(this.asyncCancelButton);
            this.groupBox4.Controls.Add(this.clearingButton);
            this.groupBox4.Controls.Add(this.testingButton);
            this.groupBox4.Controls.Add(this.calculatePriceButton);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.outputDataGridView);
            this.groupBox4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(127)))), ((int)(((byte)(160)))));
            this.groupBox4.Location = new System.Drawing.Point(319, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(494, 493);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Output Values";
            // 
            // asyncCancelButton
            // 
            this.asyncCancelButton.BackColor = System.Drawing.Color.White;
            this.asyncCancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.asyncCancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.asyncCancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(127)))), ((int)(((byte)(160)))));
            this.asyncCancelButton.Location = new System.Drawing.Point(355, 433);
            this.asyncCancelButton.Name = "asyncCancelButton";
            this.asyncCancelButton.Size = new System.Drawing.Size(101, 39);
            this.asyncCancelButton.TabIndex = 9;
            this.asyncCancelButton.Text = "Cancel";
            this.asyncCancelButton.UseVisualStyleBackColor = false;
            // 
            // clearingButton
            // 
            this.clearingButton.BackColor = System.Drawing.Color.White;
            this.clearingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearingButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(181)))));
            this.clearingButton.Location = new System.Drawing.Point(91, 433);
            this.clearingButton.Name = "clearingButton";
            this.clearingButton.Size = new System.Drawing.Size(72, 39);
            this.clearingButton.TabIndex = 8;
            this.clearingButton.Text = "Clear";
            this.clearingButton.UseVisualStyleBackColor = true;
            this.clearingButton.Click += new System.EventHandler(this.clearingButton_Click);
            // 
            // testingButton
            // 
            this.testingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(167)))), ((int)(((byte)(181)))));
            this.testingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.testingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.testingButton.ForeColor = System.Drawing.Color.White;
            this.testingButton.Location = new System.Drawing.Point(9, 433);
            this.testingButton.Name = "testingButton";
            this.testingButton.Size = new System.Drawing.Size(66, 39);
            this.testingButton.TabIndex = 7;
            this.testingButton.Text = "Test";
            this.testingButton.UseVisualStyleBackColor = true;
            this.testingButton.Click += new System.EventHandler(this.testingButton_Click);
            // 
            // calculatePriceButton
            // 
            this.calculatePriceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(4)))), ((int)(((byte)(127)))), ((int)(((byte)(160)))));
            this.calculatePriceButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calculatePriceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.calculatePriceButton.ForeColor = System.Drawing.Color.White;
            this.calculatePriceButton.Location = new System.Drawing.Point(235, 433);
            this.calculatePriceButton.Name = "calculatePriceButton";
            this.calculatePriceButton.Size = new System.Drawing.Size(101, 39);
            this.calculatePriceButton.TabIndex = 6;
            this.calculatePriceButton.Text = "Calculate";
            this.calculatePriceButton.UseVisualStyleBackColor = false;
            this.calculatePriceButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.groupBox3.Controls.Add(this.TimerPanel);
            this.groupBox3.Controls.Add(this.StandardErrorPanel);
            this.groupBox3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(84)))));
            this.groupBox3.Location = new System.Drawing.Point(9, 295);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(447, 125);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // TimerPanel
            // 
            this.TimerPanel.BackColor = System.Drawing.Color.White;
            this.TimerPanel.Controls.Add(this.timerLabel);
            this.TimerPanel.Controls.Add(this.label10);
            this.TimerPanel.ForeColor = System.Drawing.Color.White;
            this.TimerPanel.Location = new System.Drawing.Point(226, 5);
            this.TimerPanel.Name = "TimerPanel";
            this.TimerPanel.Size = new System.Drawing.Size(217, 114);
            this.TimerPanel.TabIndex = 1;
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(84)))));
            this.timerLabel.Location = new System.Drawing.Point(19, 37);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(0, 82);
            this.timerLabel.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(84)))));
            this.label10.Location = new System.Drawing.Point(3, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(225, 28);
            this.label10.TabIndex = 1;
            this.label10.Text = "Computation Time";
            // 
            // StandardErrorPanel
            // 
            this.StandardErrorPanel.BackColor = System.Drawing.Color.White;
            this.StandardErrorPanel.Controls.Add(this.label11);
            this.StandardErrorPanel.Controls.Add(this.progressBar1);
            this.StandardErrorPanel.Controls.Add(this.label9);
            this.StandardErrorPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(84)))));
            this.StandardErrorPanel.Location = new System.Drawing.Point(3, 5);
            this.StandardErrorPanel.Name = "StandardErrorPanel";
            this.StandardErrorPanel.Size = new System.Drawing.Size(217, 114);
            this.StandardErrorPanel.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(103, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(0, 28);
            this.label11.TabIndex = 2;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 62);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(182, 35);
            this.progressBar1.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 28);
            this.label9.TabIndex = 0;
            this.label9.Text = "Progress";
            // 
            // outputDataGridView
            // 
            this.outputDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outputDataGridView.Location = new System.Drawing.Point(9, 55);
            this.outputDataGridView.Name = "outputDataGridView";
            this.outputDataGridView.RowTemplate.Height = 28;
            this.outputDataGridView.Size = new System.Drawing.Size(447, 234);
            this.outputDataGridView.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.tenorTextbox);
            this.groupBox2.Controls.Add(this.sigTextBox);
            this.groupBox2.Controls.Add(this.rTextBox);
            this.groupBox2.Controls.Add(this.kTextBox);
            this.groupBox2.Controls.Add(this.sTextBox);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(127)))), ((int)(((byte)(160)))));
            this.groupBox2.Location = new System.Drawing.Point(7, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 495);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input";
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.White;
            this.groupBox5.Controls.Add(this.checkedListBox1);
            this.groupBox5.Controls.Add(this.stepsTextBox);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.trialsTextBox);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(84)))));
            this.groupBox5.Location = new System.Drawing.Point(6, 255);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(267, 219);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Simulatin Setup";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(84)))));
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBox1.ForeColor = System.Drawing.Color.White;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Antithetic Variance Reduction",
            "Control Variate",
            "Multithread Parallel Compute"});
            this.checkedListBox1.Location = new System.Drawing.Point(10, 134);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(251, 79);
            this.checkedListBox1.TabIndex = 28;
            // 
            // stepsTextBox
            // 
            this.stepsTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.stepsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stepsTextBox.Location = new System.Drawing.Point(160, 84);
            this.stepsTextBox.Name = "stepsTextBox";
            this.stepsTextBox.Size = new System.Drawing.Size(76, 35);
            this.stepsTextBox.TabIndex = 27;
            this.stepsTextBox.TextChanged += new System.EventHandler(this.stepsTextBox_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(84)))));
            this.label8.Location = new System.Drawing.Point(6, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 23);
            this.label8.TabIndex = 26;
            this.label8.Text = "Steps";
            // 
            // trialsTextBox
            // 
            this.trialsTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.trialsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trialsTextBox.Location = new System.Drawing.Point(160, 42);
            this.trialsTextBox.Name = "trialsTextBox";
            this.trialsTextBox.Size = new System.Drawing.Size(76, 35);
            this.trialsTextBox.TabIndex = 22;
            this.trialsTextBox.TextChanged += new System.EventHandler(this.trialsTextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(149)))), ((int)(((byte)(84)))));
            this.label7.Location = new System.Drawing.Point(6, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 23);
            this.label7.TabIndex = 17;
            this.label7.Text = "Trials";
            // 
            // tenorTextbox
            // 
            this.tenorTextbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tenorTextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tenorTextbox.Location = new System.Drawing.Point(166, 215);
            this.tenorTextbox.Name = "tenorTextbox";
            this.tenorTextbox.Size = new System.Drawing.Size(76, 35);
            this.tenorTextbox.TabIndex = 21;
            this.tenorTextbox.TextChanged += new System.EventHandler(this.tenorTextBox_TextChanged);
            // 
            // sigTextBox
            // 
            this.sigTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.sigTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sigTextBox.Location = new System.Drawing.Point(166, 170);
            this.sigTextBox.Name = "sigTextBox";
            this.sigTextBox.Size = new System.Drawing.Size(76, 35);
            this.sigTextBox.TabIndex = 20;
            this.sigTextBox.TextChanged += new System.EventHandler(this.sigTextBox_TextChanged);
            // 
            // rTextBox
            // 
            this.rTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.rTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTextBox.Location = new System.Drawing.Point(166, 125);
            this.rTextBox.Name = "rTextBox";
            this.rTextBox.Size = new System.Drawing.Size(76, 35);
            this.rTextBox.TabIndex = 19;
            this.rTextBox.TextChanged += new System.EventHandler(this.rTextBox_TextChanged);
            // 
            // kTextBox
            // 
            this.kTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.kTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kTextBox.Location = new System.Drawing.Point(166, 80);
            this.kTextBox.Name = "kTextBox";
            this.kTextBox.Size = new System.Drawing.Size(76, 35);
            this.kTextBox.TabIndex = 18;
            this.kTextBox.TextChanged += new System.EventHandler(this.kTextBox_TextChanged);
            // 
            // sTextBox
            // 
            this.sTextBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.sTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sTextBox.Location = new System.Drawing.Point(166, 35);
            this.sTextBox.Name = "sTextBox";
            this.sTextBox.Size = new System.Drawing.Size(76, 35);
            this.sTextBox.TabIndex = 17;
            this.sTextBox.TextChanged += new System.EventHandler(this.sTextBox_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(127)))), ((int)(((byte)(160)))));
            this.label6.Location = new System.Drawing.Point(27, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 23);
            this.label6.TabIndex = 16;
            this.label6.Text = "Tenor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(127)))), ((int)(((byte)(160)))));
            this.label5.Location = new System.Drawing.Point(27, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 23);
            this.label5.TabIndex = 15;
            this.label5.Text = "Volatility %";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(127)))), ((int)(((byte)(160)))));
            this.label4.Location = new System.Drawing.Point(27, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "Interest Rate %";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(127)))), ((int)(((byte)(160)))));
            this.label3.Location = new System.Drawing.Point(27, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 23);
            this.label3.TabIndex = 13;
            this.label3.Text = "Strike Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(127)))), ((int)(((byte)(160)))));
            this.label2.Location = new System.Drawing.Point(27, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 23);
            this.label2.TabIndex = 12;
            this.label2.Text = "Underlying Price";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1077, 602);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.sidePanel);
            this.Font = new System.Drawing.Font("Century Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.Form_Load);
            this.sidePanel.ResumeLayout(false);
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.TimerPanel.ResumeLayout(false);
            this.TimerPanel.PerformLayout();
            this.StandardErrorPanel.ResumeLayout(false);
            this.StandardErrorPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outputDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel sidePanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tenorTextbox;
        private System.Windows.Forms.TextBox sigTextBox;
        private System.Windows.Forms.TextBox rTextBox;
        private System.Windows.Forms.TextBox kTextBox;
        private System.Windows.Forms.TextBox sTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView outputDataGridView;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox trialsTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button calculatePriceButton;
        private System.Windows.Forms.TextBox stepsTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button testingButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button clearingButton;
        private System.Windows.Forms.Panel TimerPanel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel StandardErrorPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Button asyncCancelButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label11;
    }
}

