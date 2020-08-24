using System;
using System.Collections.Generic;
using System.Text;

namespace afw_project.Model.Validation.Objects
{
    class Country : ValidatableObject
    {
        public Country(string value) : base(value) { }
        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty { Message = "Country input required." });
            validations.Add(new IsCountry { Message = "Select a country from the list." });
        }
    }
}
