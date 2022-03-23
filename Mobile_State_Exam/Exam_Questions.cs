using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Mobile_State_Exam
{
    public class Exam_Questions
    {
        private int Id;
        private int Number; //номер вопроса в егэ вопрос№1(темы №1, №2, №4)
        private int? Theme_Id;
        [ForeignKey("Theme_Id")]
        private Theme Theme;
        private int? Exam_Id;
        [ForeignKey("Exam_Id")]
        private Exam Exam;
        private int? Question_Id;
        [ForeignKey("Question_Id")]
        private Question Question;


        public int id
        {
            get { return Id; }
            set
            {
                if (Id != value)
                {
                    Id = value;
                }
            }
        }
        public int number
        {
            get { return Number; }
            set
            {
                if (Number != value)
                {
                    Number = value;
                }
            }
        }
        public int? theme_Id
        {
            get { return Theme_Id; }
            set
            {
                if (Theme_Id != value)
                {
                    Theme_Id = value;
                }
            }
        }
        public Theme theme
        {
            get { return Theme; }
            set
            {
                if (Theme != value)
                {
                    Theme = value;
                }
            }
        }
        public int? exam_Id
        {
            get { return Exam_Id; }
            set
            {
                if (Exam_Id != value)
                {
                    Exam_Id = value;
                }
            }
        }
        public Exam exam
        {
            get { return Exam; }
            set
            {
                if (Exam != value)
                {
                    Exam = value;
                }
            }
        }
        public int? question_Id
        {
            get { return Question_Id; }
            set
            {
                if (Question_Id != value)
                {
                    Question_Id = value;
                }
            }
        }
        public Question question
        {
            get { return Question; }
            set
            {
                if (Question != value)
                {
                    Question = value;
                }
            }
        }
        public ObservableCollection<Question> LoadExamQuestion(int exam_id)
        {
            ObservableCollection<Question> quest_list = new ObservableCollection<Question>();
            using (Context cont = new Context())
            {
                var ex = cont.Exam_Questions.Where(x => x.exam_Id == exam_id);
                var res = ex.Join(cont.Question, p => p.question_Id, c => c.id, (p, c) => new Question { description = c.description, answer = c.answer }).ToList();
                foreach (var item in res)
                {
                    quest_list.Add(item);
                }
            }
            return quest_list;
        }
        public void SaveData(Exam exam)
        {
            using (Context db = new Context())
            {
                if (db.Exam.Any(x => x.id == exam.id))
                {
                    var p = db.Exam.First(x => x.id == exam.id);
                    p.count_correct = exam.count_correct;
                    p.count_wrong = exam.count_wrong;
                    p.total_score = exam.total_score;
                    db.SaveChanges();
                }

            }
        }
    }
}
