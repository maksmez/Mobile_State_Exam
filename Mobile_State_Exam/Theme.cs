using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Mobile_State_Exam
{
    public class Theme
    {
        private int Id;
        private string Name;
        private string Theory;
        private int Count_correct;
        private int Count_wrong;
        private int Total_score;
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
        public string name
        {
            get { return Name; }
            set
            {
                if (Name != value)
                {
                    Name = value;
                }
            }
        }
        public string theory
        {
            get { return Theory; }
            set
            {
                if (Theory != value)
                {
                    Theory = value;
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

        public ObservableCollection<Theme> LoadData(int id_science)
        {
            ObservableCollection<Theme> theme_list = new ObservableCollection<Theme>();
            using (Context cont = new Context())
            {
                foreach (var item in cont.Theme.Where(x => x.science_Id == id_science).ToList().OrderBy(x => x.name))
                {
                    theme_list.Add(item);
                }
            }
            return theme_list;
        }
        public void SaveData(Theme theme)
        {
            using (Context db = new Context())
            {
                if (db.Theme.Any(x => x.id == theme.id))
                {
                    var p = db.Theme.First(x => x.id == theme.id);
                    p.count_correct = theme.count_correct;
                    p.count_wrong = theme.count_wrong;
                    p.total_score = theme.total_score;
                    db.SaveChanges();
                }

            }
        }
    }

}
