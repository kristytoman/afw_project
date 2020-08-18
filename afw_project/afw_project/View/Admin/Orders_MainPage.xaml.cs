using afw_project.View_Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Orders_MainPage : TabbedPage
    {
        #region Constructor
        /// <summary>
        /// Creates a main tabbed page for orders.
        /// </summary>
        public Orders_MainPage()
        {
            InitializeComponent();
            Children.Add(new Orders("All"));
            foreach(string name in Enum.GetNames(typeof(OrderStateType)))
            {
                Children.Add(new Orders(name));
            }
        }
        #endregion
    }
}