using System.Diagnostics;
using System.Text;

namespace ConsoleApp2;

internal class BankAccount
{
    public decimal Balance { get; set; }
    public string Owner { get; }
    public int Id { get;  }
    protected List<Transaction> TransactionHistory { get; } = new List<Transaction>();
    public BankAccount(decimal balance, string owner, int id)
    {

        Balance = balance;
        Owner = owner;
        Id = id;
    }

    protected virtual void WithdrawValidity(decimal amount)
    {
        if (Balance < amount)
        {
            throw new ArgumentException("Not enough funds");
        }
    }
    protected virtual void Withdraw(decimal amount, BankAccount to, string name)
    {
        WithdrawValidity(amount);

        if (amount <= 0)
        {
            throw new Exception("Amount must be > 0");
        }
        
        Transaction t = new Transaction(DateTime.Now, name, Transaction.TypeEnum.Withdraw, amount,to);
        TransactionHistory.Add(t);

        Balance -= amount;
        to.Balance += amount;
    }
    
    public virtual void Deposit(decimal amount, BankAccount from,string name)
    {

        try
        { // amount > 0 && amount > balance
            from.Withdraw(amount, this, name); //Withdraw from the other and put cash into this
        }
        catch
        {
            return;
        }
        //Don't make a transaction if the withdraw didn't work
        Transaction t = new Transaction(DateTime.Now, name, Transaction.TypeEnum.Deposit, amount, from);
        TransactionHistory.Add(t);
    }

    public override string ToString()
    {
        return $"Owner:{Owner.PadRight(10)} Balance:{decimal.Floor(Balance).ToString().PadRight(10)} id:{Id.ToString().PadRight(10)}";
    }

    public void WriteTransactionHistory()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(Id).AppendLine(":");

        foreach (var transaction in TransactionHistory)
        {
            builder.AppendLine(transaction.ToString());
        }

        Console.WriteLine(builder.ToString());
    }
    public static void WriteStatus(List<BankAccount> accounts)
    {
        StringBuilder builder = new StringBuilder();
        foreach (var bankAccount in accounts)
        {
            builder.AppendLine(bankAccount.ToString());
        }

        Console.WriteLine(builder.ToString());
    }
}