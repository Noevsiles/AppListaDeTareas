
using AppListaDeTareas.MVVM.ViewModels;

namespace AppListaDeTareas.MVVM.Views;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

        // Ocultar la barra de navegación para esta página
        NavigationPage.SetHasNavigationBar(this, false);
    }
}