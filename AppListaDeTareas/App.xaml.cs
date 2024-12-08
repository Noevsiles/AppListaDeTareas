using AppListaDeTareas.MVVM.Views;

namespace AppListaDeTareas
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
        }
    }
}

