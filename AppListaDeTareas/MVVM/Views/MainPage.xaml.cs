
using AppListaDeTareas.MVVM.ViewModels;

namespace AppListaDeTareas.MVVM.Views;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();

        // Ocultar la barra de navegaci�n para esta p�gina
        NavigationPage.SetHasNavigationBar(this, false);
    }
}