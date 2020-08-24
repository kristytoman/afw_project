
namespace afw_project.Model.Validation.Objects
{
    class Surname : ValidatableObject
    {
        public Surname(string value) : base(value) { }



        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty { Message = "Surame input required." });
            validations.Add(new HasRightFormat { Message = "Invalid surname format.", Format = @"^[\p{L}\p{M}\s,\.\-']+$" });
            validations.Add(new HasRightEnding { Message = "Invalid surname ending.", End = @"[^\s-]$" });
            validations.Add(new IsShortEnough { Message = "Surname input is too long.", Max = 250 });
        }
    }
}
