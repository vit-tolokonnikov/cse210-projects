using System;
using System.IO;

class State
{
    private bool _isRunning = true;
    private int _curPoints = 0;
    List<Goal> _goalList = new List<Goal>();

    public void Run()
    {
        while (_isRunning)
        {
            ShowMenu(); 
        }
    }
    

    public void ShowMenu()
    {
        string menu = $"You have {_curPoints} points.\n\n"+
            "Menu Options:\n" +
            "  1. Create New Goal\n" +
            "  2. List Goals\n" +
            "  3. Save Goals\n" +
            "  4. Load Goals\n" +
            "  5. Reload Event\n" +
            "  6. Quit\n" +
            "Select a choice from the menu: ";

        Console.Write(menu);
        string choice = Console.ReadLine();

        if (choice == "1")
        {
            ShowGoalMenu();
        }
        else if (choice == "2")
        {
            GetGoalList();
        }
        else if (choice == "3")
        {
            SaveGoals();
        }
        else if (choice == "4")
        {
            LoadGoals();
        }
        else if (choice == "5")
        {
            RecordEvent();
        }
        else if (choice == "6")
        {
            Quit();
        }
    }

    public void ShowGoalMenu()
    {
        string goalMenu = "The types of Goals are:\n" +
            "  1. Simple Goal\n" +
            "  2. Eternal Goal\n" +
            "  3. Checklist Goal\n" +
            "Which type of goal would you like to create? ";
        
        Console.Write(goalMenu);
        string typeGoal = Console.ReadLine();
        CreateGoal(typeGoal);
    }

    private void CreateGoal(string typeGoal)
    {
        if (typeGoal == "1")
        {
            SimpleGoal sGoal = new SimpleGoal();
            sGoal.SetGoalName();
            sGoal.SetGoalDescription();
            sGoal.SetPoints();
            sGoal.SetTypeGoal("SimpleGoal");
            _goalList.Add(sGoal);
        }
        else if (typeGoal == "2")
        {
            EternalGoal eGoal = new EternalGoal();
            eGoal.SetGoalName();
            eGoal.SetGoalDescription();
            eGoal.SetPoints();
            eGoal.SetTypeGoal("EternalGoal");
            _goalList.Add(eGoal);
        }
        else if (typeGoal == "3")
        {
            ListGoal lGoal = new ListGoal();
            lGoal.SetGoalName();
            lGoal.SetGoalDescription();
            lGoal.SetPoints();
            lGoal.SetBonusTimes();
            lGoal.SetExtraBonus();
            lGoal.SetTypeGoal("ChecklistGoal");
            _goalList.Add(lGoal);
        }
        else
        {

        }
    }

    public void GetGoalList()
    {
        string str = "The goals are:\n";
        foreach (var goal in _goalList)
        {
            int i = _goalList.IndexOf(goal) + 1;
            str += $"{i}. " + goal.PrintFullText() + "\n"; 
        }
        str += "\n";
        Console.Write(str);
    }

    public void RecordEvent()
    {
        string str = "The goals are:\n";
        foreach (var goal in _goalList)
        {
            int i = _goalList.IndexOf(goal) + 1;
            str += $"{i}. " + goal.GetGoalName() + "\n"; 
        }
        str += "\n";
        str += "Which goal did you accomplish? ";
        Console.Write(str);

        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        Congratulations(goalIndex);
    }

    public void Congratulations(int index)
    {
        foreach (var goal in _goalList)
        {
            int i = _goalList.IndexOf(goal);
            
            if (i == index)
            {
                string str = "You have already reached this goal!\n\n";
                if (goal.GetTypeGoal() == "SimpleGoal" && goal.IsCompleted() != "x")
                {
                    goal.SetIsCompleted("x");
                    _curPoints += goal.GetPoints();
                    str = $"Congratulations! You have earned {goal.GetPoints()} points!\n";
                }
                else if (goal.GetTypeGoal() == "ChecklistGoal" && goal.IsCompleted() != "x")
                {
                    goal.SetNumCompleted();
                    _curPoints += goal.GetPoints();
                    if (goal.GetExtra())
                    {
                        _curPoints += goal.GetExtaBonus();
                        goal.SetIsCompleted("x");
                    }
                    str = $"Congratulations! You have earned {goal.GetPoints()} points!\n";
                }
                else if (goal.GetTypeGoal() == "EternalGoal")
                {
                    _curPoints += goal.GetPoints();
                    str = $"Congratulations! You have earned {goal.GetPoints()} points!\n";
                }

                Console.Write(str);
            }
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");

        string fileName = Console.ReadLine();
        
        using (StreamWriter sw = File.CreateText(fileName))
        {
            sw.Write(_curPoints + "\n");

            foreach (var goal in _goalList)
            {
                sw.WriteLine(goal.PrepareForSaving());
            }
        }

        if (File.Exists(fileName))
        {
            Console.WriteLine($"The file {fileName} was created.");
        }
        else
        {
            Console.WriteLine($"There is an error in creating this file: {fileName}.");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");

        string fileName = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(fileName);
        int number;

        foreach (string line in lines)
        {
            string[] parts = line.Split(";");
            
            if (int.TryParse(parts[0], out number))
            {
                _curPoints = int.Parse(parts[0]);
            }
            else
            {
                if (parts[0] == "SimpleGoal")
                {
                    SimpleGoal sGoal = new SimpleGoal();
                    sGoal.SetGoalName(parts[1]);
                    sGoal.SetGoalDescription(parts[2]);
                    sGoal.SetPoints(parts[3]);
                    sGoal.SetIsCompleted(parts[4]);
                    sGoal.SetTypeGoal(parts[0]);
                    _goalList.Add(sGoal);
                }
                else if (parts[0] == "ChecklistGoal")
                {
                    ListGoal lGoal = new ListGoal();
                    lGoal.SetGoalName(parts[1]);
                    lGoal.SetGoalDescription(parts[2]);
                    lGoal.SetPoints(parts[3]);
                    lGoal.SetIsCompleted(parts[4]);
                    lGoal.SetNumCompletedFromFile(int.Parse(parts[5]));
                    lGoal.SetExtraBonus(parts[6]);
                    lGoal.SetBonusTimes(parts[7]);
                    lGoal.SetTypeGoal("ChecklistGoal");
                    _goalList.Add(lGoal);
                }
                else if (parts[0] == "EternalGoal")
                {
                    EternalGoal eGoal = new EternalGoal();
                    eGoal.SetGoalName(parts[1]);
                    eGoal.SetGoalDescription(parts[2]);
                    eGoal.SetPoints(parts[3]);
                    eGoal.SetIsCompleted(parts[4]);
                    eGoal.SetTypeGoal(parts[0]);
                    _goalList.Add(eGoal);
                }
            }
        }
    }

    private void Quit()
    {
        _isRunning = false;
    }
}