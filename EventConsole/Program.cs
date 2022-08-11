using DemoDay1;
using System;
using System.Collections.Generic;

namespace EventConsole
{
    internal class Program
    {
        static int n = 1;
        static void Main(string[] args)
        {
            do
            {
                Console.WriteLine("Enter number textbox : ");
                n = Convert.ToInt32(Console.ReadLine());
            } while (n > 10);
            Button btnSubmit = new Button();
            //gan su kien click cho button
            btnSubmit.ButtonClick += BtnSubmit_ButtonClick;

            //mo phong nhan nut submit
            Console.WriteLine("Enter any key to submit :");
            Console.ReadKey();
            btnSubmit.Click();
            foreach (Textbox t in list)
            {
                Console.WriteLine("Text box : " + t.Text);
            }


            Button btnAdd = new Button();
            //gan su kien cho nut add
            btnAdd.ButtonClick += BtnAdd_AddClick;
            //mo phong nhan nut add
            Console.WriteLine("Enter any key to add :");
            Console.ReadKey();
            btnAdd.Click();
            foreach (Checkbox c in listCheckBox)
            {
                Console.WriteLine("Check box : " + c.Text);
            }

            //mo phong checkbox check or uncheck
            while (true)
            {
                Console.WriteLine("Enter check box you want to choose : ");
                int option = Convert.ToInt32(Console.ReadLine());
                if (option == 0)
                {
                    break;
                }
                for (int i = 0; i < n; i++)
                {
                    if (option - 1 == i)
                    {
                        Console.WriteLine("1. Checked");
                        Console.WriteLine("2. Uncheck");
                        int check = Convert.ToInt32(Console.ReadLine());
                        if (check == 1)
                        {
                            listCheckBox[i].Checked = true;
                        }
                        else
                        {
                            listCheckBox[i].Checked = false;
                        }
                    }
                }
            }

            //mo phong text value change cho cac textbox
            //moi khi value cua textbox bi thay doi thong bao Oldvalue : xxx . Newvalue : xxx va thay doi text cua check tuong ung
          
            while (true)
            {
                Console.WriteLine("Enter textbox you want to change : (1,2,3,4.....)");
                int number = Convert.ToInt32(Console.ReadLine());
                if (number == 0)
                {
                    break;
                }
                for (int i = 0; i < n; i++)
                {
                    if (number - 1 == i)
                    {
                        Console.WriteLine("Enter new text : ");                   
                        list[i].Text = Console.ReadLine();
                        listCheckBox[i].Text = list[i].Text; 
                                             
                    }
                }              
            }

        }

        static List<Checkbox> listCheckBox = new List<Checkbox>();
        private static void BtnAdd_AddClick()
        {
            for (int i = 0; i < n; i++)
            {
                Checkbox checkbox = new Checkbox();
                checkbox.Text = list[i].Text;
                checkbox.checkChange += Checkbox_checkChange;
                listCheckBox.Add(checkbox);
            }
        }

        private static void Checkbox_checkChange(string text, bool check)
        {
            Console.WriteLine(text + " " + (check ? "checked" : "uncheck"));
        }

        static List<Textbox> list = new List<Textbox>();
        private static void BtnSubmit_ButtonClick()
        {
            for (int i = 1; i <= n; i++)
            {
                Textbox textbox = new Textbox();
                Console.WriteLine("Enter text :");
                textbox.Text = Console.ReadLine();    
                textbox.changeText += Textbox_changeText;
                list.Add(textbox);
            }
        }

        private static void Textbox_changeText(string Oldtext, string Newtext)
        {
            Console.WriteLine("Oldtext: "+ Oldtext + " -- Newtext: " +Newtext);
        }
    }
}
