using afw_project.Validation;
using afw_project.View.Admin;
using afw_project.View_Model.Validation;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    class VM_NewProduct : VM_Base
    {
        /// <summary>
        /// Validatable object with name input.
        /// </summary>
        private Description name;

        /// <summary>
        /// Error message to display with invalid name input.
        /// </summary>
        private string error_name;

        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid product name input.
        /// </summary>
        public string Error_name
        {
            get
            {
                return error_name;
            }
            private set
            {
                error_name = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Validatable object with category input.
        /// </summary>
        private Name category;

        /// <summary>
        /// Error message to display with invalid category input.
        /// </summary>
        private string error_category;

        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid product category input.
        /// </summary>
        public string Error_category
        {
            get
            {
                return error_category;
            }
            private set
            {
                error_category = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Validatable object with description input.
        /// </summary>
        private Description description;

        /// <summary>
        /// Error message to display with invalid description input.
        /// </summary>
        private string error_description;

        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid product description input.
        /// </summary>
        public string Error_description
        {
            get
            {
                return error_description;
            }
            private set
            {
                error_description = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Validatable object with price input.
        /// </summary>
        private Number price;

        /// <summary>
        /// Error message to display with invalid price input.
        /// </summary>
        private string error_price;


        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid product price input.
        /// </summary>
        public string Error_price
        {
            get
            {
                return error_price;
            }
            private set
            {
                error_price = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Validatable object with amount input.
        /// </summary>
        private Number amount;

        /// <summary>
        /// Error message to display with invalid amount input.
        /// </summary>
        private string error_amount;

        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid product amount input.
        /// </summary>
        public string Error_amount
        {
            get
            {
                return error_amount;
            }
            private set
            {
                error_amount = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Bindable command for adding new product into the e-shop database.
        /// </summary>
        public Command Add { get; set; }

        /// <summary>
        ///  Creates a new View Model for a New product page.
        /// </summary>
        public VM_NewProduct()
        {
            Add = new Command(AddNewProduct);
        }

        /// <summary>
        /// Validates the admin input and shows/hides the error message for invalid description.
        /// </summary>
        /// <param name="value">Description entry value.</param>
        /// <param name="type">Type of description.</param>
        /// <returns>True if the entry is valid, false if it is invalid</returns>
        public bool Validate(string value, string type)
        {
            switch (type)
            {
                case Description.type_productName:
                    name = new Description(value, type);
                    Error_name = name.Validate();
                    return name.isValid;
                case Description.type_productDescription:
                    description = new Description(value, type);
                    Error_description = description.Validate();
                    return description.isValid;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Validates the admin input and shows/hides the error message for invalid category.
        /// </summary>
        /// <param name="input">Category entry's value.</param>
        /// <returns>True if the entry is valid, false if it is invalid</returns>
        public bool Validate(Name input)
        {
            category = input;
            Error_category = category.Validate();
            return category.isValid;
        }

        /// <summary>
        /// Validates the admin input and shows/hides the error message for invalid price/amount.
        /// </summary>
        /// <param name="input">Validatable object with number value</param>
        /// <param name="type">"price" or "amount"</param>
        /// <returns>True if the entry is valid, false if it is invalid</returns>
        public bool Validate(Number input, string type)
        {
            switch (type)
            {
                case "price":
                    price = input;
                    price.Validate();
                    return price.isValid;
                case "amount":
                    amount = input;
                    amount.Validate();
                    return amount.isValid;
            }
            return false;
        }

        /// <summary>
        /// Checks whether all validatable objects are valid.
        /// </summary>
        /// <returns>True if all objects are valid, false if at least one is invalid.</returns>
        private bool isValid()
        {
            if (!name.isValid) return false;
            if (!category.isValid) return false;
            if (!description.isValid) return false;
            if (!price.isValid) return false;
            if (!amount.isValid) return false;
            return true;
        }

        /// <summary>
        /// Creates a new user account if all input values are valid and returns back to a product page.
        /// </summary>
        public void AddNewProduct()
        {
            if (!isValid())
            {
                Application.Current.MainPage.DisplayAlert
               (
                   "Invalid input",
                   "Please correct your information",
                   "OK"
               );
                return;
            }

            Product p = new Product
            (
                name.Value,
                category.Value,
                description.Value,
                int.Parse(price.Value),
                int.Parse(amount.Value)
            );

            if (p.CreateNewProduct())
            {
                Application.Current.MainPage.DisplayAlert
                (
                   "Succesful operation",
                   "Product was added to the database",
                   "OK"
                );
                App.Current.MainPage = new View_MainPage();
            }
            else
            {
                Application.Current.MainPage.DisplayAlert
                (
                    "Operation failed",
                    "Something went wrong with adding the item.",
                    "OK"
                );
            }

        }
    }
}
