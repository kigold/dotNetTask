﻿using System.ComponentModel.DataAnnotations;

namespace ProgramsAPI.Data.Models
{
    public class ProgramData
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProgramId { get; set; }
        public Guid QuestionId { get; set; }
        public string Response {  get; set; } = string.Empty;
        public string[] MultipleResponse { get; set; } = new string[0];
    }
}