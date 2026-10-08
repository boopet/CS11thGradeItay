using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace CS11thGradeItay
{
    public class UnitTest
    {
        public static void Run()
        {
            Test1();
        }
        public static void Test1()
        {
            //IntNode n1 = new IntNode(-17);
            //IntNode n = new IntNode(17, n1);
            //n1 = null;
            //Console.WriteLine(n1);
            //Console.WriteLine(n);
            //Console.WriteLine(n.GetNext());
            IntNode n2 = new IntNode(51);
            IntNode n1 = new IntNode(3, n2);
            IntNode n = new IntNode(42, n1);
            n2 = null;
            n1 = null;
            n.GetNext().GetNext().SetNext(new IntNode(99));
            //IntNode pos = n;
            //string s = "";
            //while(pos != null)
            //{
            //    s += pos.ToString() + " ";
            //    pos = pos.GetNext();
            //}
            //s += "null";
            //Console.WriteLine(s);
            //Console.WriteLine(n.GetValue());
            Console.WriteLine(Print(n));
            Console.WriteLine(n.GetValue());
            n.GetNext().GetNext().SetNext(null);
            Console.WriteLine(Print(n));
            Console.WriteLine(Sum(n));
        }
        public static string Print(IntNode lst)
        {
            string s = "";
            while (lst != null)
            {
                s += lst.ToString() + " ";
                lst = lst.GetNext();
            }
            s += "null";
            return s;
        }
        public static int Sum(IntNode lst)
        {
            int sum = 0;
            while (lst != null)
            {
                sum += lst.GetValue();
                lst = lst.GetNext();
            }
            return sum;
        }
    }
}
