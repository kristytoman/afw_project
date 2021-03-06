﻿using afw_project.View_Model;
using afw_project.Model.Validation.Objects;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductForm : ContentPage
    {
        // used twice - global or parent??
        //
        /// <summary>
        /// Color for valid entry.
        /// </summary>
        readonly Color validColor = Color.Green;
        //
        /// <summary>
        /// Color for invalid entry.
        /// </summary>
        readonly Color invalidColor = Color.Red;
        //
        //

        private readonly VM_ProductForm viewModel;

        /// <summary>
        /// Initializing new NewProduct page.
        /// </summary>
        public ProductForm()
        {
            InitializeComponent();
            viewModel = new VM_ProductForm();
            BindingContext = viewModel;
        }

        public ProductForm(ProductItem product)
        {
            InitializeComponent();
            viewModel = new VM_ProductForm(product);
            BindingContext = viewModel;
            
        }

        // used twice - global or parent?
        //
        /// <summary>
        /// Changes the style of an entry.
        /// </summary>
        /// <param name="entry">Entry to change style.</param>
        /// <param name="valid">State of input value.</param>
        private void ChangeEntry(Entry entry, bool valid)
        {
            if (valid)
            {
                entry.BackgroundColor = validColor;
                return;
            }

            entry.BackgroundColor = invalidColor;
        }

        /// <summary>
        /// Validates the name entry after unfocusing.
        /// </summary>
        /// <param name="sender">Name entry.</param>
        /// <param name="e"></param>
        private void Name_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry, viewModel.Validate(new ProductName(entry.Text)));
            
        }

        /// <summary>
        /// Validates the category entry after unfocusing.
        /// </summary>
        /// <param name="sender">Category entry.</param>
        /// <param name="e"></param>
        private void Category_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry, viewModel.Validate(new CategoryName(entry.Text)));
        }

        /// <summary>
        /// Validates the description entry after unfocusing.
        /// </summary>
        /// <param name="sender">Description entry.</param>
        /// <param name="e"></param>
        private void Description_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry,viewModel.Validate(new Description(entry.Text)));
        }

        /// <summary>
        /// Validates the price entry after unfocusing.
        /// </summary>
        /// <param name="sender">Price entry.</param>
        /// <param name="e"></param>
        private void Price_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry, viewModel.Validate(new Cost(entry.Text)));
        }

        /// <summary>
        /// Validates the amount entry after unfocusing.
        /// </summary>
        /// <param name="sender">Amount entry.</param>
        /// <param name="e"></param>
        private void Amount_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            ChangeEntry(entry, viewModel.Validate(new Amount(entry.Text)));
        }

    }
}