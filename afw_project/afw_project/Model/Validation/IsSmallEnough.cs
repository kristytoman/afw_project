
namespace afw_project.Model.Validation
{
    class IsSmallEnough : IValidation
    {
        public string Message { get; set; }

        public double Max { get; set; }

        public bool Check(string value)
        {
            return int.Parse(value) <= Max;
        }
    }
}
