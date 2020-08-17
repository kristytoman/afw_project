namespace afw_project.View_Model
{
    internal class Order_ProductItem
    {
        public string Name { get; private set; }
        public string ProductAmount { get; private set; }
        public string OriginalPrice { get; private set; }
        public string Sale { get; private set; }
        public string FinalPrice { get; private set; }
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
    }
}
