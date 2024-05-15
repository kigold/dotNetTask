namespace ProgramsAPI.Data.Models
{
    public class PersonalInformation
    {
        public string Question { get; set; } = string.Empty;
        public bool IsMandatory { get; set; }
        public bool IsInternal { get; set; }
        public bool Hide { get; set; }
    }
}
