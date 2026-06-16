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
                
                bool questionHasOneCorrectAnswer = false;
                while (true)
                {
                    questionHasOneCorrectAnswer = Logic.CheckIfThereIsAnAnswerAssignedAsTrue(answerList);
                    answerList.Add(UI.PrepareAnswer(questionHasOneCorrectAnswer));
                    
                    if (answerList.Count >= Constants.TWO_QUESTIONS_IN_QUESTION_LIST)
                    {
                        if (!UI.AskUserIfMoreAnswersAreNeeded())
                        {
                            break;
                        }    
                    } 
                }
                
                question.answerList = answerList;
                
                if (questionList.Count >= Constants.TWO_QUESTIONS_IN_QUESTION_LIST)
                {
                    if (!UI.AskUserIfMoreQuestionsAreNeeded())
                        break;
                }
            }
            
            Logic.SerializeTheBuiltQuizGame(questionList);
        }

        if (modeOption == Constants.PLAY_QUIZ_MODE)
        {
            List<Question> questionList = new List<Question>();
            questionList = Logic.DeserializeTheBuiltQuizGame();
            
            
            if (questionList.Count == Constants.EMPTY_LIST)
            {
                UI.ShowMessageIfQuestionListIsEmpty();
            }

            else
            {
                int pointCounter = 0;
                Random rnd = new Random();
                while (true)
                {
                    if (questionList.Count == Constants.EMPTY_LIST)
                    {
                        UI.ShowMessageIfThereAreNoQuestionsLeft();
                        break;
                    }

                    int randomIndex = rnd.Next(Constants.FIRST_QUESTION_IN_THE_LIST, questionList.Count);
                    Question question = questionList[randomIndex];
                    questionList.RemoveAt(randomIndex);
                    
                    UI.DisplayQuestions(question);
                    
                    for (int i = 0; i < question.answerList.Count; i++)
                    {
                        Answer answer = question.answerList[i];
                        UI.DisplayAnswerOptions(answer, i);
                    }
                    
                    int userOption = UI.AskUserToChooseOneOfTheOptions(question);
                        
                    Answer pickedAnswer = question.answerList[userOption - 1];
                    
                    UI.ShowUserIfChoosenOptionIsCorrectOrNot(pickedAnswer.correct); 
                    pointCounter += Logic.CalculatePointCounterValue(pickedAnswer.correct);

                    if (questionList.Count == Constants.EMPTY_LIST)
                    {
                        UI.DisplayTheFinalCounter(pointCounter);
                        break;
                    }
                }
            }
        }    
    }
}