using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    public enum Enum_OrderState
    {
        Ordered,
        Shipped,
        Fulfilled, 
        Cancelled
    }
    class Order_ProductItem
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
    class OrderItem : ObservableCollection<Order_ProductItem>, INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string OrderPrice { get; set; }
        public string OrderState { get; set; }
        public bool IsCancelable
        {
            get
            {
                return OrderState == Enum_OrderState.Ordered.ToString();
            }
        }

        #region Constructor
        public OrderItem(Order template)
        {
            ID = template.ID;
            OrderPrice = template.Price.ToString()+ " EUR";

            if (template.ReceivedTime != null)
            {
                OrderState = Enum_OrderState.Fulfilled.ToString();
            }
            else if (template.SendTime != null)
            {
                if (template.SendTime == DateTime.MinValue)
                {
                    OrderState = Enum_OrderState.Cancelled.ToString();
                }
                else
                {
                    OrderState = Enum_OrderState.Shipped.ToString();
                }
            }
            else
            {
                OrderState = Enum_OrderState.Ordered.ToString();
            }

            Command_cancel = new Command(CancelOrder);
        }
        #endregion

        #region Button command
        public Command Command_cancel { get; set; }

        public void CancelOrder()
        {
            Order.CancelTheOrder(ID);
        }
        #endregion

        #region NotifyPropertyChanged

        public new event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Alerts the changing of property.
        /// </summary>
        /// <param name="propertyName">Name of calling property.</param>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    class VM_Orders_Customer : VM_Base
    {
        public List<OrderItem> Orders { get; private set; }
        public VM_Orders_Customer()
        {
            List<Order> result = App.User.GetOrders();
            Orders = new List<OrderItem>();
            if (result!=null)
            {
                foreach(Order item in result)
                {
                    OrderItem oi = new OrderItem(item);
                    foreach (ProductOrder product in item.GetOrderProducts())
                    {
                        oi.Add
                        (
                            new Order_ProductItem
                            (
                                product.Product.Name,
                                product.Amount.ToString() + " pcs",
                                product.Product.Price.ToString() + " EUR",
                                product.Sale.ToString() + " %",
                                ((product.Product.Price - product.Product.Price * product.Sale) * product.Amount).ToString()+" EUR"
                            )
                        );
                    }
                    Orders.Add(oi);
                }
            }
        }
    }
}
