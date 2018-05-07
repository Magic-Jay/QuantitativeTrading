using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Eagle.Business_Logic;
using System.Collections.Generic;


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
            Close();
        }

        private void refeshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Refresh();
            ListTrade.Items.Clear();

            ListViewItem i;
            foreach (Trade t in AppEntities.Trades)
            {
                i = new ListViewItem();
                i.Text = t.Id.ToString();
                i.SubItems.Add(t.Instrument.Ticker);
                i.SubItems.Add(t.Instrument.InstrumentType.TypeName);
                i.SubItems.Add(t.IsBuy ? "BUY" : "SELL");
                i.SubItems.Add(t.Quantity.ToString());
                i.SubItems.Add(t.Price.ToString());
                i.SubItems.Add("0");
                i.SubItems.Add("0");
                i.SubItems.Add("0");
                i.SubItems.Add("0");
                i.SubItems.Add("0");
                i.SubItems.Add("0");
                i.SubItems.Add("0");
                ListTrade.Items.Add(i);
            }
        }

        private void priceTradeBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem i in ListTrade.Items)
            {
                Int32 tmp = Convert.ToInt32(i.Text);
                Trade tt = (from q in AppEntities.Trades
                            where q.Id == tmp
                            select q).FirstOrDefault();


                double s = getLatestPrice(tt.Instrument);
                double k = Convert.ToDouble(tt.Instrument.Strike);
                double t = (double)tt.Instrument.Tenor;
                double r = getInterestRate(tt.Instrument);
                double sig = Convert.ToDouble(textBoxVol.Text) / 100.0;
                int instrumentTypeId = (Int32)tt.Instrument.InstrumentTypeId;
                int barrierTypeId = (Int32)tt.Instrument.BarrierTypeId;
                double barrier = (double)tt.Instrument.Barrier;
                double rebate = (double)tt.Instrument.Rebate;

                int steps = 100, trials = 10000;
                DataSet result = new DataSet();
                Dictionary<String, double> stockMetric = new Dictionary<string, double>();
                stockMetric.Add("Delta", 1);

                switch (instrumentTypeId)
                {
                    case 1:
                        stockMetric.Add("Delta", 1);
                        break;
                    case 2:
                        result = AsianOption.GetDataSet(steps, trials, s, k, t, sig, r);
                        break;
                    case 3:
                        result = EuropeanOption.GetDataSet(steps, trials, s, k, t, sig, r);
                        break;
                    case 4:
                        result = BarrierOption.GetDataSet(steps, trials, s, k, t, sig, r, barrier);
                        break;
                    case 5:
                        result = RangeOption.GetDataSet(steps, trials, s, k, t, sig, r, rebate);
                        break;
                    case 6:
                        result = LookBackOption.GetDataSet(steps, trials, s, k, t, sig, r, 0);
                        break;
                    default:
                        break;
                }

                ListViewItem i2;
                i2 = new ListViewItem();
                i2.Text = tt.Id.ToString();
                i2.SubItems.Add(tt.Instrument.Ticker);
                i2.SubItems.Add(tt.Instrument.InstrumentType.TypeName);
                i2.SubItems.Add(tt.IsBuy ? "BUY" : "SELL");
                i2.SubItems.Add(tt.Quantity.ToString());
                i2.SubItems.Add(tt.Price.ToString());
                i2.SubItems.Add("10");
                i2.SubItems.Add("10");
                i2.SubItems.Add("10");
                i2.SubItems.Add("10");
                i2.SubItems.Add("10");
                i2.SubItems.Add("10");
                i2.SubItems.Add("10");
                ListTrade.Items.Add(i2);
            }
        }

        private void listSum_SelectedIndexChanged(object sender, EventArgs e)
        {
            double totalpl = 0;
            double totaldelta = 0;
            double totalgamma = 0;
            double totalvega = 0;
            double totalrho = 0;
            double totaltheta = 0;
            foreach (ListViewItem i in ListTrade.SelectedItems)
            {
                totalpl += Convert.ToDouble(i.SubItems[7].Text);
                totaldelta += Convert.ToDouble(i.SubItems[8].Text);
                totalgamma += Convert.ToDouble(i.SubItems[9].Text);
                totalvega += Convert.ToDouble(i.SubItems[10].Text);
                totalrho += Convert.ToDouble(i.SubItems[11].Text);
                totaltheta += Convert.ToDouble(i.SubItems[12].Text);
            }

            listSum.Items.Clear();
            ListViewItem t = new ListViewItem();
            t.Text = " " + totalpl.ToString();
            t.SubItems.Add(totaldelta.ToString());
            t.SubItems.Add(totalgamma.ToString());
            t.SubItems.Add(totalvega.ToString());
            t.SubItems.Add(totalrho.ToString());
            t.SubItems.Add(totaltheta.ToString());

            listSum.Items.Add(t);
        }

        private double getLatestPrice(Instrument i)
        {
            var q = (from g in AppEntities.DailyPrices
                     where g.InstrumentId == i.Id
                     orderby g.Date descending
                     select g).FirstOrDefault();

            var result = q;
            double LastPrie = q.ClosingPrice;
            return LastPrie;

        }

        private double getInterestRate(Instrument i)
        {

            var m = (from g in AppEntities.InterestRates
                     orderby g.Id descending
                     select g);

            return (m.FirstOrDefault() == null ? 0 : m.FirstOrDefault().Rate);
        }
    }
}

