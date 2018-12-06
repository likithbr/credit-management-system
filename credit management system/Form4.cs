﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace credit_management_system
{
    public partial class panel_Form4 : Form
    {
        public panel_Form4()
        {
            InitializeComponent();
            content_panel.Controls.Add(user_UserControl1.Instance);
            user_UserControl1.Instance.Dock = DockStyle.Fill;
            user_UserControl1.Instance.BringToFront();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void content_panel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                user_UserControl1.Instance.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!content_panel.Controls.Contains(bank_UserControl1.Instance))
            {
                content_panel.Controls.Add(bank_UserControl1.Instance);
                bank_UserControl1.Instance.Dock = DockStyle.Fill;
                bank_UserControl1.Instance.BringToFront();
            }
            else
            {
                bank_UserControl1.Instance.BringToFront();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!content_panel.Controls.Contains(account_UserControl1.Instance))
            {
                content_panel.Controls.Add(account_UserControl1.Instance);
                account_UserControl1.Instance.Dock = DockStyle.Fill;
                account_UserControl1.Instance.BringToFront();
            }
            else
            {
                account_UserControl1.Instance.BringToFront();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!content_panel.Controls.Contains(blocked_UserControl.Instance))
            {
                content_panel.Controls.Add(blocked_UserControl.Instance);
                blocked_UserControl.Instance.Dock = DockStyle.Fill;
                blocked_UserControl.Instance.BringToFront();
            }
            else
            {
                blocked_UserControl.Instance.BringToFront();
            }

        }
    }
}
