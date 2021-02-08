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
    public partial class Form2 : Form
    {
        public Form2(string CNIC, string taxyear)
        {
            InitializeComponent();
            textBox1.Text = CNIC;

            SqlConnection con = new SqlConnection("Data Source=DESKTOP-A02U3PR;Initial Catalog=DB;Integrated Security=True");
            con.Open();

            //SqlCommand cmd = new SqlCommand("select TotalIncome from TimePeriod where UserCNIC = '"+textBox1+"' and TaxYear = '"+taxyear+"'", con);
            //string score = textBox2.ToString(); 
            //object result = (int)cmd.ExecuteScalar();
            //int ti;
            //int.TryParse(result.ToString(), out ti);
            //textBox2.Text = ti.ToString();  
            // This would be update NOT INSERT 
           // cmd.Parameters.Add("'+ +'", SqlDbType.VarChar, 5).Value = score;
            //SqlCommand cmd = new SqlCommand("Update TimePeriod set TotalIncome = (select  (AnnualSalary + Pension + BehboodCertificate + ProfitOnDebt + ForeignRemittance + Allowances) from Income, TimePeriod, UserInfo where Income.ID = TimePeriod.Income_ID and TimePeriod.UserCNIC = UserInfo.CNIC and CNIC = '"+textBox1.Text+"'),TotalAssets = (select( (BankBalance+Vehicle+Jeweller+Gift+CashInHand+PrizeBond+Assets.Others)- (Outflows.HouseholdExpenses + Utilities + ForeignTravelling + EducationExpenses+ Outflows.Others ) )  from Assets , TimePeriod, UserInfo, Outflows where  Outflows.ID = Assets.Outflows_ID and Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.UserCNIC = UserInfo.CNIC and CNIC = '"+textBox1.Text+"' ) ", con );
            //cmd.ExecuteNonQuery();
            //SqlCommand cmd1 = new SqlCommand("Update TimePeriod SET TotalTax = (  ( (select TotalIncome from TimePeriod where UserCNIC = '"+textBox1.Text+ "') - ( select (Utilities + Property + Education + Winnings + Insurance + Dividend + Functions + AirTicket + PensionFund + Auction + [Transfer]+ CommercialVehicleTokenTax + Leasing + Registration + Sale+ Rebate + OtherTax ) from TaxReductions, TimePeriod, UserInfo where TaxReductions.ID = TimePeriod.TaxReductions_ID  and UserInfo.CNIC = TimePeriod.UserCNIC and UserCNIC = '" + textBox1.Text + "') ) * 0.05  )    where (UserCNIC = (select CNIC from UserInfo, TimePeriod where TimePeriod.UserCNIC = UserInfo.CNIC ))", con);
            //cmd1.ExecuteNonQuery(); 
            //SqlCommand cmd1 = new SqlCommand("select TotalIncome from TimePeriod, UserInfo where UserInfo.CNIC = TimePeriod.UserCNIC and CNIC = '"+textBox1.Text+"'", con);
            //SqlCommand cmd2 = new SqlCommand("select TotalAssets from TimePeriod, UserInfo where UserInfo.CNIC = TimePeriod.UserCNIC and CNIC = '" + textBox1.Text + "'", con);
            //SqlCommand cmd3 = new SqlCommand("select (Utilities + Property + Education + Winnings + Insurance + Dividend + Functions + AirTicket + PensionFund + Auction + [Transfer]+ CommercialVehicleTokenTax + Leasing + Registration + Sale+ Rebate + OtherTax ) from TaxReductions, TimePeriod, UserInfo where TaxReductions.ID = TimePeriod.TaxReductions_ID   and UserInfo.CNIC = TimePeriod.UserCNIC and CNIC = '" + textBox1.Text + "'", con);
            //SqlCommand cmd4 = new SqlCommand("select ((select TotalIncome from TimePeriod, UserInfo where UserInfo.CNIC = TimePeriod.UserCNIC and CNIC = '" + textBox1.Text + "') - (select (Utilities + Property + Education + Winnings + Insurance + Dividend + Functions + AirTicket + PensionFund + Auction + [Transfer] + CommercialVehicleTokenTax + Leasing + Registration + Sale+ Rebate + OtherTax ) from TaxReductions, TimePeriod, UserInfo where TaxReductions.ID = TimePeriod.TaxReductions_ID   and UserInfo.CNIC = TimePeriod.UserCNIC and CNIC = '" + textBox1.Text + "')) ", con); 
            //cmd.ExecuteNonQuery();
            // cmd1.ExecuteNonQuery();
            //cmd2.ExecuteNonQuery();
            //cmd3.ExecuteNonQuery();
            //cmd4.ExecuteNonQuery();
            //    cmd1.ExecuteNonQuery();
            //object result = (int)cmd1.ExecuteScalar();
            // if ()
            //textBox2.Text = result.ToString(); 

            // cmd.ExecuteNonQuery();
            con.Close(); 

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
