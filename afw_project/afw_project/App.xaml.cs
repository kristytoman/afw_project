using afw_project.Model;
using afw_project.View;
using afw_project.View_Model.Sales;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace afw_project
{
    public partial class App : Application
    {
        /// <summary>
        /// Gets or sets the current user account that is using the application.
        /// </summary>
        public static Customer User { get; set; }

        /// <summary>
        /// Gets or sets the current sale season for the prices.
        /// </summary>
        public static Type SaleSeason { get; set; }

        public App()
        {
            InitializeComponent();
            User = new Customer();
            switch (DateTime.Now.Month)
            {
                case 1:
                case 2:
                case 12:
                    SaleSeason = typeof(WinterPrice);
                    break;
                case 3:
                case 4:
                case 5:
                    SaleSeason = typeof(SpringPrice);
                    break;
                case 6:
                case 7:
                case 8:
                    SaleSeason = typeof(SummerPrice);
                    break;
                case 9:
                case 10:
                case 11:
                    SaleSeason = typeof(AutumnPrice);
                    break;
            }
            if (!ContextCredentials.GetSavedCredentials())
                MainPage = new Init();
            else
            {
                MainPage = new MainPage();
                using (Context db = new Context())
                {
                    if (db.Products.Where(p => p.Sale != 0).Any())
                    {
                        SaleSeason = typeof(AutumnPrice);
                    }
                }
            }
        }
    }
}
