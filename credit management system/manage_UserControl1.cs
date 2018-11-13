using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace credit_management_system
{
    public partial class manage_UserControl1 : UserControl
    {
        private static manage_UserControl1 _instance;

        public static manage_UserControl1 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new manage_UserControl1();
                }
                return _instance;
            }
        }
        public manage_UserControl1()
        {
            InitializeComponent();
        }

        private void manage_Click(object sender, EventArgs e)
        {

        }
    }
}
