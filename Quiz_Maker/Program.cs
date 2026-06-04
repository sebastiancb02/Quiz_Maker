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
                
                bool hasCorrectAnswer = false;
                while (true)
                {
                    Answer answer = new Answer();
                    answer.answerText = UI.AskUserToWriteTheTextOfTheAnswers();
                    if (hasCorrectAnswer == false)
                    {
                        answer.correct = UI.AskUserToAssignTrueOrFalse();
                    }
                    
                    if (answer.correct)
                    {
                        hasCorrectAnswer = true;

                        for (int i = 0; i < answerList.Count; i++)
                        {
                            question.answerList[i].correct = false;
                        }
                    }
                    answerList.Add(answer);
                    question.answerList = answerList;

                    if (answerList.Count >= 2)
                    {
                        if (!UI.AskUserIfMoreAnswersAreNeeded())
                        {
                            break;
                        }    
                    } 
                }
                
                if (questionList.Count >= 2)
                {
                    if (!UI.AskUserIfMoreQuestionsAreNeeded())
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
                
                Question question = questionList[rnd.Next(0, questionList.Count)];

                List<Answer> answerList = new List<Answer>();
                
                for (int i = 0; i < question.answerList.Count; i++)
                {
                    Answer answer = question.answerList[i];
                    
                    UI.DisplayBothQuestionAndAnswerOptions(question, i);

                    int userOption = UI.AskUserToChooseOneOfTheOptions(question);
                    
                    Answer pickedAnswer = question.answerList[userOption - 1];
                        
                    int pointCounter = 0;
                    if (pickedAnswer.correct)
                    {
                        UI.ShowUserIfChoosenOptionIsCorrectOrNot(pickedAnswer.correct);
                        pointCounter += 1;
                    }   
                
                    else
                    {
                        UI.ShowUserIfChoosenOptionIsCorrectOrNot(pickedAnswer.correct);
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