using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform_EF_NET.Models;

namespace Winform_EF_NET
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

        private void loadData()
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                //var data1 = context.Products.ToList();
                dataProduct.DataSource = context.Products.Include(x => x.Category).Select(x => new
                {
                    ProductID = x.ProductId,
                    ProductName = x.ProductName,
                    Price = x.UnitPrice.ToString(),
                    //UnitPrice = String.Format("{0:0.00}", x.UnitPrice),
                    Stock = x.UnitsInStock,
                    Image = x.Image,
                    CategoryName = x.Category.CategoryName
                }).ToList();
                var dataCat = context.Categories.ToList();
                categoryBox.DataSource = dataCat;
                categoryBox.DisplayMember = "CategoryName";
                categoryBox.ValueMember = "CategoryId";
            }


        }

        private void dataProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            idBox.ReadOnly = true;
            idBox.Text = dataProduct.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
            nameBox.Text = dataProduct.Rows[e.RowIndex].Cells["ProductName"].FormattedValue.ToString();
            unitPriceBox.Text = dataProduct.Rows[e.RowIndex].Cells["Price"].FormattedValue.ToString();
            unitInStockBox.Value = Convert.ToDecimal(dataProduct.Rows[e.RowIndex].Cells["Stock"].FormattedValue.ToString());
            categoryBox.Text = dataProduct.Rows[e.RowIndex].Cells["CategoryName"].FormattedValue.ToString();
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                //Tao doi tuong 
                Product product = new Product
                {
                    ProductName = nameBox.Text,
                    UnitPrice = Convert.ToDecimal(unitPriceBox.Text),
                    UnitsInStock = Convert.ToInt32(unitInStockBox.Value),
                    Image = imgBox.Text,
                    CategoryId = Convert.ToInt32(categoryBox.SelectedValue)
                };
                context.Products.Add(product);

                //Insert
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Inserted");
                    loadData();
                }
                else
                {
                    MessageBox.Show("Failed insert");
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            using (MySaleDBContext context = new MySaleDBContext())
            {
                //Tim product

                Product product = context.Products.FirstOrDefault(x => x.ProductId == Convert.ToInt32(idBox.Text));

                context.Products.Remove(product);

                //Insert
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Deleted");
                    loadData();
                }
                else
                {
                    MessageBox.Show("Failed delete");
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            //Tim product
            using (MySaleDBContext context = new MySaleDBContext())
            {
                //Tim product

                Product product = context.Products.FirstOrDefault(x => x.ProductId == Convert.ToInt32(idBox.Text));
                product.ProductName = nameBox.Text;
                product.UnitPrice = Convert.ToDecimal(unitPriceBox.Text);
                product.UnitsInStock = Convert.ToInt32(unitInStockBox.Value);
                product.Image = imgBox.Text;
                product.CategoryId = Convert.ToInt32(categoryBox.SelectedValue);
                //context.Products.Update(product);

                //Insert
                if (context.SaveChanges() > 0)
                {
                    MessageBox.Show("Updated");
                    loadData();
                }
                else
                {
                    MessageBox.Show("Failed update");

                }
            }
        }
    }
}
