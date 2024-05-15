namespace ProgramsAPI.Data.Models
{
    public class Response
    {
        public Guid QuestionId { get; set; }
        public string Answer { get; set; } = string.Empty;
        public ICollection<Choice> MultipleChoice { get; set; } = new List<Choice>();
    }
}
