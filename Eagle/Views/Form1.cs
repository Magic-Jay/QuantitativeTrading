using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using Eagle.Business_Logic;



namespace Eagle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            disable_CalcuateButton();
            outputDataGridView.DataSource = EuropeanOption.SetDataTable();
            optionTypeComboBox.SelectedIndex = 0;
        }

        #region Button Controls
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
                    if (EuropeanOption.VaraianceReductionOptions.ContainsKey(item.ToString().Replace(' ', '_')))
                    {
                        EuropeanOption.VaraianceReductionOptions[item.ToString().Replace(' ', '_')] = true;
                    }
                }

                label11.Text = Environment.ProcessorCount.ToString() + " Cores";
                double s = String.IsNullOrEmpty(sTextBox.Text) ? 0 : Convert.ToDouble(sTextBox.Text);
                double k = String.IsNullOrEmpty(kTextBox.Text) ? 0 : Convert.ToDouble(kTextBox.Text);
                double t = String.IsNullOrEmpty(tenorTextbox.Text) ? 0 : Convert.ToDouble(tenorTextbox.Text);
                double sig = String.IsNullOrEmpty(sigTextBox.Text) ? 0 : (Convert.ToDouble(sigTextBox.Text) / 100);
                double r = String.IsNullOrEmpty(rTextBox.Text) ? 0 : (Convert.ToDouble(rTextBox.Text) / 100);
                int steps = String.IsNullOrEmpty(stepsTextBox.Text) ? 0 : Convert.ToInt32(stepsTextBox.Text);
                int trials = String.IsNullOrEmpty(trialsTextBox.Text) ? 0 : Convert.ToInt32(trialsTextBox.Text);

                disable_CalcuateButton();
                disable_ClearButton();
                diable_TestingButton();

                object[] parameter = new object[] { s, k, t, sig, r, steps, trials };
                backgroundWorker1.RunWorkerAsync(parameter);
            }
        }

        private void asyncCancelButton_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // Cancel the asynchronous operation.
                backgroundWorker1.CancelAsync();
            }

            enable_CalcuateButton();
            enable_ClearButton();
            enable_TestingButton();

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
            optionTypeComboBox.SelectedIndex = 1;
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
            outputDataGridView.DataSource = EuropeanOption.SetDataTable();
            timerLabel.Text = "";
            optionTypeComboBox.SelectedIndex = 0;
        }
        #endregion

        #region Background Worker

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            //int test = (int)e.Argument;

            object[] parameters = e.Argument as object[];
            int steps = Convert.ToInt16(parameters[5]);
            int trials = Convert.ToInt32(parameters[6]);
            double s = Convert.ToDouble(parameters[0]);
            double k = Convert.ToDouble(parameters[1]);
            double t = Convert.ToDouble(parameters[2]);
            double sig = Convert.ToDouble(parameters[3]);
            double r = Convert.ToDouble(parameters[4]);

            try
            {            

                for (int i = 1; i <= 1; i++)
                {
                    if (worker.CancellationPending == true)
                    {
                        e.Cancel = true;
                        break;
                    }
                    else
                    {
                        // Perform a time consuming operation and report progress.
                        e.Result = EuropeanOption.GetDataSet(steps, trials, s, k, t, sig, r);
                        System.Threading.Thread.Sleep(100);
                        worker.ReportProgress(i * 100);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        ////This event handler updates the progress.
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;           
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                MessageBox.Show("Cancelled!");
            }
            else if (e.Error != null)
            {
                //resultLabel.Text = "Error: " + e.Error.Message;
                MessageBox.Show("Error: " + e.Error.Message + "\n" +
                            EuropeanOption.log);
            }
            else
            {                

                var dataSet = (DataSet)e.Result;
                outputDataGridView.DataSource = dataSet.Tables[0];

                DataTable timer = dataSet.Tables[1];
                timerLabel.Text = timer.Rows[0][0].ToString() + " sec";

                MessageBox.Show("Calculation Succeed!");
                enable_CalcuateButton();
                enable_ClearButton();
                enable_TestingButton();
            }
        }
        #endregion

        #region UI Methods
        private void disable_CalcuateButton()
        {
            calculatePriceButton.Enabled = false;
            calculatePriceButton.BackColor = Color.Gray;
        }

        private void diable_TestingButton()
        {
            testingButton.Enabled = false;
            testingButton.BackColor = Color.Gray;
        }

        private void disable_ClearButton()
        {
            clearingButton.Enabled = false;
            clearingButton.BackColor = Color.Gray;

        }

        private void enable_CalcuateButton()
        {
            calculatePriceButton.Enabled = true;
            calculatePriceButton.BackColor = Color.FromArgb(4, 127, 160);
        }

        private void enable_TestingButton()
        {
            testingButton.Enabled = true;
            testingButton.BackColor = Color.FromArgb(0, 167, 181);
        }

        private void enable_ClearButton()
        {
            clearingButton.Enabled = true;
            clearingButton.BackColor = Color.White;
        }
        #endregion

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

