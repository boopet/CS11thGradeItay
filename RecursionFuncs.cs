using System;
using System.Collections.Generic;
using System.Text;

namespace CS11thGradeItay
{
    internal class RecursionFuncs
    {
        public static int RecFunc1(int n)// סכום מספרים שלמים.
        {
            if (n == 1)
                return 1;
            return n + RecFunc1(n - 1);
        }
        public static int RecFunc2(int n)// עצרת של מספר.
        {
            if (n == 1)
                return 1;
            return n * RecFunc2(n - 1);
        }
        public static int RecFunc3(int n)//מכפלת מספרים אי-זוגיים.
        {
            if (n == 1)
                return 1;
            if (n % 2 != 0)
                return n * RecFunc3(n - 1);
            return RecFunc3(n - 1);
        }
        public static int RecFunc4(int n)// כמות ספרות.
        {
            if (n > 9)
                return RecFunc4(n / 10) + 1;
            return 1;
        }
        public static int RecFunc5(int n1, int n2)//חילוק בעזרת חיסור.
        {
            if (n2 < 0)
                return -RecFunc5(n1, -n2);
            if (n1 < 0)
                return -RecFunc5(-n1, n2);
            if (n1 < n2)
                return 0;
            return RecFunc5(n1 - n2, n2) + 1;
        }
        public static int RecFunc6(int n1, int n2)// שארית בעזרת חיסור.
        {
            if (n2 < 0)
                return -RecFunc6(n1, -n2);
            if (n1 < 0)
                return -RecFunc6(-n1, n2);
            if (n1 < n2)
                return n1;
            return RecFunc6(n1 - n2, n2);
        }
        public static bool RecFunc7(int x, int y)// מציאת כפולות מספר.
        {
            if (x == 0)
                return true;
            if (Math.Abs(x) - Math.Abs(y) == 0)
                return true;
            if (Math.Abs(x) - Math.Abs(y) < 0)
                return false;
            return RecFunc7(Math.Abs(x) - Math.Abs(y), y);
        }
        public static bool RecFunc8(int n, int t)// בדיקה אם מספר ראשוני
        {
            if (n <= 1)
                return false;
            if (n % t == 0 && n != t && t != 1)
                return false;
            if (n == t)
                return true;
            return RecFunc8(n, t + 1);
        }
        public static bool RecFunc9(int n)// בדיקה אם אותה זוגיות.
        {
            if (n < 10)
                return true;
            if ((n % 10) % 2 != ((n / 10) % 10) % 2)
                return false;
            return RecFunc9(n / 10);
        }
        public static int RecFunc10(int n)// סכום סדרה.
        {
            if (n == 0)
                return 0;
            if (n % 2 == 1)
                return (n * 2) + RecFunc10(n - 1);
            else
                return (n * n) + RecFunc10(n - 1);
        }
        public static double RecFunc11(int n, int I)// סכום שורשים מתחלפים.
        {
            if (n < I)
                return 0;
            if (I % 2 == 1)
                return (I * 2 - 1) + RecFunc11(n, I + 1);
            else
                return -Math.Sqrt(I * 2 - 1) + RecFunc11(n, I + 1);
        }
        public static int RecFunc12(int n1, int n2, int I)// סכום כפולות חסומות.
        {
            if (n1 * I >= n2)
                return 0;
            return (n1 * I) + RecFunc12(n1, n2, I + 1);
        }
        public static int RecFunc13_A(int I)// חישוב איבר בסדרה.
        {
            if (I == 1)
                return 0;
            if (I == 2)
                return 1;
            return RecFunc13_A(I - 2) * RecFunc13_A(I - 2) + RecFunc13_A(I - 1) * RecFunc13_A(I - 1);
        }
        public static int RecFunc13_B(int n)// סכום איברי הסדרה.
        {
            if (n == 1)
                return RecFunc13_A(1);
            return RecFunc13_A(n) + RecFunc13_B(n - 1);
        }
        public static void UnitTest()
        {
            //Console.WriteLine(RecFunc1(6)); 
            //Console.WriteLine(RecFunc2(5));
            //Console.WriteLine(RecFunc3(8));
            //Console.WriteLine(RecFunc4(354535));
            //Console.WriteLine(RecFunc5(-10, 3));
            //Console.WriteLine(RecFunc6(-17, -3));
            //Console.WriteLine(RecFunc7(-18, -3));
            //Console.WriteLine(RecFunc8(1, 1));
            //Console.WriteLine(RecFunc9(1557235));
            //Console.WriteLine(RecFunc10(10));
            //Console.WriteLine(RecFunc11(10, 1));
            //Console.WriteLine(RecFunc12(5, 11, 1));
            //Console.WriteLine(RecFunc13_A(6));
            Console.WriteLine(RecFunc13_B(5));
        }
    }
}