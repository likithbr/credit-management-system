using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace credit_management_system
{
    public partial class account_UserControl1 : UserControl
    {

        SqlConnection con = new SqlConnection(Form2.connectionString);
        private static account_UserControl1 _instance;
        static string BID = " ";
        static string acc= " ";

        public static account_UserControl1 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new account_UserControl1();
                }
                return _instance;
            }
        }
        public account_UserControl1()
        {
            InitializeComponent();
        }
        public void refresh_grid()
        {

            con.Open();
            String syn = "Select * from accounts";
            SqlCommand cmd = new SqlCommand(syn, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            dataGridView1.DataSource = ds;
        }



        private void manage_Click(object sender, EventArgs e)
        {
        }
        public void clear()
        {

            textBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox4.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                String qry = $"insert into accounts(u_id,b_id,acc_no,balance,overdue)values({textBox1.Text},'{textBox7.Text}','{textBox6.Text}','{textBox5.Text}','{textBox4.Text}')";
                SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();
                dr.Close();
                con.Close();
                refresh_grid();
            
                MessageBox.Show("Data added succesfully");
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("      invalid sql operation     " + ex);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteForm obj = new DeleteForm("accounts", "acc_no");
            obj.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void account_UserControl1_Load(object sender, EventArgs e)
        {
            refresh_grid();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            BID = textBox7.Text;
            acc = textBox6.Text;
            String qry1 = $"Select * from [accounts] where b_id='{BID}' and acc_no='{acc}'";
            con.Open();
            SqlDataReader dr = new SqlCommand(qry1, con).ExecuteReader();
            dr.Read();
            textBox1.Text = dr[0].ToString();
            textBox5.Text = dr[3].ToString();
            textBox4.Text = dr[4].ToString();
            
            dr.Close();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            String qry2 = $"Update [accounts] set u_id='{textBox1.Text}',balance='{textBox5.Text}',overdue='{textBox4.Text}'  where b_id='{BID}' and acc_no='{acc}' ;";
            SqlDataReader dr = new SqlCommand(qry2, con).ExecuteReader();
            dr.Close();
            con.Close();
            clear();
            refresh_grid();
        }
    }
}
