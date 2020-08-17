using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    class OrderItem : ObservableCollection<Order_ProductItem>, INotifyPropertyChanged
    {
        public int ID { get; set; }
        public string OrderPrice { get; set; }

        private Enum_OrderState orderState;
        public string OrderState
        {
            get => orderState.ToString();
            set
            {

                if (int.TryParse(value, out int input) && (Enum_OrderState)input != orderState)
                {
                    orderState = (Enum_OrderState)input;
                    OnPropertyChanged();
                }
            }
        }

        private readonly bool isAdmin;

        public bool IsVisible => isAdmin && OrderState != "Cancelled" && OrderState != "Fulfilled";

        public string ButtonName
        {
            get
            {
                if (OrderState == "Ordered") return "Send";
                if (OrderState == "Send") return "Received";
                return "";
            }
        }
        public bool IsCancelable => OrderState == Enum_OrderState.Ordered.ToString();

        #region Constructor
        public OrderItem(Order template, bool isAdmin)
        {
            this.isAdmin = isAdmin;
            ID = template.ID;
            OrderPrice = template.Price.ToString()+ " EUR";

            if (template.ReceivedTime == null)
            {
                if (template.SendTime == null)
                {
                    orderState = Enum_OrderState.Ordered;
                }
                else
                {
                    orderState = template.SendTime == DateTime.MinValue ? Enum_OrderState.Cancelled : Enum_OrderState.Shipped;
                }
            }
            else
            {
                orderState = Enum_OrderState.Fulfilled;
            }

            Command_cancel = new Command(CancelOrder);
            if (isAdmin)
            {
                Command_change = new Command(ChangeTheOrderState);
            }
        }
        #endregion

        #region Button command
        public Command Command_cancel { get; private set; }

        public void CancelOrder()
        {
            Order.CancelTheOrder(ID);
            OrderState = "4";
        }

        public Command Command_change { get; private set; }

        public void ChangeTheOrderState()
        {
            if (orderState == Enum_OrderState.Ordered)
            {
                Order.SendTheOrder(ID);
                OrderState = "2";
            }
            if (orderState == Enum_OrderState.Shipped)
            {
                Order.FulfillTheOrder(ID);
                OrderState = "3";
            }
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
}
