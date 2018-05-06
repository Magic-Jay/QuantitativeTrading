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
    public partial class AddTrade : Form
    {
        PortfolioAppEntities AppEntity = new PortfolioAppEntities();

        public AddTrade()
        {
            InitializeComponent();
        }

        private void Add_Trade_Load(object sender, EventArgs e)
        {
            comboBoxInst.Items.AddRange((from q in AppEntity.Instruments
                                               group q by q.Ticker into g
                                               select g.Key).ToArray());
            //comboBoxInstType.Items.AddRange((from q in AppEntity.InstTypes
            //                                   group q by q.TypeName into g
            //                                   select g.Key).ToArray());
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Instrument inst = (from g in AppEntity.Instruments
                                 where g.Ticker == comboBoxInst.Text
                                 select g).FirstOrDefault();

            AppEntity.Trades.Add(new Trade()
            {
                IsBuy = radioButton1.Checked ? true : false,
                Quantity  = textBoxQuantity.Text == string.Empty ? 0 : Convert.ToInt32(textBoxQuantity.Text),
                Price = (textBoxTradePrice.Text == string.Empty ? 0.0 : Convert.ToInt32(textBoxTradePrice.Text)),
                TimeStamp = DateTime.Now,
                InstrumentId = inst.Id,
            });
            AppEntity.SaveChanges();
            MessageBox.Show("Trade added successfully!");
            this.Dispose();
        
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
