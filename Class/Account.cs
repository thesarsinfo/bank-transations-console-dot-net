using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank
{
    public class Account
    {
        //propriedades da classe
        private TypeOfAccount TypeOfAccount { get; set; }
        private double Balance { get; set; }
        private double Credit { get; set; }
        private string Name { get; set; }

        public Account(TypeOfAccount typeOfAccount, double balance, double credit, string name)
        {
            this.TypeOfAccount = typeOfAccount;
            this.Balance = balance;
            this.Credit = credit;
            this.Name = name;
        }

        public bool Withdraw( double valueWithdraw)
        {
            //Validation if enought balance to withdraw
            if (this.Balance - valueWithdraw < (this.Credit *-1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Balance -= valueWithdraw;
            Console.WriteLine("Saldo Atual da conta de {0} é {1}", this.Name, this.Balance);
            return true;
        }
        public void Deposit(double valueDeposit) 
        {
            this.Balance += valueDeposit;
            Console.WriteLine("Saldo Atual da conta de {0} é {1}", this.Name, this.Balance);
        }
        public void Transfer(double valueTransfer, Account destinyAccount)
        {
            if (this.Withdraw(valueTransfer))
            {
                destinyAccount.Deposit(valueTransfer);
            }
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo de Conta " + this.TypeOfAccount + " | ";
            retorno += "Nome " + this.Name + " | ";
            retorno += "Saldo " + this.Balance + " | ";
            retorno += " Crédito " + this.Credit;
            return retorno;
        }
    }
}
