using System.ComponentModel.DataAnnotations.Schema;

namespace exam.Models
{
    public class UserAnswer
    {
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
