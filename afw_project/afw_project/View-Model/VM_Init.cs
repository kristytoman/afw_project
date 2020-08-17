using afw_project.Model;
using afw_project.View;
using afw_project.Model.Validation.Objects;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    class VM_Init : VM_Base
    {
        #region Properties
        /// <summary>
        /// Server name for the database connection string.
        /// </summary>
        public string ServerName { get; set; }


        /// <summary>
        /// Database name for the database connection string.
        /// </summary>
        public string DatabaseName { get; set; }


        /// <summary>
        /// Database user of the database.
        /// </summary>
        public string DatabaseUser { get; set; }


        /// <summary>
        /// Password for the database user authentication.
        /// </summary>
        public string DatabasePassword { get; set; }


        /// <summary>
        /// Username for administrator authentication.
        /// </summary>
        private Name username;
        /// <summary>
        /// Label to view error if the username was invalid.
        /// </summary>
        private string error_username;
        /// <summary>
        /// Gets or sets the error label with invalid username.
        /// </summary>
        public string Error_username
        {
            get => error_username;
            private set
            {
                if (value != error_username)
                {
                    error_username = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Password for the administrator authentication.
        /// </summary>
        private Password password;
        /// <summary>
        /// Label to view error if the password was invalid.
        /// </summary>
        private string error_password;
        /// <summary>
        /// Gets or sets the error label with invalid password.
        /// </summary>
        public string Error_password
        {
            get => error_password;
            private set
            {
                if (value != error_password)
                {
                    error_password = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Gets or sets the command for saving the credentials.
        /// </summary>
        public Command Save { get; set; }
        #endregion


        #region Constructor
        /// <summary>
        /// Initialize the view-model for the Init page.
        /// </summary>
        public VM_Init()
        {
            Save = new Command(Initialize);
        }
        #endregion



        #region Validations
        /// <summary>
        /// Validates the administrator username input.
        /// </summary>
        /// <param name="input">Validatable object with the username value.</param>
        /// <returns>True if the input is valid, false if invalid.</returns>
        public bool Validate(Name input)
        {
            username = input;
            Error_username = username.Validate();
            return username.isValid;
        }

        /// <summary>
        /// Validates the administator password input.
        /// </summary>
        /// <param name="input">Validatable object with the password value.</param>
        /// <returns>True if the input is valid, false if invalid.</returns>
        public bool Validate(Password input)
        {
            password = input;
            Error_password = password.Validate();
            return password.isValid;
        }

        /// <summary>
        /// Checks if all input values are valid.
        /// </summary>
        /// <returns>True if all values are valid, false if at least one value is invalid.</returns>
        private bool CheckInput()
        {
            if (!username.isValid) return false;
            if (!password.isValid) return false;
            return true;
        }
        #endregion



        #region Finish
        /// <summary>
        /// Sends the values and initialize the application. 
        /// </summary>
        public void Initialize()
        {
            if (ServerName == string.Empty || DatabaseName == string.Empty || DatabaseUser == string.Empty || DatabasePassword == string.Empty)
            {
                Application.Current.MainPage.DisplayAlert("Empty input", "All information is required.", "OK");
                return;
            }
            if (!CheckInput())
            {
                Application.Current.MainPage.DisplayAlert("Invalid input", "Please correct invalid information.", "OK");
                return;
            }

            ContextCredentials.SetCredentials($"server={ServerName};database={DatabaseName};user={DatabaseUser};password={DatabasePassword}", username.Value, password.Value);
            Context db = new Context();

            if (!db.Database.CanConnect())
            {
                Application.Current.MainPage.DisplayAlert("Something went wrong", "The connection to the database failed.", "OK");
                return;
            }
            else
            {
                Application.Current.MainPage = new MainPage();
            }
        }
        #endregion
    }
}
