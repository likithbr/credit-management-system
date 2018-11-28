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
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(Form2.connectionString);
        SqlCommand cmd;
        SqlDataReader dr;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        private String authenticate(String uName)
        {
            con.Open();
            String syntax = $"SELECT password FROM [user] WHERE u_id='{uName}'";
            cmd = new SqlCommand(syntax, con);
            dr = cmd.ExecuteReader();
            String temp = "";
            if (dr.HasRows)
            {
                dr.Read();
                temp = dr[0].ToString();
            }
            con.Close();
            return temp;

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Hide();label4.Hide();
            String uid = textBox1.Text, pass = authenticate(uid), typedPass = textBox2.Text;
            if (pass.Equals(""))
                label5.Show();
            else
            {
                if (pass.Equals(typedPass))
                {
                    con.Open();
                    String qry1 = $"SELECT * FROM [cibil] WHERE u_id='{uid}'";
                    cmd = new SqlCommand(qry1, con);
                    dr = cmd.ExecuteReader();
                    Boolean exists = dr.HasRows;
                    dr.Close();
                    if(!exists)
                    {
                        String qry2= $"INSERT into cibil (u_id,c_score,t_score,blocked,balance,overdue)values({uid},0,0,0,0,0);";
                        cmd = new SqlCommand(qry2, con);
                        dr = cmd.ExecuteReader();
                        dr.Close();
                    }

                    con.Close();

                    Form5 obj = new Form5(uid);
                    this.Hide();
                    obj.Show();
                    obj.displayDetails();
                }
                else
                    label4.Show();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
