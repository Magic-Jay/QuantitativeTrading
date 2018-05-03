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
    public partial class Add_Interest_Rate : Form
    {
        Portfolio_x0020_ManagerContainer pmc = new Portfolio_x0020_ManagerContainer();

        public Add_Interest_Rate()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double rate, tenor, check;
            if (!double.TryParse(textBoxRate.Text, out rate)||
                Convert.ToDouble(textBoxRate.Text)<=0 || textBoxRate.Text.ToString()==string.Empty)
            {
                MessageBox.Show("Please Enter a Valid Rate.");
            }

            else if (!double.TryParse(textBoxTenor.Text, out check) ||
                Convert.ToDouble(textBoxTenor.Text) <= 0 || textBoxTenor.Text.ToString() == string.Empty)
            {
                MessageBox.Show("Please Enter a Valid Tenor.");
            }

            tenor = Convert.ToDouble(textBoxTenor.Text);
            pmc.InterestRates.Add(new InterestRate()
            {
                Rate = rate,
                Tenor = tenor,
                //convert Tenor to double in EF and re-generate the data model again.
            });

            pmc.SaveChanges();
            MessageBox.Show("Interest Rate added successfully!");
            this.Dispose();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Add_Interest_Rate_Load(object sender, EventArgs e)
        {

        }
        
       
        
        
    }
}
