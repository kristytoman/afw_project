using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace afw_project
{
    abstract class ValidatableObject : VM_Base
    {
        /// <summary>
        /// String value to validate
        /// </summary>
        protected string value;
        public string Value 
        { 
            get 
            { 
                return value; 
            } 
            set 
            { 
                this.value = value;
                // notifying the view about change
                OnPropertyChanged(); 
            } 
        }

        /// <summary>
        /// List of validating methods to use
        /// </summary>
        protected List<IValidation> validations;

        /// <summary>
        /// Test result boolean
        /// </summary>
        public bool isValid;

        /// <summary>
        /// Constructor for the object
        /// Creates the list of validations
        /// </summary>
        /// <param name="value">input string to validate</param>
        public ValidatableObject(string value)
        {
            this.value = value;
            validations = new List<IValidation>();
            isValid = false;
        }

        /// <summary>
        /// Adds the validation methods to test the string value.
        /// </summary>
        protected abstract void AddValidations();

        /// <summary>
        /// Run tests to validate the input
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
    }

    /// <summary>
    /// Creating test method
    /// </summary>
    interface IValidation
    {
        /// <summary>
        /// Error message to display
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Test the rule
        /// </summary>
        /// <param name="value">Input to validate</param>
        /// <returns></returns>
        bool Check(string value);
    }

    /// <summary>
    /// Rule for having a content
    /// </summary>
    public class IsNotEmpty : IValidation
    {
        public string Message { get; set; }
        public bool Check(string value)
        {
            if (value == null)
            {
                return false;
            }
            if (value == string.Empty)
            {
                return false;
            }
            return true;
        }
    }
}
