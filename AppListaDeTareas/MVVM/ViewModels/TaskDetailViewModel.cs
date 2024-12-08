using AppListaDeTareas.MVVM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppListaDeTareas.MVVM.ViewModels
{
    class TaskDetailViewModel : INotifyPropertyChanged
    {
        private TaskModel _selectedTask;
        // La propiedad SelectedTask es la tarea que vamos a editar
        public TaskModel SelectedTask
        {
            get => _selectedTask;
            set
            {
                if (_selectedTask != value)
                {
                    _selectedTask = value;
                    OnPropertyChanged(nameof(SelectedTask));
                }
            }
        }
        // Constructor para recibir la tarea
        public TaskDetailViewModel(TaskModel task)
        {
            SelectedTask = task;
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
