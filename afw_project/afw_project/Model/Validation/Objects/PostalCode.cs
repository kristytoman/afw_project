using System;
using System.Collections.Generic;
using System.Text;

namespace afw_project.Model.Validation.Objects
{
    class PostalCode : ValidatableObject
    {
        public PostalCode(string value) : base(value) { }



        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty { Message = "Please fill in the postal code." });
        }
    }
}
