﻿using afw_project.Model;
using afw_project.View;
using afw_project.Model.Validation.Objects;
using Xamarin.Forms;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Collections.ObjectModel;

namespace afw_project.View_Model
{
    class VM_ProductForm : VM_Base
    {
        #region Properties
        /// <summary>
        /// Identification number for the product.
        /// </summary>
        private readonly int product_id;



        /// <summary>
        /// Validatable object with name input.
        /// </summary>
        private ProductName validation_name;
        /// <summary>
        /// Error message to display with invalid name input.
        /// </summary>
        private string error_name;
        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid product name input.
        /// </summary>
        public string Error_name
        {
            get => error_name;
            private set
            {
                if (error_name != value)
                {
                    error_name = value;
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// String value of the name. 
        /// </summary>
        private string input_name;
        /// <summary>
        /// Bindable property that gets or sets the string value of the name.
        /// </summary>
        public string Input_name
        {
            get => input_name;
            set
            {
                if (value != input_name)
                {
                    input_name = value;
                    OnPropertyChanged();
                }
            }
        }



        public ObservableCollection<string> Categories { get; set; }
        private bool selectingCategory;
        public bool SelectingCategory
        {
            get => selectingCategory;
            set
            {
                if (value!=selectingCategory)
                {
                    selectingCategory = value;
                    OnPropertyChanged();
                }
            }
        }
        private string selectedCategory;
        public string SelectedCategory
        {
            get => selectedCategory;
            set
            {
                if (value != selectedCategory)
                {
                    selectedCategory = value;
                    if (selectedCategory == "Add new category")
                    {
                        NewCategory = true;
                        SelectingCategory = false;
                    }
                }
            }
        }
        private bool newCategory;
        public bool NewCategory
        {
            get => newCategory;
            set
            {
                if (value!=newCategory)
                {
                    newCategory = value;
                    OnPropertyChanged();
                }
            }
        }
        /// <summary>
        /// Validatable object with category input.
        /// </summary>
        private CategoryName validation_category;
        /// <summary>
        /// Error message to display with invalid category input.
        /// </summary>
        private string error_category;
        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid product category input.
        /// </summary>
        public string Error_category
        {
            get => error_category;
            private set
            {
                error_category = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// String value of the category.
        /// </summary>
        private string input_category;
        /// <summary>
        /// Bindable property that gets or sets the string value of the category.
        /// </summary>
        public string Input_category
        {
            get => input_category;
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
            get => error_description;
            private set
            {
                error_description = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// String value of the description
        /// </summary>
        private string input_description;
        /// <summary>
        /// Bindable property that gets or sets the string value of the description.
        /// </summary>
        public string Input_description
        {
            get => input_description;
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
        /// Bindable property that sets whether the price can be edited.
        /// </summary>
        public bool PriceEdit
        {
            get
            {
                return !isEdited;
            }
        }
        /// <summary>
        /// Validatable object with price input.
        /// </summary>
        private Cost validation_price;
        /// <summary>
        /// Error message to display with invalid price input.
        /// </summary>
        private string error_price;
        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid product price input.
        /// </summary>
        public string Error_price
        {
            get => error_price;
            private set
            {
                error_price = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// String value of the price.
        /// </summary>
        private string input_price;
        /// <summary>
        /// Bindable property that gets or sets the string value of the price.
        /// </summary>
        public string Input_price
        {
            get => input_price;
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
        /// Validatable object with amount input.
        /// </summary>
        private Amount validation_amount;
        /// <summary>
        /// Error message to display with invalid amount input.
        /// </summary>
        private string error_amount;
        /// <summary>
        /// Bindable property that gets or sets the error message to display with invalid product amount input.
        /// </summary>
        public string Error_amount
        {
            get => error_amount;
            private set
            {
                if (error_amount != value)
                    error_amount = value;
                OnPropertyChanged();
            }
        }
        /// <summary>
        /// String value of the amount
        /// </summary>
        private string input_amount;
        /// <summary>
       /// Bindable property that gets or sets the string value of the amount.
       /// </summary>
        public string Input_amount
        {
            get => input_amount;
            set
            {
                if (value != input_amount)
                {
                    input_amount = value;
                    OnPropertyChanged();
                }
            }
        }

        

        /// <summary>
        /// Defines whether the product is edited or not.
        /// </summary>
        private readonly bool isEdited;


        /// <summary>
        /// Bindable property that gets or sets the text of the button.
        /// </summary>
        public string Button => isEdited ? "Save changes" : "Add product";


        /// <summary>
        /// Bindable command for adding new product into the e-shop database.
        /// </summary>
        public Command Commit { get; set; }
        #endregion


        #region Constructors
        /// <summary>
        ///  Creates a new View Model for a New product page.
        /// </summary>
        public VM_ProductForm()
        {
            Commit = new Command(AddNewProduct);
            Categories = new ObservableCollection<string>();
            Categories.Add("Add new category");
            newCategory = false;
            selectingCategory = true;
            foreach (Category item in Category.GetCategories())
            {
                Categories.Add(item.Name);
            }
            isEdited = false;
        }


        /// <summary>
        /// Creates a new View-model for an edited product.
        /// </summary>
        /// <param name="edited"></param>
        public VM_ProductForm(ProductItem edited) : this()
        {
            product_id = edited.ID;
            Input_name = edited.Name;
            validation_name = new ProductName(Input_name);
            validation_name.Validate();
            Input_category = edited.Category;
            SelectedCategory = edited.Category;
            validation_category = new CategoryName(Input_category);
            validation_category.Validate();
            Input_description = edited.Description;
            validation_description = new Description(Input_description);
            validation_description.Validate();
            Input_price = edited.Price;
            validation_price = new Cost(Input_price);
            validation_price.Validate();
            Input_amount = edited.Amount;
            validation_amount = new Amount(Input_amount);
            validation_amount.Validate();
            isEdited = true;
        }
        #endregion



        #region Validations

        /// <summary>
        /// Validates the admin input and shows/hides the error message for invalid category.
        /// </summary>
        /// <param name="input">Category entry's value.</param>
        /// <returns>True if the entry is valid, false if it is invalid</returns>
        public bool Validate(ValidatableObject input)
        {
            if (input is ProductName input_name)
            {
                validation_name = input_name;
                Error_name = validation_name.Validate();
                return validation_name.isValid;
            }
            else if (input is CategoryName input_category)
            {
                validation_category = input_category;
                Error_category = validation_category.Validate();
                return validation_category.isValid;
            }
            else if (input is Description input_description)
            {
                validation_description = input_description;
                Error_description = validation_description.Validate();
                return validation_description.isValid;
            }
            else if (input is Cost input_cost)
            {
                validation_price = input_cost;
                validation_price.Validate();
                return validation_price.isValid;
            }
            else if (input is Amount input_amount)
            {
                validation_amount = input_amount;
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
            if (NewCategory && !validation_category.isValid) return false;
            if (!validation_description.isValid) return false;
            if (!validation_price.isValid) return false;
            if (!validation_amount.isValid) return false;
            return true;
        }
        #endregion



        #region Finish
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
                    SelectingCategory ? SelectedCategory : validation_category.Value,
                    validation_description.Value,
                    double.Parse(validation_price.Value),
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
                    ((MainPage)Application.Current.MainPage).Detail = new Products_MainPage();
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
                    ((MainPage)Application.Current.MainPage).Detail = new Products_MainPage();
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
        #endregion
    }
}
