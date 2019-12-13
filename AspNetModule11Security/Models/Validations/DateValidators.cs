using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AspNetModule11Security.Models.Validations
{
    public class DateValidators : ValidationAttribute
    {
        public enum DateValidatorMode
        {
            OverNow,
            OverOrEqualToProperty
        }

        public string MinDate { get; set; }
        public string RefProperty { get; set; }
        public DateValidatorMode Mode { get; set; }

        public DateValidators(string minDate)
        {
            this.MinDate = minDate;
            this.Mode = DateValidatorMode.OverNow;
        }

        public DateValidators(string data, DateValidatorMode mode)
        {
            switch (mode)
            {
                case DateValidatorMode.OverNow:
                    this.MinDate = data;
                    break;
                case DateValidatorMode.OverOrEqualToProperty:
                    this.RefProperty = data;
                    break;
                default:
                    break;
            }
            
            this.Mode = mode;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime currentDateTime;

            if (DateTime.TryParse(value.ToString(), out currentDateTime))
            {
                if (Mode == DateValidatorMode.OverOrEqualToProperty)
                {
                    DateTime refPropertyDate;
                    Object instance = validationContext.ObjectInstance;
                    Type type = instance.GetType();
                    Object data = type.GetProperty(this.RefProperty).GetValue(instance, null);

                    if (data != null && data is DateTime)
                    {
                        refPropertyDate = (DateTime)data;
                    }
                    else
                    {
                        return new ValidationResult("Property reference date is null or not DateTime value");
                    }

                    if (DateTime.Compare(currentDateTime,refPropertyDate) >= 0)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Current DateTime is lower than min property");
                    }
                }
                else if (Mode == DateValidatorMode.OverNow)
                {
                    DateTime minDateTime;
                    if (MinDate.Equals("Now"))
                    {
                        minDateTime = DateTime.Now;
                    }
                    else
                    {
                        DateTime dt;
                        if (!DateTime.TryParse(MinDate, out dt))
                        {
                            return new ValidationResult("Cannot parse reference min date to date");
                        }
                        else
                        {
                            minDateTime = dt;
                        }
                    }
                    
                    if (DateTime.Compare(currentDateTime,minDateTime.Date) >= 0)
                    {
                        return ValidationResult.Success;
                    }
                    else
                    {
                        return new ValidationResult("Current DateTime is lower than Now or min DateTime");
                    }
                }
            }
            else
            {
                return new ValidationResult("Cannot parse to date");
            }

            return new ValidationResult("Error");
        }
    }
}