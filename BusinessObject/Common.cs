
using System.Collections.Generic;
namespace BusinessObject
{
    public class Common
    {
        public static List<Answer> GetAnswers()
        {
            List<Answer> list = new List<Answer>
            {
                new Answer() { Id = 1, Name = "Excellent", Css = "" },
                new Answer() { Id = 2, Name = "Very Good", Css = "" },
                new Answer() { Id = 3, Name = "Good", Css = "" },
                new Answer() { Id = 4, Name = "Neutral", Css = "" },
                new Answer() { Id = 5, Name = "Poor", Css = "" }
            };
            return list;
        }
    }
}
