namespace ConsoleApp2;

class LineOfCreditAccount : BankAccount 
{
    //Can go negative
    //Fees for going negative

    private const decimal Margin = 1000m;
    private const decimal NegativeFee = 19m;
    public LineOfCreditAccount(decimal balance, string owner, int id) : base(balance, owner, id)
    {
    }

    protected override void WithdrawValidity(decimal amount)
    {
        if (Balance + Margin < amount)
        {
            throw new Exception("Too deep into negative");
        }
    }

    protected override void Withdraw(decimal amount, BankAccount to, string name)
    {
        base.Withdraw(amount, to, name);
        if (Balance < 0)
        {
            //Charge fees
            Balance -= NegativeFee;
            Program.Accounts[0].Balance += NegativeFee; //"Central bank or something"
            Transaction t = new Transaction(DateTime.Now, "Fee", Transaction.TypeEnum.Withdraw, NegativeFee,
                Program.Accounts[0]);
            TransactionHistory.Add(t);
        }
    }
}