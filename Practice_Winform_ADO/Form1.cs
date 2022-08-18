using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice_Winform_ADO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadData();
        }

        DataTable dt = new DataTable();
        private void loadData()
        {
            string strSelect = "select * from Customers";
            dt = new DataProvider().executeQuery(strSelect);
            dataProduct.DataSource = dt;

        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            string insert = "insert into Customers values ("
                + "N'" + customerNameBox.Text + "',"
                + "'" + dateTimePicker1.Value + "',"
                + (maleButton.Checked ? 1 : 0) + ","
                + "N'" + addressBox.Text + "'"
                + ")";
            if (dateTimePicker1.Value > DateTime.Now)
            {
                MessageBox.Show("Vui long nhap dung date of birth");
                return;
            }
            if (new DataProvider().executeNonQuery(insert))
            {
                MessageBox.Show("Inserted");
                loadData();
            }
            else
            {
                MessageBox.Show("Insert sai");
            }
        }

        private void dataProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            else
            {
                idBox.Text = dataProduct.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                customerNameBox.Text = dataProduct.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                if (Convert.ToBoolean(dataProduct.Rows[e.RowIndex].Cells[3].FormattedValue) == false)
                {
                    femaleButton.Checked = true;
                }
                else
                {
                    maleButton.Checked = true;
                }
                addressBox.Text = dataProduct.Rows[e.RowIndex].Cells[4].FormattedValue.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataProduct.Rows[e.RowIndex].Cells[2].FormattedValue.ToString());
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataProduct.SelectedCells != null)
                {
                    string update = "update Customers set"
                    + " CustomerName = N'" + customerNameBox.Text + "',"
                    + " Birthdate = '" + dateTimePicker1.Value + "',"
                    + " Gender =" + (maleButton.Checked ? 1 : 0) + ","
                    + " Address = N'" + addressBox.Text + "'"
                    + " where CustomerId =" + Convert.ToInt32(idBox.Text);
                    if (new DataProvider().executeNonQuery(update))
                    {
                        MessageBox.Show("Updated");
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("Insert sai");
                    }
                }
                else
                {
                    MessageBox.Show("Vui long chon de update");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Vui long chon de update");
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataProduct.SelectedCells != null)
            {
                string delete = "delete from Customers where CustomerId =" + idBox.Text;
                if (string.IsNullOrEmpty(idBox.Text))
                {
                    MessageBox.Show("Vui long chon de delete");
                    return;
                }
                if (new DataProvider().executeNonQuery(delete))
                {
                    MessageBox.Show("Deleted");
                    loadData();
                }
                else
                {
                    MessageBox.Show("Deleted sai");
                }
            }
            else
            {
                MessageBox.Show("Vui long chon de delete");
            }
        }

        private void customerNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(customerNameBox.Text))
                {
                    string name = customerNameBox.Text.Trim().ToLower();
                    string select = "select * from Customers where CustomerName like '%" + name + "%'";
                    dt = new DataProvider().executeQuery(select);
                    dataProduct.DataSource = dt;
                }
                else
                {
                    loadData();
                }
            }
        }
    }
}
