using System;
using System.Collections.Generic;

namespace DemoDay1
{
    internal class Program:IManager
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
                                m.update(code,name,mark);
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
