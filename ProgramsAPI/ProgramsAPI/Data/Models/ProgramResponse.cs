using System.ComponentModel.DataAnnotations;

namespace ProgramsAPI.Data.Models
{
    public class ProgramResponse
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProgramId { get; set; }
        public ICollection<Response> Responses { get; set; } = new List<Response>();
    }
}
