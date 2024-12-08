using AppListaDeTareas.MVVM.Models;
using AppListaDeTareas.MVVM.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;


namespace AppListaDeTareas.MVVM.ViewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        // ObservableCollection para las tareas
        public ObservableCollection<TaskModel> Tasks { get; set; } = new ObservableCollection<TaskModel>();

        private TaskModel _selectedTask;
        public TaskModel SelectedTask
        {
            get => _selectedTask;
            set
            {
                if (_selectedTask != value)
                {
                    _selectedTask = value;
                    OnPropertyChanged(nameof(SelectedTask));
                    OnPropertyChanged(nameof(IsTaskSelected));
                }
            }
        }

        public bool IsTaskSelected => SelectedTask != null;

        // Comandos
        public ICommand AddTaskCommand { get; }
        public ICommand NavigateToDetailCommand { get; }
        public ICommand DeleteTaskBySwipeCommand { get; }

        public TaskViewModel()
        {
            // Inicialización de los comandos
            AddTaskCommand = new Command(AddTask);
            NavigateToDetailCommand = new Command<TaskModel>(NavigateToDetailPage);
            DeleteTaskBySwipeCommand = new Command<TaskModel>(DeleteTaskBySwipe);
            AddSampleTasks();
        }

        // Método para agregar una nueva tarea 
        private void AddTask()
        {
            Tasks.Add(new TaskModel { Name = "Nueva tarea", IsCompleted = false });
        }

        // Método para eliminar tarea al deslizar
        private void DeleteTaskBySwipe(TaskModel taskToDelete)
        {
            if (taskToDelete != null)
            {
                Tasks.Remove(taskToDelete);
                if (SelectedTask == taskToDelete)
                {
                    SelectedTask = null;
                    OnPropertyChanged(nameof(IsTaskSelected));
                }
            }
        }
        //Método para añadir tareas de prueba
        private void AddSampleTasks()
        {
            Tasks.Add(new TaskModel { Name = "Fregar los platos", IsCompleted = false });
            Tasks.Add(new TaskModel { Name = "Pasear a los perros", IsCompleted = true });
            Tasks.Add(new TaskModel { Name = "Hacer la compra", IsCompleted = false });
            Tasks.Add(new TaskModel { Name = "Hacer la colada", IsCompleted = false });

        }

        // Método para navegar a la página de detalles de la tarea
        private async void NavigateToDetailPage(TaskModel task)
        {
            if (task != null)
            {
                // Creamos el ViewModel de la página de detalles y asignamos la tarea seleccionada
                var taskDetailViewModel = new TaskDetailViewModel(task);

                // Navegamos a la página de detalles y pasamos el ViewModel
                var taskDetailPage = new TaskDetailPage(task)
                {
                    BindingContext = taskDetailViewModel
                };

                await Application.Current.MainPage.Navigation.PushAsync(taskDetailPage);
            }
        }

        // Notificar cambios en las propiedades
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

