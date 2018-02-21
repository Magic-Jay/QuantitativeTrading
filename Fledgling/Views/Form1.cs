using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;



namespace Fledgling
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
        }

        private void Form_Load(object sender, EventArgs e)
        {
            disable_CalcuateButton();
            outputDataGridView.DataSource = Business_Logic.PricingAlgo.SetDataTable();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(sTextBox.Text) || String.IsNullOrEmpty(kTextBox.Text) || String.IsNullOrEmpty(tenorTextbox.Text)
                || String.IsNullOrEmpty(sigTextBox.Text) || String.IsNullOrEmpty(rTextBox.Text) || String.IsNullOrEmpty(stepsTextBox.Text)
                || String.IsNullOrEmpty(trialsTextBox.Text))
            {
                MessageBox.Show("Please Enter all your input!");
            }
            else
            {
                foreach (var item in checkedListBox1.CheckedItems)
                {
                    Business_Logic.PricingAlgo.Antithetic = (item.ToString() == "Antithetic Variance Reduction");
                   
                }
                
                double s = String.IsNullOrEmpty(sTextBox.Text) ? 0 : Convert.ToDouble(sTextBox.Text);
                double k = String.IsNullOrEmpty(kTextBox.Text) ? 0 : Convert.ToDouble(kTextBox.Text);
                double t = String.IsNullOrEmpty(tenorTextbox.Text) ? 0 : Convert.ToDouble(tenorTextbox.Text);
                double sig = String.IsNullOrEmpty(sigTextBox.Text) ? 0 : (Convert.ToDouble(sigTextBox.Text) / 100);
                double r = String.IsNullOrEmpty(rTextBox.Text) ? 0 : (Convert.ToDouble(rTextBox.Text) / 100);
                int steps = String.IsNullOrEmpty(stepsTextBox.Text) ? 0 : Convert.ToInt32(stepsTextBox.Text);
                int trials = String.IsNullOrEmpty(trialsTextBox.Text) ? 0 : Convert.ToInt32(trialsTextBox.Text);

                try
                {
                    outputDataGridView.DataSource = Business_Logic.PricingAlgo.GetDataTable(steps, trials, s, k, t, sig, r);     
                    timerLabel.Text = Convert.ToString(Business_Logic.PricingAlgo.AlgoTime) + " sec";

                    //MessageBox.Show("Calculation Succeed!" + Business_Logic.PricingAlgo.log);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }                        
        }

        private void testingButton_Click(object sender, EventArgs e)
        {
            sTextBox.Text = "50";
            kTextBox.Text = "50";
            tenorTextbox.Text = "1";
            sigTextBox.Text = "50";
            rTextBox.Text = "5";
            stepsTextBox.Text = "100";
            trialsTextBox.Text = "10000";
        }

        private void clearingButton_Click(object sender, EventArgs e)
        {
            sTextBox.Text = "";
            kTextBox.Text = "";
            tenorTextbox.Text = "";
            sigTextBox.Text = "";
            rTextBox.Text = "";
            stepsTextBox.Text = "";
            trialsTextBox.Text = "";
            outputDataGridView.DataSource = Business_Logic.PricingAlgo.SetDataTable();
            timerLabel.Text = "";            
        }

        private void disable_CalcuateButton()
        {
            calculatePriceButton.Enabled = false;
            calculatePriceButton.BackColor = System.Drawing.Color.Gray;
        }

        #region Client-Side Validation       

        private void sTextBox_TextChanged(object sender, EventArgs e)
        {
            validate_Number(sTextBox);
        }

        private void kTextBox_TextChanged(object sender, EventArgs e)
        {
            validate_Number(kTextBox);
        }

        private void tenorTextBox_TextChanged(object sender, EventArgs e)
        {
            validate_Number(tenorTextbox);
        }

        private void rTextBox_TextChanged(object sender, EventArgs e)
        {
            validate_Number(rTextBox);
        }

        private void sigTextBox_TextChanged(object sender, EventArgs e)
        {
            validate_Number(sigTextBox);
        }

        private void stepsTextBox_TextChanged(object sender, EventArgs e)
        {
            validate_Int(stepsTextBox);
        }

        private void trialsTextBox_TextChanged(object sender, EventArgs e)
        {
            validate_Int(trialsTextBox);           
        }

        //Some UI Validations using errorProvider. Disable calcuate button if input is invalid.
        private void validate_Number(Control c)
        {
            double num;
            if (!double.TryParse(c.Text, out num) || num < 0)
            {
                errorProvider1.SetError(c, "Please Enter a Positive Number!");
                disable_CalcuateButton();
            }
            else
            {
                errorProvider1.SetError(c, string.Empty);
                calculatePriceButton.Enabled = true;
                calculatePriceButton.BackColor = System.Drawing.Color.FromArgb(0, 167, 181);
            }
        }

        private void validate_Int(Control c)
        {
            int num;
            if (!Int32.TryParse(c.Text, out num) || num < 0)
            {
                errorProvider1.SetError(c, "Please Enter a Positive Integer!");
            }
            else
            {
                errorProvider1.SetError(c, string.Empty);
                calculatePriceButton.Enabled = true;
                calculatePriceButton.BackColor = System.Drawing.Color.FromArgb(0, 167, 181);
            }
        }

        #endregion

        #region Football Field        
        //An attempt to shorten client-side validation but failed
        //Add the line below at Form1() method.
        //sTextBox.LostFocus += TextBox_LostFocus;

        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    var c = GetAll(this, typeof(TextBox));
        //    MessageBox.Show("Total Controls: " + c.Count());
        //}

        //private void TextBox_LostFocus(object sender, EventArgs e)
        //{
        //    var c = GetAll(this, typeof(TextBox));
        //    double num;

        //    foreach (Control item in c)
        //    {
        //        if (!double.TryParse(item.Text, out num) || num < 0)
        //        {
        //            errorProvider1.SetError(item, "Please Enter a Positive Number!");
        //            calculatePriceButton.Enabled = false;
        //            calculatePriceButton.BackColor = System.Drawing.Color.Gray;
        //        }
        //        else
        //        {
        //            errorProvider1.SetError(item, string.Empty);
        //            calculatePriceButton.Enabled = true;
        //            calculatePriceButton.BackColor = System.Drawing.Color.FromArgb(0, 167, 181);
        //        }
        //    }
        //}

        //public IEnumerable<Control> GetAll(Control control, Type type)
        //{
        //    var controls = control.Controls.Cast<Control>();

        //    return controls.SelectMany(ctrl => GetAll(ctrl, type))
        //                              .Concat(controls)
        //                              .Where(c => c.GetType() == type);
        //}
        #endregion

    }
}

