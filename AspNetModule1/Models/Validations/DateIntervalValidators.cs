using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetModule1.Models.Validations
{
    public class DateIntervalValidators : ValidationAttribute
    {
        public string MinProperty { get; set; }
        public string MaxProperty { get; set; }

        public DateIntervalValidators(string minProperty, string maxProperty)
        {
            this.MinProperty = minProperty;
            this.MaxProperty = maxProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime minPropertyDate;
            Object instanceMin = validationContext.ObjectInstance;
            Type typeMin = instanceMin.GetType();
            Object dataMin = typeMin.GetProperty(this.MinProperty).GetValue(instanceMin, null);
            if (dataMin != null && dataMin is DateTime)
            {
                minPropertyDate = (DateTime)dataMin;
            }
            else
            {
                return new ValidationResult("Property reference date is null or not DateTime value");
            }

            DateTime maxPropertyDate;
            Object instanceMax = validationContext.ObjectInstance;
            Type typeMax = instanceMax.GetType();
            Object dataMax = typeMax.GetProperty(this.MaxProperty).GetValue(instanceMax, null);
            if (dataMax != null && dataMax is DateTime)
            {
                maxPropertyDate = (DateTime)dataMax;
            }
            else
            {
                return new ValidationResult("Property reference date is null or not DateTime value");
            }

            if (!(DateTime.Compare(maxPropertyDate,minPropertyDate) >= 0))
            {
                return new ValidationResult("Min DateTime is higher than Max DateTime");
            }

            int data;
            if (int.TryParse(value.ToString(),out data))
            {
                if (data <= 0)
                {
                    return new ValidationResult("Data cannot be less or equals than 0");
                }
                if (data <= (maxPropertyDate - minPropertyDate).TotalDays)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Less than days between dates");
                }
            }
            else
            {
                return new ValidationResult("Data is not an int value");
            }
        }
    }
}