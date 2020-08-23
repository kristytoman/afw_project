
namespace afw_project.Model.Validation
{
    class IsShortEnough : IValidation
    {
        public string Message { get; set; }

        /// <summary>
        /// Maximum lenght of input.
        /// </summary>
        public int Max { get; set; }

        public bool Check(string value)
        {
            return value.Length <= Max;
        }
    }
}
