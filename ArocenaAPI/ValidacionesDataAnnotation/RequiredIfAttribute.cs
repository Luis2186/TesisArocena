using System.ComponentModel.DataAnnotations;

namespace ArocenaAPI.ValidacionesDataAnnotation
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class RequiredIfAttribute : RequiredAttribute
    {
        private string OtherProperty { get; set; }
        private object DesiredValue { get; set; }

        public RequiredIfAttribute(string otherProperty, object desiredValue)
        {
            OtherProperty = otherProperty;
            DesiredValue = desiredValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            if (otherPropertyInfo == null)
            {
                return new ValidationResult($"Property '{OtherProperty}' not found.");
            }

            var otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance);
            if (otherPropertyValue == null || otherPropertyValue.Equals(DesiredValue))
            {
                return base.IsValid(value, validationContext);
            }

            return ValidationResult.Success;
        }
    }
}
