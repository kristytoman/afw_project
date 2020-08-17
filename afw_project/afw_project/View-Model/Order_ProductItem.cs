
namespace afw_project.View_Model
{
    internal class Order_ProductItem
    {
        #region Item properties
        public string Name { get; private set; }
        public string ProductAmount { get; private set; }
        public string OriginalPrice { get; private set; }
        public string Sale { get; private set; }
        public string FinalPrice { get; private set; }
        #endregion


        #region Constructor
        public Order_ProductItem(string name, string amount, string originalPrice, string sale, string finalPrice)
        {
            Name = name;
            ProductAmount = amount; 
            OriginalPrice = originalPrice;
            if (sale != "0 %")
            {
                Sale = sale;
            }
            FinalPrice = finalPrice;
        }
        #endregion
    }
}
