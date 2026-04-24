namespace Quiz_Maker;

public class UI
{
    public static void IntroText()
    {
        Console.WriteLine("Welcome! Today you're going to make your own Quiz :)");
    }
    
    public static string AskUserToWriteAQuestion()
    {
        Console.WriteLine("Please write your question");
        return Console.ReadLine();
    }
    
    public static string AskUserToWritePossibleAnswers()
    {
        Console.WriteLine("Please write as many possible answers as you want");
        return Console.ReadLine();
    }    
}