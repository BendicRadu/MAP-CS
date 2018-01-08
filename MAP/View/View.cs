using MAP.Controller;
using MAP.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAP.View
{ 
   class TextMenu
   {
        private Dictionary<string, Command> commands;
        public TextMenu() { commands = new Dictionary<string, Command>(); }
        public void addCommand(Command c)
        {
            commands.Add(c.getKey(), c);
        }

        private void printMenu()
        {
        foreach (Command com in commands.Values)
        {
            string line = string.Format("{0} : {1} \n", com.getKey(), com.getDescription());
            Console.Write(line);
        }
    }

    public void show()
    {
        
        while (true)
        {
            printMenu();
            Console.Write("Input the option: ");
                
            string key = Console.ReadLine();

            try
            {
                Command com = commands[key];
                if (com == null)
                {
                    throw new Exception("Invalid option \n");
                }
                com.execute();
            }
            catch (KeyNotFoundException )
            {
                Console.Write("Invalid Option \n");
            }
        }
    }
}


public abstract class Command
{
    private string key, description;
    public Command(string key, string description) { this.key = key; this.description = description; }
    public abstract void execute();
    public string getKey() { return key; }
    public string getDescription() { return description; }
}

public class ExitCommand : Command
    {

        public ExitCommand(string key, string desc) : base(key, desc) { }
        
        public override void execute()
        {
            throw new EndException("Done");
        }
    }
    
public class RunExample : Command
{

    Ctrl ctr;
    
    public RunExample(string key, string desc, Ctrl ctr) : base(key, desc)
    {
        this.ctr = ctr;
    }

    
    public override void execute()
    {

        Console.Write("Input file name: ");
        string fileName = Console.ReadLine();
        ctr.setLogFile(fileName);
        
        try
        {
            ctr.allStep();
        }
        catch (Exception e) {
                Console.Write(e.Message + "\n");
        }      
        }
        }
}