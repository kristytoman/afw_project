using afw_project.Model;
using afw_project.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace afw_project
{
    public partial class App : Application
    {
        /// <summary>
        /// Gets or sets the current user account that is using the application.
        /// </summary>
        public static Customer User { get; set; }

        /// <summary>
        /// Gets or sets the current user's cart.
        /// </summary>
        public static Order Cart { get; set; }

        public App()
        {
            InitializeComponent();
            User = new Customer();
            Cart = new Order { Customer = User };
            if (!ContextCredentials.GetSavedCredentials())
            {
                MainPage = new Init();
            }
            else
            {
                MainPage = new MainPage();
            }
        }
    }
}
