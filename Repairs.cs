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
    public partial class Repairs : Form
    {

        Functions Con;
        int key = 0;
        public Repairs()
        {
            InitializeComponent();
            Con = new Functions();
            ShowRepairs();
            GetCustomers();
            GetSpares();
            GetSpareCost();
        }

        private void ShowRepairs()
        {
            String Query = "Select * from RepairTB";
            RData.DataSource = Con.GetData(Query);
        }

        private void GetCustomers()
        {
            string Query = "Select * from CustomerTB";
            RCust.DisplayMember = Con.GetData(Query).Columns["CustName"].ToString();
            RCust.ValueMember = Con.GetData(Query).Columns["CustId"].ToString();
            RCust.DataSource = Con.GetData(Query);
        }

        private void GetSpares()
        {
            string Query = "Select * from SpareTB";
            RSpare.DisplayMember = Con.GetData(Query).Columns["SpName"].ToString();
            RSpare.ValueMember = Con.GetData(Query).Columns["SpId"].ToString();
            RSpare.DataSource = Con.GetData(Query);
        }

        private void GetSpareCost()
        {
            string Query = "Select * from SpareTB where SpId = {0}";
            Query = string.Format(Query, RSpare.SelectedValue.ToString());
            foreach (DataRow dr in Con.GetData(Query).Rows)
            {
                RSpareC.Text = dr["SpCost"].ToString();
            }
        }

        private void Clear()
        {
            RPhone.Text = "";
            RDevice.Text = "";
            RDeviceM.Text = "";
            RProb.Text = "";
            RCost.Text = "";
            GetSpareCost();
        }

        private void Repairs_Load(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void CName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void CPhone_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (RCust.SelectedIndex == -1 || RSpare.SelectedIndex == -1 || RPhone.Text == "" || RDevice.Text == "" || RDeviceM.Text == "" || RProb.Text == "" || RSpareC.Text == "" || RCost.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                String date = RDate.Value.Date.ToShortDateString();
                int customer= Convert.ToInt32(RCust.SelectedValue.ToString());
                String phone= RPhone.Text;
                String device = RDevice.Text;
                String deviceM = RDeviceM.Text;
                String problem = RProb.Text;
                int spare = Convert.ToInt32(RSpare.SelectedValue.ToString());
                int totalCost = Convert.ToInt32(RSpareC.Text) + Convert.ToInt32(RCost.Text);
                String Query = "insert into RepairTB values('{0}',{1},'{2}','{3}','{4}','{5}',{6},{7})";
                Query = string.Format(Query, date, customer, phone, device, deviceM,problem,spare,totalCost);
                Con.SetData(Query);
                ShowRepairs();
                Clear();
                MessageBox.Show("Repair Added!!!");
            }
        }

        private void RSpare_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSpareCost();
        }

        private void RData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            RDate.Text = RData.SelectedRows[0].Cells[1].Value.ToString();
            RCust.SelectedValue = RData.SelectedRows[0].Cells[2].Value.ToString();
            RPhone.Text = RData.SelectedRows[0].Cells[3].Value.ToString();
            RDevice.Text = RData.SelectedRows[0].Cells[4].Value.ToString();
            RDeviceM.Text = RData.SelectedRows[0].Cells[5].Value.ToString();
            RProb.Text = RData.SelectedRows[0].Cells[6].Value.ToString();
            RSpare.SelectedValue = RData.SelectedRows[0].Cells[7].Value.ToString();
            RCost.Text = (Convert.ToInt32(RData.SelectedRows[0].Cells[8].Value.ToString())-Convert.ToInt32(RSpareC.Text)).ToString();
            if (RSpareC.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(RData.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                String Query = "Delete from RepairTB where RepId = {0}";
                Query = string.Format(Query, key);
                Con.SetData(Query);
                ShowRepairs();
                Clear();
                MessageBox.Show("Repair Deleted!!!");
            }
        }
    }
}
