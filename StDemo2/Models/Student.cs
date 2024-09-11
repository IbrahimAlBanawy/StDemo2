using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StDemo2.Models
{
    public class Student
    {
        
        public int Id { get; set; }
        [Required]
        [StringLength(15,MinimumLength = 3)]
        public string Name { get; set; }
        [Range(10,20)]
        public int Age { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z0-9_]+@[a-zA-Z]+.[a-zA-Z]{2,4}")]
        
        public string Email { get; set; }
        [Required,StringLength(15)]
        [DataType(DataType.Password)]
        public string Password {  get; set; }
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("Password")]
        
        public string CPassword { get; set; }

        [ForeignKey("Department")]
        public int DeptNo { get; set; }

        public virtual Department Department { get; set; }
        public override string ToString()
        {
            return $"{Id}:{Name}:{Age}:{DeptNo}";
        }
    }
}
