using System;

namespace Delegate_Demo
{
    internal class Program
    {
        delegate void MyDelegate(int a, int b);
        delegate int Tich(int a, int b);
        static void Main(string[] args)
        {
            Tong(4, 6);
            UCLN(4,6);
            Compare(4,6);

            //Su dung delegate

            MyDelegate my = new MyDelegate(Tong);
            Console.WriteLine("");
            Console.WriteLine("Use delegate :");
            my += UCLN;
            my += Compare;
            my(1,2);
            Console.WriteLine("");
            Console.WriteLine("After remove function :");
            my -= UCLN;
            my(10, 20);

            //Cach tao delegate thu 2
            Tich t = new Tich(tich);
            Tich t2 = delegate (int a, int b)
            {
                return a * b;
            };
            Console.WriteLine("");
            Console.WriteLine("Way to use delegate");
            Console.WriteLine("t = " +t(1,2));
            Console.WriteLine("t2 = " + t2(1,2));

            //Bien doi t2 thanh lambda
            Console.WriteLine("");
            Console.WriteLine("Lambda expression : ");
            Tich t3 =  (a, b) => (a * b);
            Console.WriteLine("t3 = " + t3(1, 2));
        }

        private static int tich(int a, int b)
        {
            return a*b;
        }

        static void Tong(int a, int b)
        {
            Console.WriteLine("a+b = " + (a+b));  
        }
        static void UCLN(int a, int b)
        {
            while (a != b)
            {
                if (a > b)
                {
                    a = a - b;
                }
                else
                {
                    b = b-a;
                }
            }
            Console.WriteLine("UCLN" + a);
        }

        static void Compare(int a, int b)
        {
            if (a == b) Console.WriteLine("a = b");
            else Console.WriteLine("a != b");
            
        }
    }
}
