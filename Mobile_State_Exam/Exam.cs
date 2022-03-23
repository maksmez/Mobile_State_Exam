using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Mobile_State_Exam
{
    public class Exam
    {
        private int Id;
        private string Name_option; //номер варианта вариант№333
        private int Count_correct; //количество правильных
        private int Count_wrong; //количество неправильных
        private int Total_score; //общая оценка в процентах (количество правильных / общее *100)
        private int? Science_Id;
        [ForeignKey("Science_Id")]
        private Science Science;
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
        public string name_option
        {
            get { return Name_option; }
            set
            {
                if (Name_option != value)
                {
                    Name_option = value;
                }
            }
        }
        public int count_correct
        {
            get { return Count_correct; }
            set
            {
                if (Count_correct != value)
                {
                    Count_correct = value;
                }
            }
        }
        public int count_wrong
        {
            get { return Count_wrong; }
            set
            {
                if (Count_wrong != value)
                {
                    Count_wrong = value;
                }
            }
        }
        public int total_score
        {
            get { return Total_score; }
            set
            {
                if (Total_score != value)
                {
                    Total_score = value;
                }
            }
        }
        public int? science_Id
        {
            get { return Science_Id; }
            set
            {
                if (Science_Id != value)
                {
                    Science_Id = value;
                }
            }
        }
        public Science science
        {
            get { return Science; }
            set
            {
                if (Science != value)
                {
                    Science = value;
                }
            }
        }

        public ObservableCollection<Exam> LoadData(int id_science)
        {
            ObservableCollection<Exam> exam_list = new ObservableCollection<Exam>();
            using (Context cont = new Context())
            {
                foreach (var item in cont.Exam.Where(x => x.science_Id == id_science).ToList().OrderBy(x => x.name_option))
                {
                    exam_list.Add(item);
                }
            }
            return exam_list;
        }

    }
}
