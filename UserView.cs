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
    public partial class UserView : Form
    {
        public UserView(string CNIC_No)
        {
         
            InitializeComponent();
            // public string CNIC = CNIC_No; 
            textBox1.Text = CNIC_No; 
        }

        private void button2_Click(object sender, EventArgs e)
        {

            AddReturn addnew = new AddReturn(textBox1.Text);
            addnew.Show();
        }

        private void UserView_Load(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-A02U3PR;Initial Catalog=projDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("select * from UserInfo where CNIC = '" +textBox1.Text+ "'  ", con);

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-A02U3PR;Initial Catalog=DB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            if (textBox2.Text.Length == 0)
            {
                cmd.CommandText = "select * from UserInfo, TimePeriod, TaxReductions, Income, Assets, Outflows where UserInfo.CNIC = TimePeriod.UserCNIC and TaxReductions.ID = TimePeriod.TaxReductions_ID and TimePeriod.Income_ID = Income.ID and TimePeriod.Assets_RefNo = Assets.RefNo and Assets.Outflows_ID = Outflows.ID and CNIC = '"+textBox1.Text+"' ";
            }
            else
            {
                cmd.CommandText = "select * from UserInfo, TimePeriod, TaxReductions, Income, Assets, Outflows where UserInfo.CNIC = TimePeriod.UserCNIC and TaxReductions.ID = TimePeriod.TaxReductions_ID and TimePeriod.Income_ID = Income.ID and TimePeriod.Assets_RefNo = Assets.RefNo and Assets.Outflows_ID = Outflows.ID and CNIC = '" + textBox1.Text + "' and TaxYear = '"+textBox2.Text+"'";

            }
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
    }
}
