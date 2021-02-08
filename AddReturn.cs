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
    public partial class AddReturn : Form
    {
        public AddReturn(string CNIC)
        {
            InitializeComponent();
            textBox29.Text = CNIC; // CNIC would be stored in read only form 
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            


        }

        private void AddReturn_Load(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
   
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-A02U3PR;Initial Catalog=DB;Integrated Security=True");
            con.Open();

            SqlCommand cmd_check_year = new SqlCommand("select COUNT(*) from TimePeriod tp where UserCNIC = '"+textBox29.Text+"'  and TaxYear = '"+textBox38.Text+"' ", con);
            object eligibility1 = (int)cmd_check_year.ExecuteScalar();
            int eli;
        
            int.TryParse(eligibility1.ToString(), out eli);


            if (textBox38.Text != DateTime.Now.Year.ToString())
            {
                MessageBox.Show("Invalid tax year ");
            }
            if (eli >= 1)
            {
                MessageBox.Show("You have alraedy entered tax record for this year before");
            }
            else
            {

            
                SqlDataAdapter sda = new SqlDataAdapter("Select  MAX(ID) + 1 from Outflows ", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                SqlCommand cmdd = new SqlCommand("select (MAX(ID)+1) from Outflows", con);
                SqlCommand cmdd1 = new SqlCommand("select (MAX(RefNo)+1) from Assets", con);
                SqlCommand cmdd2 = new SqlCommand("select (MAX(ID)+1) from TaxReductions", con); //TaxReductions 
                SqlCommand cmdd3 = new SqlCommand("select (MAX(ID)+1) from Income", con); // Income 
                SqlCommand cmdd4 = new SqlCommand("select (MAX(RefNo)+1) from TimePeriod", con); // Income 

                object result = (int)cmdd.ExecuteScalar();
                object result1 = (int)cmdd1.ExecuteScalar();
                object result2 = (int)cmdd2.ExecuteScalar();
                object result3 = (int)cmdd3.ExecuteScalar();
                object result4 = (long)cmdd4.ExecuteScalar();

                int ID; // Outflows 
                int RefNo; // Assets 
                int ID_TaxRed; // Tax Reduction 
                int ID_Income; // Income 
                int ID_TimePeriod; // ID for Time Period 

                //// For ID 
                if (result == null || result == DBNull.Value) // Need to test if this works: when database is empty and you need to instroduce the first tax payer 
                {
                    ID = 1;
                }
                else
                {
                    int.TryParse(result.ToString(), out ID);
                }
                //For ref No 
                if (result1 == null || result1 == DBNull.Value) // Need to test if this works: when database is empty and you need to instroduce the first tax payer 
                {
                    RefNo = 1;
                }
                else
                {
                    int.TryParse(result1.ToString(), out RefNo);
                }
                // For ID of Tax reductions rebates 
                if (result2 == null || result2 == DBNull.Value) // Need to test if this works: when database is empty and you need to instroduce the first tax payer 
                {
                    ID_TaxRed = 1;
                }
                else
                {
                    int.TryParse(result2.ToString(), out ID_TaxRed);
                }
                // For ID of Income 
                if (result3 == null || result3 == DBNull.Value) // Need to test if this works: when database is empty and you need to instroduce the first tax payer 
                {
                    ID_Income = 1;
                }
                else
                {
                    int.TryParse(result3.ToString(), out ID_Income);
                }
                // For ID of Time Period 
                if (result4 == null || result4 == DBNull.Value) // Need to test if this works: when database is empty and you need to instroduce the first tax payer 
                {
                    ID_TimePeriod  = 1;
                }
                else
                {
                    int.TryParse(result4.ToString(), out ID_TimePeriod);
                }


                SqlCommand cmd = new SqlCommand("insert into Outflows (ID, Utilities, HouseholdExpenses, ForeignTravelling, EducationExpenses, Others) values (  '" + ID + "' ,'" + textBox8.Text + "' ,'" + textBox9.Text + "' , '" + textBox12.Text + "', '" + textBox11.Text + "', '" + textBox10.Text + "'); insert into Assets(RefNo, Outflows_ID, BankBalance, Vehicle, Jeweller, Gift, CashInHand, PrizeBond, Others) values (  '" + RefNo + "' ,'" + ID + "', '" + textBox3.Text + "' ,'" + textBox7.Text + "' , '" + textBox1.Text + "', '" + textBox6.Text + "', '" + textBox2.Text + "', '" + textBox5.Text + "', '" + textBox4.Text + "'); insert into TaxReductions(ID, Utilities, Property, Education, Winnings, Insurance, Dividend, Functions, Airticket, PensionFund, Auction, Transfer, CommercialVehicleTokenTax, Leasing, Registration, Sale, Rebate, OtherTax, Zakat) values ('" + ID_TaxRed + "' , '" + textBox20.Text + "', '" + textBox19.Text + "', '" + textBox18.Text + "', '" + textBox17.Text + "', '" + textBox16.Text + "', '" + textBox15.Text + "', '" + textBox31.Text + "', '" + textBox14.Text + "', '" + textBox21.Text + "', '" + textBox22.Text + "', '" + textBox30.Text + "', '" + textBox13.Text + "', '" + textBox23.Text + "', '" + textBox24.Text + "', '" + textBox25.Text + "', '" + textBox26.Text + "', '" + textBox27.Text + "', '" + textBox28.Text + "') ; insert into Income(ID, AnnualSalary, Pension, BehboodCertificate, ProfitOnDebt, ForeignRemittance, Allowances) values ( '" + ID_Income + "' ,'" + textBox32.Text + "' , '" + textBox33.Text + "' , '" + textBox37.Text + "' , '" + textBox35.Text + "' , '" + textBox34.Text + "' , '" + textBox36.Text + "' ); ", con);
                SqlCommand cmd1 = new SqlCommand("insert into TimePeriod (RefNo, TaxReductions_ID, Assets_RefNo, Income_ID, TaxYear,  UserCNIC) values ('"+ID_TimePeriod+"' , '"+ID_TaxRed+"' , '"+RefNo+"' , '"+ID_Income+"' , '"+textBox38.Text+"', '"+textBox29.Text+"' ) ;", con);
           
                cmd.ExecuteNonQuery();
                cmd1.ExecuteNonQuery(); 
                SqlCommand cmd6 = new SqlCommand("Update TimePeriod set TotalIncome = (select  (AnnualSalary + Pension + BehboodCertificate + ProfitOnDebt + ForeignRemittance + Allowances) from Income, TimePeriod, UserInfo where Income.ID = TimePeriod.Income_ID and TimePeriod.UserCNIC = UserInfo.CNIC and CNIC = '" + textBox1.Text + "'),TotalAssets = (select( (BankBalance+Vehicle+Jeweller+Gift+CashInHand+PrizeBond+Assets.Others)- (Outflows.HouseholdExpenses + Utilities + ForeignTravelling + EducationExpenses+ Outflows.Others ) )  from Assets , TimePeriod, UserInfo, Outflows where  Outflows.ID = Assets.Outflows_ID and Assets.RefNo = TimePeriod.Assets_RefNo and TimePeriod.UserCNIC = UserInfo.CNIC and CNIC = '" + textBox1.Text + "' ) ", con);
                cmd6.ExecuteNonQuery();
                SqlCommand cmd7 = new SqlCommand("Update TimePeriod SET TotalTax = (  ( (select TotalIncome from TimePeriod where UserCNIC = '" + textBox1.Text + "' and TaxYear = '"+textBox38.Text+"') - ( select (Utilities + Property + Education + Winnings + Insurance + Dividend + Functions + AirTicket + PensionFund + Auction + [Transfer]+ CommercialVehicleTokenTax + Leasing + Registration + Sale+ Rebate + OtherTax ) from TaxReductions, TimePeriod, UserInfo where TaxReductions.ID = TimePeriod.TaxReductions_ID  and UserInfo.CNIC = TimePeriod.UserCNIC and UserCNIC = '" + textBox1.Text + "' and TaxYear = '" + textBox38.Text + "') ) * 0.05  )    where (UserCNIC = (select CNIC from UserInfo, TimePeriod where TimePeriod.UserCNIC = UserInfo.CNIC  and UserCNIC = '"+textBox1.Text+"' and TaxYear = '" + textBox38.Text + "'))", con);
                cmd7.ExecuteNonQuery();

                MessageBox.Show("You Record has been saved"); //////// Calculation //////////////

                this.Hide();
                //Form2 fm2 = new Form2(textBox29.Text , textBox38.Text); // CNIC , Year 
                //fm2.Show();
            }
            con.Close();
            //////////////THIS IS THEMPORARY AND NEEDS TO BE MIVED UP ////////////////
            //Form2 fm3 = new Form2(textBox29.Text , "2019");
            //fm3.Show();
        }

        private void textBox38_TextChanged(object sender, EventArgs e)
        {
           
        }
    }
}
