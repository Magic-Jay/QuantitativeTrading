namespace Monte_Carlo_6._1
{
    partial class My_Portfolio_Manager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historicalPriceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interestRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTradeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refeshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.priceTradeBookToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listSum = new System.Windows.Forms.ListView();
            this.TotalPLs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalDeltas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalGammas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalVegas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalRhos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalThetas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListTrade = new System.Windows.Forms.ListView();
            this.IDs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Instruments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InstrumentTypes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Directions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantitys = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TradePrices = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MarketPrices = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PLs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Deltas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Gammas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Vegas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Rhos = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Thetas = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxVol = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1120, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.refeshToolStripMenuItem,
            this.priceTradeBookToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historicalPriceToolStripMenuItem,
            this.instrumentTypeToolStripMenuItem,
            this.instrumentToolStripMenuItem,
            this.interestRateToolStripMenuItem,
            this.addTradeToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(227, 30);
            this.newToolStripMenuItem.Text = "New";
            // 
            // historicalPriceToolStripMenuItem
            // 
            this.historicalPriceToolStripMenuItem.Name = "historicalPriceToolStripMenuItem";
            this.historicalPriceToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.historicalPriceToolStripMenuItem.Text = "Historical Price";
            this.historicalPriceToolStripMenuItem.Click += new System.EventHandler(this.historicalPriceToolStripMenuItem_Click);
            // 
            // instrumentTypeToolStripMenuItem
            // 
            this.instrumentTypeToolStripMenuItem.Name = "instrumentTypeToolStripMenuItem";
            this.instrumentTypeToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.instrumentTypeToolStripMenuItem.Text = "Instrument Type";
            this.instrumentTypeToolStripMenuItem.Click += new System.EventHandler(this.instrumentTypeToolStripMenuItem_Click);
            // 
            // instrumentToolStripMenuItem
            // 
            this.instrumentToolStripMenuItem.Name = "instrumentToolStripMenuItem";
            this.instrumentToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.instrumentToolStripMenuItem.Text = "Instrument";
            this.instrumentToolStripMenuItem.Click += new System.EventHandler(this.instrumentToolStripMenuItem_Click);
            // 
            // interestRateToolStripMenuItem
            // 
            this.interestRateToolStripMenuItem.Name = "interestRateToolStripMenuItem";
            this.interestRateToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.interestRateToolStripMenuItem.Text = "Interest Rate";
            // 
            // addTradeToolStripMenuItem
            // 
            this.addTradeToolStripMenuItem.Name = "addTradeToolStripMenuItem";
            this.addTradeToolStripMenuItem.Size = new System.Drawing.Size(225, 30);
            this.addTradeToolStripMenuItem.Text = "Trade";
            this.addTradeToolStripMenuItem.Click += new System.EventHandler(this.addTradeToolStripMenuItem_Click);
            // 
            // refeshToolStripMenuItem
            // 
            this.refeshToolStripMenuItem.Name = "refeshToolStripMenuItem";
            this.refeshToolStripMenuItem.Size = new System.Drawing.Size(227, 30);
            this.refeshToolStripMenuItem.Text = "Refesh";
            this.refeshToolStripMenuItem.Click += new System.EventHandler(this.refeshToolStripMenuItem_Click);
            // 
            // priceTradeBookToolStripMenuItem
            // 
            this.priceTradeBookToolStripMenuItem.Name = "priceTradeBookToolStripMenuItem";
            this.priceTradeBookToolStripMenuItem.Size = new System.Drawing.Size(227, 30);
            this.priceTradeBookToolStripMenuItem.Text = "Price trade book";
            this.priceTradeBookToolStripMenuItem.Click += new System.EventHandler(this.priceTradeBookToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(227, 30);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(74, 4);
            // 
            // listSum
            // 
            this.listSum.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TotalPLs,
            this.TotalDeltas,
            this.TotalGammas,
            this.TotalVegas,
            this.TotalRhos,
            this.TotalThetas});
            this.listSum.FullRowSelect = true;
            this.listSum.GridLines = true;
            this.listSum.Location = new System.Drawing.Point(12, 110);
            this.listSum.Name = "listSum";
            this.listSum.Size = new System.Drawing.Size(1034, 194);
            this.listSum.TabIndex = 1;
            this.listSum.UseCompatibleStateImageBehavior = false;
            this.listSum.View = System.Windows.Forms.View.Details;
            // 
            // TotalPLs
            // 
            this.TotalPLs.Text = "Total P&L";
            this.TotalPLs.Width = 91;
            // 
            // TotalDeltas
            // 
            this.TotalDeltas.Text = "Total Delta";
            this.TotalDeltas.Width = 107;
            // 
            // TotalGammas
            // 
            this.TotalGammas.Text = "Total Gamma";
            this.TotalGammas.Width = 123;
            // 
            // TotalVegas
            // 
            this.TotalVegas.Text = "Total Vega";
            this.TotalVegas.Width = 93;
            // 
            // TotalRhos
            // 
            this.TotalRhos.Text = "Total Rho";
            this.TotalRhos.Width = 103;
            // 
            // TotalThetas
            // 
            this.TotalThetas.Text = "Total Theta";
            this.TotalThetas.Width = 116;
            // 
            // ListTrade
            // 
            this.ListTrade.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IDs,
            this.Instruments,
            this.InstrumentTypes,
            this.Directions,
            this.Quantitys,
            this.TradePrices,
            this.MarketPrices,
            this.PLs,
            this.Deltas,
            this.Gammas,
            this.Vegas,
            this.Rhos,
            this.Thetas});
            this.ListTrade.FullRowSelect = true;
            this.ListTrade.GridLines = true;
            this.ListTrade.Location = new System.Drawing.Point(12, 336);
            this.ListTrade.Name = "ListTrade";
            this.ListTrade.Size = new System.Drawing.Size(1034, 209);
            this.ListTrade.TabIndex = 2;
            this.ListTrade.UseCompatibleStateImageBehavior = false;
            this.ListTrade.View = System.Windows.Forms.View.Details;
            this.ListTrade.SelectedIndexChanged += new System.EventHandler(this.ListTrade_SelectedIndexChanged_1);
            // 
            // IDs
            // 
            this.IDs.Text = "ID";
            // 
            // Instruments
            // 
            this.Instruments.Text = "Instrument";
            this.Instruments.Width = 97;
            // 
            // InstrumentTypes
            // 
            this.InstrumentTypes.Text = "Instrument Type";
            this.InstrumentTypes.Width = 137;
            // 
            // Directions
            // 
            this.Directions.Text = "Direction";
            this.Directions.Width = 78;
            // 
            // Quantitys
            // 
            this.Quantitys.Text = "Quantity";
            this.Quantitys.Width = 87;
            // 
            // TradePrices
            // 
            this.TradePrices.Text = "Trade Price";
            this.TradePrices.Width = 100;
            // 
            // MarketPrices
            // 
            this.MarketPrices.Text = "Market Price";
            this.MarketPrices.Width = 111;
            // 
            // PLs
            // 
            this.PLs.Text = "P&L";
            // 
            // Deltas
            // 
            this.Deltas.Text = "Delta";
            // 
            // Gammas
            // 
            this.Gammas.Text = "Gamma";
            // 
            // Vegas
            // 
            this.Vegas.Text = "Vega";
            // 
            // Rhos
            // 
            this.Rhos.Text = "Rho";
            // 
            // Thetas
            // 
            this.Thetas.Text = "Theta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Volatility(%)";
            // 
            // textBoxVol
            // 
            this.textBoxVol.Location = new System.Drawing.Point(126, 53);
            this.textBoxVol.Name = "textBoxVol";
            this.textBoxVol.Size = new System.Drawing.Size(64, 26);
            this.textBoxVol.TabIndex = 4;
            this.textBoxVol.Text = "50";
            // 
            // My_Portfolio_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 594);
            this.Controls.Add(this.textBoxVol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListTrade);
            this.Controls.Add(this.listSum);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "My_Portfolio_Manager";
            this.Text = "My Portfolio Manager";
            this.Load += new System.EventHandler(this.My_Portfolio_Manager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historicalPriceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instrumentTypeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instrumentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interestRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTradeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refeshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem priceTradeBookToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ListView listSum;
        private System.Windows.Forms.ListView ListTrade;
        private System.Windows.Forms.ColumnHeader IDs;
        private System.Windows.Forms.ColumnHeader Instruments;
        private System.Windows.Forms.ColumnHeader InstrumentTypes;
        private System.Windows.Forms.ColumnHeader Directions;
        private System.Windows.Forms.ColumnHeader Quantitys;
        private System.Windows.Forms.ColumnHeader TradePrices;
        private System.Windows.Forms.ColumnHeader MarketPrices;
        private System.Windows.Forms.ColumnHeader PLs;
        private System.Windows.Forms.ColumnHeader Deltas;
        private System.Windows.Forms.ColumnHeader Gammas;
        private System.Windows.Forms.ColumnHeader Vegas;
        private System.Windows.Forms.ColumnHeader Rhos;
        private System.Windows.Forms.ColumnHeader Thetas;
        private System.Windows.Forms.ColumnHeader TotalPLs;
        private System.Windows.Forms.ColumnHeader TotalDeltas;
        private System.Windows.Forms.ColumnHeader TotalGammas;
        private System.Windows.Forms.ColumnHeader TotalVegas;
        private System.Windows.Forms.ColumnHeader TotalRhos;
        private System.Windows.Forms.ColumnHeader TotalThetas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxVol;
    }
}