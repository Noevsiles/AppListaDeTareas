using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeTareas.MVVM.Models
{
    public class TaskModel : INotifyPropertyChanged
    {
        //TaskModel (modelo de tarea) representa una tarea con dos propiedades (el nombre y si esta completada) 
        //Se introduce el INotifyPropertyChanged  para notificar a la vista en el momento en el que cambien las propiedades

        private string _name;
        private bool _isCompleted;

        public string Name
        {
            get => _name;

            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        public bool IsCompleted
        {
            get => _isCompleted;
            set
            {
                if (_isCompleted != value)
                {
                    _isCompleted = value;
                    OnPropertyChanged(nameof(IsCompleted));
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
