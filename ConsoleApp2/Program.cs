using ConsoleApp2;

class Program
{
    [STAThread]
    private static void Main()
    {
        List<BankAccount> accounts = new List<BankAccount>()
        {
            new(0, "Code", 0),
            new(500, "Martin", 1),
            new(500, "Jakub", 2),
            new(1, "Matyáš", 3)
        };
        while (true)
        {
            BankAccount.GiveInterests(accounts);
            BankAccount.WriteStatus(accounts);
            Thread.Sleep(3000);
        }
    }
}