using afw_project.View;
using afw_project.Model;
using afw_project.Model.Validation;
using afw_project.Model.Validation.Objects;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    class VM_CustomerForm : VM_Base
    {
        #region Properties
        /// <summary>
        /// Validatable object with email input.
        /// </summary>
        private Email email;
        /// <summary>
        /// Error message to display with invalid email input.
        /// </summary>
        private string error_email;
        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid email input.
        /// </summary>
        public string Error_email
        {
            get => error_email;
            private set
            {
                if (value != error_email)
                {
                    error_email = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Bindable property that gets or sets the label password.
        /// </summary>
        public string Label_password
        { 
            get
            {
                return isSignUp ? "Password*" : "Password";
            } 
        }
        /// <summary>
        /// Validatable object with password input.
        /// </summary>
        private Password password;
        /// <summary>
        /// Error message to display with invalid password input.
        /// </summary>
        private string error_password;
        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid password input.
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
        /// Validatable object with first name input.
        /// </summary>
        private Name firstName;
        /// <summary>
        /// Error message to display with invalid first name input.
        /// </summary>
        private string error_firstName;
        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid first name input.
        /// </summary>
        public string Error_firstName
        {
            get => error_firstName;
            private set
            {
                if (value != error_firstName)
                {
                    error_firstName = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Validatable object with last name input.
        /// </summary>
        private Surname lastName;
        /// <summary>
        /// Error message to display with invalid last name input.
        /// </summary>
        private string error_lastName;
        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid last name input.
        /// </summary>
        public string Error_lastName
        {
            get
            {
                return error_lastName;
            }
            private set
            {
                if (value != error_lastName)
                {
                    error_lastName = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Validatable object with phone number input.
        /// </summary>
        private PhoneNumber phone;
        /// <summary>
        /// Error message to display with invalid phone number input.
        /// </summary>
        private string error_phone;
        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid phone number input.
        /// </summary>
        public string Error_phone
        {
            get => error_phone;
            private set
            {
                if (value != error_phone)
                {
                    error_phone = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Validatable object with street address input.
        /// </summary>
        private StreetName street;
        /// <summary>
        /// Error message to display with invalid street address input.
        /// </summary>
        private string error_street;
        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid street address input.
        /// </summary>
        public string Error_street
        {
            get => error_street;
            private set
            {
                if (value != error_street)
                {
                    error_street = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Validatable object with building number input.
        /// </summary>
        private Building building;
        /// <summary>
        /// Error message to display with invalid building number input.
        /// </summary>
        private string error_building;
        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid building number input.
        /// </summary>
        public string Error_building
        {
            get => error_building;
            private set
            {
                if (value != error_building)
                {
                    error_building = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Validatable object with city address input.
        /// </summary>
        private CityName city;
        /// <summary>
        /// Error message to display with invalid city address input.
        /// </summary>
        private string error_city;
        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid city address input.
        /// </summary>
        public string Error_city
        {
            get => error_city;
            private set
            {
                if (value != error_city)
                {
                    error_city = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Validatable object with postal code input.
        /// </summary>
        private PostalCode code;
        /// <summary>
        /// Error message to display with invalid postal code input.
        /// </summary>
        private string error_code;
        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid postal code input.
        /// </summary>
        public string Error_code
        {
            get => error_code;
            private set
            {
                if (value != error_code)
                {
                    error_code = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Bindable property with the list of countries.
        /// </summary>
        public string[] Countries
        {
            get
            {
                return IsCountry.Countries;
            }
        }
        /// <summary>
        /// Country address input value.
        /// </summary>
        private Country country;
        /// <summary>
        /// Error message to display when the country input is invalid
        /// </summary>
        private string error_country;
        /// <summary>
        /// Bindable property that gets or sets the error message to display when the country input is invalid.
        /// </summary>
        public string Error_country
        {
            get => error_country;
            set
            {
                if (value!=error_country)
                {
                    error_country = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Defines whether the page is for sign up
        /// </summary>
        public readonly bool isSignUp;


        /// <summary>
        /// Name of the button.
        /// </summary>
        public string ButtonName => isSignUp ? "Sign up" : "Send order";

        /// <summary>
        /// Bindable command for adding new customer account into the e-shop database.
        /// </summary>
        public Command Finish { get; set; }
        #endregion


        #region Constructor
        /// <summary>
        /// Creates a new View Model for a Sign Up page.
        /// </summary>
        public VM_CustomerForm(bool isSignUp)
        {
            Finish = new Command(CreateNewCustomer);
            this.isSignUp = isSignUp;
        }
        #endregion



        #region Validation methods
        /// <summary>
        /// Validates the user input and shows/hides the error message for invalid e-mail.
        /// </summary>
        /// <param name="input">Object for validating e-mail value.</param>
        /// <returns>True if the input is valid, false if it's invalid.</returns>
        public bool Validate(ValidatableObject input)
        {
            if (input is Email input_email)
            {
                email = input_email;
                Error_email = email.Validate();
                return email.isValid;
            }
            else if (input is Password input_password)
            {
                password = input_password;
                Error_password = password.Validate();
                return password.isValid;
            }
            else if (input is Name input_name)
            {
                firstName = input_name;
                Error_firstName = firstName.Validate();
                return firstName.isValid;
            }
            else if (input is Surname input_surname)
            {
                lastName = input_surname;
                Error_lastName = lastName.Validate();
                return lastName.isValid;
            }
            else if (input is PhoneNumber input_phone)
            {
                phone = input_phone;
                Error_phone = phone.Validate();
                return phone.isValid;
            }
            else if (input is StreetName input_street)
            {
                street = input_street;
                Error_street = street.Validate();
                return street.isValid;
            }
            else if (input is Building input_building)
            {
                building = input_building;
                Error_building = building.Validate();
                return building.isValid;
            }
            else if (input is CityName input_city)
            {
                city = input_city;
                Error_city = city.Validate();
                return city.isValid;
            }
            else if (input is PostalCode input_code)
            {
                code = input_code;
                Error_code = code.Validate();
                return code.isValid;
            }
            else if (input is Country input_country)
            {
                country = input_country;
                Error_country = country.Validate();
                return country.isValid;
            }
            return false;
        }
       

        /// <summary>
        /// Checks whether all validatable objects are valid.
        /// </summary>
        /// <returns>True if all objects are valid, false if at least one is invalid.</returns>
        public bool CheckInput()
        {
            if (!email.isValid) return false;
            if (isSignUp && !password.isValid) return false;
            if (!firstName.isValid) return false;
            if (!lastName.isValid) return false;
            if (!phone.isValid) return false;
            if (!street.isValid) return false;
            if (!building.isValid) return false;
            if (!city.isValid) return false;
            if (!code.isValid) return false;
            return true;
        }
        #endregion



        #region Finish
        /// <summary>
        /// Creates a new user account if all input values are valid and returns back to a product page.
        /// </summary>
        private void CreateNewCustomer()
        {
            if (!CheckInput())
            {
                Application.Current.MainPage.DisplayAlert
                (
                    "Invalid input",
                    "Please correct your information",
                    "OK"
                );
                return;
            }
            if (isSignUp)
            {
                /// Creates new instance for customer account.
                Customer c = new Customer
                (
                    email.Value,
                    password.Value == string.Empty ? null : password.Value,
                    firstName.Value,
                    lastName.Value,
                    phone.Value,
                    street.Value,
                    building.Value,
                    city.Value,
                    code.Value,
                    country.Value
                );

                /// Tries to create a new record in a database.
                if (c.CreateNewCustomer())
                {
                    Application.Current.MainPage.DisplayAlert
                    (
                        "Succesful operation",
                        "You are succesfully signed up",
                        "OK"
                    );
                    Application.Current.MainPage = new MainPage();
                }


                else
                {
                    Application.Current.MainPage.DisplayAlert
                    (
                        "Something went wrong",
                        "The signing up failed",
                        "OK"
                    );
                }
            }
            else
            {
               
                if (!App.User.SaveCustomer(
                    email.Value,
                    password.Value == string.Empty ? null : password.Value,
                    firstName.Value,
                    lastName.Value,
                    phone.Value,
                    street.Value,
                    building.Value,
                    city.Value,
                    code.Value,
                    country.Value
                ))
                {
                    Application.Current.MainPage.DisplayAlert
                    (
                        "Something went wrong",
                        "We were unable to send the order.",
                        "OK"
                    );
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert
                    (
                        "Successful operation",
                        "Your order has been sent.",
                        "OK"
                    );
                }
            }
        }
        #endregion
    }
}
