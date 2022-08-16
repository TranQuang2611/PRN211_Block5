using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_ADO_NET
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
        //load data len datagridview va combox category
        private void loadData()
        {
            string strSelect = "select ProductID as 'Ma san pham', ProductName, UnitPrice, UnitsInStock, Image, c.CategoryName from Products p, Categories c where c.CategoryID = p.CategoryID";
            
            dt = new DataProvider().executeQuery(strSelect);
            //Customize data
            //DataTable dt2 = new DataTable();
            //dt2.Columns.Add("ID", typeof(string));
            //dt2.Columns.Add("Name", typeof(string));
            //foreach (DataRow item in dt.Rows)
            //{
            //    string code = "P " + item.ItemArray[0].ToString();
            //    string name = item.ItemArray[1].ToString();
            //    dt2.Rows.Add(new object[] { code, name });
            //}


            dataProduct.DataSource = dt;
            dt = new DataProvider().executeQuery("Select * from Categories");
            categoryBox.DataSource = dt;
            categoryBox.DisplayMember = "CategoryName";
            categoryBox.ValueMember = "CategoryId";
        }

        private void dataProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex == -1)
            {
                return;
            }
            idBox.ReadOnly = true;
            idBox.Text = dataProduct.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            nameBox.Text = dataProduct.Rows[e.RowIndex].Cells["ProductName"].FormattedValue.ToString();
            unitPriceBox.Text = dataProduct.Rows[e.RowIndex].Cells["UnitPrice"].FormattedValue.ToString();
            unitInStockBox.Value = Convert.ToDecimal(dataProduct.Rows[e.RowIndex].Cells["UnitsInStock"].FormattedValue.ToString());
            categoryBox.Text = dataProduct.Rows[e.RowIndex].Cells["CategoryName"].FormattedValue.ToString();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            string insert = "insert into Products(ProductName,UnitPrice,UnitsInStock,Image,CategoryID) values ("
                + "'" + nameBox.Text + "',"
                + "'" + unitPriceBox.Text + "',"
                + Convert.ToInt32(unitInStockBox.Text)+","
                + "'" + imgBox.Text + "',"
                + categoryBox.SelectedValue
                + ")";                    
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

        private void updateButton_Click(object sender, EventArgs e)
        {
            try
            {              
                if (dataProduct.SelectedCells != null)
                {
                    string update = "update Products set"
                    + " ProductName = '" + nameBox.Text + "',"
                    + " UnitPrice = '" + unitPriceBox.Text + "',"
                    + " UnitsInStock =" + Convert.ToInt32(unitInStockBox.Text) + ","
                    + " Image = '" + imgBox.Text + "',"
                    + " CategoryID =" + categoryBox.SelectedValue + " where ProductID =" + Convert.ToInt32(idBox.Text);
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
                string delete = "delete from Products where ProductID ="+idBox.Text;
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

        private void nameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(nameBox.Text))
                {
                    string name = nameBox.Text.Trim().ToLower();
                    string select = "select * from Products where ProductName like '%"+name+"%'";
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
