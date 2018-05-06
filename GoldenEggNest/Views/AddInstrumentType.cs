using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoldenEggNest
{
    public partial class AddInstrumentType : Form
    {
        PortfolioAppEntities AppEntity = new PortfolioAppEntities();

        public AddInstrumentType()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (comboBoxInstType.SelectedItem == null)
            {
                MessageBox.Show("Please make a selection!");
            }
            else
            {
                AppEntity.InstrumentTypes.Add(new InstrumentType()
                {
                    TypeName = Convert.ToString(comboBoxInstType.SelectedItem),
                });

                AppEntity.SaveChanges();

                MessageBox.Show("Instrument Type added successfully!");
            }

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
