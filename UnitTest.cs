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
            IntNode n4 = new IntNode(-25);
            IntNode n3 = new IntNode(81, n4);
            n4 = null;
            IntNode n2 = new IntNode(166, n3);
            n3 = null;
            IntNode n1 = new IntNode(785, n2);
            n2 = null;
            //Test1();
            //Console.WriteLine(Sum(n1));
            //Console.WriteLine(OddsCount(n1));
            //Console.WriteLine(DifferenceEvenOdd(n1));
            //Console.WriteLine(PosOverNeg(n1));
            //Console.WriteLine(IsInNode(n1, -81));
            Console.WriteLine(DescendingOrder(n1));

        }
        public static void Test1()
        {
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
            Console.WriteLine(OddsCount(n));
        }

        public static string Print(IntNode lst)
        {
            string s = "";
            while (lst != null)
            {
                s += lst.ToString() + "->";
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
        public static int OddsCount(IntNode lst)
        {
            int count = 0;
            while (lst != null)
            {
                if(lst.GetValue() % 2 == 1)
                {
                    count++;                                                                                            
                }
                lst = lst.GetNext();
            }
            return count;
        }
        public static int DifferenceEvenOdd(IntNode lst)
        {
            int sumEven = 0, sumOdd = 0;
            while (lst != null)
            {
                if (lst.GetValue() % 2 == 0)
                    sumEven += lst.GetValue();
                else
                    sumOdd += lst.GetValue();
                lst = lst.GetNext();
            }
            return Math.Abs(sumEven - sumOdd);
        }
        public static bool PosOverNeg(IntNode lst)
        {
            int countPos = 0, countNeg = 0;
            while (lst != null)
            {
                if (lst.GetValue() >= 0)
                    countPos++;
                else
                    countNeg++;
                lst = lst.GetNext();
            }
            return countPos >= countNeg;
        }
        public static bool IsInNode(IntNode lst, int n)
        {
            while(lst != null)
            {
                if (n == lst.GetValue())
                    return true;
                lst = lst.GetNext();
            }
            return false;
        }
        public static bool DescendingOrder(IntNode lst)
        {
            while (lst.GetNext() != null)
            {
                if (!(lst.GetValue() > lst.GetNext().GetValue()))
                    return false;
                lst = lst.GetNext();
            }
            return true;
        }
        //IntNode Josh = null;
        //for(int i = arr.Length - 1; i >= 0; i--)
        //   josh = new IntNode(arr[i], josh)
        // return josh;
    }
}
