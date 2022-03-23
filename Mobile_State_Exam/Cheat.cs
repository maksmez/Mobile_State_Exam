using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Mobile_State_Exam
{
    public class Cheat
    {
        private int Id;
        private string Name; //название темы шпаргалки
        private string Path; //путь до html страницы
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
        public string path
        {
            get { return Path; }
            set
            {
                if (Path != value)
                {
                    Path = value;
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
        public ObservableCollection<Cheat> LoadData(int id_science)
        {
            ObservableCollection<Cheat> list_cheat = new ObservableCollection<Cheat>();
            using (Context cont = new Context())
            {
                foreach (var item in cont.Cheat.Where(x => x.science_Id == id_science).ToList().OrderBy(x => x.name))
                {
                    list_cheat.Add(item);
                }
            }
            return list_cheat;
        }
    }
}
