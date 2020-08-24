
namespace afw_project.Model.Validation.Objects
{
    class PostalCode : ValidatableObject
    {
        public PostalCode(string value) : base(value) { }



        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty { Message = "Postal code input required." });
            validations.Add(new HasRightFormat { Message = "Invalid postal code format.", Format = @"^[\d\s\-]+$" });
            validations.Add(new HasRightStart { Message = "Invalid input beginning.", Start = @"^\d+" });
            validations.Add(new HasRightEnding { Message = "Invalid input ending.", End = @"[^\s-]$" });
            validations.Add(new IsShortEnough { Message = "Input is too long.", Max = 12 });
        }
    }
}
