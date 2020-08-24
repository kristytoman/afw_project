
namespace afw_project.Model.Validation.Objects
{
    class Cost : ValidatableObject
    {
        public Cost(string value) : base(value) { }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty { Message = "Price input required." });
            validations.Add(new HasRightFormat { Message = "Invalid price format.", Format = @"^[\.0-9]+$" });
            validations.Add(new HasRightStart { Message = "Invalid price beginning.", Start = @"^[0-9]+" });
            validations.Add(new HasRightEnding { Message = "Invalid price ending.", End = @"[0-9]+$" });
            validations.Add(new IsBigEnough { Message = "Price is too small.", Min = 0.01 });
            validations.Add(new IsSmallEnough { Message = "Price is too large.", Max = double.MaxValue });
        }
    }
}
