using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileRepairsManagementSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UserName.Text == "" || Password.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else if (UserName.Text == "Eslam" && Password.Text == "Alaa")
            {
                Customers page = new Customers();
                page.Show();
                this.Hide();
            }
            else
            {
                UserName.Text = "";
                Password.Text = "";
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
