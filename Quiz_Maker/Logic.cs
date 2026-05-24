using System.Xml.Serialization;

namespace Quiz_Maker;
public class Logic
{
    public static void SerializeTheBuiltQuizGame(List<Question> questionList)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));

        string path = Constants.QUIZ_FILE_PATH;
        using (FileStream file = File.Create(path))
        {
            serializer.Serialize(file, questionList);
        }
    }

    public static List<Question> DeserializeTheBuiltQuizGame()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
        string path = Constants.QUIZ_FILE_PATH;
        string curFile = Constants.QUIZ_FILE_PATH;
        
        if (File.Exists(curFile))
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
}