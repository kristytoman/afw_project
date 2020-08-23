using System;
using System.Text.RegularExpressions;

namespace afw_project.Model.Validation
{
    class HasRightEnding : IValidation
    {
        public string Message { get; set; }

        public string End { get; set; }

        public bool Check(string value)
        {
            try
            {
                if (Regex.IsMatch(value, End))
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
