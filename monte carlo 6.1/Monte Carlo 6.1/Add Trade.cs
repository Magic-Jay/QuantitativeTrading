using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monte_Carlo_6._1
{
    public partial class Add_Trade : Form
    {
        Portfolio_x0020_ManagerContainer pmc = new Portfolio_x0020_ManagerContainer();

        public Add_Trade()
        {
            InitializeComponent();
        }

        private void Add_Trade_Load(object sender, EventArgs e)
        {
            comboBoxInst.Items.AddRange((from q in pmc.Instruments
                                               group q by q.Ticker into g
                                               select g.Key).ToArray());
            comboBoxInstType.Items.AddRange((from q in pmc.InstTypes
                                               group q by q.TypeName into g
                                               select g.Key).ToArray());
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Instrument inst = (from g in pmc.Instruments
                                 where g.Ticker == comboBoxInst.Text
                                 select g).FirstOrDefault();

            pmc.Trades.Add(new Trade()
            {
                IsBuy = radioButton1.Checked ? true : false,
                Quantity  = textBoxQuantity.Text == string.Empty ? 0 : Convert.ToDouble(textBoxQuantity.Text),
                Price = (textBoxTradePrice.Text == string.Empty ? 0.0 : Convert.ToDouble(textBoxTradePrice.Text)),
                Timestamp = DateTime.Now,
                InstrumentId = inst.Id,
            });
            pmc.SaveChanges();
            MessageBox.Show("Trade added successfully!");
            this.Dispose();
        
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
