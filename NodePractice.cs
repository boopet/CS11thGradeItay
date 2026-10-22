using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace CS11thGradeItay
{
    public class NodePractice
    {
        //עד המבחן עד 47
        public void Run()
        {
            Node<int> josh = new Node<int>(17);
            Node<string> kosh = new Node<string>("Josh");
            Node<object> bcm = new Node<object>("Josh");
            bcm.SetNext(new Node<object>(17));
        }
        public static string Print<T>(Node<T> lst)
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
        public static void Question15_A(Node<char> lst, char ch)
        {
            int count = 0;
            while (lst != null)
            {
                if (lst.GetValue() == ch)
                    count++;
                lst = lst.GetNext();
            }
            Console.WriteLine($"The amount of times the character appears in the list is {count}.");
        }
        public static void Question15_B()
        {
            Console.WriteLine("Enter character: ");
            char c = char.Parse(Console.ReadLine());
            Node<int> node = new Node<int>(c);
            while (c != '@')
            {
                Console.WriteLine("Enter character: ");
                c = char.Parse(Console.ReadLine());
                node = new Node<int>(c);
            }
            while (node != null)
            {

            }
        }
        //יש שני סוגי הכנסות: להכניס איבר לסוף הרשימה אז האיבר האחרון יהיה בסוף הרשימה,
        //chain = new Node<int>(lst.GetValue(), chain); do this in a loop
        //the line above in a loop creates a reversed list;
        //make one that adds a value to the end, adds n times to the end.
        public static Node<int> Copy(Node<int> lst)
        {
            Node<int> head = new Node<int>(lst.GetValue());
            Node<int> pos = head; /*- this line makes sure we don't lose the head*/
            lst = lst.GetNext();
            while (lst != null)
            {
                pos.SetNext(new Node<int>(lst.GetValue()));
                lst = lst.GetNext();
                pos = pos.GetNext();
            }
            return head;
        }
        //the function above makes an exact copy of a list.
        //There are 3 kinds of questions in polymorphism.
        //שאלה של נכון או לא נכון אם תהיה שגיאה או לא
        //אם זה נכון מהו הפלט, לא נכון למה
        //לתכנן מערכת לפי סיפור של בערך 2 עמודים, דריסות 
        //מעקב של עצמים ולצייר תרשים עצמים
        //השלם את החסר, יש נתונים וצריך להסיק מה חסר
        public static void Remove(Node<int> lst, int x)
        {
            while (lst.GetNext() != null && lst.GetNext().GetValue() != x)
            {
                if (lst.GetNext() != null)
                {
                    Node<int> temp = lst.GetNext();
                    lst.SetNext(temp.GetNext());
                    temp.SetNext(null);
                }
            }
        }
        //The function above remove a value from the list.d
        //תמיד לבנות תרשים עצמים בכל שאלה של פולימפיזם, ירושה, הכלה.
        //לבדוק הרשאות גישה, תמיד לכתוב base בירושה, לסרטט תרשים עצמים

        //תבנית מחפשת מספר אי זוגי ראשון ומחזירה מצביע למיקומו, תבנית שמחפשת מספר זוגי אחרון ומחזירה מצביע למיקומו, תבנית שמקבלת שני מצבעים ומחליפה את הערכים ביניהם. - שאלה 26
        public static void AddLast(Node<int> lst, int x)
        {
            while (lst.GetNext() != null)
            {
                lst = lst.GetNext();
                lst.SetNext(new Node<int>(x));
            }
        }
    }
}