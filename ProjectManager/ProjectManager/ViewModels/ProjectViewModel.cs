using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Models;

namespace ProjectManager.ViewModels
{
    public class ProjectViewModel : INotifyPropertyChanged
    {
        public string Title
        {
            get => _project.Title;
            set
            {
                _project.Title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }

        public string Description
        {
            get => _project.Description;
            set
            {
                _project.Description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Description"));
            }
        }

        public DateTime Date
        {
            get => _project.Date;
            set
            {
                _project.Date = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Date"));
            }
        }

        public string Icon
        {
            get => _project.Icon;
            set
            {
                _project.Icon = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Icon"));
            }
        }

        public Project Project => _project;

        private Project _project;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ProjectViewModel(Project project) 
        { 
            _project = project;
        }
    }
}
