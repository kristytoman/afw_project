
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
                    viewModel.Price.ChangeProductPrice(ID, value); 
                    viewModel.SetTheCosts();

                    OnPropertyChanged();
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


        public CartItem() { }



        /// <summary>
        /// Sends the new amount of the item to the model.
        /// </summary>
        public void ChangeTheAmount()
        {
            App.Cart.ChangeAmountOfProduct(ID, Amount);
        }
    }
}
