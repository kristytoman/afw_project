using afw_project.View_Model;
using System;
using System.Linq;

namespace afw_project.Model.Validation
{
    class IsCountry : IValidation
    {
        public string Message { get; set; }

        public bool Check(string value)
        {
            return VM_CustomerForm.Countries.Contains(value);
        }
    }
}
