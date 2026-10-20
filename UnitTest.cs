using System;
using System.Collections.Generic;
using System.Text;

namespace CS11thGradeItay
{
    public class UnitTest
    {
        public static void Run()
        {
            IntNode n4 = new IntNode(166);
            IntNode n3 = new IntNode(81, n4);
            n4 = null;
            IntNode n2 = new IntNode(166, n3);
            n3 = null;
            IntNode n1 = new IntNode(166, n2);
            n2 = null;
            //Test1();
            //Console.WriteLine(Sum(n1));
            //Console.WriteLine(OddsCount(n1));
            //Console.WriteLine(DifferenceEvenOdd(n1));
            //Console.WriteLine(PosOverNeg(n1));
            //Console.WriteLine(IsInNode(n1, -81));
            //Console.WriteLine(DescendingOrder(n1));
            //Console.WriteLine(CountSeq(n1, 166));
            //Console.WriteLine(OddOrEven(n1));
            //IntNode result = RemoveValue(n1, 166);
            //IntNode p = result;
            //while(p != null)
            //{
            //    Console.WriteLine(p.GetValue());
            //    p = p.GetNext();
            //}
            //Console.WriteLine("null");
            IntNode result = NoDuplicates(n1);
            IntNode p = result;
            while(p != null)
            {
                Console.WriteLine(p.GetValue());
                p = p.GetNext();
            }
            Console.WriteLine("null");
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
                if (lst.GetValue() % 2 == 1)
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
            while (lst != null)
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
        public static int CountSeq(IntNode lst, int n)
        {
            int count = 0;
            while (lst != null)
            {
                if (lst.GetValue() == n && (lst.GetNext() == null || lst.GetNext().GetValue() != n))
                    count++;
                lst = lst.GetNext();
            }
            return count;
        }
        public static char OddOrEven(IntNode lst)
        {
            int count = 0;
            while (lst != null)
            {
                if (lst.GetValue() % 2 == 0)
                    count++;
                else
                    count--;
                lst = lst.GetNext();
            }
            if (count > 0)
                return 'z';
            if (count < 0)
                return 'e';
            return 's';
        }
        public static IntNode RemoveValue(IntNode lst, int n)
        {
            IntNode curr = lst;
            while(curr.GetNext() != null)
            {
                if (curr.GetNext().GetValue() == n)
                    curr.SetNext(curr.GetNext().GetNext());
                else
                    curr = curr.GetNext();
            }
            return lst;
        }
        public static IntNode NoDuplicates(IntNode lst)
        {
            IntNode curr = lst;
            IntNode head = null;
            IntNode tail = null;
            IntNode p = lst;
            bool exists = true;
            while (curr != null)
            {
                exists = false;
                p = head;
                while (p != null)
                {
                    if (p.GetValue() == curr.GetValue())
                        exists = true;
                    p = p.GetNext();
                }
                if (!exists)
                {
                    IntNode newNode = new IntNode(curr.GetValue());
                    if(head == null)
                    {
                        head = newNode;
                        tail = newNode;
                    }
                    else
                    {
                        tail.SetNext(newNode);
                        tail = newNode;
                    }
                }
                curr = curr.GetNext();
            }
            return head;
        }
        public static void PrintBigger(IntNode lst)
        {
            IntNode p = lst; 
            while (lst.GetNext() != null)
            {
                if (lst.GetNext().GetValue() > lst.GetValue())
                    lst.GetValue();
            }
        }
        //IntNode Josh = null;
        //for(int i = arr.Length - 1; i >= 0; i--)
        //   josh = new IntNode(arr[i], josh)
        // return josh;
    }
}