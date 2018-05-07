using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;


namespace GoldenEggNest
{
    public partial class AddDailyPrice : Form
    {
        PortfolioAppEntities AppEntity = new PortfolioAppEntities();
        public AddDailyPrice()
        {
            InitializeComponent();
        }

        private void AddDailyPrice_Load(object sender, EventArgs e)
        {
            List<String> instrumentsNames = new List<String>();
            var instruments = AppEntity.retrieveInstruments();
            foreach (var item in instruments)
            {
                instrumentsNames.Add(item.Instrument);
            }

            instrumentComboBox.Items.AddRange(instrumentsNames.ToArray());

        }


        private void button1_Click(object sender, EventArgs e)
        {
            Int32 instrumentId = 0;

            foreach (var inst in AppEntity.retrieveInstruments())
            {
                if (inst.Instrument == instrumentComboBox.Text)
                {
                    instrumentId = inst.InstrumentId;
                }
            }

            if (validate_Input())
            {
                AppEntity.DailyPrices.Add(new DailyPrice()
                {
                    Date = Convert.ToDateTime(dateTimePicker1.Value),
                    InstrumentId = instrumentId,
                    ClosingPrice = Convert.ToDouble(textBoxClosingPrice.Text),
                });

                AppEntity.SaveChanges();

                MessageBox.Show("Added successfully!");
            }
        }
        
        private bool validate_Input()
        {
            bool result = true;
            double closingPrice;

            if (instrumentComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please make an Instrument selection!");
                result = false;
            }

            if (!double.TryParse(textBoxClosingPrice.Text, out closingPrice) ||
              Convert.ToDouble(textBoxClosingPrice.Text) <= 0 || textBoxClosingPrice.Text.ToString() == string.Empty)
            {
                MessageBox.Show("Please Enter a Valid Price.");
                result = false;
            }

            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
