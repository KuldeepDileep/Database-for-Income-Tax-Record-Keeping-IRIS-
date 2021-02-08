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
    //////////////////////////////////TO CHANGE ?/////////////////////////////////////////////////////////////////////
{
    public partial class AdministratorView : Form
    {
        public AdministratorView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-A02U3PR;Initial Catalog=DB;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (textBox1.Text == "" && textBox4.Text == "" && textBox3.Text == "" && textBox2.Text == "")
            {
                cmd.CommandText = "select CNIC, Password_2, PIN, Resident, TaxYear, TotalIncome, TotalTax, TotalAssets from Assets, Income, TimePeriod, UserInfo where Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.Income_ID = Income.ID and TimePeriod.UserCNIC = UserInfo.CNIC "; 
                // -- cmd.CommandText = " select ui.CNIC , ui.Password_2 , ui.PIN, ui.Resident, ui.TotalIncome, ui.TotalTax, ui.TotalAssets from UserInfo as ui, Junctiontableforuserinforandtimeperiod as j, TimePeriod as tp, Income as i, TaxReductions as tr, Assets as a, Outflows as o where ui.CNIC = j.UserInfo_CNIC and j.TimePeriod_RefNo = tp.RefNo and tp.Income_ID = i.ID and tp.TaxReductions_ID = tr.ID and tp.Assets_RefNo = a.RefNo and a.Outflows_ID = o.ID ";

            }
            else if (textBox1.Text != "" && textBox4.Text == "" && textBox3.Text == "" && textBox2.Text == "")
            {
                cmd.CommandText = "select CNIC, Password_2, PIN, Resident, TaxYear, TotalIncome, TotalTax, TotalAssets from Assets, Income, TimePeriod, UserInfo where Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.Income_ID = Income.ID and TimePeriod.UserCNIC = UserInfo.CNIC and CNIC = '"+textBox1.Text+"'";

                // cmd.CommandText = "select ui.CNIC , ui.Password_2 , ui.PIN, ui.Resident, ui.TotalIncome, ui.TotalTax, ui.TotalAssets   from UserInfo as ui, Junctiontableforuserinforandtimeperiod as j, TimePeriod as tp, Income as i, TaxReductions as tr, Assets as a, Outflows as o where ui.CNIC = j.UserInfo_CNIC and j.TimePeriod_RefNo = tp.RefNo and tp.Income_ID = i.ID and tp.TaxReductions_ID = tr.ID and tp.Assets_RefNo = a.RefNo and a.Outflows_ID = o.ID and CNIC LIKE  '" + textBox1.Text + "%'";
            }
            else if (textBox1.Text == "" && textBox4.Text != "" && textBox3.Text == "" && textBox2.Text == "" )
            {
                cmd.CommandText = "select CNIC, Password_2, PIN, Resident, TaxYear, TotalIncome, TotalTax, TotalAssets from Assets, Income, TimePeriod, UserInfo where Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.Income_ID = Income.ID and TimePeriod.UserCNIC = UserInfo.CNIC and TaxYear = '"+textBox4.Text+"'";

                //  cmd.CommandText = "select ui.CNIC , ui.Password_2 , ui.PIN, ui.Resident, ui.TotalIncome, ui.TotalTax, ui.TotalAssets  from UserInfo as ui, Junctiontableforuserinforandtimeperiod as j, TimePeriod as tp, Income as i, TaxReductions as tr, Assets as a, Outflows as o where ui.CNIC = j.UserInfo_CNIC and j.TimePeriod_RefNo = tp.RefNo and tp.Income_ID = i.ID and tp.TaxReductions_ID = tr.ID and tp.Assets_RefNo = a.RefNo and a.Outflows_ID = o.ID and tp.TaxYear LIKE '" + textBox4.Text+"'";
            }
            else if (textBox1.Text == "" && textBox4.Text == "" && textBox3.Text != "" && textBox2.Text == "")
            {
                cmd.CommandText = "select CNIC, Password_2, PIN, Resident, TaxYear, TotalIncome, TotalTax, TotalAssets from Assets, Income, TimePeriod, UserInfo where Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.Income_ID = Income.ID and TimePeriod.UserCNIC = UserInfo.CNIC and BankBalance = '"+textBox3.Text+"'";

                // cmd.CommandText = "select ui.CNIC , ui.Password_2 , ui.PIN, ui.Resident, ui.TotalIncome, ui.TotalTax, ui.TotalAssets from UserInfo as ui, Junctiontableforuserinforandtimeperiod as j, TimePeriod as tp, Income as i, TaxReductions as tr, Assets as a, Outflows as o where ui.CNIC = j.UserInfo_CNIC and j.TimePeriod_RefNo = tp.RefNo and tp.Income_ID = i.ID and tp.TaxReductions_ID = tr.ID and tp.Assets_RefNo = a.RefNo and a.Outflows_ID = o.ID and a.BankBalance LIKE '"+ textBox3.Text +"'";
            }
            else if (textBox1.Text == "" && textBox4.Text != "" && textBox3.Text == "" && textBox2.Text != "")
            {
                cmd.CommandText = "select CNIC, Password_2, PIN, Resident, TaxYear, TotalIncome, TotalTax, TotalAssets from Assets, Income, TimePeriod, UserInfo where Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.Income_ID = Income.ID and TimePeriod.UserCNIC = UserInfo.CNIC and AnnualSalary = '"+textBox2.Text+"' ";

                // cmd.CommandText = "select ui.CNIC , ui.Password_2 , ui.PIN, ui.Resident, ui.TotalIncome, ui.TotalTax, ui.TotalAssets   from UserInfo as ui, Junctiontableforuserinforandtimeperiod as j, TimePeriod as tp, Income as i, TaxReductions as tr, Assets as a, Outflows as o where ui.CNIC = j.UserInfo_CNIC and j.TimePeriod_RefNo = tp.RefNo and tp.Income_ID = i.ID and tp.TaxReductions_ID = tr.ID and tp.Assets_RefNo = a.RefNo and a.Outflows_ID = o.ID and i.AnnualSalary LIKE '" + textBox2.Text + "'";
            }

            ///////////////////////////////////////////
            else if (textBox1.Text != "" && textBox4.Text != "" && textBox3.Text == "" && textBox2.Text == "") // C , B 
            {
                cmd.CommandText = "select CNIC, Password_2, PIN, Resident, TaxYear, TotalIncome, TotalTax, TotalAssets from Assets, Income, TimePeriod, UserInfo where Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.Income_ID = Income.ID and TimePeriod.UserCNIC = UserInfo.CNIC and CNIC = '" + textBox1.Text + "' and TaxYear = '" + textBox4.Text + "'";

                //cmd.CommandText = "select ui.CNIC , ui.Password_2 , ui.PIN, ui.Resident, ui.TotalIncome, ui.TotalTax, ui.TotalAssets  from UserInfo as ui, Junctiontableforuserinforandtimeperiod as j, TimePeriod as tp, Income as i, TaxReductions as tr, Assets as a, Outflows as o where ui.CNIC = j.UserInfo_CNIC and j.TimePeriod_RefNo = tp.RefNo and tp.Income_ID = i.ID and tp.TaxReductions_ID = tr.ID and tp.Assets_RefNo = a.RefNo and a.Outflows_ID = o.ID and  CNIC LIKE  '" + textBox1.Text + "%' and    tp.TaxYear LIKE '" + textBox4.Text + "' ";
            }
            else if (textBox1.Text != "" && textBox4.Text == "" && textBox3.Text != "" && textBox2.Text == "") // C, T 
            {
                cmd.CommandText = "select CNIC, Password_2, PIN, Resident, TaxYear, TotalIncome, TotalTax, TotalAssets from Assets, Income, TimePeriod, UserInfo where Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.Income_ID = Income.ID and TimePeriod.UserCNIC = UserInfo.CNIC and CNIC = '" + textBox1.Text + "' and BankBalance = '" + textBox3.Text + "'";

                // cmd.CommandText = "select ui.CNIC , ui.Password_2 , ui.PIN, ui.Resident, ui.TotalIncome, ui.TotalTax, ui.TotalAssets  from UserInfo as ui, Junctiontableforuserinforandtimeperiod as j, TimePeriod as tp, Income as i, TaxReductions as tr, Assets as a, Outflows as o where ui.CNIC = j.UserInfo_CNIC and j.TimePeriod_RefNo = tp.RefNo and tp.Income_ID = i.ID and tp.TaxReductions_ID = tr.ID and tp.Assets_RefNo = a.RefNo and a.Outflows_ID = o.ID and CNIC LIKE  '" + textBox1.Text + "%'  and a.BankBalance LIKE '" + textBox3.Text + "'";
            }
            else if (textBox1.Text != "" && textBox4.Text == "" && textBox3.Text == "" && textBox2.Text != "") // C, S 
            {
                cmd.CommandText = "select CNIC, Password_2, PIN, Resident, TaxYear, TotalIncome, TotalTax, TotalAssets from Assets, Income, TimePeriod, UserInfo where Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.Income_ID = Income.ID and TimePeriod.UserCNIC = UserInfo.CNIC and CNIC = '" + textBox1.Text + "' and AnnualSalary = '" + textBox2.Text + "'";

                //cmd.CommandText = "select ui.CNIC , ui.Password_2 , ui.PIN, ui.Resident, ui.TotalIncome, ui.TotalTax, ui.TotalAssets  from UserInfo as ui, Junctiontableforuserinforandtimeperiod as j, TimePeriod as tp, Income as i, TaxReductions as tr, Assets as a, Outflows as o where ui.CNIC = j.UserInfo_CNIC and j.TimePeriod_RefNo = tp.RefNo and tp.Income_ID = i.ID and tp.TaxReductions_ID = tr.ID and tp.Assets_RefNo = a.RefNo and a.Outflows_ID = o.ID and CNIC LIKE  '" + textBox1.Text + "%'    and i.AnnualSalary LIKE '" + textBox2.Text + "'";
            }
            else if (textBox1.Text == "" && textBox4.Text != "" && textBox3.Text != "" && textBox2.Text == "") // B, T
            {
                cmd.CommandText = "select CNIC, Password_2, PIN, Resident, TaxYear, TotalIncome, TotalTax, TotalAssets from Assets, Income, TimePeriod, UserInfo where Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.Income_ID = Income.ID and TimePeriod.UserCNIC = UserInfo.CNIC and TaxYear = '" + textBox4.Text + "' and BankBalance = '" + textBox3.Text + "'";

                // cmd.CommandText = "select ui.CNIC , ui.Password_2 , ui.PIN, ui.Resident, ui.TotalIncome, ui.TotalTax, ui.TotalAssets  from UserInfo as ui, Junctiontableforuserinforandtimeperiod as j, TimePeriod as tp, Income as i, TaxReductions as tr, Assets as a, Outflows as o where ui.CNIC = j.UserInfo_CNIC and j.TimePeriod_RefNo = tp.RefNo and tp.Income_ID = i.ID and tp.TaxReductions_ID = tr.ID and tp.Assets_RefNo = a.RefNo and a.Outflows_ID = o.ID and tp.TaxYear LIKE '" + textBox4.Text + "' and a.BankBalance LIKE '" + textBox3.Text + "'";
            }
            else if (textBox1.Text == "" && textBox4.Text != "" && textBox3.Text == "" && textBox2.Text != "") // B, S
            {
                cmd.CommandText = "select CNIC, Password_2, PIN, Resident, TaxYear, TotalIncome, TotalTax, TotalAssets from Assets, Income, TimePeriod, UserInfo where Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.Income_ID = Income.ID and TimePeriod.UserCNIC = UserInfo.CNIC and TaxYear = '" + textBox4.Text + "' and AnnualSalary = '" + textBox2.Text + "'";

                //cmd.CommandText = "select ui.CNIC , ui.Password_2 , ui.PIN, ui.Resident, ui.TotalIncome, ui.TotalTax, ui.TotalAssets  from UserInfo as ui, Junctiontableforuserinforandtimeperiod as j, TimePeriod as tp, Income as i, TaxReductions as tr, Assets as a, Outflows as o where ui.CNIC = j.UserInfo_CNIC and j.TimePeriod_RefNo = tp.RefNo and tp.Income_ID = i.ID and tp.TaxReductions_ID = tr.ID and tp.Assets_RefNo = a.RefNo and a.Outflows_ID = o.ID and tp.TaxYear LIKE '" + textBox4.Text + "' and i.AnnualSalary LIKE '" + textBox2.Text + "'";
            }
            else if (textBox1.Text == "" && textBox4.Text == "" && textBox3.Text != "" && textBox2.Text != "") // T, S  
            {
                cmd.CommandText = "select CNIC, Password_2, PIN, Resident, TaxYear, TotalIncome, TotalTax, TotalAssets from Assets, Income, TimePeriod, UserInfo where Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.Income_ID = Income.ID and TimePeriod.UserCNIC = UserInfo.CNIC and BankBalance = '" + textBox3.Text + "' and AnnualSalary = '" + textBox2.Text + "'";

                //cmd.CommandText = "select ui.CNIC , ui.Password_2 , ui.PIN, ui.Resident, ui.TotalIncome, ui.TotalTax, ui.TotalAssets  from UserInfo as ui, Junctiontableforuserinforandtimeperiod as j, TimePeriod as tp, Income as i, TaxReductions as tr, Assets as a, Outflows as o where ui.CNIC = j.UserInfo_CNIC and j.TimePeriod_RefNo = tp.RefNo and tp.Income_ID = i.ID and tp.TaxReductions_ID = tr.ID and tp.Assets_RefNo = a.RefNo and a.Outflows_ID = o.ID and a.BankBalance LIKE '" + textBox3.Text + "'  and i.AnnualSalary LIKE '" + textBox2.Text + "'";
            }
            ///////////////////////////////////////// pairs of 3 ////////////////////////////////////////////////////////
            ///
            else if (textBox1.Text != "" && textBox4.Text != "" && textBox3.Text != "" && textBox2.Text == "")
            {
                cmd.CommandText = "select CNIC, Password_2, PIN, Resident, TaxYear, TotalIncome, TotalTax, TotalAssets from Assets, Income, TimePeriod, UserInfo where Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.Income_ID = Income.ID and TimePeriod.UserCNIC = UserInfo.CNIC and BankBalance = '" + textBox3.Text + "' and CNIC = '" + textBox1.Text + "'  and TaxYear = '" + textBox4.Text + "'";

                //cmd.CommandText = "select ui.CNIC , ui.Password_2 , ui.PIN, ui.Resident, ui.TotalIncome, ui.TotalTax, ui.TotalAssets  from UserInfo as ui, Junctiontableforuserinforandtimeperiod as j, TimePeriod as tp, Income as i, TaxReductions as tr, Assets as a, Outflows as o where ui.CNIC = j.UserInfo_CNIC and j.TimePeriod_RefNo = tp.RefNo and tp.Income_ID = i.ID and tp.TaxReductions_ID = tr.ID and tp.Assets_RefNo = a.RefNo and a.Outflows_ID = o.ID  and CNIC LIKE  '" + textBox1.Text + "%' and    tp.TaxYear LIKE '" + textBox4.Text + "' and a.BankBalance LIKE '" + textBox3.Text + "'";
            }
            else if (textBox1.Text == "" && textBox4.Text != "" && textBox3.Text != "" && textBox2.Text != "")
            {
                cmd.CommandText = "select CNIC, Password_2, PIN, Resident, TaxYear, TotalIncome, TotalTax, TotalAssets from Assets, Income, TimePeriod, UserInfo where Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.Income_ID = Income.ID and TimePeriod.UserCNIC = UserInfo.CNIC and BankBalance = '" + textBox3.Text + "' and AnnualSalary = '" + textBox2.Text + "'  and TaxYear = '" + textBox4.Text + "'";

                //cmd.CommandText = "select ui.CNIC , ui.Password_2 , ui.PIN, ui.Resident, ui.TotalIncome, ui.TotalTax, ui.TotalAssets  from UserInfo as ui, Junctiontableforuserinforandtimeperiod as j, TimePeriod as tp, Income as i, TaxReductions as tr, Assets as a, Outflows as o where ui.CNIC = j.UserInfo_CNIC and j.TimePeriod_RefNo = tp.RefNo and tp.Income_ID = i.ID and tp.TaxReductions_ID = tr.ID and tp.Assets_RefNo = a.RefNo and a.Outflows_ID = o.ID  and  i.AnnualSalary LIKE '" + textBox2.Text + "' and    tp.TaxYear LIKE '" + textBox4.Text + "' and a.BankBalance LIKE '" + textBox3.Text + "'";
            }
            else if (textBox1.Text != "" && textBox4.Text != "" && textBox3.Text == "" && textBox2.Text != "")
            {
                cmd.CommandText = "select CNIC, Password_2, PIN, Resident, TaxYear, TotalIncome, TotalTax, TotalAssets from Assets, Income, TimePeriod, UserInfo where Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.Income_ID = Income.ID and TimePeriod.UserCNIC = UserInfo.CNIC and CNIC = '" + textBox1.Text + "' and AnnualSalary = '" + textBox2.Text + "'  and TaxYear = '" + textBox4.Text + "'";

                //cmd.CommandText = "select ui.CNIC , ui.Password_2 , ui.PIN, ui.Resident, ui.TotalIncome, ui.TotalTax, ui.TotalAssets  from UserInfo as ui, Junctiontableforuserinforandtimeperiod as j, TimePeriod as tp, Income as i, TaxReductions as tr, Assets as a, Outflows as o where ui.CNIC = j.UserInfo_CNIC and j.TimePeriod_RefNo = tp.RefNo and tp.Income_ID = i.ID and tp.TaxReductions_ID = tr.ID and tp.Assets_RefNo = a.RefNo and a.Outflows_ID = o.ID  and   CNIC LIKE  '" + textBox1.Text + "%' and    tp.TaxYear LIKE '" + textBox4.Text + "'  and i.AnnualSalary LIKE '" + textBox2.Text + "'";
            }
            ///////////////// All given /////////////////////////////////////////////////////////////////////////////////
            ///
            else 
            {
                cmd.CommandText = "select CNIC, Password_2, PIN, Resident, TaxYear, TotalIncome, TotalTax, TotalAssets from Assets, Income, TimePeriod, UserInfo where Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.Income_ID = Income.ID and TimePeriod.UserCNIC = UserInfo.CNIC and CNIC = '" + textBox1.Text + "' and AnnualSalary = '" + textBox2.Text + "'  and TaxYear = '" + textBox4.Text + "' and  BankBalance = '" + textBox3.Text+ "' ";

                // cmd.CommandText = "select ui.CNIC , ui.Password_2 , ui.PIN, ui.Resident, ui.TotalIncome, ui.TotalTax, ui.TotalAssets  from UserInfo as ui, Junctiontableforuserinforandtimeperiod as j, TimePeriod as tp, Income as i, TaxReductions as tr, Assets as a, Outflows as o where ui.CNIC = j.UserInfo_CNIC and j.TimePeriod_RefNo = tp.RefNo and tp.Income_ID = i.ID and tp.TaxReductions_ID = tr.ID and tp.Assets_RefNo = a.RefNo and a.Outflows_ID = o.ID and CNIC LIKE  '" + textBox1.Text + "%' and    tp.TaxYear LIKE '" + textBox4.Text + "' and a.BankBalance LIKE '" + textBox3.Text + "' and i.AnnualSalary LIKE '" + textBox2.Text + "'";
            }
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt; 
            con.Close(); 
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)

        {

        }
    }
}
