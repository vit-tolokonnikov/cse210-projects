class Account {
    private string _name;
    private string _login;
    private string _password;

    public void SetAccountName()
    {
        Console.Write("What is the name of your Account? ");
        _name = Console.ReadLine();
    }

    public void SetAccountLogin()
    {
        Console.Write("What is the login of your Account? ");
        _login = Console.ReadLine();
    }

    public void SetAccountPassword()
    {
        Console.Write("Do you want to generate password? (yes/no) ");

        string answer = Console.ReadLine();

        if (answer == "yes") {
            Console.Write("How many simbols it should be? ");
            int length = int.Parse(Console.ReadLine());
            PasswordGenerator password = new PasswordGenerator(length);
            
            _password = password.Generate();
        } else {
            Console.Write("What is the password of your Account? ");
            _password = Console.ReadLine();
        }
        
    }

    public string GetAccountName()
    {
        return _name;
    }

    public string GetAccountLogin()
    {
        return _login;
    }

    public string GetAccountPassword()
    {
        return _password;
    }
}