using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class View_MainPage : MasterDetailPage
    {
        /// <summary>
        /// Creates new main page with new menu and products page.
        /// </summary>
        public View_MainPage()
        {
            InitializeComponent();

            // Ads method for opening new detail page from menu.
            View_MainMenu.MainMenu.ItemSelected += ListView_ItemSelected;
           
        }

        
        /// <summary>
        /// Opens a new page specified in target type of a menu list element
        /// </summary>
        /// <param name="sender">Main menu list view item.</param>
        /// <param name="e"></param>
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            /// Finds selected item.
            var item = e.SelectedItem as View_MasterMenuItem;
            if (item == null)
                return;

            /// Creates new page instance.
            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            /// Opens the page as a detail page of the main page.
            Detail = new NavigationPage(page);
            IsPresented = false;

            /// Resets the selected item.
            View_MainMenu.MainMenu.SelectedItem = null;
        }
    }
}