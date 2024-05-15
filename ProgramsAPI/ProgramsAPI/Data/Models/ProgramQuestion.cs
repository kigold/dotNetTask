using ProgramsAPI.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProgramsAPI.Data.Models
{
    public class ProgramQuestion
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<PersonalInformation> PersonalInformation { get; set; } = new List<PersonalInformation>();
        public ICollection<AdditionalQuestion> AdditionalQuestions { get; set; } = new List<AdditionalQuestion>();
    }
}
