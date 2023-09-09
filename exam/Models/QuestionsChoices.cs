using System.ComponentModel.DataAnnotations.Schema;

namespace exam.Models
{
    public class QuestionsChoices
    {
        public int Id { get; set; }
        public bool IsCoreect { get; set; }
        public string Title { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
