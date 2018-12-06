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


    public partial class user_UserControl1 : UserControl
    {
        private static user_UserControl1 _instance;

        public static user_UserControl1 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new user_UserControl1();
                }
                return _instance;
            }
        }

        public user_UserControl1()
        {
            InitializeComponent();
        }


        SqlConnection con = new SqlConnection(Form2.connectionString);
        static string UID = " ";
        public void refresh_grid()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("showuser_sp", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("    invalid sql operation    " + ex);
                }
                con.Close();

                dataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }


       

        private void button1_Click(object sender, EventArgs e)//addnew
        {
            SqlCommand cmd = new SqlCommand("useradd_sp", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@u_id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox7.Text);
            cmd.Parameters.AddWithValue("@aadhaar", textBox3.Text);
            cmd.Parameters.AddWithValue("@address", textBox4.Text);
            cmd.Parameters.AddWithValue("@phone", textBox5.Text);
            cmd.Parameters.AddWithValue("@email", textBox6.Text);
            cmd.Parameters.AddWithValue("@password", textBox2.Text);
            cmd.Parameters.AddWithValue("@age", textBox8.Text);


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

        private void user_UserControl1_Load(object sender, EventArgs e)
        {
            refresh_grid();
        }

        private void button2_Click(object sender, EventArgs e)//delete
        {
            DeleteForm obj = new DeleteForm("[user]","u_id");
            obj.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
        public void clear()
        {

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            UID = textBox1.Text;
            String qry1 = $"Select * from [user] where u_id='{UID}'";
            con.Open();
            SqlDataReader dr = new SqlCommand(qry1, con).ExecuteReader();
            dr.Read();
            //textBox1.Text = dr[0].ToString();

            textBox7.Text = dr[1].ToString();
            textBox3.Text = dr[2].ToString();
            textBox4.Text = dr[3].ToString();
            textBox5.Text = dr[4].ToString();
            textBox6.Text = dr[5].ToString();
            textBox2.Text = dr[6].ToString();
            textBox8.Text = dr[7].ToString();
            //button3.Text = "Save";
            dr.Close();
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            String qry2 = $"Update [user] set u_id='{textBox1.Text}',name='{textBox7.Text}',aadhaar='{textBox3.Text}',address='{textBox4.Text}',phone={textBox5.Text},email='{textBox6.Text}',password={textBox2.Text},age={textBox8.Text} where u_id={UID} ;";
            SqlDataReader dr = new SqlCommand(qry2, con).ExecuteReader();
            dr.Close();
            con.Close();
            clear();
            refresh_grid();
        }
    }
}
