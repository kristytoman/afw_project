
namespace afw_project.Model.Validation
{
    class IsBigEnough : IValidation
    {
        public string Message { get; set; }

        /// <summary>
        /// Minimum value of the input.
        /// </summary>
        public double Min { get; set; }

        public bool Check(string value)
        {
            return double.Parse(value) >= Min;
        }
    }
}
