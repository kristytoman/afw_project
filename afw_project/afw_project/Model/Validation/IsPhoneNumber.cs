using System;
using System.Text.RegularExpressions;

namespace afw_project.Model.Validation
{
    public class IsPhoneNumber : IValidation
    {
        public string Message { get; set; }

        public bool Check(string value)
        {
            try
            {
                if (Regex.IsMatch(value, @"^\+[0-9]{7,15}$")) return true;
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
