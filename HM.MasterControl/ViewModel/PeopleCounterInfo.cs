using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM.MasterControl.ViewModel
{
    public class PeopleCounterInfo : INotifyPropertyChanged
    {
        private string _id;

        public String ID
        {
            get { return _id; }
            set
            {
                _id = value; OnPropertyChange("ID");
            }
        }

        private string _name;
        public String Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChange("Name");
            }
        }

        private int _sex;
        public int Sex
        {
            get { return _sex; }
            set { _sex = value; OnPropertyChange("Sex"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChange(String prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }


    }
}
