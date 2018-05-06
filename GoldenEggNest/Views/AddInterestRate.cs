using System;
using System.Windows.Forms;

namespace GoldenEggNest
{
    public partial class AddInterestRate : Form
    {
        PortfolioAppEntities AppEntity = new PortfolioAppEntities();

        public AddInterestRate()
        {
            InitializeComponent();
        }

        private void Add_Interest_Rate_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double rateCheck, tenorCheck;
            if (!double.TryParse(textBoxRate.Text, out rateCheck) ||
                Convert.ToDouble(textBoxRate.Text)<=0 || textBoxRate.Text.ToString()==string.Empty)
            {
                MessageBox.Show("Please Enter a Valid Rate.");
            }

            else if (!double.TryParse(textBoxTenor.Text, out tenorCheck) ||
                Convert.ToDouble(textBoxTenor.Text) <= 0 || textBoxTenor.Text.ToString() == string.Empty)
            {
                MessageBox.Show("Please Enter a Valid Tenor.");
            }

            else
            {
                double tenor = Convert.ToDouble(textBoxTenor.Text);
                double rate = Convert.ToDouble(textBoxRate.Text) / 100; 

                AppEntity.InterestRates.Add(new InterestRate()
                {
                    Rate = rate,
                    Tenor = tenor,
                });

                AppEntity.SaveChanges();
                MessageBox.Show("Interest Rate added successfully!");
                this.Dispose();
            }
            
        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
