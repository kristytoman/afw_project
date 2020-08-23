using System;
using System.Collections.Generic;
using System.Text;

namespace afw_project.Model.Validation.Objects
{
    class CityName : ValidatableObject
    {
        public CityName(string value) : base(value) { }



        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty { Message = "Please fill in the city address." });
        }
    }
}
