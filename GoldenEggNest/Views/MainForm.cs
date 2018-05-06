using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenEggNest
{
    public partial class MainForm : Form
    {
        PortfolioAppEntities AppEntities = new PortfolioAppEntities();

        public MainForm()
        {
            InitializeComponent();
        }

        private void instrumentTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddInstrumentType form = new AddInstrumentType();
            form.ShowDialog();
        }

        private void instrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddInstrument f = new AddInstrument();
            f.ShowDialog();
        }


        private void interestRateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddInterestRate f = new AddInterestRate();
            f.ShowDialog();
        }

        private void historicalPriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDailyPrice f = new AddDailyPrice();
            f.ShowDialog();
        }

        private void addTradeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTrade f = new AddTrade();
            f.ShowDialog();
        }




        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void refeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Refresh();
            //ListTrade.Items.Clear();
            //ListViewItem i;
            //foreach (Trade t in pmc.Trades)
            //{
            //    i = new ListViewItem();
            //    i.Text = t.Id.ToString();
            //    i.SubItems.Add(t.IsBuy ? "BUY" : "SELL");
            //    i.SubItems.Add(t.Quantity.ToString());
            //    i.SubItems.Add(t.Instrument.Ticker);
            //    i.SubItems.Add(t.Instrument.InstType.TypeName);
            //    i.SubItems.Add(t.Price.ToString());
            //    i.SubItems.Add("0");
            //    i.SubItems.Add("0");
            //    i.SubItems.Add("0");
            //    i.SubItems.Add("0");
            //    i.SubItems.Add("0");
            //    i.SubItems.Add("0");
            //    i.SubItems.Add("0");
            //    ListTrade.Items.Add(i);
            }

        private void priceTradeBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////Price book using simulation from MonteCarlo simulator:
            //    //foreach (ListViewItem i in ListTrade.Items)
            //    //{
            //    //    var t = Convert.ToInt32(i.Text);

            //    //    Trade tt = (from q in pmc.Trades
            //    //               where q.Id == t
            //    //               select q).FirstOrDefault();


            //    //    double S0 = Get_latest_Price(tt.Instrument); 
            //    //    double K = Convert.ToDouble(tt.Instrument.Strike); 
            //    //    double R = Get_InterestRate(tt.Instrument); 
            //    //    double T = (double)tt.Instrument.Tenor; 
            //    //    double sig = Convert.ToDouble(textBoxVol.Text) / 100.0; 
            //    //    double Barr = (double)tt.Instrument.Barrier; 
            //    //    double rebate = (double)tt.Instrument.Rebate; ; 
        }

       
    }

        //private void ListTrade_SelectedIndexChanged_1(object sender, EventArgs e)
        //{

        ////    double totalpl = 0;
        ////    double totaldelta = 0;
        ////    double totalgamma = 0;
        ////    double totalvega = 0;   
        ////    double totalrho = 0;
        ////    double totaltheta = 0;
        ////    foreach (ListViewItem i in ListTrade.SelectedItems)
        ////    {
        ////        totalpl += Convert.ToDouble(i.SubItems[7].Text);
        ////        totaldelta += Convert.ToDouble(i.SubItems[8].Text);
        ////        totalgamma += Convert.ToDouble(i.SubItems[9].Text);
        ////        totalvega += Convert.ToDouble(i.SubItems[10].Text);
        ////        totalrho += Convert.ToDouble(i.SubItems[11].Text);
        ////        totaltheta += Convert.ToDouble(i.SubItems[12].Text);
        ////    }

        ////    listSum.Items.Clear();
        ////    ListViewItem t = new ListViewItem();
        ////    t.Text = " " + totalpl.ToString();
        ////    t.SubItems.Add(totaldelta.ToString());
        ////    t.SubItems.Add(totalgamma.ToString());
        ////    t.SubItems.Add(totalvega.ToString());
        ////    t.SubItems.Add(totalrho.ToString());
        ////    t.SubItems.Add(totaltheta.ToString());

        ////    listSum.Items.Add(t);
        ////}

        ////private double Get_latest_Price(Instrument i)
        ////{
        ////    var q = (from g in pmc.Prices
        ////             where g.Id == i.PriceId
        ////             orderby g.Date descending
        ////             select g).FirstOrDefault();
        ////    var m = (from p in pmc.Prices
        ////             where p.CompanyName == q.CompanyName
        ////             select p);

        ////    Price LatestPrice = m.OrderByDescending(o => o.Date).FirstOrDefault();
        ////    double LastPrie = LatestPrice.ClosingPrice;
        ////    return LastPrie;

        //}

        //private double Get_InterestRate(Instrument i)
        //{
            
        //    //var m = (from g in pmc.InterestRates
        //    //         orderby g.Id descending
        //    //         select g);
        //    //foreach (InterestRate r in m)
        //    //{
        //    //    Console.WriteLine(r.Rate);
        //    //}
        //    //return (m.FirstOrDefault() == null ? 0 : m.FirstOrDefault().Rate);
        //}

        //private void priceTradeBookToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    ////Price book using simulation from MonteCarlo simulator:
        //    //foreach (ListViewItem i in ListTrade.Items)
        //    //{
        //    //    var t = Convert.ToInt32(i.Text);

        //    //    Trade tt = (from q in pmc.Trades
        //    //               where q.Id == t
        //    //               select q).FirstOrDefault();

      
        //    //    double S0 = Get_latest_Price(tt.Instrument); 
        //    //    double K = Convert.ToDouble(tt.Instrument.Strike); 
        //    //    double R = Get_InterestRate(tt.Instrument); 
        //    //    double T = (double)tt.Instrument.Tenor; 
        //    //    double sig = Convert.ToDouble(textBoxVol.Text) / 100.0; 
        //    //    double Barr = (double)tt.Instrument.Barrier; 
        //    //    double rebate = (double)tt.Instrument.Rebate; ; 

                
                
        //    }
        //}



    }

