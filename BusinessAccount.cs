using System;
using System.Collections.Generic;
using System.Text;

namespace CS11thGradeItay
{
    public class BusinessAccount : CheckingAccount
    {
        private string businessName;
        public BusinessAccount(int bankNum, int branchNum, int accountNum, string ID, string businessName)
            : base(bankNum, branchNum, accountNum, ID)
        {
            this.businessName = businessName;
        }
        public BusinessAccount(int bankNum, int branchNum, int accountNum, string ID, string businessName, double overdraft)
            : base(bankNum, branchNum, accountNum, ID, overdraft)
        {
            this.businessName = businessName;
        }
        public string GetBusinessName() { return this.businessName; }
        public void SetBusinessName(string businessName) { this.businessName = businessName; }
        public override string ToString()
        {
            return base.ToString() + $"\nOverdraft: {this.GetOverdraft()}";
        }
        public bool PaySalary(double amount, CheckingAccount cAcc)
        {
            if (amount <= 0 || (this.GetAccountBalance() + this.GetOverdraft()) < amount)
                return false;
            this.SetAccountBalance(this.GetAccountBalance() - amount);
            cAcc.Deposit(amount);
            return true;
        }
        public bool FundsTransfer(double amount, BasicAccount bAcc)
        {
            bool b = base.Withdrawal(amount);
            if (b)
            {
                bAcc.Deposit(amount);
            }
            return b;
        }
        public override bool AtRisk()
        {
            return -(0.9 * this.GetOverdraft()) >= this.GetAccountBalance();
        }
        public static void UnitTest()
        {
            BusinessAccount business = new BusinessAccount(1, 1, 1, "595951991", "My Business", 5000);
            CheckingAccount employee = new CheckingAccount(2, 2, 2, "123456789");
            Console.WriteLine(business.GetBusinessName());
            Console.WriteLine(business);
            Console.WriteLine(business.Deposit(1000));
            Console.WriteLine(business.PaySalary(400, employee));
            Console.WriteLine(business.FundsTransfer(500, employee));
        }
    }
}