using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static BankApplication.BankAccount;

namespace BankApplication
{
    public class BankAccount
    {

        public string bankName;
        public string accountHolderName;
        public int accountNumber;
        private decimal accountBalance;

        public decimal AccountBalance
        {
            get { return this.accountBalance; }
            set
            {
                if (value >= 0)
                {
                    accountBalance = value;
                }
                else
                {
                    Console.WriteLine("Invalid balance");
                }
            }
        }

        public List<Transaction> transactions = new List<Transaction>();

        public bool Deposite(decimal amount)
        {
            bool istrue = true;
            while (istrue)
            {

                if (amount > 0)
                {
                    accountBalance += amount;
                    istrue = false;

                    Transaction t = new Transaction();

                    t.type = "Deposit";
                    t.amount = amount;
                    t.date = DateTime.Now;

                    transactions.Add(t);

                    Console.WriteLine($"Your Account balance: {accountBalance}");
                    return true;

                   
                }
                else
                {
                    Console.WriteLine("Invalid ... TRY AGAIN...");
                    return false;

                }
            }
            return false;

        }


        public bool Withdraw(decimal wamount)
        {
            bool wtrue = true;
            while (wtrue)
            {

                if (wamount >= 0)
                {
                    if (accountBalance >= wamount)
                    {
                        accountBalance -= wamount;

                        Transaction t = new Transaction();

                        t.type = "Withdraw";
                        t.amount = wamount;
                        t.date = DateTime.Now;

                        transactions.Add(t);

                        Console.WriteLine($"Your Account balance: {accountBalance}");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Balance is not enough");
                        return false;
                    }

                }
                else
                {
                    Console.WriteLine("Invalid ... TRY AGAIN...");
                    return false;
                }
            }
            return false;
        }



        public void ShowTransaction()
        {
            
            if(transactions.Count == 0)
            {
                Console.WriteLine("No transactions available");
                return;
            }
             
            Console.WriteLine("Transaction History");

            foreach (Transaction t in transactions)
            {
                Console.WriteLine($"{t.date} | {t.type} | {t.amount}");
            }
            
        }

        

        

    }
    public class Transaction
    {
        public string type;
        public decimal amount;
        public DateTime date;

        //public Transaction(string type,decimal amount,DateTime date) {

        //    this.type = type;
        //    this.amount = amount;
        //    this.date = date;
        //}

    }
    

}



