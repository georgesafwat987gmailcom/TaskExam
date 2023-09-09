using System.ComponentModel.DataAnnotations.Schema;

namespace exam.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public QuestionType Type { get; set; }
        public QuestionAnswer Answer { get; set; }
        public float Degree { get; set; }

        [ForeignKey("Exams")]
        public int ExamsId { get; set; }
        public Exams Exams { get; set; }
        public List<QuestionsChoices> QuestionsChoices { get; set; }
    }
}
