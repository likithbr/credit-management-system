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
            String syntax = $"SELECT * FROM [cibil] WHERE u_id={uid}";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            user.Text = dr[0].ToString();
            c_score.Text = dr[1].ToString();
            block.Text = dr[2].ToString();
            balance.Text = dr[3].ToString();
            overdues.Text = dr[4].ToString();
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
            update();
        }
        public void update()
        {
            con.Open();
            String qry4 = $"select * from [blockedlist] where u_id='{uid}' ";
            String qry1 = $"SELECT avg(balance),SUM(OVERDUE),count(acc_no) FROM [accounts] a WHERE a.u_id='{uid}' ";
            cmd = new SqlCommand(qry1, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            int avgBal = Convert.ToInt32(dr[0].ToString());
            int overdue = Convert.ToInt32(dr[1].ToString());
            int noAcc = Convert.ToInt32(dr[2].ToString());
            dr.Close();
            String qry3 = $"SELECT age FROM [user] a WHERE u_id='{uid}' ";
            cmd = new SqlCommand(qry3, con);
            dr = cmd.ExecuteReader();
            dr.Read();
            int age = Convert.ToInt32(dr[0].ToString());
            dr.Close();
            int credit = calculateScore(avgBal, overdue, noAcc, age);

            int blocked = (credit < 300)? 1 : 0;
            String qry2 = $"update [cibil] set balance={avgBal},overdue={overdue},c_score={credit},blocked={blocked} where u_id='{uid}' ";
            cmd = new SqlCommand(qry2, con);
            dr = cmd.ExecuteReader();
            dr.Close();
           cmd = new SqlCommand(qry4, con);
            dr = cmd.ExecuteReader();
            if (!dr.HasRows)
                button1.Enabled=true;
            else
                button1.Enabled = false;
            dr.Close();
            con.Close();
            displayDetails();
        }
        int calculateScore(int avgBal,int  overdue,int noAcc,int age)
        {
            int creditScore = 0;
            if (noAcc < 2)
                creditScore += 50;
            else
                creditScore += 100;

            if (age < 25)
                creditScore += 100;
            else if (age < 35)
                creditScore += 150;
            else if (age < 45)
                creditScore += 200;
            else
                creditScore += 250;

            if (avgBal < 1000)
                creditScore += 100;
            else if (avgBal < 5000)
                creditScore += 150;
            else if (avgBal < 10000)
                creditScore += 200;
            else if (avgBal < 30000)
                creditScore += 250;
            else if (avgBal < 60000)
                creditScore += 300;
            else if (avgBal < 80000)
                creditScore += 350;
            else
                creditScore += 400;

            if (overdue == 0)
                creditScore += 150;
            else if (overdue < 2)
                creditScore += 100;
            else if (overdue < 4)
                creditScore += 50;
            else
                creditScore += 0;


            return creditScore;
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

        private void c_score_Click(object sender, EventArgs e)
        {

        }

        private void block_Click(object sender, EventArgs e)
        {

        }

        private void balance_Click(object sender, EventArgs e)
        {

        }

        private void user_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
