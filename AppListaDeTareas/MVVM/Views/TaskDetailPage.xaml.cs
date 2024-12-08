using AppListaDeTareas.MVVM.Models;
using AppListaDeTareas.MVVM.ViewModels;
using System.Threading.Tasks;

namespace AppListaDeTareas.MVVM.Views;

public partial class TaskDetailPage : ContentPage
{

	public TaskDetailPage(TaskModel task)
    {
		InitializeComponent();
        BindingContext = new TaskDetailViewModel(task);
        // Ocultar la barra de navegación para esta página
        NavigationPage.SetHasNavigationBar(this, false);
    }

    //evento para el boton guardar
    private async void Button_Clicked(object sender, EventArgs e)
    {    
        await Navigation.PopAsync();
    }
    

}