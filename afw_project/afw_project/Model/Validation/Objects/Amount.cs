
namespace afw_project.Model.Validation.Objects
{
    internal class Amount : ValidatableObject
    {
        public Amount(string value) : base(value) { }



        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty { Message = "Amount input required." });
            validations.Add(new HasRightFormat { Message = "Invalid quantity format.", Format = @"-?\d+(?:\.\d +)?" });
            validations.Add(new IsBigEnough { Message = "Choose larger number", Min = 0 });
            validations.Add(new IsSmallEnough { Message = "Choose smaller number.", Max = double.MaxValue });
        }
    }
}
