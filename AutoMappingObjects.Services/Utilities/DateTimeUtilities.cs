using System;
using System.Collections.Generic;
using System.Text;

namespace AutoMappingObjects.Services.Utilities
{
    public static class DateTimeUtilities
    {
        public static int CalculateAge(DateTime? birthday)
        {
            var todayYear = DateTime.Today.Year;
            var todayMonth = DateTime.Today.Month;
            var todayDay = DateTime.Today.Day;

            var birthdayYear = birthday.Value.Year;
            var birthdayMonth = birthday.Value.Month;
            var birthdayDay = birthday.Value.Day;

            var age = todayYear - birthdayYear;

            if ((todayMonth < birthdayMonth) ||
                (todayMonth == birthdayMonth && todayDay < birthdayDay)
                )
            {
                age--;
            }

            return age;
        }
    }
}
