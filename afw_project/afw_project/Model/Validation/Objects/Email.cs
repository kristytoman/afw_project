
namespace afw_project.Model.Validation.Objects
{
    class Email : ValidatableObject
    {
        /// <summary>
        /// Object for validating e-mail input.
        /// </summary>
        /// <param name="value">E-mail input value.</param>
        public Email(string value) : base(value) { }

        protected override void AddValidations()
        {
            validations.Add(new IsNotEmpty() { Message = "Email address is required." });
            validations.Add(new HasRightFormat() { Message = "Not supported email address", Format= @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$" });
            validations.Add(new IsUnique() { Message = "Email address already exists in our eshop" });
        }
    }
}
