
namespace afw_project.Model.Validation
{
    class IsLongEnough : IValidation
    {
        public string Message { get; set; }

        /// <summary>
        /// Minimum lenght of the input.
        /// </summary>
        public int Min { get; set; }

        public bool Check(string value)
        {
            return value.Length >= Min;
        }
    }
}
