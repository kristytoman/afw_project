using System;
using System.Collections.Generic;
using System.Text;

namespace afw_project.Model.Validation.Objects
{
    class Cost : ValidatableObject
    {
        public Cost(string value) : base(value) { }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty { Message = "Input Required." });
        }
    }
}
