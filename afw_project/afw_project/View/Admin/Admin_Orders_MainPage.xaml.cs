using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Admin_Orders_MainPage : TabbedPage
    {
        public Admin_Orders_MainPage()
        {
            InitializeComponent();
            Children.Add(new Admin_Orders("All"));
            Children.Add(new Admin_Orders("Waiting"));
            Children.Add(new Admin_Orders("Sent"));
            Children.Add(new Admin_Orders("Fulfilled"));
            Children.Add(new Admin_Orders("Cancelled"));
        }
    }
}