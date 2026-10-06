using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace CS11thGradeItay
{
    public class UnitTest
    {
        public static void Ruin()
        {
            Test1();
        }
        public static void Test1()
        {
            IntNode n1 = new IntNode(-17);
            IntNode n = new IntNode(17, n1);
            n1 = null;
            Console.WriteLine(n1);
            Console.WriteLine(n);
            Console.WriteLine(n.GetNext());
        }
    }
}
