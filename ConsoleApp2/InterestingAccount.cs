namespace ConsoleApp2;

class InterestingAccount : BankAccount
{
    //Give interests
    private readonly decimal interestRate;

    //Tohle má rajfka, když je méně než 3 jakékoliv transakce, úrok ne směšný
    private uint TransactionsAmmount;
    private const int MinTransactionAmmount = 3;
    public InterestingAccount(decimal balance, string owner, int id, decimal interestRate) : base(balance, owner, id)
    {
        this.interestRate = interestRate;
    }

    protected override void Withdraw(decimal amount, BankAccount to, string name)
    {
        base.Withdraw(amount, to, name);
        TransactionsAmmount++;
    }

    public void GiveInterests(BankAccount from)
    {

        decimal interest = TransactionsAmmount >= MinTransactionAmmount ? Balance * interestRate : 0.1m;
        this.Deposit(interest, from, "Interest");
    }
}