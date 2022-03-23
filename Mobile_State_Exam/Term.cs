using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.ObjectModel;
using System.Linq;

namespace Mobile_State_Exam
{
    public class Term
    {
        private int Id;
        private string Name; //название термина
        private string Description; //описание термина
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

        public ObservableCollection<Term> LoadData(int id_science)
        {
            ObservableCollection<Term> term_list = new ObservableCollection<Term>();
            using (Context cont = new Context())
            {
                foreach (var item in cont.Term.Where(x => x.science_Id == id_science).ToList().OrderBy(x => x.name))
                {
                    term_list.Add(item);
                }
            }
            return term_list;
        }

        public ObservableCollection<Term> Search(string text, int b)
        {
            ObservableCollection<Term> search_list = new ObservableCollection<Term>();
            using (Context cont = new Context())
            {
                string lower = text.ToLower();
                foreach (var item in cont.Term.Where(x => x.science_Id == b).ToList().OrderBy(x => x.name))
                {
                    string a = item.name.ToLower();
                    if (a.Contains(lower))
                    {
                        search_list.Add(item);
                    }
                }
                return search_list;
            }
        }
    }
}
