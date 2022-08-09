using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDay1
{
    public class Student
    {
        // Thuoc tinh
        public string Code { get; set; }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private bool _gender;
        public bool Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string Subject { get; set; }

        public int Mark { get; set; }

        // Phuong thuc
        public Student()
        {
        }

        public Student(string code, string name, bool gender, string subject, int mark)
        {
            Code = code;
            Name = name;
            Gender = gender;
            Subject = subject;
            Mark = mark;
        }

        public override string ToString()
        {           
            string sex = "Male";
            if(Gender == false)
            {
                sex = "Female";
            }
            return Code + "\t" + Name + "\t" + sex + "\t" + Subject + "\t" + Mark;
        }
    }
}
