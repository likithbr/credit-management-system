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
    public partial class bank_UserControl1 : UserControl
    {
        private static bank_UserControl1 _instance;

        public static bank_UserControl1 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new bank_UserControl1();
                }
                return _instance;
            }
        }
        public bank_UserControl1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(Form2.connectionString);
        static string BID = " ";

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("bankadd_sp", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@b_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@b_name", textBox8.Text);
            cmd.Parameters.AddWithValue("@b_phone", textBox7.Text);
            cmd.Parameters.AddWithValue("@b_branch", textBox5.Text);
            cmd.Parameters.AddWithValue("@b_add", textBox6.Text);
            

            con.Open();
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data added succesfully");
                clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("      invalid sql operation     " + ex);
            }
            con.Close();

            refresh_grid();
        }

        public void refresh_grid()
        {
           
             con.Open();
             String syn = "Select * from bank";
             SqlCommand cmd= new SqlCommand(syn, con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable ds = new DataTable();
             da.Fill(ds);
             con.Close();
             dataGridView1.DataSource = ds;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteForm obj = new DeleteForm("bank", "b_id");
            obj.Show();
        }
        public void clear()
        {

            textBox1.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
           
        }

        private void bank_UserControl1_Load(object sender, EventArgs e)
        {
            refresh_grid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BID = textBox1.Text;
           
            String qry1 = $"Select * from [bank] where b_id='{BID}'";
            con.Open();
            SqlDataReader dr = new SqlCommand(qry1, con).ExecuteReader();
            dr.Read();
            textBox8.Text = dr[1].ToString();
            textBox7.Text = dr[2].ToString();
            textBox6.Text = dr[3].ToString();
            textBox5.Text = dr[4].ToString();


            dr.Close();
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            String qry2 = $"Update [bank] set b_name='{textBox8.Text}',b_phone='{textBox7.Text}',b_add='{textBox6.Text}',b_branch='{textBox5.Text}' where b_id='{BID}'";
            SqlDataReader dr = new SqlCommand(qry2, con).ExecuteReader();
            dr.Close();
            con.Close();
            clear();
            refresh_grid();
        }
    }
}
