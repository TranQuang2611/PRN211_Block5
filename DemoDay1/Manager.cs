using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace DemoDay1
{
    public class Manager : IManager
    {
        List<Student> list = new List<Student>();

        public Manager(List<Student> list)
        {
            this.list = list;
        }

        public void addList(string code)
        {                    
            Console.WriteLine("Enter name :");
            string name = Console.ReadLine();
            while (checkNull(name))
            {
                Console.WriteLine("Enter name again :");
                name = Console.ReadLine();
            }
            Console.WriteLine("Choose Gender :");
            Console.WriteLine("1. Male");
            Console.WriteLine("0. Female");
            int check = Convert.ToInt32(Console.ReadLine());
            bool gender = false;
            if (check == 1)
            {
                gender = true;
            }
            Console.WriteLine("Choose subject :");
            Console.WriteLine("1. Math");
            Console.WriteLine("2. Literature");
            Console.WriteLine("3. English");
            check = Convert.ToInt32(Console.ReadLine());
            string subject = "Math";
            if (check == 2)
            {
                subject = "Literature";
            }
            else if (check == 3)
            {
                subject = "English";
            }
            Console.WriteLine("Enter mark");
            int mark = Convert.ToInt32(Console.ReadLine());
            while (checkNull(mark.ToString()))
            {
                Console.WriteLine("Enter mark again :");
                mark = Convert.ToInt32(Console.ReadLine());
                Regex regex = new Regex("^[0-10]+$");
                if (!regex.IsMatch(mark.ToString()))
                {
                    Console.WriteLine("Enter mark again :");
                    mark = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            list.Add(new Student(code,name, gender, subject, mark));
            saveFile();
            Console.WriteLine("");
            Console.WriteLine("Add OK");

        }

        public bool checkCode(string code)
        {
            foreach (Student student in list)
            {
                if (student.Code.Equals(code.ToLower().Trim()))
                {
                    return true;
                }

            }
            return false;
        }

        public bool checkNull(string code)
        {
            if(string.IsNullOrEmpty(code))
            {
                return true ;
            }
            return false ;
        }

        public void detele(string code)
        {
            foreach (Student student in list)
            {
                if (student.Code.ToLower().Trim() == code.ToLower().Trim())
                {
                    list.Remove(student);
                    break;
                }
            }
        }

        public void readFile()
        {
            list.Clear();
            try
            {
                string fileName = @"..\..\..\data.txt";
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        string []pro = line.Split("\t");
                        bool gender = false;
                        if (line[3].Equals("Male"))
                        {
                            gender = true;
                        }
                        list.Add(new Student(pro[0], pro[1], gender, pro[3], Convert.ToInt32(pro[4])));
                    }
                    Console.WriteLine("Read OK !!!");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void saveFile()
        {
            try
            {
                string fileName = @"..\..\..\data.txt";
                using(StreamWriter sw = new StreamWriter(fileName))
                {
                    foreach(Student student in list)
                    {
                        sw.WriteLine(student);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void showList()
        {
            Console.WriteLine("");
            if (list.Count > 0)
            {
                Console.WriteLine("List student : ");
                Console.WriteLine("Code" + "\t" + "Name" + "\t" + "Gender" + "\t" + "Subject" + "\t\t" + "Mark");
                foreach (Student student in list)
                {
                    Console.WriteLine(student.ToString());
                }
            }
            else
            {
                Console.WriteLine("No student !!!");
            }

        }


        public void update(string code, string name, int mark)
        {
            foreach (Student student in list)
            {
                if (student.Code.ToLower().Equals(code.ToLower().Trim()))
                {
                    student.Name = name;
                    student.Mark = mark;
                }
            }
        }
    }
}