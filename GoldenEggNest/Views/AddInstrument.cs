using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GoldenEggNest
{
    public partial class AddInstrument : Form
    {
        PortfolioAppEntities AppEntity = new PortfolioAppEntities();

        public AddInstrument()
        {
            InitializeComponent();
        }

        private void Add_Instrument_Load(object sender, EventArgs e)
        {
            textBoxBarrier.Enabled = false;
            textBoxRebate.Enabled = false;

            comboBoxInstruType.Items.AddRange((from q in AppEntity.InstrumentTypes
                                               group q by q.TypeName into g
                                               select g.Key).ToArray());


            var test = AppEntity.retrieveInstruments();

            //comboBoxInstruType.Items.AddRange((from q in retrieveInstruments_Result
            //                                   group q by q.))

            foreach (retrieveInstruments_Result item in test)
            {
                var a = item.InstrumentId + item.Instrument;            
            }

            comboBoxBarrierType.Items.AddRange((from q in AppEntity.BarrierTypes
                                                group q by q.BarrierName into g
                                                select g.Key).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {


            InstrumentType instrumentType = (from i in AppEntity.InstrumentTypes
                                            where i.TypeName == comboBoxInstruType.Text
                                            select i).FirstOrDefault();

            BarrierType barrierType = (from b in AppEntity.BarrierTypes
                                       where b.BarrierName == comboBoxBarrierType.Text
                                       select b).FirstOrDefault();

            if (validate_Input())
            {
                
                AppEntity.Instruments.Add(new Instrument()
                {
                    CompanyName = textBoxCompName.Text == string.Empty ? null : Convert.ToString(textBoxCompName.Text),
                    Ticker = textBoxTicker.Text == string.Empty ? null : Convert.ToString(textBoxTicker.Text),
                    Exchange = textBoxExchange.Text == string.Empty ? null : Convert.ToString(textBoxExchange.Text),
                    Strike = textBoxStrike.Text == string.Empty ? 0 : Convert.ToDouble(textBoxStrike.Text),
                    Tenor = textBoxTenor.Text == string.Empty ? 0 : Convert.ToDouble(textBoxTenor.Text),
                    IsCall = string.IsNullOrEmpty(comboBoxCallPut.Text) ? (bool?) null : Convert.ToBoolean(comboBoxCallPut.Text),
                    Barrier = textBoxBarrier.Text == string.Empty ? 0 : Convert.ToDouble(textBoxBarrier.Text),
                    Rebate = textBoxRebate.Text == string.Empty ? 0 : Convert.ToDouble(textBoxRebate.Text),
                    InstrumentTypeId = instrumentType.Id,
                    BarrierTypeId = barrierType?.Id
                });

                AppEntity.SaveChanges();
                MessageBox.Show("Instrument Added Successfully!");
                this.Dispose();
            }
            
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validate_Input()
        {
            bool result = true; 

            double strike, tenor, check;

            if (comboBoxInstruType.SelectedItem == null)
            {
                MessageBox.Show("Please make a Instrument type selection!");
                result = false;
            }

            if (textBoxCompName.Text == "")
            {
                MessageBox.Show("Please enter a Company Name");
                result = false;
            }

            if (textBoxTicker.Text == "")
            {
                MessageBox.Show("Please enter a Ticker");
                result = false;
            }

            if (textBoxExchange.Text == "")
            {
                MessageBox.Show("Please enter an Exchange");
                result = false;
            }

            if (!double.TryParse(textBoxStrike.Text, out strike) ||
               Convert.ToDouble(textBoxStrike.Text) <= 0 || textBoxStrike.Text.ToString() == string.Empty)
            {
                MessageBox.Show("Please Enter a Valid Strike.");
                result = false;
            }

            if (comboBoxCallPut.Enabled)
            {
                if (comboBoxCallPut.SelectedItem == null)
                {
                    MessageBox.Show("Please make a Call Put selection!");
                    result = false;
                }
            }

            if (textBoxTenor.Text != null)
            {
                if (!double.TryParse(textBoxTenor.Text, out tenor) || Convert.ToDouble(textBoxTenor.Text) <= 0)
                {
                    MessageBox.Show("Please Enter a Valid Tenor.");
                    result = false;
                }
            }

            if (comboBoxInstruType.Text == "Barrier Option")
            {
                if (comboBoxBarrierType.SelectedItem == null)
                {
                    MessageBox.Show("Please make a Barrier type selection!");
                    result = false;
                }
            }
            

            if (comboBoxInstruType.Text == "Barrier Option" )
            {
                if (!double.TryParse(textBoxBarrier.Text, out check) || Convert.ToDouble(textBoxBarrier.Text) <= 0)
                {
                    MessageBox.Show("Please Enter a Valid Barrier  Value.");
                    result = false;
                }
            }

            if (comboBoxInstruType.Text == "Digital Option")
            {
                if (!double.TryParse(textBoxRebate.Text, out check) || Convert.ToDouble(textBoxRebate.Text) <= 0)
                {
                    MessageBox.Show("Please Enter a Valid Rebate Value.");
                    result = false;
                }
            }

            return result;
        }

        private void comboBoxInstruType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxInstruType.Text == "Barrier Option")
            {
                textBoxRebate.Enabled = true;
                textBoxBarrier.Enabled = true;

                label1.Enabled = true;
                label8.Enabled = true;

            }
            else
            {
                textBoxRebate.Enabled = false;
                textBoxBarrier.Enabled = false;

                label1.Enabled = false;
                label8.Enabled = false;

                comboBoxBarrierType.SelectedItem = null;
                comboBoxBarrierType.Enabled = false;
                textBoxBarrier.Text = null;
            }

            if (comboBoxInstruType.Text == "Digital Option")
            {
                textBoxRebate.Enabled = true;
                label9.Enabled = true;               
            }
            else
            {
                textBoxRebate.Enabled = false;
                label9.Enabled = false;
            }

            if (comboBoxInstruType.Text == "Stock")
            {
                label6.Enabled = false;
                comboBoxCallPut.SelectedItem = null;
                comboBoxCallPut.Enabled = false;
            }

        }
    }
}
