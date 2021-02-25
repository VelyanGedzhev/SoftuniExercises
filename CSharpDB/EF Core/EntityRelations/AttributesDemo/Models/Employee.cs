using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AttributesDemo.Models
{
    //[Table("People", Schema = "company")]
    [Index("FirstName", "Salary")]
    public class Employee
    {
        [Key]
        public int EID { get; set; }

        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        [Column("Started On", TypeName = "date")]
        public DateTime? StartWorkDate { get; set; }

        public decimal Salary { get; set; }

        //Optional
        public int DepId { get; set; }

        //Required
        [ForeignKey(nameof(DepId))]
        [InverseProperty("Employees")] //optional
        public Department Department { get; set; }
    }
}
