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
                
                List<Answer> answers = new List<Answer>();
                Answer answer = new Answer();
                
                while (true)
                {
                    answer.answerText = UI.AskUserToWriteTheTextOfTheAnswers();
                    answer.correct = UI.AskUserToAssignTrueOrFalse();
                    answers.Add(answer);
                    question.answers = answers;

                    if (UI.AskUserIfMoreAnswersAreNeeded() == false)
                        break;
                }
                
                if (questionList.Count > 3)
                {
                    if (UI.AskUserIfMoreQuestionsAreNeeded() == false)
                        break;
                }
            }
            
            Logic.SerializeTheBuiltQuizGame(questionList);
        }

        if (modeOption == Constants.PLAY_QUIZ_MODE)
        {
                
        }    
    }
}