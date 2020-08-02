using System;
using System.Text.RegularExpressions;

namespace afw_project.View_Model.Validation
{
    class Building : ValidatableObject
    {
        /// <summary>
        /// Creates new object to validate the building number. 
        /// </summary>
        /// <param name="value">Building number input.</param>
        public Building(string value) : base(value)
        {
            AddValidations();
        }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty() { Message = "Please fill in your building number" });
            validations.Add(new IsValid() { Message = "Invalid building number" });
        }
        
    }
    class IsValid : IValidation
    {
        public string Message { get; set; }

        public bool Check(string value)
        {
            try
            {
                if (Regex.IsMatch(value, @"^[0-9a-zA-Z \-/]{1,}$")) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
