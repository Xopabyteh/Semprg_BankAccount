namespace ConsoleApp2;

class Transaction
{
    public DateTime Time { get; set; }
    public string Name { get; set; }
    public TypeEnum TransactionType  { get; set; }
    public decimal Amount { get; set; }
    public BankAccount SecondParticipant { get; set; }

    public Transaction(DateTime time, string name, TypeEnum transactionType, decimal amount, BankAccount secondParticipant)
    {
        Time = time;
        Name = name;
        TransactionType = transactionType;
        Amount = amount;
        SecondParticipant = secondParticipant;
    }

    public enum TypeEnum
    {
        Withdraw,
        Deposit
    }

    public override string ToString()
    {
        string inOrOut = TransactionType == TypeEnum.Withdraw ? "To" : "From";
        return $"Amount {Amount}, Type: {TransactionType}, {inOrOut} {SecondParticipant.Id}, at {Time}";
    }
}