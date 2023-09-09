using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace exam.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Grade { get; set; }
        [ForeignKey("IdentityUser")]
        public int UserId { get; set; }
        public IdentityUser User { get; set; }

    }
}
