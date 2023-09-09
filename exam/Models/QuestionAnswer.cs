using System.ComponentModel.DataAnnotations.Schema;

namespace exam.Models
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public string Answer { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
