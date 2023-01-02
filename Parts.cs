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
    public partial class Parts : Form
    {

        Functions Con;
        int key = 0;
        public Parts()
        {
            InitializeComponent();
            Con = new Functions();
            ShowParts();
        }

        private void ShowParts()
        {
            String Query = "Select * from SpareTB";
            PData.DataSource = Con.GetData(Query);
        }

        private void Clear()
        {
            PName.Text = "";
            PCost.Text = "";
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (PName.Text == "" || PCost.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                String name = PName.Text;
                int cost = Convert.ToInt32(PCost.Text);
                String Query = "insert into SpareTB values('{0}',{1})";
                Query = string.Format(Query, name, cost);
                Con.SetData(Query);
                ShowParts();
                Clear();
                MessageBox.Show("Spare Part Added!!!");
            }
        }
    }
}
