using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Serialization;

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
        private static int Max(int[] arr, int i)
        {
            if (i == arr.Length - 1)
                return arr[i];
            return Math.Max(arr[i], Max(arr, i + 1));
        }
        public static int Max(int[] arr)
        {
            return Max(arr, 0) ;
        }
        public static int RecFunc14(int[] arr, int i)
        {
            if (i == arr.Length - 1)
                return arr[i];
            return RecFunc14(arr, i + 1) + arr[i];
        }
        public static int RecFunc15(int[] arr, int i)
        {
            if (i == 0)
            return (arr[i] > 0) ? 1 : 0;
            if (arr[i] > 0)
                return RecFunc15(arr, i - 1) + 1;
            return RecFunc15(arr, i - 1);
        }
        public static int RecFunc16(int[] arr, int n, int i)
        {
            if (i == arr.Length)
                return -1;
            if (arr[i] == n)
                return i;
            return RecFunc16(arr, n, i + 1);   
        }
        public static bool RecFunc17(int[] arr, int i)
        {
            if (i == arr.Length - 1)
                return true;
            if (arr[i] > arr[i + 1])
                return false;
            return RecFunc17(arr, i + 1);
        }
        public static bool RecFunc18(int[] arr, int i)
        {
            if (i == arr.Length)
                return true;
            if (RecFunc8(arr[i], 1))
                return false;
            return RecFunc18(arr, i + 1);
        }
        public static bool CheckRow(int[,] mat, int num, int row, int col)
        {
            if (col >= mat.GetLength(1))
                return false;
            if (mat[row, col] == num)
                return true;
            return CheckRow(mat, num, row, col + 1);
        }
        private static int RecFunc19(int[,] mat, int num, int row)
        {
            if (row < 0)
                return 0;
            if (CheckRow(mat, num, row, 0))
                return RecFunc19(mat, num, row - 1) + 1;
            return RecFunc19(mat, num, row - 1);
        }
        public static bool RecFunc20(int[] arr)
        {
            Random rnd = new Random();
            int I = rnd.Next(0, arr.Length);
            int N = rnd.Next(0, arr.Length);
            int min = Math.Min(I, N);
            int max = Math.Max(I, N);
            return HelperFunc(arr, min, max);
        }
        private static bool HelperFunc(int[] arr, int left, int right)
        {
            if (left >= right)
                return true;
            if(arr[left] != arr[right])
                return false;
            return HelperFunc(arr, left + 1, right - 1);
        }
        public static int RecFunc21(string str, int i)
        {
            if (i == str.Length)
                return 0;
            if (str[i] >= 'a' && str[i] <= 'z')
            return RecFunc21(str, i + 1) + 1;
            return RecFunc21(str, i + 1);
        }
        public static string RecFunc22(string str)
        {
            return HelperFunc22(str, 0);
        }
        private static string HelperFunc22(string str, int i)
        {
            if (i == str.Length)
                return "";
            if ((i+1) % 3 == 0 && i < str.Length - 1)
                return str[i] + "*" + HelperFunc22(str, i + 1);
            return str[i] + HelperFunc22(str, i + 1);
        }
        public static string RecFunc23(string str, int i)
        {
            if (i == str.Length)
                return "";
            return str[str.Length - i - 1] + RecFunc23(str, i + 1);
        }
        public static void RecFunc24(char ch1, char ch2)
        {
           
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
            //Console.WriteLine(RecFunc13_B(5));
            int[] arr1 = { 5, 2, 3, 5, 529, 5199, 17};
            //Console.WriteLine(Max(arr, 0));
            //Console.WriteLine(RecFunc14(arr, 0));
            int[] arr2 = { -5, 2, 3, -5, 529, -5199, 17, 0 };
            //Console.WriteLine(RecFunc15(arr2, 0));
            //Console.WriteLine(RecFunc16(arr, -5, 0));
            int[] arr3 = { 9, 10, 50, 100, 200, 250 };
            //Console.WriteLine(RecFunc17(arr3, 0));
            int[] arr4 = { 4, 8, 25, 70, 5, 90};
            //Console.WriteLine(RecFunc18(arr4, 0));
            int[,] mat = {
                { 1, 2, 7, 4 },
                { 5, 6, 8, 9 },
                { 7, 1, 3, 2 }
            };
            //Console.WriteLine(RecFunc19(mat, 7, mat.GetLength(0) - 1));
            int[] arr5 = { 7, 4, 2, 4, 5 };
            int[] arr6 = { 7, 7, 7, 7, 7 };
            int[] arr7 = { 1, 4, 2, 3, 1 };
            //Console.WriteLine(RecFunc20(arr5));
            //Console.WriteLine(RecFunc20(arr6));
            //Console.WriteLine(RecFunc20(arr7));
            //Console.WriteLine(RecFunc21("aLabDzt", 0));
            //Console.WriteLine(RecFunc22("AjmsATo"));
            Console.WriteLine(RecFunc23("bla", 0));

        }
    }
}