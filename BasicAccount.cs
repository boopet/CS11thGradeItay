using System;
using System.Collections.Generic;
using System.Text;

namespace CS11thGradeItay
{
    public class BasicAccount
    {
        private int bankNum;
        private int branchNum;
        private int accountNum;
        private string ID;
        private double accountBalance;
        public BasicAccount(int bankNum, int branchNum, int accountNum, string ID)
        {
            this.bankNum = bankNum;
            this.branchNum = branchNum;
            this.accountNum = accountNum;
            this.ID = ID;
            this.accountBalance = 0;
        }
        public int GetBankNum() { return this.bankNum; }
        public int GetBranchNum() { return this.branchNum; }
        public int GetAccountNum() { return this.accountNum; }
        public string GetID() { return this.ID; }
        public double GetAccountBalance() { return this.accountBalance; }
        protected void SetAccountBalance(double accountBalance)
        {
            this.accountBalance = accountBalance;
        }
        public bool Deposit(double amount)
        {
            if (amount > 0)
            {
                this.accountBalance += amount;
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return $"Bank Number: {this.bankNum} \n Branch Number: {this.branchNum} \n " +
                $"Account Number: {this.accountNum} \n ID: {this.ID}";
        }
        public virtual bool AtRisk()
        {
            return false;
        }
    }
}

