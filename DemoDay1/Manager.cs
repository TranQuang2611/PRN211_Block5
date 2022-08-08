using System;
using System.Collections.Generic;

namespace DemoDay1
{
    internal class Manager
    {


        public Manager()
        {
        }

        public Manager(List<Student> list)
        {
        }

        internal void addList(List<Student> list)
        {
            Console.WriteLine("Enter code :");
            string code = Console.ReadLine();
            Console.WriteLine("Enter name :");
            string name = Console.ReadLine();
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
            list.Add(new Student(code, name, gender, subject, mark));
        }

        internal void showList(List<Student> list)
        {
            foreach (Student student in list)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}