using System.IO;

public class Journal
{
    public bool _isWork = true;
    public int _choice = 0;
    
    JournalEntry entry = new JournalEntry();
    PromptGenerator prompt = new PromptGenerator();

    public void ShowMenu()
    {
        Console.WriteLine("Please select one of the following choices:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.WriteLine("What do you like to do?");
    }

    public void SetChoice()
    {
        this._choice = int.Parse(Console.ReadLine());

        if (this._choice == 5)
        {
            this.Quit();
        }
        else if (this._choice == 4)
        {
            this.SaveIntoFile();
        }
        else if (this._choice == 3)
        {
            this.LoadFile();
        }
        else if (this._choice == 2)
        {
            this.Display();
        }
        else if (this._choice == 1)
        {
            this.Write();
        }
        else
        {
            Console.WriteLine("Wrong answer!");
        }
    }

    public void Write() // 1
    {

        prompt.DisplayPrompt();
        entry.SetLastPrompt(prompt._lastPrompt);
        entry.CreateEntry();
    }

    public void Display() // 2
    {
        if (entry._curEntry == "")
        {
            Console.WriteLine("Your Journal is empty.");
        }
        else 
        {
            Console.WriteLine(entry._curEntry);
        }
    }

    public void LoadFile() // 3
    {
        Console.WriteLine("What is the name of your file?");
        string fileName = Console.ReadLine();

        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            if (line != "")
            {
                entry.SetEntry($"{line}\n");
            } 
        }
    }

    public void SaveIntoFile() // 4
    {
        Console.WriteLine("What is the name of your file?");
        string fileName = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(entry._curEntry);
        }
    }

    public void Quit() // 5
    {
        this._isWork = false;
    }

}