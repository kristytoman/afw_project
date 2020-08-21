using afw_project.Model;
using afw_project.View_Model.Sales;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    class VM_Sales : VM_Base
    {
        #region Fields and properties

        /// <summary>
        /// Bindable property that gets or sets the list of products from the databse to set autumn sale for.
        /// </summary>
        public List<ProductItem> List_products { get; set; }

        /// <summary>
        /// True if is the autumn season, false if it's other season.
        /// </summary>
        private bool isAutumn;

        /// <summary>
        /// Bindable property that gets or sets whether the autumn sale is choosen.
        /// </summary>
        public bool IsAutumn 
        {
            get => isAutumn;
            set
            {
                if (value!=isAutumn)
                {
                    isAutumn = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Bindable property that gets or sets the command for the set sale button.
        /// </summary>
        public Command Command_SetSale { get; set; }

        /// <summary>
        /// Bindable property that gets or sets the item selected from the picker.
        /// </summary>
        public string ItemSelected { get; set; }

        #endregion


        #region Constructor
        /// <summary>
        /// Creates a new view-model for admin's sale page.
        /// </summary>
        public VM_Sales()
        {
            if (App.SaleSeason == typeof(AutumnPrice))
                IsAutumn = true;
            else IsAutumn = false;
            
            List_products = Product.GetAll();
            Command_SetSale = new Command(SetSale);
        }
        #endregion



        #region Methods

        /// <summary>
        /// Sets a new sale season for the e-shop.
        /// </summary>
        public void SetSale()
        {
            bool reset = App.SaleSeason == typeof(AutumnPrice);
            switch (ItemSelected)
            {
                case "Spring season":
                    App.SaleSeason = typeof(SpringPrice);
                    break;
                case "Summer season":
                    App.SaleSeason = typeof(SummerPrice);
                    break;
                case "Autumn season":
                    App.SaleSeason = typeof(AutumnPrice);
                    IsAutumn = true;
                    return;
                case "Winter season":
                    App.SaleSeason = typeof(WinterPrice);
                    break;
                default:
                    return;
            }
            if (reset)
            {
                IsAutumn = false;
                Product.ResetSale();
            }
        }

        #endregion
    }
}
