﻿using afw_project.Validation;
using afw_project.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View_Init : ContentPage
    {
        /// <summary>
        /// Color for valid entry.
        /// </summary>
        readonly Color validColor = Color.Green;

        /// <summary>
        /// Color for invalid entry.
        /// </summary>
        readonly Color invalidColor = Color.Red;

        VM_Init viewModel;
        public View_Init()
        {
            viewModel = new VM_Init();
            BindingContext = viewModel;

            InitializeComponent();
        }

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

        private void Username_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            Name username = new Name(entry.Text,"username");
            ChangeEntry(entry, viewModel.Validate(username));
        }

        private void Password_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = (Entry)sender;
            Password password = new Password(entry.Text);
            ChangeEntry(entry, viewModel.Validate(password));
        }

    }
}