using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Journal Program!");
        Journal journal = new Journal();
        JournalEntry entry = new JournalEntry();

        bool start = journal._isWork;

        while (start)
        {
            journal.ShowMenu();
            journal.SetChoice();

            start = journal._isWork;
        }

        
        /*
        What are good candidates for classes in this program?

        Journal (Write, Display, Load, Save) - make main work.
        JournalEntry (prompt, respond, date) - work with entry. Storing information and saving it in a file.
        PromptGenerator


        What are the behaviors this class will have in order to fulfill its responsibilities?

        Journal Class:
            Adding an entry
            Displaying all the entries
            Saving to a file
            Loading from a file
        
        JournalEntry:
            prompt
            respond 
            date
        

        What attributes does this class need to fulfill its behaviors?
        
        Journal should have List<Entry>
        JournalEntry should store current date, the question, the respond
        PromptGenerator stores List<Question>

        
        */
    }
}