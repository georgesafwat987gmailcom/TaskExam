using System.ComponentModel.DataAnnotations.Schema;

namespace exam.Models
{
    public class Exams
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float FainalDegree { get; set; } //= Questions.Sum(x => x.Degree);
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public TimeOnly Duration { get; set; }
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public IEnumerable<Question> Questions { get; set; }

    }
}
