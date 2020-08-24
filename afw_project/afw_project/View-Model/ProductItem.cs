using afw_project.Model;
using System;

namespace afw_project.View_Model
{
    public class ProductItem : VM_Base
    {
        #region Item properties
        /// <summary>
        /// Bindable property that gets or sets the ID of the product.
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Bindable property that gets or sets the name of the product.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Bindable property that gets or sets the amount of the product.
        /// </summary>
        public string Amount { get; set; }

        /// <summary>
        /// Price of the product.
        /// </summary>
        private readonly double price;

        /// <summary>
        /// Bindable property that gets or sets the price of the product.
        /// </summary>
        public string Price { get; set; }

        /// <summary>
        /// Bindable property that gets or sets the sale of the product.
        /// </summary>
        public string Sale { get; set; }

        /// <summary>
        /// Sale of the product
        /// </summary>
        private byte sale;

        /// <summary>
        /// Bindable property that gets or sets the sale of the product.
        /// </summary>
        public byte Entry_Sale
        {
            get => sale;
            set
            {
                if (value != sale)
                {
                    sale = value;
                    Product.SetSale(ID, sale);
                    FinalPrice = (price - price * sale / 100).ToString();
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Final price of the product.
        /// </summary>
        private string finalPrice;

        /// <summary>
        /// Bindable property that gets or sets the final price of the product.
        /// </summary>
        public string FinalPrice 
        {
            get => finalPrice;
            set
            {
                if (value!= finalPrice)
                {
                    finalPrice = value;
                    OnPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Shortened description of the product.
        /// </summary>
        private readonly string shortDescription;

        /// <summary>
        /// Whole description of the product.
        /// </summary>
        private readonly string longDescription;

        /// <summary>
        /// Bindable property that gets the description of the product.
        /// </summary>
        public string Description => isSelected ? longDescription : shortDescription;

        /// <summary>
        /// Defines whether the item is selected or not.
        /// </summary>
        private bool isSelected;

        /// <summary>
        /// Bindable property that gets or sets the information if the product is selected.
        /// </summary>
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                isSelected = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Bindable property that gets or sets the category of the product.
        /// </summary>
        public string Category { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a product item from a template.
        /// </summary>
        /// <param name="template">Product item.</param>
        public ProductItem(Product template)
        {
            ID = template.ID;
            Name = template.Name;
            Amount = template.Amount.ToString() + " pcs";
            price = template.Price;
            Price = template.Price.ToString() + " EUR";
            Sale = template.Sale != 0 ? template.Sale.ToString() + " %" : "";
            Category = template.Category.Name;
            shortDescription = template.Description.Substring(0, template.Description.Length < 50 ? template.Description.Length : 50);
            longDescription = template.Description;
            FinalPrice = Math.Round((double)(template.Price - template.Price * template.Sale / 100), 2).ToString() + " EUR";
            isSelected = false;
        }


        /// <summary>
        /// Creates an ordered product item.
        /// </summary>
        /// <param name="template">Product item.</param>
        /// <param name="amount">Amount of ordered products.</param>
        /// <param name="sale">Sale of the product/</param>
        public ProductItem(Product template, int amount, int sale) : this(template)
        {
            Amount = amount.ToString();
            Sale = sale.ToString();
        }
        #endregion
    }
}
