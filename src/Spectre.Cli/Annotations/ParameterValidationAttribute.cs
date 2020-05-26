using System;

// ReSharper disable once CheckNamespace
namespace Spectre.Cli
{
    /// <summary>
    /// An base class attribute used for parameter validation.
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public abstract class ParameterValidationAttribute : Attribute
    {
        /// <summary>
        /// Gets the validation error message.
        /// </summary>
        /// <value>The validation error message.</value>
        public string ErrorMessage { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParameterValidationAttribute"/> class.
        /// </summary>
        /// <param name="errorMessage">The validation error message.</param>
        protected ParameterValidationAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        /// <summary>
        /// Validates the parameter value.
        /// </summary>
        /// <param name="value">The parameter value.</param>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The validation result.</returns>
        public abstract ValidationResult Validate(object? value, string propertyName);
    }
}