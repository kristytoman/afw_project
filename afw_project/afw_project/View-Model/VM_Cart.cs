using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace afw_project.View_Model
{
    class VM_Cart : VM_Base
    {
        public ObservableCollection<Product> Cart_products { get; set; }
    }
}
