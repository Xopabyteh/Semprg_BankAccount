using System.Text;

namespace ConsoleApp2;

internal class BankAccount
{
    public decimal Balance { get; private set; }
    public string Owner { get; }
    public int Id { get;  }
    public List<Transaction> TransactionHistory { get; }
    public BankAccount(decimal balance, string owner, int id)
    {
        Balance = balance;
        Owner = owner;
        Id = id;
        TransactionHistory = new List<Transaction>();
    }

    private void Withdraw(decimal amount, BankAccount to, string name)
    {
        if (Id != 0)
        {
            if (Balance < amount)
            {
                throw new ArgumentException("Not enough funds");
            }

            if (amount <= 0)
            {
                throw new Exception("Amount must be > 0");
            }
        }
        Transaction t = new Transaction(DateTime.Now, name, Transaction.TypeEnum.Withdraw, amount,to);
        TransactionHistory.Add(t);

        Balance -= amount;
        to.Balance += amount;
    }
    
    public void Deposit(decimal amount, BankAccount from,string name)
    {
        Transaction t = new Transaction(DateTime.Now, name, Transaction.TypeEnum.Deposit, amount,from);
        TransactionHistory.Add(t);

        from.Withdraw(amount, this, name); //Withdraw from the other and put cash into this
    }

    public override string ToString()
    {
        return $"Owner:{Owner.PadRight(10)} Balance:{decimal.Floor(Balance).ToString().PadRight(10)} id:{Id.ToString().PadRight(10)}";
    }

    public void WriteTransactionHistory()
    {
        StringBuilder builder = new StringBuilder();
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
    
    private const decimal InterestRate = 0.02m;
    public static void GiveInterests(List<BankAccount> accounts)
    {
        //acc[0] is central bank
        BankAccount centralBank = accounts[0];
        for (int i = 1; i < accounts.Count; i++)
        {
            BankAccount acc = accounts[i];
            decimal interest = acc.Balance * InterestRate;
            acc.Deposit(interest,centralBank,"Interest");
        }
    }
}