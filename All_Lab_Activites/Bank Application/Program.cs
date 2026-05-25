using System;
using System.Security.Principal;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Transactions;
namespace BankApplication
{





    internal class programs
    {

        static void WelcomeMsg()
        {
            Console.WriteLine("TIC BANK");
            Console.WriteLine("HELLO WELCOME OUR BANK......");
            Console.WriteLine("-----------------------------");
        }

        public static int Menu()
        {
            int menu;
            Console.WriteLine(" 1)View Account \n 2)Check Balance \n 3)Deposit \n 4)Withdraw \n 5)Transaction History \n 6)Exit");
            Console.Write("Select your option ? ");
            menu = int.Parse(Console.ReadLine());
            return menu;
        }


        public static void AccountDetails(BankAccount acc)
        {
            Console.Write("Enter Your BankName? ");
            acc.bankName = Console.ReadLine();

            Console.Write("Enter Your Accountholdername? ");
            acc.accountHolderName = Console.ReadLine();

            Console.Write("Enter Your Accountnumber? ");
            acc.accountNumber = int.Parse(Console.ReadLine());

            bool validBalance = false;

            while (!validBalance)
            {
                Console.Write("Enter Your Accountbalnce: ");
                decimal balance;

                if (decimal.TryParse(Console.ReadLine(), out balance))
                {
                    acc.AccountBalance = balance;
                    validBalance = true;
                }
                else
                {
                    Console.WriteLine("Invalid balance... TRY AGAIN");
                }

            }
        }


            static void Main(string[] args)
            {


                WelcomeMsg();

                BankAccount acc = new BankAccount();
                AccountDetails(acc);



                bool running = true;
                while (running)
                {
                    int choice = Menu();

                    Console.Clear();

                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine($"Account Balance: {acc.bankName}");
                            Console.WriteLine($"Account Holder Name: {acc.accountHolderName}");
                            Console.WriteLine($"Account Number: {acc.accountNumber}");
                            Console.WriteLine($"Account Balance: {acc.AccountBalance:F2}");
                            break;
                        case 2:
                            Console.WriteLine($"Current Balance: {acc.AccountBalance:F2}");
                            break;
                        case 3:
                            Console.WriteLine("Enter a deposit Amount: ");
                            decimal amount;

                            if (decimal.TryParse(Console.ReadLine(), out amount))
                            {
                                bool result = acc.Deposite(amount);
                                if (result)
                                {
                                    Console.WriteLine("Deposite Successful");
                                }
                                else { Console.WriteLine("Deposite failier"); }
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount");
                            }

                            break;

                        case 4:

                            Console.WriteLine("Enter a withdrawal Amount: ");
                            decimal wamount;

                            if (decimal.TryParse(Console.ReadLine(), out wamount))
                            {
                                bool withdrawResult = acc.Withdraw(wamount);

                                if (withdrawResult)
                                {
                                    Console.WriteLine("Withdraw Successful");
                                }
                                else
                                {
                                    Console.WriteLine("Withdraw Failed");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid amount");
                            }


                            break;



                        case 5:
                            acc.ShowTransaction();
                            break;


                        case 6:
                            Console.WriteLine("exit");
                            running = false;
                            break;



                        default:
                            Console.WriteLine("Invalid option");
                            break;

                    }



                    //if (menu == 1)
                    //{
                    //    //viwe accunt
                    //}
                    //else if (menu == 2)
                    //{
                    //    //check balance
                    //}
                    //else if (menu == 3)
                    //{
                    //    //deposit
                    //}
                    //else if (menu == 4)
                    //{
                    //    //withdraw
                    //}
                    //else if (menu == 5) { 
                    ////exit
                    //running = false;
                    //    Console.WriteLine("Exit");
                    //}else
                    //{
                    //    Console.WriteLine("Invalid option...");
                    //}





                }
            }
        }
    }
