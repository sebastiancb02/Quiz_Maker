namespace Quiz_Maker;

public class Logic
{
    public static void SerializeTheBuiltQuizGame(List<Question> questionList)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Question>));
        serializer.Serialize(Console.Out, questionList);

        var path = @"/Users/sebastiancoparabackevall/RiderProjects/Quiz_Maker/Quiz_Maker";
        using (FileStream file = File.Create(path))
        {
            serializer.Serialize(file, questionList);
        }    
    }

    public static void DeserializeTheBuiltQuizGame(List<Question> questionList)
    {
        
    }
}