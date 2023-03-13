using Assignment6.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Assignment6.ViewModels
{
    public class PeopleViewModel:INotifyPropertyChanged
    {
        //// Bindable properties

        private string _name;

        public string Name
        {
            get => _name;
            private set
            {
                _name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        private string _age;

        public string Age
        {
            get => _age;
            private set
            {
                _age = value;
                NotifyPropertyChanged(nameof(Age));
            }
        }

        public ICommand Previous { get; }

        public ICommand Next { get; }

        //// Implementation

        private PersonModel[] people = new PersonModel[] {
        new PersonModel("Alice", 20),
        new PersonModel("Bob", 25),
        new PersonModel("Charlie", 30)
    };

        private int index = 0;

        public PeopleViewModel()
        {
            Name = people[index].Name;
            Age = people[index].Age.ToString();

            Previous = new RelayCommand(() =>
            {
                if (index > 0)
                {
                    index--;
                    Name = people[index].Name;
                    Age = people[index].Age.ToString();
                }
            });

            Next = new RelayCommand(() =>
            {
                if (index < people.Length - 1)
                {
                    index++;
                    Name = people[index].Name;
                    Age = people[index].Age.ToString();
                }
            });
        }

        //// Boilerplate code to satisfy INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged is null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
