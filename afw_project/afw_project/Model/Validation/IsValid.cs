using System;
using System.Text.RegularExpressions;

namespace afw_project.Model.Validation
{
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
