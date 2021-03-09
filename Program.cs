using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    class Program
    {
        static List<Account> listAccount = new List<Account>();
        static void Main(string[] args)
        {
            
            string userOption = GetUserOption();
            while ( userOption.ToUpper() != "X" )
            {
                switch (userOption)
                {
                    case "1":
                        AccountList();
                        break;
                    case "2":
                        InsertAccount();
                        break;
                    case "3":
                        Transfer();
                        break;
                    case "4":
                        Withdraw();
                        break;
                    case "5":
                        Deposit();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Valor informado errado!");
                        break;

                }
                userOption = GetUserOption();
            }
        }

        private static void Withdraw()
        {
            Console.Write("Digite o número da conta que deseja sacar ");
            int accountIndexEntry = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser sacado: ");
            double withdrawValueEntry = double.Parse(Console.ReadLine());
            listAccount[accountIndexEntry].Withdraw(withdrawValueEntry);
        }
        private static void Deposit()
        {
            Console.Write("Digite o número da conta que deseja sacar ");
            int accountIndexEntry = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser sacado: ");
            double depositValueEntry = double.Parse(Console.ReadLine());
            listAccount[accountIndexEntry].Deposit(depositValueEntry);
        }
        private static void AccountList()
        {
            if (listAccount.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta cadastrada no sistema.");
            }
            for (int i = 0; i < listAccount.Count; i++)
            {
                Account account = listAccount[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(account);
            }
        }

        private static void InsertAccount()
        {
            Console.WriteLine("Inserir nova Account");
            Console.Write("Digite 1 para Conta Física ou 2 para Conta Jurídica: ");
            int accountTypeEntry = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome do Cliente ");
            string accountNameEntry = Console.ReadLine();
            Console.Write("Digite o saldo inicial do cliente ");
            double accountBalanceEntry = double.Parse(Console.ReadLine());
            Console.Write("Digite o crétido inicial do cliente ");
            double accountCreditEntry = double.Parse(Console.ReadLine());

            Account newAccount = new Account(typeOfAccount: (TypeOfAccount)accountTypeEntry,
                                             balance: accountBalanceEntry,
                                             credit: accountCreditEntry,
                                             name: accountNameEntry);
            listAccount.Add(newAccount);
        }
        private static void Transfer()
        {
            Console.Write("Digite o número da conta de origem ");
            int accountIndexEntry = int.Parse(Console.ReadLine());
            Console.Write("Digite o número da conta de destino ");
            int accountDestinyIndexEntry = int.Parse(Console.ReadLine());
            Console.Write("Digite o valor a ser transferido ");
            double transferValueEntry = double.Parse(Console.ReadLine());

            listAccount[accountIndexEntry].Transfer(transferValueEntry, listAccount[accountDestinyIndexEntry]);
        }
        public static string GetUserOption()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao DIO Bank");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string userOption = Console.ReadLine();
            return userOption;

        }
    }
   
}
