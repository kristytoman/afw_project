using System;
using System.Collections.Generic;
using System.Text;

namespace afw_project.Model.Validation.Objects
{
    class ProductName : ValidatableObject
    {
        public ProductName(string value) : base(value) { }



        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty { Message = "Please fill in the product name." });
        }
    }
}
