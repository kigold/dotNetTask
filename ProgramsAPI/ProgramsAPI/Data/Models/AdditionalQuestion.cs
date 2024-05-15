using ProgramsAPI.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProgramsAPI.Data.Models
{
    public class AdditionalQuestion
    {
        [Key]
        public Guid Id { get; set; }
        public string Question { get; set; } = string.Empty;
        public QuestionType QuestionType { get; set; }
        public ICollection<Choice> Choices { get; set; } = new List<Choice>();
    }
}
