
namespace afw_project.Model.Validation.Objects
{
    class StreetName : ValidatableObject
    {
        public StreetName(string value) : base(value) { }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty { Message = "Street name required." });
            validations.Add(new HasRightFormat { Message = "Invalid street name format.", Format = @"^[\p{L}\p{M}\d\s,\.\-']+$" });
            validations.Add(new IsShortEnough { Message = "Street name is too long.", Max = 250 });
        }
    }
}
