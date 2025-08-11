using System;
using System.ComponentModel.DataAnnotations;

namespace AP_Films.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class YearRangeAttribute : ValidationAttribute
    {
        private readonly int min;
        private readonly int max;
        public YearRangeAttribute(int minYear, int maxYear)
        {
            min = minYear;
            max = maxYear;
        }
        public override bool IsValid(object value)
        {
            if (value is int y) return y >= min && y <= max;
            return false;
        }
    }
}