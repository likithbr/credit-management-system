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

           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
