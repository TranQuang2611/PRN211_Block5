using Practice_Winform_EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice_Winform_EF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using(MySaleDBContext context = new MySaleDBContext())
            {
                dataProduct.DataSource = context.Customers.Select(x => new
                {
                    CustomerID = x.CustomerId,
                    CustomerName = x.CustomerName,
                    Gender = x.Gender==true?"Male":"Female",
                    DOB = x.Birthdate.ToString("dd-MM-yyyy"),
                    Address = x.Address
                }).ToList();

            }
        }

        private void dataProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            idBox.Text = dataProduct.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            customerNameBox.Text = dataProduct.Rows[e.RowIndex].Cells["CustomerName"].FormattedValue.ToString();
            if (dataProduct.Rows[e.RowIndex].Cells["Gender"].FormattedValue.ToString().Equals("Male"))
            {
                maleButton.Checked = true;
            }
            else
            {
                femaleButton.Checked = true;
            }
            addressBox.Text = dataProduct.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataProduct.Rows[e.RowIndex].Cells["DOB"].FormattedValue.ToString());
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if(dataProduct.SelectedCells.Count > 0)
            {
                using(MySaleDBContext context = new MySaleDBContext())
                {
                    Customer customer = context.Customers.FirstOrDefault(x => x.CustomerId == Convert.ToInt32(idBox.Text));
                    customer.CustomerName = customerNameBox.Text;
                    if (maleButton.Checked)
                    {
                        customer.Gender = true;
                    }
                    else
                    {
                        customer.Gender = false;
                    }
                    customer.Address = addressBox.Text;
                    customer.Birthdate = dateTimePicker1.Value;
                    if (context.SaveChanges() > 0)
                    {
                        MessageBox.Show("Update OK");
                    }
                    else
                    {
                        MessageBox.Show("Failed update");
                    }

                }
            }
        }
    }
}
