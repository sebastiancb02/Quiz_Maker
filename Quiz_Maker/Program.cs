namespace Quiz_Maker;

class Program
{
    static void Main(string[] args)
    {
        UI.IntroText();

        for (int i = 0; i < 4; i++)
        {
            Question.questionText = UI.AskUserToWriteAQuestion();
        }    
    }
}