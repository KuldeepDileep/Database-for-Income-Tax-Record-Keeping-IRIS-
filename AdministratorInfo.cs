using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IRKS
{
    public partial class AdministratorInfo : Form
    {
        public AdministratorInfo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text == "admin")
            {
                this.Hide();
                AdministratorView adview = new AdministratorView();
                adview.Show();
            }
            else
            {
                MessageBox.Show("Invalid Password");
            }
        }
    }
}
