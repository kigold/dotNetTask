using ProgramsAPI.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProgramsAPI.Data.Models
{
    public class ProgramInformation
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<PersonalInformation> PersonalInformation { get; set; } = new PersonalInformation[0];
        public ICollection<AdditionalQuestion> AdditionalQuestions { get; set; } = new AdditionalQuestion[0];
    }
}
