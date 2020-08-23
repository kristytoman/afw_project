using System.Collections.Generic;

namespace afw_project.Model.Validation.Objects
{
    abstract class ValidatableObject
    {
        #region Properties and fields
        /// <summary>
        /// Gets or sets the string value to validate.
        /// </summary>
        public string Value{ get; private set; }

        /// <summary>
        /// List of validating methods to use.
        /// </summary>
        protected List<IValidation> validations;

        /// <summary>
        /// The result of the validation tests.
        /// </summary>
        public bool isValid;
        #endregion


        #region Constructor
        /// <summary>
        /// Constructor for the object.
        /// Creates the list of validations.
        /// </summary>
        /// <param name="value">Input string to validate.</param>
        public ValidatableObject(string value)
        {
            Value = value;
            validations = new List<IValidation>();
            isValid = false;
            AddValidations();
        }
        #endregion



        #region Methods
        /// <summary>
        /// Adds the validation methods to test the string value.
        /// </summary>
        protected abstract void AddValidations();



        /// <summary>
        /// Run tests to validate the input.
        /// </summary>
        /// <returns>The error message or empty string if the testing was succesful.</returns>
        public string Validate()
        {
            foreach(IValidation test in validations)
            {
                if (!test.Check(Value))
                {
                    return test.Message;
                }
            }
            isValid = true;
            return "";
        }
        #endregion
    }
}
