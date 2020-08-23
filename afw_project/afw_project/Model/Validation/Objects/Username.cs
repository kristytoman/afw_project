using System;
using System.Collections.Generic;
using System.Text;

namespace afw_project.Model.Validation.Objects
{
    internal class Username : ValidatableObject
    {
        public Username(string value) : base(value) { }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty { Message = "Input required." });
        }
    }
}
