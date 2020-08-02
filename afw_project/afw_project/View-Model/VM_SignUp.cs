using afw_project.Validation;
using afw_project.View.Admin;
using afw_project.View_Model.Validation;
using Xamarin.Forms;

namespace afw_project
{
    class VM_SignUp : VM_Base
    {
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
            get
            {
                return error_email;
            }
            private set
            {
                error_email = value;
                OnPropertyChanged();
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
            get
            {
                return error_password;
            }
            private set
            {
                error_password = value;
                OnPropertyChanged();
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
            get
            {
                return error_firstName;
            }
            private set
            {
                error_firstName = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Validatable object with last name input.
        /// </summary>
        private Name lastName;

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
                error_lastName = value;
                OnPropertyChanged();
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
            get
            {
                return error_phone;
            }
            private set
            {
                error_phone = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Validatable object with street address input.
        /// </summary>
        private Name street;

        /// <summary>
        /// Error message to display with invalid street address input.
        /// </summary>
        private string error_street;

        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid street address input.
        /// </summary>
        public string Error_street
        {
            get
            {
                return error_street;
            }
            private set
            {
                error_street = value;
                OnPropertyChanged();
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
            get
            {
                return error_building;
            }
            private set
            {
                error_building = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Validatable object with city address input.
        /// </summary>
        private Name city;

        /// <summary>
        /// Error message to display with invalid city address input.
        /// </summary>
        private string error_city;

        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid city address input.
        /// </summary>
        public string Error_city
        {
            get
            {
                return error_city;
            }
            private set
            {
                error_city = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Validatable object with postal code input.
        /// </summary>
        private Number code;

        /// <summary>
        /// Error message to display with invalid postal code input.
        /// </summary>
        private string error_code;

        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid postal code input.
        /// </summary>
        public string Error_code
        {
            get
            {
                return error_code;
            }
            private set
            {
                error_code = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Country address input value.
        /// </summary>
        private string country = "";

        /// <summary>
        /// Bindable property that gets or sets the country input.
        /// </summary>
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                country = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Bindable command for adding new customer account into the e-shop database.
        /// </summary>
        public Command AddCustomer { get; set; }

        /// <summary>
        /// Creates a new View Model for a Sign Up page.
        /// </summary>
        public VM_SignUp()
        {
            AddCustomer = new Command(CreateNewCustomer);
        }

        /// <summary>
        /// Validates the user input and shows/hides the error message for invalid e-mail.
        /// </summary>
        /// <param name="input">Object for validating e-mail value.</param>
        /// <returns>True if the input is valid, false if it's invalid.</returns>
        public bool Validate(Email input)
        {
            email = input;
            Error_email = email.Validate();
            return email.isValid;
        }

        /// <summary>
        /// Validates the user input and shows/hides the error message for invalid password.
        /// </summary>
        /// <param name="input">Object for validating password value.</param>
        /// <returns>True if the input is valid, false if it's invalid.</returns>
        public bool Validate(Password input)
        {
            password = input;
            Error_password = password.Validate();
            return password.isValid;
        }

        /// <summary>
        /// Validates the user input and shows/hides the error message for invalid input.
        /// </summary>
        /// <param name="value">User's input value.</param>
        /// <param name="type">Type of name value.</param>
        /// <returns>True if the input is valid, false if it's invalid.</returns>
        public bool Validate(string value, string type)
        {
            switch (type)
            {
                case Name.type_firstName:

                    firstName = new Name(value, type);
                    Error_firstName = firstName.Validate();
                    return firstName.isValid;

                case Name.type_lastName:

                    lastName = new Name(value, type);
                    Error_lastName = lastName.Validate();
                    return lastName.isValid;

                case Name.type_street:

                    street = new Name(value, type);
                    Error_street = street.Validate();
                    return street.isValid;

                case Name.type_city:

                    city = new Name(value, type);
                    Error_city = city.Validate();
                    return city.isValid;

                default:
                    return false;
            }
        }

        /// <summary>
        /// Validates the user input and shows/hides the error message for invalid phone number.
        /// </summary>
        /// <param name="input">Object for validating phone number value.</param>
        /// <returns>True if the input is valid, false if it's invalid.</returns>
        public bool Validate(PhoneNumber input)
        {
            phone = input;
            Error_phone = phone.Validate();
            return phone.isValid;
        }

        /// <summary>
        /// Validates the user input and shows/hides the error message for invalid building number.
        /// </summary>
        /// <param name="input">Object for validating building number value.</param>
        /// <returns>True if the input is valid, false if it's invalid.</returns>
        public bool Validate(Building input)
        {
            building = input;
            Error_building = building.Validate();
            return building.isValid;
        }

        /// <summary>
        /// Validates the user input and shows/hides the error message for invalid postal code.
        /// </summary>
        /// <param name="input">Object for validating postal code value.</param>
        /// <returns>True if the input is valid, false if it's invalid.</returns>
        public bool Validate(Number input)
        {
            code = input;
            Error_code = code.Validate();
            return code.isValid;
        }

        /// <summary>
        /// Checks whether all validatable objects are valid.
        /// </summary>
        /// <returns>True if all objects are valid, false if at least one is invalid.</returns>
        public bool CheckInput()
        {
            if (!email.isValid) return false;
            if (!password.isValid) return false;
            if (!firstName.isValid) return false;
            if (!lastName.isValid) return false;
            if (!phone.isValid) return false;
            if (!street.isValid) return false;
            if (!building.isValid) return false;
            if (!city.isValid) return false;
            if (!code.isValid) return false;
            return true;
        }
       
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

            /// Creates new instance for customer account.
            Customer c = new Customer
            (
                email.Value,
                password.Value,
                firstName.Value,
                lastName.Value,
                phone.Value,
                street.Value,
                building.Value,
                city.Value,
                code.Value,
                country
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
                App.Current.MainPage = new View_MainPage();
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
    }
}
