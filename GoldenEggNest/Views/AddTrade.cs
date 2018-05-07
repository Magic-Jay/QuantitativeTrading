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
            List<String> instrumentsNames = new List<String>();
            var instruments = AppEntity.retrieveInstruments();
            foreach (var item in instruments)
            {
                instrumentsNames.Add(item.Instrument);
            }

            comboBoxInst.Items.AddRange(instrumentsNames.ToArray());
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Int32 instrumentId = 0;

            foreach (var inst in AppEntity.retrieveInstruments())
            {
                if (inst.Instrument == comboBoxInst.Text)
                {
                    instrumentId = inst.InstrumentId;
                }
            }

            if (validate_Input())
            {
                AppEntity.Trades.Add(new Trade()
                {
                    IsBuy = radioButton1.Checked ? true : false,
                    Quantity = textBoxQuantity.Text == string.Empty ? 0 : Convert.ToInt32(textBoxQuantity.Text),
                    Price = (textBoxTradePrice.Text == string.Empty ? 0.0 : Convert.ToInt32(textBoxTradePrice.Text)),
                    TimeStamp = DateTime.Now,
                    InstrumentId = instrumentId,
                });

                AppEntity.SaveChanges();
                MessageBox.Show("Trade added successfully!");
                this.Dispose();
            }
           
        }
        
        private bool validate_Input()
        {
            bool result = true;
            double quantity, price;

            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Please make a buy/sell selection!");
                result = false;
            }

            if (comboBoxInst.SelectedItem == null)
            {
                MessageBox.Show("Please make a Instrument selection!");
                result = false;
            }

            if (!double.TryParse(textBoxQuantity.Text, out quantity) ||
               Convert.ToDouble(textBoxQuantity.Text) <= 0 || textBoxQuantity.Text.ToString() == string.Empty)
            {
                MessageBox.Show("Please Enter a Valid Quantity.");
                result = false;
            }

            if (!double.TryParse(textBoxTradePrice.Text, out price) ||
               Convert.ToDouble(textBoxTradePrice.Text) <= 0 || textBoxTradePrice.Text.ToString() == string.Empty)
            {
                MessageBox.Show("Please Enter a Valid Trade Price.");
                result = false;
            }

            return result;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
