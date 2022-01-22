namespace ConsoleApp2;

class GiftCardAccount : BankAccount
{
    //Can only be charged at the every start of the month
    //Seems kinda useless to me ;)

    private DateTime lastValidDepositDate = DateTime.MinValue;
    
    public GiftCardAccount(decimal balance, string owner, int id) : base(balance, owner, id)
    {

    }

    public override void Deposit(decimal amount, BankAccount from, string name)
    {
        if (lastValidDepositDate.AddMonths(1) <= DateTime.Now)
        {
            base.Deposit(amount, from, name);
            lastValidDepositDate = DateTime.Now;
        }
        else
        {
            throw new Exception("Cannot be charged yet");
        }
    }
}