using afw_project.Validation;
using afw_project.View.Admin;
using afw_project.View_Model.Validation;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    class VM_ProductForm : VM_Base
    {
        private readonly int product_id;
        /// <summary>
        /// Validatable object with name input.
        /// </summary>
        private Description validation_name;

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
        private string input_name;
        public string Input_name
        {
            get
            {
                return input_name;
            }
            set
            {
                if (value!=input_name)
                {
                    input_name = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Validatable object with category input.
        /// </summary>
        private Name validation_category;

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
        private string input_category;
        public string Input_category
        {
            get
            {
                return input_category;
            }
            set
            {
                if (value != input_category)
                {
                    input_category = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Validatable object with description input.
        /// </summary>
        private Description validation_description;

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

        private string input_description;
        public string Input_description
        {
            get
            {
                return input_description;
            }
            set
            {
                if (value != input_description)
                {
                    input_description = value;
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// Validatable object with price input.
        /// </summary>
        private Number validation_price;

        /// <summary>
        /// Error message to display with invalid price input.
        /// </summary>
        private string error_price;

        private string input_price;
        public string Input_price
        {
            get
            {
                return input_price;
            }
            set
            {
                if (value != input_price)
                {
                    input_price = value;
                    OnPropertyChanged();
                }
            }
        }
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
        private Number validation_amount;

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

        private string input_amount;
        public string Input_amount
        {
            get
            {
                return input_amount;
            }
            set
            {
                if (value != input_amount)
                {
                    input_amount = value;
                    OnPropertyChanged();
                }
            }
        }
        private readonly bool isEdited;
        public string Button
        {
            get
            {
                if (isEdited)
                    return "Save changes";
                else
                    return "Add product";
            }
        }
        /// <summary>
        /// Bindable command for adding new product into the e-shop database.
        /// </summary>
        public Command Commit { get; set; }

        /// <summary>
        ///  Creates a new View Model for a New product page.
        /// </summary>
        public VM_ProductForm()
        {
            Commit = new Command(AddNewProduct);
            isEdited = false;
        }

        public VM_ProductForm(ProductItem edited)
        {
            product_id = edited.ID;
            Input_name = edited.Name;
            validation_name = new Description(Input_name, "name");
            validation_name.Validate();
            Input_category = edited.Category;
            validation_category = new Name(Input_category, "category");
            validation_category.Validate();
            Input_description = edited.Description;
            validation_description = new Description(Input_description, "description");
            validation_description.Validate();
            Input_price = edited.Price;
            validation_price = new Number(Input_price);
            validation_price.Validate();
            Input_amount = edited.Amount;
            validation_amount = new Number(Input_amount);
            validation_amount.Validate();
            isEdited = true;
            Commit = new Command(AddNewProduct);

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
                    validation_name = new Description(value, type);
                    Error_name = validation_name.Validate();
                    return validation_name.isValid;
                case Description.type_productDescription:
                    validation_description = new Description(value, type);
                    Error_description = validation_description.Validate();
                    return validation_description.isValid;
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
            validation_category = input;
            Error_category = validation_category.Validate();
            return validation_category.isValid;
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
                    validation_price = input;
                    validation_price.Validate();
                    return validation_price.isValid;
                case "amount":
                    validation_amount = input;
                    validation_amount.Validate();
                    return validation_amount.isValid;
            }
            return false;
        }

        /// <summary>
        /// Checks whether all validatable objects are valid.
        /// </summary>
        /// <returns>True if all objects are valid, false if at least one is invalid.</returns>
        private bool IsValid()
        {
            if (!validation_name.isValid) return false;
            if (!validation_category.isValid) return false;
            if (!validation_description.isValid) return false;
            if (!validation_price.isValid) return false;
            if (!validation_amount.isValid) return false;
            return true;
        }

        /// <summary>
        /// Creates a new user account if all input values are valid and returns back to a product page.
        /// </summary>
        public void AddNewProduct()
        {
            if (!IsValid())
            {
                Application.Current.MainPage.DisplayAlert
               (
                   "Invalid input",
                   "Please correct your information",
                   "OK"
               );
                return;
            }
            if (!isEdited)
            {
                Product p = new Product
                (
                    validation_name.Value,
                    validation_category.Value,
                    validation_description.Value,
                    int.Parse(validation_price.Value),
                    int.Parse(validation_amount.Value)
                );

                if (p.CreateNewProduct())
                {
                    Application.Current.MainPage.DisplayAlert
                    (
                       "Succesful operation",
                       "Product was added to the database",
                       "OK"
                    );
                    ((View_MainPage)Application.Current.MainPage).Detail = new View_Products();
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
            else
            {
                if (Product.ChangeProduct(product_id, validation_name.Value, validation_category.Value, validation_description.Value, int.Parse(validation_price.Value), int.Parse(validation_amount.Value)))
                {
                    ((View_MainPage)Application.Current.MainPage).Detail = new View_Products();
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
}
