using System;
using System.Collections.Generic;
using System.Text;

namespace CS11thGradeItay
{
    public class CheckingAccount : BasicAccount
    {
        const int DEFAULT_OVERDRAFT = 1000;
        private double overdraft;
        public CheckingAccount(int bankNum, int branchNum, int accountNum, string ID) : base(bankNum, branchNum, accountNum, ID)
        {
            this.overdraft = CheckingAccount.DEFAULT_OVERDRAFT;
        }
        public CheckingAccount(int bankNum, int branchNum, int accountNum, string ID, double overdraft) : base(bankNum, branchNum, accountNum, ID)
        {
            this.overdraft = overdraft;
        }
        public double GetOverdraft() { return this.overdraft; }
        public void SetOverdraft(double overdraft) { if (overdraft >= 0) this.overdraft = overdraft; }
        public override string ToString()
        {
            return base.ToString() + $"\nOverdraft: {this.overdraft}";
        }

        public bool Withdrawal(double amount)
        {
            if (amount > 0 && (this.GetAccountBalance() + this.overdraft) >= amount)
            {
                this.SetAccountBalance(this.GetAccountBalance() - amount);
                return true;
            }
            return false;
        }
        public override bool AtRisk()
        {
            return this.GetAccountBalance() < 0;
        }
        public static void UnitTest()
        {
            CheckingAccount checking = new CheckingAccount(1, 1, 1, "595951991");
            checking.SetOverdraft(5000);
            Console.WriteLine(checking.GetOverdraft());
            Console.WriteLine(checking);
            Console.WriteLine(checking.Deposit(500));
            Console.WriteLine(checking.Withdrawal(700));
        }
    }
}