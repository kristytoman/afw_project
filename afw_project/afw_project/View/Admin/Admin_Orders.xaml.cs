using afw_project.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace afw_project.View.Admin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Admin_Orders : ContentPage
    {
        public Admin_Orders(string name)
        {
            Title = name;
            InitializeComponent();
            BindingContext = new VM_Orders_Admin(name);
        }
    }
}