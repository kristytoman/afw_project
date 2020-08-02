using afw_project.View_Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View_MainMenu : ContentPage
    {
        /// <summary>
        /// List view of main menu containing header and the items for opening new pages.
        /// </summary>
        public ListView MainMenu;

        public View_MainMenu()
        {
            InitializeComponent();

            /// Creates new view-model.
            BindingContext = new VM_MainMenu();
            
            /// Bind the view with the main page.
            MainMenu = listView_MainMenu;
        }

        /// <summary>
        /// Opens log in page.
        /// </summary>
        /// <param name="sender">Log in button.</param>
        /// <param name="e"></param>
        private void Login_Clicked(object sender, EventArgs e)
        {
            ((View_MainPage)Parent).Detail = new Customer_Login();
        }

        /// <summary>
        /// Opens sign up page.
        /// </summary>
        /// <param name="sender">Sign up button.</param>
        /// <param name="e"></param>
        private void SignUp_Clicked(object sender, EventArgs e)
        {
            ((View_MainPage)Parent).Detail = new Customer_SignUp();
        }

        /// <summary>
        /// Deletes the instance of logged user and restarts the main page.
        /// </summary>
        /// <param name="sender">Log out button.</param>
        /// <param name="e"></param>
        private void LogOut_Clicked(object sender, EventArgs e)
        {
            VM_Login.LoggedUser = null;
            DisplayAlert("Log out", "You were succesfully logged out.", "OK");
            Application.Current.MainPage = new View_MainPage();
        }
    }
}