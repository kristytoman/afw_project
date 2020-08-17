using afw_project.Model;
using afw_project.View;
using afw_project.View.Admin;
using afw_project.View.Customer;
using System.Collections.ObjectModel;

namespace afw_project.View_Model
{
    class VM_MainMenu : VM_Base
    {
        #region Properties
        /// <summary>
        /// Gets the information if there's not any logged user in the application.
        /// </summary>
        public bool IsNotLoggedIn => App.User.Password == null || App.User.Password == string.Empty;

        /// <summary>
        /// Gets the information if there's a logged user in the application.
        /// </summary>
        public bool IsLoggedIn => App.User.Password != null && App.User.Password != string.Empty;


        /// <summary>
        /// List of items for opening new detail pages.
        /// </summary>
        public ObservableCollection<MasterMenuItem> MenuItems { get; set; }
        #endregion


        #region Constructor
        /// <summary>
        /// Creates a new lists of menu items for a user or logged admin.
        /// </summary>
        public VM_MainMenu()
        {
            if (ContextCredentials.CheckTheAdmin(App.User.Email,App.User.Password))
            {
                MenuItems = new ObservableCollection<MasterMenuItem>(new[]
                {
                    new MasterMenuItem { Id = 1,   Title = "Your products",      TargetType = typeof(Products_MainPage) },
                    new MasterMenuItem { Id = 2,   Title = "Customers' orders",  TargetType = typeof(Orders_MainPage) },
                    new MasterMenuItem { Id = 3,   Title = "Season Sales",       TargetType = typeof(Sales) },
                });
            }
            else
            {
                MenuItems = new ObservableCollection<MasterMenuItem>(new[]
                {
                    new MasterMenuItem{ Id = 1,   Title = "Products",        TargetType = typeof(Products_MainPage) },
                    new MasterMenuItem{ Id = 2,   Title = "Shopping Cart",   TargetType = typeof(Cart) },
                    new MasterMenuItem{ Id = 3,   Title = "Your orders",     TargetType = typeof(View.Customer.Orders) }
                });
            }
        }
        #endregion
    }
}
