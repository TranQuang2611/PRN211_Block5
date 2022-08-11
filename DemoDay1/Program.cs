using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoDay1
{
    internal class Program : IManager
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            IManager m = new Manager(list);
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("1. Add to list Students");
                Console.WriteLine("2. Show list Students");
                Console.WriteLine("3. Update information Student");
                Console.WriteLine("4. Save to file");
                Console.WriteLine("5. Load from file");
                Console.WriteLine("6. Delete student");
                Console.WriteLine("7. Report");
                Console.WriteLine("0. Exit");
                Console.WriteLine("");
                Console.WriteLine("Enter Option");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        {
                            Console.WriteLine("Good Bye !!!");
                            break;
                        }
                    case 1:
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Enter code :");
                            string code = Console.ReadLine();
                            while (m.checkCode(code) || m.checkNull(code))
                            {
                                Console.WriteLine("Enter code again:");
                                code = Console.ReadLine();
                            }
                            if (m.checkCode(code) == false)
                            {
                                m.addList(code);
                            }
                            break;
                        }
                    case 2:
                        {
                            m.showList();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter code");
                            string code = Console.ReadLine();
                            while (!m.checkCode(code) || m.checkNull(code))
                            {
                                Console.WriteLine("Enter code again:");
                                code = Console.ReadLine();
                            }
                            if (m.checkCode(code))
                            {
                                Console.WriteLine("Enter new name : ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Enter new mark : ");
                                int mark = Convert.ToInt32(Console.ReadLine());
                                m.update(code, name, mark);
                            }
                            break;
                        }
                    case 4:
                        {
                            m.saveFile();
                            Console.WriteLine("Save done !!!");
                            break;
                        }
                    case 5:
                        {
                            m.readFile();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter code");
                            string code = Console.ReadLine();
                            bool check = false;
                            while (!m.checkCode(code) || m.checkNull(code))
                            {
                                Console.WriteLine("Enter code again:");
                                code = Console.ReadLine();
                                check = true;
                            }
                            if (check == true)
                            {
                                m.detele(code);
                                Console.WriteLine("Delete OK !!!");
                            }
                            break;
                        }
                    case 7:
                        {
                            //Cach 1
                            var result = list.Where(x => x.Gender == false);
                            if (result.Count() == 0)
                            {
                                Console.WriteLine("No student found !!!");
                            }
                            else
                            {
                                Console.WriteLine("Student is Female");
                                foreach (var item in result)
                                {
                                    Console.WriteLine(item.ToString());
                                }
                            }
                            //Cach 2
                            var result2 = from s in list
                                          where s.Gender == true
                                          select s;
                            if (result2.Count() > 0)
                            {
                                Console.WriteLine("Student is Male");
                                foreach (var item in result2)
                                {
                                    Console.WriteLine(item.ToString());
                                }
                            }
                            else
                            {
                                Console.WriteLine("No student is Male !!!");
                            }


                            Console.WriteLine("");
                            var listStudentMark = list.Where(x => x.Mark > 5);
                            if (listStudentMark.Count() > 0)
                            {
                                Console.WriteLine("Student have mark >5");
                                foreach (var item in listStudentMark)
                                {
                                    Console.WriteLine(item.ToString());
                                }
                                Console.WriteLine("Co " + listStudentMark.Count() + " sinh vien qua mon");
                            }
                            else
                            {
                                Console.WriteLine("No student !!!");
                            }

                            //Co bao nhieu sinh vien ma ten 3 tu tro len
                            Console.WriteLine("");
                            Console.WriteLine("Sinh vien co ten tu 3 tu tro len");
                            int count = 0;
                            foreach (var item in list)
                            {
                                int temp = item.Name.Trim().Split(" ").Count();
                                if (temp > 2)
                                {
                                    count++;
                                    Console.WriteLine(item.ToString());
                                }                                                             
                            }
                            Console.WriteLine("Co " + count + " sinh vien");

                            //Tinh tong diem nhung sinh vien ho nguyen
                            Console.WriteLine("");
                            var tongdiem = list.Where(x => x.Name.Trim().ToLower().StartsWith("nguyen")).Sum(x => x.Mark);
                            Console.WriteLine("tong diem cua sinh vien bat dau ten bang 'nguyen': " + tongdiem);

                            //Hien thi nhung sinh vien diem cao nhat
                            Console.WriteLine("");
                            var maxMark = list.Max(x => x.Mark);
                            var listMaxMark = list.Where(x => x.Mark==maxMark);
                            Console.WriteLine("Nhung sinh vien diem cao nhat : ");
                            foreach(var item in listMaxMark)
                            {
                                Console.WriteLine(item.ToString());
                            }

                            //Sinh vien khong hoc math
                            Console.WriteLine("");
                            Console.WriteLine("Sinh vien khong hoc Math");
                            var listNoMath = list.Where(x => !x.Subject.ToLower().Equals("math"));
                            foreach(var item in listNoMath)
                            {
                                Console.WriteLine(item.ToString());
                            }

                            //Danh sach tang dan theo diem
                            Console.WriteLine("");
                            Console.WriteLine("Danh sach sv tang dan theo diem");
                            var listMarkAsc = list.OrderBy(x => x.Mark);
                            foreach (var item in listMarkAsc)
                            {
                                Console.WriteLine(item.ToString());
                            }

                            //Danh sach sv giam dan theo gioi tinh
                            Console.WriteLine("");
                            Console.WriteLine("Danh sach sv giam dan theo gioi tinh");
                            var listGender = list.OrderByDescending(x => x.Gender).ThenBy(x => x.Mark);
                            foreach(var item in listGender)
                            {
                                Console.WriteLine(item.ToString());
                            }
                            break;

                        }
                    default:
                        {
                            Console.WriteLine("Enter from 0 to 5");
                            break;
                        }
                }
            }
        }

        public void addList()
        {
            throw new NotImplementedException();
        }

        public void addList(string code)
        {
            throw new NotImplementedException();
        }

        public bool checkCode(string code)
        {
            throw new NotImplementedException();
        }

        public bool checkNull(string code)
        {
            throw new NotImplementedException();
        }

        public void detele(string code)
        {
            throw new NotImplementedException();
        }

        public void readFile()
        {
            throw new NotImplementedException();
        }

        public void saveFile()
        {
            throw new NotImplementedException();
        }

        public void showList()
        {
            throw new NotImplementedException();
        }

        public void update(string code, string name, int mark)
        {
            throw new NotImplementedException();
        }
    }
}
