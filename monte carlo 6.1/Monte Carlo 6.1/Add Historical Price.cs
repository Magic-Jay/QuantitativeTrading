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
    public partial class Add_Historical_Price : Form
    {
        Portfolio_x0020_ManagerContainer pmc = new Portfolio_x0020_ManagerContainer();
        public Add_Historical_Price()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            pmc.Prices.Add(new Price()
            {
                Date = Convert.ToDateTime(dateTimePicker1.Value),
                CompanyName = Convert.ToString(textBox_HistPrice_Instrument.Text),
                ClosingPrice = Convert.ToDouble(textBoxClosingPrice.Text),               
            });

            pmc.SaveChanges();

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
