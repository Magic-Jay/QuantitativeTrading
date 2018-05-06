using System;
using System.Windows.Forms;

namespace GoldenEggNest
{
    public partial class AddDailyPrice : Form
    {
        PortfolioAppEntities AppEntity = new PortfolioAppEntities();
        public AddDailyPrice()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            AppEntity.DailyPrices.Add(new DailyPrice()
            {
                Date = Convert.ToDateTime(dateTimePicker1.Value),
                InstrumentId = Convert.ToInt32(textBox_HistPrice_Instrument.Text),
                ClosingPrice = Convert.ToDouble(textBoxClosingPrice.Text),               
            });

            AppEntity.SaveChanges();

            MessageBox.Show("Added successfully!");

        }

        private void textBox_HistPrice_Instrument_TextChanged(object sender, EventArgs e)
        {

        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }       
    }
}
