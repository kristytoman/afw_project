using afw_project.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace afw_project.View_Model
{
    class OrderItem : ObservableCollection<Order_ProductItem>, INotifyPropertyChanged
    {
        private readonly bool isAdmin;
        
        #region Item properties
        public int ID { get; set; }
        public string OrderPrice { get; set; }

        private OrderStateType orderState;
        public string OrderState
        {
            get => orderState.ToString();
            set
            {

                if (int.TryParse(value, out int input) && (OrderStateType)input != orderState)
                {
                    orderState = (OrderStateType)input;
                    OnPropertyChanged();
                }
            }
        }
        #endregion


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
                    orderState = OrderStateType.Waiting;
                }
                else
                {
                    orderState = template.SendTime == DateTime.MinValue ? OrderStateType.Cancelled : OrderStateType.Shipped;
                }
            }
            else
            {
                orderState = OrderStateType.Fulfilled;
            }

            Command_cancel = new Command(CancelOrder);
            if (isAdmin)
            {
                Command_change = new Command(ChangeTheOrderState);
            }
        }
        #endregion



        #region Button command

        /// <summary>
        /// Defines whether the button for cancelling is visible.
        /// </summary>
        public bool IsVisible => isAdmin && OrderState != "Cancelled" && OrderState != "Fulfilled";

        /// <summary>
        /// Defines the name of the continue button.
        /// </summary>
        public string ButtonName
        {
            get
            {
                if (OrderState == "Waiting") return "Send";
                if (OrderState == "Send") return "Received";
                return "";
            }
        }

        /// <summary>
        /// Defines whether an item is cancelable or not.
        /// </summary>
        public bool IsCancelable => OrderState == OrderStateType.Waiting.ToString();

        /// <summary>
        /// Command to cancel an order.
        /// </summary>
        public Command Command_cancel { get; private set; }
        
        /// <summary>
        /// Command to change order state.
        /// </summary>
        public Command Command_change { get; private set; }



        /// <summary>
        /// Cancels the order.
        /// </summary>
        public void CancelOrder()
        {
            Order.CancelTheOrder(ID);
            OrderState = "4";
        }



        /// <summary>
        /// Changes the order state.
        /// </summary>
        public void ChangeTheOrderState()
        {
            if (orderState == OrderStateType.Waiting)
            {
                Order.SendTheOrder(ID);
                OrderState = "2";
            }
            if (orderState == OrderStateType.Shipped)
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
