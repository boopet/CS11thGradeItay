using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CS11thGradeItay
{
    public class SavingAccount : BasicAccount
    {
        private Date date;
        public SavingAccount(int bankNum, int branchNum, int accountNum, string ID, Date date) : base(bankNum, branchNum, accountNum, ID)
        {
            this.date = new Date(date);
        }

        public Date GetDate() { return new Date(this.date); }
        public void SetDate(Date date) { this.date = new Date(date); }
        public override string ToString()
        {
            return base.ToString() + $"\nExpiry Date: {this.date}";
        }

        public bool Withdrawal(Date d)
        {
            if (d.CompareTo(this.date) >= 0)
            {
                this.SetAccountBalance(0);
                return true;
            }
            return false;
        }
        public override bool AtRisk()
        {
            return this.GetAccountBalance() == 0;
        }
        public static void UnitTest()
        {
            Date d = new Date(15, 2, 2020);
            SavingAccount saving = new SavingAccount(1, 1, 1, "595951991", d);
            Date d2 = new Date(17, 2, 2025);
            saving.SetDate(d2);
            Console.WriteLine(saving.GetDate());
            Console.WriteLine(saving);
            Console.WriteLine(saving.Deposit(500));
            Console.WriteLine(saving.Withdrawal(d2));
        }
    }
}