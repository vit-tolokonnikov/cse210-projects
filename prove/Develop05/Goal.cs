class Goal
{
    private string _fullText;
    private string _goalName;
    private string _goalDescription;
    private int _points;
    private int _bonusTimes;
    private int _extraBonus;
    private string _isCompleted = " ";
    private string _typeGoal;


    public void SetGoalName(string str = "No")
    {
        if (str == "No")
        {
            Console.Write("What is the name of your goal? ");
            _goalName = Console.ReadLine();
        }
        else
        {
            _goalName = str;
        }
        
    }
    public void SetGoalDescription(string str = "")
    {
        if (str == "")
        {
            Console.Write("What is a short description of it? ");
            _goalDescription = Console.ReadLine();
        }
        else
        {
            _goalDescription = str;
        }
        SetFullText();
    }
    public void SetPoints(string points = "0")
    {
        if (points == "0")
        {
            Console.Write("What is the amount of points associated with this goal? ");
            _points = int.Parse(Console.ReadLine());
        }
        else
        {
            _points = int.Parse(points);
        }
        
    }
    public void SetBonusTimes(string num = "0")
    {
        if (num == "0")
        {
            Console.Write("How many times does this goal need to be accomplished for a bonus? ");
            _bonusTimes = int.Parse(Console.ReadLine());
        }
        else
        {
            _bonusTimes = int.Parse(num);
        }
    }
    public void SetExtraBonus(string num = "0")
    {
        if (num == "0")
        {
            Console.Write("What is the bonus for accompishing it that many times? ");
            _extraBonus = int.Parse(Console.ReadLine());
        }
        else
        {
           _extraBonus = int.Parse(num);
        }
    }
    
    public void SetIsCompleted(string str)
    {
        _isCompleted = str;
        SetFullText();
    }
    public void SetTypeGoal(string typeGoal)
    {
        _typeGoal = typeGoal;
    }

    public void SetFullText()
    {
        _fullText = $" [{IsCompleted()}] {_goalName} ({_goalDescription})";
    }

    public string IsCompleted()
    {
        return _isCompleted;
    }

    public int GetExtaBonus()
    {
        return _extraBonus;
    }

    public string GetTypeGoal()
    {
        return _typeGoal;
    }

    public string GetGoalName()
    {
        return _goalName;
    }

    public string GetGoalDescription()
    {
        return _goalDescription;
    }

    public int GetPoints()
    {
        return _points;
    }

    public string GetFullText()
    {
        return _fullText;
    }
    
    public virtual string PrintFullText()
    {
        return _fullText;
    }

    public int GetBonusTimes()
    {
        return _bonusTimes;
    }

    public virtual string PrepareForSaving() { return " "; }
    public virtual void SetNumCompletedFromFile(int num) {}
    public virtual void SetNumCompleted() {}
    public virtual bool GetExtra() { return false; }
}