namespace Quiz_Maker;

class Program
{
    static void Main(string[] args)
    {
        int modeOption = UI.ValidateUserInput(UI.AllowUserToChooseGameMode());
        
        if (modeOption == Constants.BUILD_YOUR_QUIZ_MODE)
        {    
            List<Question> questionList = new List<Question>();
            
            while(true) 
            {
                Question question = new Question();
                question.questionText = UI.AskUserToWriteAQuestion(questionList);
                questionList.Add(question);
                
                List<Answer> answerList = new List<Answer>();
                Answer answer = new Answer();
                
                while (true)
                {
                    answer.answerText = UI.AskUserToWriteTheTextOfTheAnswers();
                    answer.correct = UI.AskUserToAssignTrueOrFalse();
                    answerList.Add(answer);
                    question.answerList = answerList;//Is this correct????

                    if (UI.AskUserIfMoreAnswersAreNeeded() == false)
                        break;
                }
                
                if (questionList.Count > 2)
                {
                    if (UI.AskUserIfMoreQuestionsAreNeeded() == false)
                        break;
                }
            }
            
            Logic.SerializeTheBuiltQuizGame(questionList);
        }

        if (modeOption == Constants.PLAY_QUIZ_MODE)
        {
            bool keepPlaying = true;
            while (keepPlaying)
            {
                List<Question> questionList = new List<Question>();
                questionList = Logic.DeserializeTheBuiltQuizGame();

                if (questionList.Count == 0)
                {
                    UI.ShowMessageIfQuestionListIsEmpty();
                    break;
                }

                Random rnd = new Random();
                
                Question question = questionList[rnd.Next(1, questionList.Count)];

                List<Answer> answerList = new List<Answer>();
                
                for (int i = 0; i < question.answerList.Count; i++)
                {
                    Answer answer = question.answerList[i];
                    
                    //Create method for the 2 lines below
                    Console.WriteLine(question.questionText);
                    Console.WriteLine($"{i}." + question.answerList);

                    int userOption = UI.AskUserToChooseOneOfTheOptions(question);
                    
                    Answer pickedAnswer = question.answerList[userOption - 1];
                        
                    int pointCounter = 0;
                    if (pickedAnswer.correct)
                    {
                        Console.WriteLine("Good boy");
                        pointCounter += 1;
                    }   
                
                    else 
                    { 
                        Console.WriteLine("Bad boy"); 
                        pointCounter -= 1;
                    }    
                       
                }

                if (!UI.AskUserIfWantToContinueGame())
                {
                    keepPlaying = false;
                    break;
                }
            }
        }    
    }
}