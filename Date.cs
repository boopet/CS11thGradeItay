using System;
using System.Collections.Generic;
using System.Text;

namespace CS11thGradeItay
{
    public class Date
    {
        private int day;
        private int month;
        private int year;
        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
        public Date(Date other)
        {
            this.day = other.day;
            this.month = other.month;
            this.year = other.year;
        }


        public Date() : this(DateTime.Today.Day, DateTime.Today.Month, DateTime.Today.Year)
        {

        }

        public int GetYear() { return this.year; }
        public int GetMonth() { return this.month; }
        public int GetDay() { return this.day; }

        public void SetYear(int yearToSet) { if (yearToSet >= 1111 && yearToSet <= 9999) this.year = yearToSet; }
        public void Month(int monthToSet) { if (monthToSet >= 1 && monthToSet <= 12) this.month = monthToSet; }
        public void SetDay(int dayToSet) { if (dayToSet >= 1 && dayToSet <= 31) this.day = dayToSet; }

        public int CompareTo(Date other)
        {
            if (this.year > other.year)
                return 1;
            else if (this.year < other.year)
                return -1;
            if (this.month > other.month)
                return 1;
            else if (this.month < other.month)
                return -1;
            if (this.day > other.day)
                return 1;
            else if (this.day < other.day)
                return -1;
            return 0;
        }

        public override string ToString()
        {
            return $"{this.day}.{this.month}.{this.year}";
        }

        public bool LeapYear()
        {
            return ((GetYear() % 4 == 0 && GetYear() % 100 != 0) || GetYear() % 400 == 0);
        }
        public static Date[] SortDates(Date[] dates)
        {
            Date temp;
            for (int i = 0; i < dates.Length - 1; i++)
            {
                for (int j = 0; j < dates.Length - 1; j++)
                {
                    if (dates[j].CompareTo(dates[j + 1]) > 0)
                    {
                        temp = dates[j];
                        dates[j] = dates[j + 1];
                        dates[j + 1] = temp;

                    }
                }
            }
            return dates;
        }

        public static void UnitTest()
        {
            Date dt1 = new Date(17, 3, 2027);
            Date dt2 = new Date(10, 5, 2029);
            Console.WriteLine(dt1);
            Console.WriteLine(dt2.CompareTo(dt1));
            Date dt3 = new Date(7, 2, 2028);
            Date dt4 = new Date(8, 4, 2400);
            Date dt5 = new Date(21, 1, 2300);
            Console.WriteLine(dt2.LeapYear());
            Console.WriteLine(dt3.LeapYear());
            Console.WriteLine(dt4.LeapYear());
            Console.WriteLine(dt5.LeapYear());
            Date[] dates = { dt2, dt3, dt4, dt1, dt5 };
            Date.SortDates(dates);
            for (int i = 0; i < dates.Length; i++)
            {
                Console.WriteLine(dates[i] + " ");
            }
        }
    }
}