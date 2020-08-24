
using Xamarin.Forms;

namespace afw_project.View_Model
{
    internal class CartItem : VM_Base
    {
        /// <summary>
        /// view model connected to the cart item.
        /// </summary>
        private readonly VM_Cart viewModel;


        #region Item properties

        /// <summary>
        /// Gets or sets the ID of the product in the cart.
        /// </summary>
        public int ID { get; set; }


        /// <summary>
        /// Gets or sets the name of the product in the cart.
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// Amount of ordered goods of this type.
        /// </summary>
        private int amount;
        /// <summary>
        /// Gets or sets the mount of ordered goods of this type.
        /// </summary>
        public int Amount
        {
            get => amount;
            set
            {
                if (value != amount)
                {
                    amount = value;
                    if (viewModel.Price.ChangeAmount(ID, value))
                    {
                        viewModel.SetTheCosts();

                        OnPropertyChanged();
                    }
                    else
                    {
                        Application.Current.MainPage.DisplayAlert
                        (
                            "Can't order that much.", 
                            "There is not enough of this product to fulfill the requirement.", 
                            "OK"
                        );
                    }    
                }
            }
        }


        /// <summary>
        /// Original cost of the ordered goods.
        /// </summary>
        private double summedPrice;
        /// <summary>
        /// Gets or sets the original cost of the ordered goods.
        /// </summary>
        public double SummedPrice
        {
            get => summedPrice;
            set
            {
                if (value != summedPrice)
                {
                    summedPrice = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Sale of the product.
        /// </summary>
        private byte sale;
        /// <summary>
        /// Gets or sets the sale of the product in the cart.
        /// </summary>
        public byte Sale
        {
            get => sale;
            set
            {
                if (value != sale)
                {
                    sale = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Total price of all products with a sale.
        /// </summary>
        private double finalPrice;
        /// <summary>
        /// Gets or sets the total price of all products with a sale.
        /// </summary>
        public double FinalPrice
        {
            get
            {
                return finalPrice;
            }
            set
            {
                if (value != finalPrice)
                {
                    finalPrice = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion


        #region Constructors
        /// <summary>
        /// Creates a new instance for a product-order to show in the cart page.
        /// </summary>
        /// <param name="vM">View-model of the page.</param>
        /// <param name="id">ID of the product.</param>
        /// <param name="name">Name of the product.</param>
        /// <param name="amount">Amount of the product.</param>
        /// <param name="summedPrice">Price of the ordered amount of the product.</param>
        public CartItem(VM_Cart vM, int id, string name, int amount, double summedPrice)
        {
            viewModel = vM;
            ID = id;
            Name = name;
            this.amount = amount;
            SummedPrice = summedPrice;
            FinalPrice = summedPrice;
        }

        /// <summary>
        /// Creates a new instance for a product-order to show in the cart page.
        /// </summary>
        /// <param name="vM">View-model of the page.</param>
        /// <param name="id">ID of the product.</param>
        /// <param name="name">Name of the product.</param>
        /// <param name="amount">Amount of the product.</param>
        /// <param name="summedPrice">Price of the ordered amount of the product.</param>
        /// <param name="sale">Sale for the ordered product.</param>
        /// <param name="finalPrice">Price for the ordered product.</param>
        public CartItem(VM_Cart vM, int id, string name, int amount, double summedPrice, byte sale, double finalPrice) : this(vM, id, name, amount, summedPrice)
        {
            Sale = sale;
            FinalPrice = finalPrice;
        }
        #endregion
    }
}
