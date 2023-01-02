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

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (PName.Text == "" || PCost.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                String name = PName.Text;
                int cost = Convert.ToInt32(PCost.Text);
                String Query = "Update SpareTB set SpName = '{0}',SpCost = {1} where SpId = {2}";
                Query = string.Format(Query, name, cost,key);
                Con.SetData(Query);
                ShowParts();
                Clear();
                MessageBox.Show("Spare Part Updated!!!");
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
                String Query = "Delete from SpareTB where SpId = {0}";
                Query = string.Format(Query, key);
                Con.SetData(Query);
                ShowParts();
                Clear();
                MessageBox.Show("Spare Part Deleted!!!");
            }
        }

        private void PData_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            PName.Text = PData.SelectedRows[0].Cells[1].Value.ToString();
            PCost.Text = PData.SelectedRows[0].Cells[2].Value.ToString();
            if (PName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(PData.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
