using afw_project.View.Customer;
using afw_project.View_Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        /// <summary>
        /// List view of main menu containing header and the items for opening new pages.
        /// </summary>
        public ListView listView_MainMenu;

        public MainMenu()
        {
            InitializeComponent();

            /// Creates new view-model.
            BindingContext = new VM_MainMenu();
            
            /// Bind the view with the main page.
            listView_MainMenu = mainMenuList;
        }

        /// <summary>
        /// Opens log in page.
        /// </summary>
        /// <param name="sender">Log in button.</param>
        /// <param name="e"></param>
        private void Login_Clicked(object sender, EventArgs e)
        {
            ((MainPage)Parent).Detail = new Login();
        }

        /// <summary>
        /// Opens sign up page.
        /// </summary>
        /// <param name="sender">Sign up button.</param>
        /// <param name="e"></param>
        private void SignUp_Clicked(object sender, EventArgs e)
        {
            ((MainPage)Parent).Detail = new CustomerForm(true);
        }

        /// <summary>
        /// Deletes the instance of logged user and restarts the main page.
        /// </summary>
        /// <param name="sender">Log out button.</param>
        /// <param name="e"></param>
        private void LogOut_Clicked(object sender, EventArgs e)
        {
            App.User = new Model.Customer();
            
            DisplayAlert("Log out", "You were succesfully logged out.", "OK");
            Application.Current.MainPage = new MainPage();
        }
    }
}