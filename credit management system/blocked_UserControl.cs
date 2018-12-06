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
    public partial class blocked_UserControl : UserControl
    {
        private static blocked_UserControl _instance;
        SqlConnection con = new SqlConnection(Form2.connectionString);

        public static blocked_UserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new blocked_UserControl();
                }
                return _instance;
            }
        }
        public void refresh_grid()
        {

            con.Open();
            String syn = "Select * from blockedlist";
            SqlCommand cmd = new SqlCommand(syn, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable ds = new DataTable();
            da.Fill(ds);
            con.Close();
            dataGridView1.DataSource = ds;
        }
        public blocked_UserControl()
        {
            InitializeComponent();
        }

        private void blocked_UserControl_Load(object sender, EventArgs e)
        {
            refresh_grid();
        }
    }
}
