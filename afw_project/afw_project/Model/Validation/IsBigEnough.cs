﻿using System;
using System.Collections.Generic;
using System.Text;

namespace afw_project.Model.Validation.Objects
{
    class IsBigEnough : IValidation
    {
        public string Message { get; set; }

        /// <summary>
        /// Minimum value of the input.
        /// </summary>
        public double Min { get; set; }

        public bool Check(string value)
        {
            return double.Parse(value) >= Min;
        }
    }
}
