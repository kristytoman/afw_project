using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        /// <summary>
        /// Creates new main page with new menu and products page.
        /// </summary>
        public MainPage()
        {
            InitializeComponent();

            // Ads method for opening new detail page from menu.
            MainMenuPage.listView_MainMenu.ItemSelected += ListView_ItemSelected;
           
        }

        
        /// <summary>
        /// Opens a new page specified in target type of a menu list element
        /// </summary>
        /// <param name="sender">Main menu list view item.</param>
        /// <param name="e"></param>
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            /// Finds selected item.
            if (!(e.SelectedItem is MasterMenuItem item))
                return;

            /// Creates new page instance.
            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            /// Opens the page as a detail page of the main page.
            Detail = new NavigationPage(page);
            IsPresented = false;

            /// Resets the selected item.
            MainMenuPage.listView_MainMenu.SelectedItem = null;
        }
    }
}