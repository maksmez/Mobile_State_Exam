using System.Collections.ObjectModel;
using System.Linq;

namespace Mobile_State_Exam
{
    public class Science
    {
        private int Id;
        private string Name;


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
        public ObservableCollection<Science> LoadData()
        {
            using (Context cont = new Context())
            {
                ObservableCollection<Science> science_list = new ObservableCollection<Science>();
                foreach (var item in cont.Science.AsEnumerable())
                {
                    science_list.Add(item);
                }
                return science_list;
            }
        }
    }
}
