using System;
using System.Collections.Generic;

namespace DemoDay1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            Manager m = new Manager(list);
            while (true)
            {
                Console.WriteLine("1. Add to list Students");
                Console.WriteLine("2. Show list Students");
                Console.WriteLine("3. Update information Student");
                Console.WriteLine("4. Save to file");
                Console.WriteLine("5. Load from file");
                Console.WriteLine("0. Exit");
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
                            m.addList(list);
                            Console.WriteLine("Add OK");
                            break;
                        }
                    case 2:
                        {
                            m.showList(list);
                            if(list.Count == 0)
                            {
                                Console.WriteLine("No student !!!!!!!!!!!");
                            }
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter");
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter");
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter");
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

        private static void showList(List<Student> list)
        {
            
        }
    }
}
