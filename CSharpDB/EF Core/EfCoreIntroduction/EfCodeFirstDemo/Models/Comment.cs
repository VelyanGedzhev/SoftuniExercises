using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EfCodeFirstDemo.Models
{
    [Index(nameof(QuestionId), Name = "IX_QuestionID")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Content { get; set; }

        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}
