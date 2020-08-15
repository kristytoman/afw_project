using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace afw_project.View_Model
{
    class VM_Orders_Customer : VM_Base
    {
        public ObservableCollection<Order> Orders { get; set; }
    }
}
