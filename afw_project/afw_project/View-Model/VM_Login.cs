using afw_project.View.Admin;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    class VM_Login : VM_Base
    {
        /// <summary>
        /// Gets or sets the current user account that is using the application.
        /// </summary>
        public static Customer LoggedUser { get; set; }

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
            LoggedUser = Customer.GetCustomer(Email, Password);

            /// Unsuccesful operation
            if (LoggedUser == null)
            {
                Application.Current.MainPage.DisplayAlert
               (
                   "Unsuccesfull login",
                   "Invalid login information",
                   "OK"
               );
                return;
            }
            
            /// Succesful operation
            Application.Current.MainPage.DisplayAlert
              (
                  "Succesfull login",
                  "You are succesfully logged in",
                  "OK"
              );

            if (LoggedUser.Email == "admin") /// Admin login
            {
                App.Current.MainPage = new View_MainPage();
            }
            else /// Customer login
            {
                App.Current.MainPage = new View_MainPage();
            }
        }
    }
}
