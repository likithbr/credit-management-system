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

namespace credit_management_system
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(Form2.connectionString);
        SqlCommand cmd;
        SqlDataReader dr;
        String uid;
        public Form5(String UID)
        {
            InitializeComponent();
            uid = UID;
        }
        public void displayDetails()
        {
            con.Open();
            String syntax = $"SELECT * FROM [cibil] WHERE u_id=1001";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            user.Text = dr[0].ToString();
            c_score.Text = dr[1].ToString();
            t_score.Text = dr[2].ToString();
            block.Text = dr[3].ToString();
            balance.Text = dr[4].ToString();
            overdues.Text = dr[5].ToString();
            dr.Close();
            con.Close();

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            caluclateScore();
        }
        public void caluclateScore()
        {
            con.Open();
            String qry1 = $"SELECT avg(balance),SUM(OVERDUE) FROM [accounts] WHERE u_id='{uid}'";
            cmd = new SqlCommand(qry1, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            string avgBal =dr[0].ToString();
            string overdue = dr[1].ToString();
            dr.Close();
            String qry2 = $"update [cibil] set balance={avgBal},overdue={overdue} where u_id='{uid}' ";
            cmd = new SqlCommand(qry2, con);
            dr = cmd.ExecuteReader();
            dr.Close();
            con.Close();
            displayDetails();
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            displayDetails();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj = new Form1();
            obj.Show();
        }
    }
}
