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
    public partial class UserInfo : Form
    {
        public UserInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-A02U3PR;Initial Catalog=DB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select COUNT(*) from UserInfo where CNIC =  '" + textBox1.Text   + "'  and Password_2 = '" + textBox2.Text + "' ; ", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                UserView uv = new UserView(textBox1.Text);
                uv.Show();
            }
            else
            {
                MessageBox.Show("Incorrect UserName or Password "); 
                
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
