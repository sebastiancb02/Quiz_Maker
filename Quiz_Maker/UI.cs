namespace Quiz_Maker;

public class UI
{
    public static char AllowUserToChooseGameMode()
    {
        Console.WriteLine("\nWelcome! You can choose between 2 modes:");
        Console.WriteLine("\nPress 1 if you want to build your own quiz");
        Console.WriteLine("Press 2 if you want to play a quiz game");

        return Console.ReadKey(true).KeyChar;
        Console.WriteLine();
    }

    public static int ValidateUserInput(char input)
    {
        while (true)
        {    
            string userInputAsString = input.ToString();
            int userInput;

            bool valid = int.TryParse(userInputAsString, out userInput);
                
            if (!valid)
            {
                Console.WriteLine("\nInvalid Input"); 
                input = Console.ReadKey(true).KeyChar;
                continue;
            }

            if (userInput < 1 || userInput > 2) 
            {
                Console.WriteLine("\nPlease, make sure to choose either 1 or 2"); 
                input = Console.ReadKey(true).KeyChar;
                continue;
            }
                
            return userInput;
        }
    }
    //Mode 1
    public static string AskUserToWriteAQuestion(List<Question> questionList)
    {
        if (questionList.Count >= 1)
            Console.Clear();
        
        Console.WriteLine("\nPlease write your question + Hit ENTER:");
        return Console.ReadLine();
    }
    
    public static string AskUserToWriteTheTextOfTheAnswers()
    {
        Console.WriteLine("\nWrite an answer + Hit Enter:");
        return Console.ReadLine();
    }

    public static bool AskUserToAssignTrueOrFalse()
    {
        Console.WriteLine("\nIs this answer true or false?");
        Console.WriteLine("Press 'T' if true");
        Console.WriteLine("Press 'F' if false");
        
        while (true)
        {
            char userOption = Console.ReadKey(true).KeyChar;
            
            if (userOption == 'T' || userOption == 't')
                return true;
        
            if (userOption == 'F' || userOption == 'f')
                return false;
            
            Console.WriteLine("\nPlease, make sure to input a valid character"); 
        }
        
        return true;
    }

    public static bool AskUserIfMoreAnswersAreNeeded()
    {
        Console.WriteLine("\nDo you want to keep adding answers to this question? (y/n)");

        while (true)
        {
            char userOption = Console.ReadKey(true).KeyChar;
            
            if (userOption == 'y' || userOption == 'Y')
                return true;
        
            if (userOption == 'n' || userOption == 'N')
                return false;
            
            Console.WriteLine("\nPlease, make sure to input a valid character"); 
        }
        
        return true;
    }

    public static bool AskUserIfMoreQuestionsAreNeeded()
    {
        Console.WriteLine("\nDo you want to keep adding more questions? (y/n)");
        while (true)
        {
            char userOption = Console.ReadKey(true).KeyChar;
            
            if (userOption == 'y' || userOption == 'Y')
                return true;
        
            if (userOption == 'n' || userOption == 'N')
                return false;

            Console.WriteLine("\nPlease, make sure to input a valid character"); 
        }
        
        return true;
    }
    
    //Mode 2
    public static void ShowMessageIfQuestionListIsEmpty()
    {
        Console.WriteLine("\nQuestion list is empty, therefore this mode is not playable :(");
    }

    public static void ShowMessageIfThereAreNoQuestionsLeft()
    {
        Console.Clear();
        Console.WriteLine("\nThere are no more questions left to play with. Thank you for playing!");
    }    
    
    public static bool AskUserIfWantToContinueGame()
    {
        Console.WriteLine("\nWould you like to keep playing? (y/n)");
        
        while (true)
        {
            char userOption = Console.ReadKey(true).KeyChar;
            
            if (userOption == 'y' || userOption == 'Y')
                return true;
        
            if (userOption == 'n' || userOption == 'N')
                return false;

            Console.WriteLine("\nPlease, make sure to input a valid character"); 
        }
        
        return true;
    }

    public static int AskUserToChooseOneOfTheOptions(Question question)
    {
        while (true)
        {    
            char input = Console.ReadKey(true).KeyChar;
            string userInputAsString = input.ToString();
            int userInput;

            bool valid = int.TryParse(userInputAsString, out userInput);
                
            if (!valid)
            {
                Console.WriteLine("\nInvalid Input"); 
                input = Console.ReadKey(true).KeyChar;
                continue;
            }
            
            if (userInput < 1 || userInput > question.answerList.Count) 
            {
                Console.WriteLine("\nYour chosen option is not valid, pick another one"); 
                input = Console.ReadKey(true).KeyChar;
                continue;
            }
                
            return userInput;
        }
    }

    public static void DisplayQuestions(Question question)
    {
        Console.Clear();
        Console.WriteLine("\n" + question.questionText); 
    }
    
    public static void DisplayAnswerOptions(Question question, int i)
    {
        Console.WriteLine($"{i + 1}." + question.answerList[i].answerText);
    }

    public static void ShowUserIfChoosenOptionIsCorrectOrNot(bool correct)
    {
        if (correct)
        {
            Console.WriteLine("\nYour answer is correct!");    
        }    

        else
        {
            Console.WriteLine("\nIncorrect answer :,(");    
        }
    }

    public static void DisplayTheFinalCounter(int pointCounter)
    {
        Console.WriteLine($"The final counter is {pointCounter}");
    }
}