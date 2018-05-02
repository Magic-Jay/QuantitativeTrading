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
    public partial class Add_Instrument : Form
    {
        Portfolio_x0020_ManagerContainer pmc = new Portfolio_x0020_ManagerContainer();
        public Add_Instrument()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void comboBoxInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Add_Instrument_Load(object sender, EventArgs e)
        {
            textBoxBarrier.Enabled = false;
            textBoxRebate.Enabled = false;

            comboBoxInstrument.Items.AddRange((from q in pmc.Prices
                                               group q by q.CompanyName into g
                                               select g.Key).ToArray());
            comboBoxInstruType.Items.AddRange((from q in pmc.InstTypes
                                               group q by q.TypeName into g
                                              select g.Key).ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {

            InstType a = (from q in pmc.InstTypes
                          where q.TypeName == comboBoxInstruType.Text
                          select q).FirstOrDefault();
            Price p = (from q in pmc.Prices
                       where q.CompanyName == textBoxCompName.Text
                       select q).FirstOrDefault();

            pmc.Instruments.Add(new Instrument()
            {
                CompanyName = textBoxCompName.Text == string.Empty ? null : Convert.ToString(textBoxCompName.Text),
                Ticker = textBoxTicker.Text == string.Empty ? null : Convert.ToString(textBoxTicker.Text),
                Exchange = textBoxExchange.Text == string.Empty ? null : Convert.ToString(textBoxExchange.Text),
                Strike = textBoxStrike.Text == string.Empty ? 0 : Convert.ToDouble(textBoxStrike.Text),
                Tenor = textBoxTenor.Text == string.Empty ? 0 : Convert.ToDouble(textBoxTenor.Text),
                IsCall = Convert.ToBoolean(comboBoxCallPut.Text),
                InstTypeId = a.Id,
                Barrier = textBoxBarrier.Text == string.Empty ? 0 : Convert.ToDouble(textBoxBarrier.Text),
                Rebate = textBoxRebate.Text == string.Empty ? 0 : Convert.ToDouble(textBoxRebate.Text),
                PriceId = p.Id,        
            });

            pmc.SaveChanges();
            MessageBox.Show("Instrument Added Successfully!");
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBoxInstruType_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxRebate.Enabled = comboBoxInstruType.Text == "Digital";
            textBoxBarrier.Enabled = (comboBoxInstruType.Text == "Barrier");
        }
    }
}
