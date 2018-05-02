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
    public partial class Form1 : Form
    {
       Portfolio_x0020_ManagerContainer pmc = new Portfolio_x0020_ManagerContainer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {

          pmc.InstTypes.Add(new InstType()
           {
               TypeName = Convert.ToString(comboBoxInstType.SelectedItem),
           });

            pmc.SaveChanges();

            MessageBox.Show("Instrument Type added successfully!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxAddInstruType_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxInstType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
