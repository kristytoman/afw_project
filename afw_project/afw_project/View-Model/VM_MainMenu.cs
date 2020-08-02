using afw_project.View.Admin;
using System.Collections.ObjectModel;

namespace afw_project.View_Model
{
    class VM_MainMenu : VM_Base
    {
        /// <summary>
        /// Gets the information if there's not any logged user in the application.
        /// </summary>
        public bool IsNotLoggedIn
        {
            get
            {
                return VM_Login.LoggedUser == null;
            }
        }

        /// <summary>
        /// Gets the information if there's a logged user in the application.
        /// </summary>
        public bool IsLoggedIn
        {
            get
            {
                return VM_Login.LoggedUser != null;
            }
        }

        /// <summary>
        /// List of items for opening new detail pages.
        /// </summary>
        public ObservableCollection<View_MasterMenuItem> MenuItems { get; set; }

        /// <summary>
        /// Creates a new lists of menu items for a user or logged admin.
        /// </summary>
        public VM_MainMenu()
        {
            if (IsLoggedIn && VM_Login.LoggedUser.Email == "admin")
            {
                MenuItems = new ObservableCollection<View_MasterMenuItem>(new[]
                {
                    new View_MasterMenuItem { Id = 1,   Title = "Your products",      TargetType = typeof(View_Products) },
                    new View_MasterMenuItem { Id = 2,   Title = "Customers' orders" },
                    new View_MasterMenuItem { Id = 3,   Title = "Season Sales" },
                });
            }
            else
            {
                MenuItems = new ObservableCollection<View_MasterMenuItem>(new[]
                {
                    new View_MasterMenuItem{ Id = 1,   Title = "Products",        TargetType = typeof(View_Products) },
                    new View_MasterMenuItem{ Id = 2,   Title = "Shopping Cart",   TargetType = typeof(Customer_Cart) },
                    new View_MasterMenuItem{ Id = 3,   Title = "Your orders",     TargetType = typeof(Customer_Orders) }
                });
            }
        }
    }
}
