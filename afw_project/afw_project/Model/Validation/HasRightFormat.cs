using System;
using System.Text.RegularExpressions;

namespace afw_project.Model.Validation
{
    class HasRightFormat : IValidation
    {
        public string Message { get; set; }

        public string Format { get; set; }

        public bool Check(string value)
        {
            try
            {
                if (Regex.IsMatch(value, Format))
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
