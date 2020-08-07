using afw_project.Model;
using afw_project.View;
using afw_project.View.Admin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace afw_project
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if (!ContextCredentials.GetSavedCredentials())
            {
                MainPage = new View_Init();
            }
            else
            {
                MainPage = new View_MainPage();

            }

        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
