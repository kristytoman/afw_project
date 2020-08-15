﻿using afw_project.View_Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Admin_Products : ContentPage
    {

        /// <summary>
        /// View model of the current page.
        /// </summary>
        VM_Products viewModel;

        /// <summary>
        /// Selected product in a list of products.
        /// </summary>
        ProductView selectedItem;


        /// <summary>
        /// Creates a new page for a viewing products.
        /// </summary>
        /// <param name="name">Category name for viewing products of the category or "All" for viewing all products.</param>
        public Admin_Products(string name)
        {
            Title = name;

            InitializeComponent();

            viewModel = new VM_Products(Title);
            BindingContext = viewModel;
        }



        /// <summary>
        /// Method for expanding the item of the list of products. Shows a delete and edit button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Products_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(sender is ListView lw))
            {
                return;
            }

            if (selectedItem != null)
            {
                selectedItem.IsSelected = false;
            }

            if (!(lw.SelectedItem is ProductView item))
            {
                return;
            }

            item.IsSelected = true;
            selectedItem = item;
        }



        /// <summary>
        /// Opens a page to edit the selected item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Edit_Clicked(object sender, EventArgs e)
        {
            ((View_MainPage)Application.Current.MainPage).Detail = new Admin_ProductForm(selectedItem);
        }



        /// <summary>
        /// Delete the selected item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Clicked(object sender, EventArgs e)
        {
            viewModel.DeleteSelectedItem(selectedItem);
        }
    }
}