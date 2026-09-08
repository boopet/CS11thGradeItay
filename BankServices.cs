using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CS11thGradeItay
{
    public class BankServices
    {
        public BasicAccount[] BAccArray;
        public BankServices(int size)
        {
            this.BAccArray = new BasicAccount[size];
        }
        public BasicAccount[] GetBasicAccount()
        {
            return this.BAccArray;
        }
        public void SetBasicAccount(BasicAccount[] BAccArray)
        {
            this.BAccArray = BAccArray;
        }
        public bool Add(BasicAccount account)
        {
            for (int i = 0; i < this.BAccArray.Length; i++)
            {
                if (this.BAccArray[i] == null)
                {
                    this.BAccArray[i] = account;
                    return true;
                }
            }
            return false;
        }

        public string AccountDetails(int accountNum)
        {
            for (int i = 0; i < BAccArray.Length; i++)
            {
                if (this.BAccArray[i] != null && this.BAccArray[i].GetAccountNum() == accountNum)
                {
                    return this.BAccArray[i].ToString();
                }
            }
            return "";
        }
        public int AccountsNumber(int accountNum)
        {
            int count = 0;
            string IDHolder = "";
            bool found = false;
            for (int i = 0; i < this.BAccArray.Length && !found; i++)
            {
                if (this.BAccArray[i] != null && this.BAccArray[i].GetAccountNum() == accountNum)
                {
                    IDHolder = this.BAccArray[i].GetID();
                    found = true;
                }
            }
            if (!found)
                return 0;
            for (int i = 0; i < this.BAccArray.Length; i++)
            {
                if (this.BAccArray[i] != null && IDHolder == this.BAccArray[i].GetID())
                    count++;
            }
            return count;
        }
        public BasicAccount[] ReturnSameOwnerAccounts(string ID)
        {
            int count = 0, j = 0;
            for (int i = 0; i < this.BAccArray.Length; i++)
            {
                if (this.BAccArray[i] != null && ID == this.BAccArray[i].GetID())
                {
                    count++;
                }
            }
            if (count == 0)
            {
                return null;
            }
            BasicAccount[] arr = new BasicAccount[count];
            for (int i = 0; i < this.BAccArray.Length; i++)
            {
                if (this.BAccArray[i] != null && ID == this.BAccArray[i].GetID())
                {
                    arr[j] = this.BAccArray[i];
                    j++;
                }
            }
            return arr;
        }
        public string ReturnMaxClient()
        {
            string maxID = "", cID = "";
            double maxMoney = double.MinValue, cTotalMoney = 0;
            for (int i = 0; i < this.BAccArray.Length; i++)
            {
                if (this.BAccArray[i] != null)
                {
                    cID = this.BAccArray[i].GetID();
                    cTotalMoney = 0;
                    BasicAccount[] accs = ReturnSameOwnerAccounts(cID);
                    if (accs != null)
                    {
                        for (int j = 0; j < accs.Length; j++)
                        {
                            cTotalMoney += accs[j].GetAccountBalance();
                        }
                    }
                    if (cTotalMoney > maxMoney)
                    {
                        maxMoney = cTotalMoney;
                        maxID = cID;
                    }
                }
            }
            return maxID;
        }
        public BasicAccount[] RiskAccounts()
        {
            int count = 0, index = 0;
            for (int i = 0; i < this.BAccArray.Length; i++)
            {
                if (this.BAccArray[i] != null && this.BAccArray[i].AtRisk())
                {
                    count++;
                }
            }
            BasicAccount[] arr = new BasicAccount[count];
            for (int i = 0; i < this.BAccArray.Length; i++)
            {
                if (this.BAccArray[i] != null && this.BAccArray[i].AtRisk())
                {
                    arr[index] = this.BAccArray[i];
                    index++;
                }
            }
            return arr;
        }
        public static void UnitTest()
        {
            Date d = new Date(5, 3, 2027);
            BasicAccount bAcc1 = new BasicAccount(5, 7, 591, "123123123");
            SavingAccount bAcc2 = new SavingAccount(6, 8, 592, "234234234", d);
            CheckingAccount bAcc3 = new CheckingAccount(7, 9, 593, "345345345");
            BasicAccount bAcc4 = new CheckingAccount(8, 10, 594, "345345345");
            BasicAccount[] arr = { bAcc1, bAcc2, bAcc3 };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            BankServices Bank = new BankServices(5);
            Console.WriteLine("=== Add Accounts ===");
            Console.WriteLine(Bank.Add(bAcc1));
            Console.WriteLine(Bank.Add(bAcc2));
            Console.WriteLine(Bank.Add(bAcc3));
            Console.WriteLine(Bank.Add(bAcc4));
            bAcc2.Deposit(1234567);
            Console.WriteLine("=== Account Details ===");
            Console.WriteLine(Bank.AccountDetails(bAcc2.GetAccountNum()));
            Console.WriteLine("=== Accounts Count ===");
            Console.WriteLine(Bank.AccountsNumber(bAcc3.GetAccountNum()));
            Console.WriteLine("=== Same Owner ===");
            BasicAccount[] sameOwner = Bank.ReturnSameOwnerAccounts(bAcc3.GetID());
            for (int i = 0; i < sameOwner.Length; i++)
            {
                Console.WriteLine(sameOwner[i]);
            }
            Console.WriteLine("=== Max Client ===");
            Console.WriteLine(Bank.ReturnMaxClient());
            Console.WriteLine("=== Risk Accounts ===");
            BasicAccount[] riskAccounts = Bank.RiskAccounts();
            for (int i = 0; i < riskAccounts.Length; i++)
            {
                Console.WriteLine(riskAccounts[i]);
            }
        }
    }
}