namespace Quiz_Maker;

class Program
{
    static void Main(string[] args)
    {
        UI.MenuText();

        while(true)
        {
            Question question = new Question();
            question.questionText = UI.AskUserToWriteAQuestion();
            
            List<Answer> answers = new List<Answer>();
            Answer answer = new Answer();
            
            while (true)
            {
                answer.answerText = UI.AskUserToWriteTheTextOfTheAnswers();
                answer.correct = UI.AskUserToAssignTrueOrFalse();
                answers.Add(answer);
                question.answers = answers;

                if (UI.AskUserIfMoreAnswersAreNeeded() == false)
                {
                    break;
                }
            }
        }    
    }
}