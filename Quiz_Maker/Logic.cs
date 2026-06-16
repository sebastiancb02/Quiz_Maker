using System.Xml.Serialization;

namespace Quiz_Maker;
public class Logic
{
    public static readonly XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
    public static void SerializeTheBuiltQuizGame(List<Question> questionList)
    {
        string path = Constants.QUIZ_FILE_PATH;
        using (FileStream file = File.Create(path))
        {
            serializer.Serialize(file, questionList);
        }
    }

    public static List<Question> DeserializeTheBuiltQuizGame()
    {
        string path = Constants.QUIZ_FILE_PATH;
        
        if (File.Exists(path))
        {
            using (FileStream file = File.OpenRead(path))
            {
                return serializer.Deserialize(file) as List<Question>;
            }    
        }

        else
        {
            return new List<Question>();
        }
    }
    
    public static bool CheckIfThereIsAnAnswerAssignedAsTrue (List<Answer> answerList)
    {
        foreach (Answer answer in answerList)
        {
            if (answer.correct)
            {
                return true;
            }
        }

        return false;
    }
    
    public static int CalculatePointCounterValue(bool correct)
    {
        int pointCounter = 0;
        
        if (correct)
        {
            pointCounter += 1;
        }

        else
        {
            pointCounter -= 1;
        }

        return pointCounter;
    }    
}