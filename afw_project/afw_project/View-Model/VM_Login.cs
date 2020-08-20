using afw_project.Model;
using afw_project.View;
using afw_project.View.Admin;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    class VM_Login : VM_Base
    {
        #region Properties
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
        #endregion


        #region Constructor
        /// <summary>
        /// Creates a new View-Model for the Login page
        /// </summary>
        public VM_Login()
        {
            Login = new Command(LogUserIn);
        }
        #endregion


        #region Finish
        /// <summary>
        /// Tries to get user with the input credentials from the database
        /// </summary>
        private void LogUserIn()
        {
            if (ContextCredentials.CheckTheAdmin(Email, Password))
            {
                App.User = new Customer(Email,Password);
                Application.Current.MainPage = new MainPage();
                return;
            }
            App.User = Customer.GetCustomer(Email, Password,App.User.GetCart());

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
            Application.Current.MainPage = new MainPage();
        }
        #endregion
    }
}
