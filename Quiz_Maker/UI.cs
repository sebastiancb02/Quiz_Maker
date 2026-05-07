namespace Quiz_Maker;

public class UI
{
    public static char MenuText()
    {
        Console.WriteLine("Welcome! Choose between 2 modes:");
        Console.WriteLine("Press 1 if you want to build your own quiz");
        Console.WriteLine("Press 2 if you want to play a quiz game");

        char modeOption = Console.ReadKey().KeyChar;
        
        if (modeOption == '1')
            return '1';  
        
        if (modeOption == '2')
            return '2';
        
        return modeOption;
    }
    
    public static string AskUserToWriteAQuestion()
    {
        Console.WriteLine("\nPlease write your question");
        return Console.ReadLine();
    }
    
    public static string AskUserToWriteTheTextOfTheAnswers()
    {
        Console.WriteLine("\nPlease write as many possible answers as you want");
        return Console.ReadLine();
    }

    public static bool AskUserToAssignTrueOrFalse()
    {
        Console.WriteLine("\nIs this answer true or false?");
        Console.WriteLine("Press 'T' if true");
        Console.WriteLine("Press 'F' if false");
        char userOption = Console.ReadKey(true).KeyChar;
        
        if (userOption == 'T' || userOption == 't')
            return true;
        
        if (userOption == 'F' || userOption == 'f')
            return false;
        
        return true;
    }

    public static bool AskUserIfMoreAnswersAreNeeded()
    {
        Console.WriteLine("\nDo you want to keep adding answers to this question? (y/n)");
        Console.WriteLine();
        char userOption = Console.ReadKey().KeyChar;

        if (userOption == 'y' || userOption == 'Y')
            return true;
        
        if (userOption == 'n' || userOption == 'N')
            return false;
        
        return true;
    }
}