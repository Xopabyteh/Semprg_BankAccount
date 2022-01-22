using ConsoleApp2;

class Program
{
    
    public static List<BankAccount> Accounts = new()
    {
        new(1000000000m, "Code", 0),
        new InterestingAccount(500, "Martin", 1,1m), //interest 100% hmmmm
        new LineOfCreditAccount(20, "Jakub", 2),
        new GiftCardAccount(300, "Matyas", 3)
    };
    [STAThread]
    private static void Main()
    {
        Showcase();
    }

    private static void Showcase()
    {
        BankAccount.WriteStatus(Accounts);

        Accounts[1].Deposit(30, Accounts[2], "dlazbaA");
        Accounts[1].Deposit(40, Accounts[2], "dlazbaB");
        Accounts[1].Deposit(50, Accounts[2], "dlazbaC");

        BankAccount.WriteStatus(Accounts);

        ((InterestingAccount)Accounts[1]).GiveInterests(Accounts[0]);

        Accounts[1].WriteTransactionHistory();
        Accounts[2].WriteTransactionHistory();

        BankAccount.WriteStatus(Accounts);
    }
}