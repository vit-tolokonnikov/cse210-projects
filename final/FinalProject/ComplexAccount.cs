class ComplexAccount: Account
{
    private string _email;
    private string _phone;
    private string _description;

    public void SetAccountEmail()
    {
        Console.Write("What is the email of your Account? ");
        _email = Console.ReadLine();
    }

    public void SetAccountPhone()
    {
        Console.Write("What is the phone of your Account? ");
        _phone = Console.ReadLine();
    }

    public void SetAccountDescription()
    {
        Console.Write("What is the description of your Account? ");
        _description = Console.ReadLine();
    }

    public string GetAccountEmail()
    {
        return _email;
    }
    public string GetAccountPhone()
    {
        return _phone;
    }
    public string GetAccountDescription()
    {
        return _description;
    }
}