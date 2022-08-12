using DemoDay1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //tao 3 button
            //for (int i = 0; i < 3; i++)
            //{
            //    Button btn = new Button();
            //    btn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            //    btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            //    btn.Location = new System.Drawing.Point(444+125*(i+1), 456);
            //    btn.Name = "exitButton";
            //    btn.Size = new System.Drawing.Size(95, 30);
            //    btn.TabIndex = 22;
            //    btn.Text = "Button"+i;
            //    btn.UseVisualStyleBackColor = true;
            //    this.Controls.Add(btn);
            //    btn.Click += Btn_Click;
            //}
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            MessageBox.Show("Do you want to exit ?", "Confirm", buttons);
        }

        List<Student> students = new List<Student>();
        private void Btn_Click(object? sender, EventArgs e)
        {
            //xu li form confirm
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string code = codeBox.Text;
            string name = nameBox.Text;
            bool gender = false;
            if (maleButton.Checked)
            {
                gender = true;
            }
            string subject = subjectBox.SelectedItem.ToString();
            int mark = Convert.ToInt32(markBox.Text);
            Student student = new Student
            {
                Name = name,
                Code = code,
                Gender = gender,
                Subject = subject,
                Mark = mark
            };
            bool check = false;
            foreach (Student s in students)
            {
                if (s.Code == code)
                {
                    check = true;
                    MessageBox.Show("Student nay da ton tai");
                    break;
                }

            }
            if (check == false)
            {
                students.Add(student);
                listStudent.Items.Add(student);
            }
        }

        private void listStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string []temp = listStudent.SelectedItem.ToString().Split('\t');
            codeBox.Text = temp[0];          
            nameBox.Text = temp[1];
            if (temp[2] == "Male")
            {
                maleButton.Checked = true;
            }
            else
            {
                femaleButton.Checked = true;
            }
            subjectBox.Text = temp[3];
            markBox.Text = temp[4];
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (listStudent.SelectedItem==null)
            {
                MessageBox.Show("Vui long chon student de update !");            
            }
            else
            {
                foreach (Student s in students)
                {
                    if (s.Code == codeBox.Text)
                    {
                        s.Name = nameBox.Text;
                        if (maleButton.Checked)
                        {
                            s.Gender = true;
                        }
                        else
                        {
                            s.Gender = false;
                        }
                        s.Subject = subjectBox.Text;
                        s.Mark = Convert.ToInt32(markBox.Text);

                        MessageBox.Show("Update OK !!");
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Khong ton tai student");
                    }
                }
                Load();
                
            }
            
        }

        private void Load()
        {
            codeBox.Text = "";
            nameBox.Text = "";
            maleButton.Checked = true;
            markBox.Text = "";
            listStudent.Items.Clear();
            foreach (Student item in students)
            {
                listStudent.Items.Add(item);
            }
        }

        private void deleteButoon_Click(object sender, EventArgs e)
        {
            if (listStudent.SelectedItem == null)
            {
                MessageBox.Show("Vui long chon student de xoa !");
            }
            else
            {
                foreach (Student s in students)
                {
                    if (s.Code == codeBox.Text)
                    {
                        students.Remove(s);
                        MessageBox.Show("Delete OK !!");
                        break;
                    }
                    else
                    {
                        MessageBox.Show("Khong ton tai student");
                    }
                }
                Load();
            }

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = @"..\..\..\studentData.txt";
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (Student s in students)
                    {
                        writer.WriteLine(s);
                    }
                }
                MessageBox.Show("Save done !!!");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            students.Clear();
            try
            {
                string fileName = @"..\..\..\studentData.txt";
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        string[] pro = line.Split("\t");
                        bool gender = false;
                        if (pro[2].Equals("Male"))
                        {
                            gender = true;
                        }
                        students.Add(new Student(pro[0], pro[1], gender, pro[3], Convert.ToInt32(pro[4])));
                    }
                    MessageBox.Show("Load OK !!");
                }
                Load();
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

