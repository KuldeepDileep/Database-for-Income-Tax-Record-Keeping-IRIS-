using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace IRKS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            if(radioButton2.Checked == true )
            {
                AdministratorInfo logA = new AdministratorInfo();
                logA.Show();
            }
            else if (radioButton1.Checked == true )
            {
                UserInfo logA = new UserInfo();
                logA.Show();
            }
            
        }


    }
}
