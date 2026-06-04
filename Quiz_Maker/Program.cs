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
                    else
                    {
                        answer.correct = false;
                        hasCorrectAnswer = true;
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
            Random rnd = new Random();
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
                
                Question question = questionList[rnd.Next(0, questionList.Count)];
                
                UI.DisplayQuestions(question);
                
                for (int i = 0; i < question.answerList.Count; i++)
                {
                    Answer answer = question.answerList[i];
                    UI.DisplayAnswerOptions(question, i);
                }
                
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
                

                if (!UI.AskUserIfWantToContinueGame())
                {
                    keepPlaying = false;
                    break;
                }
            }
        }    
    }
}