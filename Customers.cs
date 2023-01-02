﻿using System;
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
    public partial class Customers : Form
    {
        Functions Con;
        int key = 0;
        public Customers()
        {
            InitializeComponent();
            ShowCustomers();
        }
        private void ShowCustomers()
        {
            String Query = "Select * from CustomersTB";
            CData.DataSource = Con.GetData(Query);
        }

        private void Clear()
        {
            CName.Text = "";
            CPhone.Text = "";
            CAddress.Text = "";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CName.Text == "" || CPhone.Text == "" || CAddress.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                String name = CName.Text;
                String phone = CPhone.Text;
                String address = CAddress.Text;
                String Query = "insert into CustomersTB values('{0}','{1}','{2}')";
                Query = string.Format(Query, name, phone,address);
                Con.SetData(Query);
                ShowCustomers();
                Clear();
                MessageBox.Show("Customer Added!!!");
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (CName.Text == "" || CPhone.Text == "" || CAddress.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                String name = CName.Text;
                String phone = CPhone.Text;
                String address = CAddress.Text;
                String Query = "Update CustomersTB set CustName='{0}',CustPhone='{1}',CustAdd='{2}' where CustId={3}";
                Query = string.Format(Query, name, phone, address,key);
                Con.SetData(Query);
                ShowCustomers();
                Clear();
                MessageBox.Show("Customer Updated!!!");
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
                String Query = "Delete from CustomersTB where CustId = {0}";
                Query = string.Format(Query, key);
                Con.SetData(Query);
                ShowCustomers();
                Clear();
                MessageBox.Show("Customer Deleted!!!");
            }
        }

        private void CData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            CName.Text = CData.SelectedRows[0].Cells[1].Value.ToString();
            CPhone.Text = CData.SelectedRows[0].Cells[2].Value.ToString();
            CAddress.Text = CData.SelectedRows[0].Cells[3].Value.ToString();
            if (CName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CData.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
