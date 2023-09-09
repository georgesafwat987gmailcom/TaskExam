using exam.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace exam.ModelView
{
    public class QuestionModelView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public QuestionType Type { get; set; }
        public string Answer { get; set; }
        public float Degree { get; set; }
        public int ExamsId { get; set; }
        public IEnumerable<QuestionsChoices> QuestionsChoices { get; set; }
    }
}
