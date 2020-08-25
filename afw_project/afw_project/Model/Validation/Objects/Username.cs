
namespace afw_project.Model.Validation.Objects
{
    internal class Username : ValidatableObject
    {
        public Username(string value) : base(value) { }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty { Message = "Username input required." });
            validations.Add(new HasRightFormat { Message = "Invalid username format.", Format = @"^[\p{L}\p{M}\d\s]+$" });
            validations.Add(new HasRightEnding { Message = "Invalid username ending.", End = @"[^\s]$" });
            validations.Add(new IsShortEnough { Message = "Username input is too long.", Max = 250 });
        }
    }
}
