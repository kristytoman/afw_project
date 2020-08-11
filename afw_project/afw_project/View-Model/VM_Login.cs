using afw_project.Model;
using afw_project.View.Admin;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    class VM_Login : VM_Base
    {
        /// <summary>
        /// Bindable string to get the user's input email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Bindable string to get the user's password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Bindable command to log in the user
        /// </summary>
        public Command Login { get; set; }

        /// <summary>
        /// Creates a new View-Model for the Login page
        /// </summary>
        public VM_Login()
        {
            Login = new Command(LogUserIn);
        }

        /// <summary>
        /// Tries to get user with the input credentials from the database
        /// </summary>
        private void LogUserIn()
        {
            if (ContextCredentials.CheckTheAdmin(Email, Password))
            {
                App.User = new Customer(Email,Password);
                Application.Current.MainPage = new View_MainPage();
                return;
            }

            App.User = Customer.GetCustomer(Email, Password);

            /// Unsuccesful operation
            if (App.User == null)
            {
                Application.Current.MainPage.DisplayAlert
               (
                   "Unsuccesfull login",
                   "Invalid login information",
                   "OK"
               );
                return;
            }

            Application.Current.MainPage = new View_MainPage();
        }
    }
}
