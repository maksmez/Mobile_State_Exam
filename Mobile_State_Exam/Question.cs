using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Mobile_State_Exam
{
    public class Question
    {
        private int Id;
        private string Description;
        private string Answer;
        private int? Theme_ID;
        [ForeignKey("Theme_ID")]
        private Theme Theme;


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
        public string description
        {
            get { return Description; }
            set
            {
                if (Description != value)
                {
                    Description = value;
                }
            }
        }
        public string answer
        {
            get { return Answer; }
            set
            {
                if (Answer != value)
                {
                    Answer = value;
                }
            }
        }
        public int? theme_ID
        {
            get { return Theme_ID; }
            set
            {
                if (Theme_ID != value)
                {
                    Theme_ID = value;
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
        public Question LoadData(int id_theme)
        {
            ObservableCollection<Question> question_list = new ObservableCollection<Question>();
            using (Context cont = new Context())
            {
                foreach (var item in cont.Question.Where(x => x.theme_ID == id_theme).ToList())
                {
                    question_list.Add(item);
                }
            }
            Question question = question_list[new Random().Next(0, question_list.Count)];
            return question;
        }
    }

}
