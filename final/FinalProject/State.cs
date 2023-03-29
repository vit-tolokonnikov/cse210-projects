using System.Text.Json;

class State
{
    private bool _isRunning = true;
    List<Converter> _jsonList = new List<Converter>();
    List<Account> _accountList = new List<Account>();


    public void Run()
    {
        while (_isRunning)
        {
            ShowMenu(); 
        }
    }

    public void ShowMenu()
    {
        string menu = $"Menu Options:\n" +
            "  1. Create Account\n" +
            "  2. List Accounts\n" +
            "  3. Save Accounts\n" +
            "  4. Load Accounts\n" +
            "  5. Search Account\n" +
            "  6. Quit\n" +
            "Select a choice from the menu: ";

        Console.Write(menu);
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            ShowAccountMenu();
        }
        else if (choice == "2")
        {
            GetAccountsList();
        }
        else if (choice == "3")
        {
            SaveAccounts();
        }
        else if (choice == "4")
        {
            LoadAccounts();
        }
        else if (choice == "5")
        {
            Search();
        }
        else if (choice == "6")
        {
            Quit();
        }
    }

    public void ShowAccountMenu()
    {
        string accountMenu = "The types of Accounts are:\n" +
            "  1. Simple Account\n" +
            "  2. Complex Account\n" +
            "Which type of Account would you like to create? ";
        
        Console.Write(accountMenu);
        string typeAccount = Console.ReadLine();
        CreateAccount(typeAccount);
    }

    // 1
    private void CreateAccount(string typeAccount)
    {
        if (typeAccount == "1")
        {
            SimpleAccount sAccount = new SimpleAccount();
            sAccount.SetAccountName();
            sAccount.SetAccountLogin();
            sAccount.SetAccountPassword();
            
            Converter sAccountJson = new Converter { 
                Name = sAccount.GetAccountName(), 
                Login =  sAccount.GetAccountLogin(),
                Password = sAccount.GetAccountPassword()
            };
            _jsonList.Add(sAccountJson);
            _accountList.Add(sAccount);
        }
        else if (typeAccount == "2")
        {
            ComplexAccount cAccount = new ComplexAccount();
            cAccount.SetAccountName();
            cAccount.SetAccountLogin();
            cAccount.SetAccountPassword();
            cAccount.SetAccountEmail();
            cAccount.SetAccountPhone();
            cAccount.SetAccountDescription();

            Converter cAccountJson = new Converter { 
                Name = cAccount.GetAccountName(), 
                Login =  cAccount.GetAccountLogin(),
                Password = cAccount.GetAccountPassword(),
                Email = cAccount.GetAccountEmail(),
                Phone = cAccount.GetAccountPhone(),
                Description = cAccount.GetAccountDescription()
            };

            _jsonList.Add(cAccountJson);
            _accountList.Add(cAccount);
        }
    }

    // 2
    private void GetAccountsList()
    {
        Console.WriteLine("{0,-20} {1,-20} {2,-20} {3, -20} {4, -20} {5, -20}", "Name", "Login", "Password", "Email", "Phone", "Description");
        Console.WriteLine("{0,-20} {1,-20} {2,-20} {3, -20} {4, -20} {5, -20}", "--------", "--------", "--------", "--------", "--------", "--------");
        foreach (var account in _jsonList)
        {
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3, -20} {4, -20} {5, -20}", $"{account.Name}", $"{account.Login}", $"{account.Password}", $"{account.Email}", $"{account.Phone}", $"{account.Description}");
        }
    }

    // 3
    private void SaveAccounts()
    {
        string jsonString = JsonSerializer.Serialize(_jsonList);

        File.WriteAllText("accounts.json", jsonString);
        Console.Write("\nAll information were saved in account.json\n");
    }

    // 4 
    private void LoadAccounts()
    {
        string jsonString = File.ReadAllText("accounts.json");
        var person = JsonSerializer.Deserialize<List<Converter>>(jsonString);
        _jsonList = person;

        Console.Write("\nAll information were loaded.\n\n");
    }
    
    // 5
    private void Search()
    {
        Console.Write("Enter account Name: ");
        string accountName = Console.ReadLine();
        Converter curAccount = null;
        foreach (var account in _jsonList)
        {
            if (account.Name == accountName)
            {
                curAccount = account;
            }
        }
        
        if (curAccount == null)
        {
            Console.Write($"\nAccount '{accountName}' is not found.\n\n");
        }
        else
        {
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3, -20} {4, -20} {5, -20}", "Name", "Login", "Password", "Email", "Phone", "Description");
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3, -20} {4, -20} {5, -20}", "--------", "--------", "--------", "--------", "--------", "--------");
            Console.WriteLine("{0,-20} {1,-20} {2,-20} {3, -20} {4, -20} {5, -20}", $"{curAccount.Name}", $"{curAccount.Login}", $"{curAccount.Password}", $"{curAccount.Email}", $"{curAccount.Phone}", $"{curAccount.Description}");
        }
        
    }

    // 6
    private void Quit()
    {
        _isRunning = false;
    }
}