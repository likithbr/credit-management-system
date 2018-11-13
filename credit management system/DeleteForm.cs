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
    public partial class DeleteForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True");
        public static string tableName = "";
        public static string attribute = "";

        public DeleteForm(string tabname,string attr)
        {
            tableName = tabname;
            attribute = attr;
            InitializeComponent();
            this.label2.Text = $"ENTER THE {attribute}";
            this.label1.Text = attribute+ " :";
        }
        private void DeleteForm_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Do you want to delete {tableName} = '{textBox1.Text}' ", "Alert!!", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    String qry = $"Delete from {tableName} where {attribute}={textBox1.Text}"; 
                    con.Open();
                    SqlDataReader dr = new SqlCommand(qry, con).ExecuteReader();
                    con.Close();
                    if (tableName.Equals("[user]"))
                        user_UserControl1.Instance.refresh_grid();
                    else
                        bank_UserControl1.Instance.refresh_grid();
                    MessageBox.Show("Data deleted successfully!!");
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(" " + ex);
                }

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}