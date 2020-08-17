using System;
using System.Text.RegularExpressions;

namespace afw_project.Model.Validation.Objects
{
    class IsSupported : IValidation
    {
        public string Message { get; set; }

        public bool Check(string value)
        {
            try
            {
                if (Regex.IsMatch(value, @"[\p{L}\p{M}- ]{2,}"))
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
