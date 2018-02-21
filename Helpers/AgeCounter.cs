using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class AgeCounter
    {
        public static int GetAgeByBirthdate(DateTime BirthDate)
        {
            DateTime TodayDate = DateTime.Now;

            int YearsPassed = TodayDate.Year - BirthDate.Year;
            if (TodayDate.Month < BirthDate.Month || (TodayDate.Month == BirthDate.Month && TodayDate.Day < BirthDate.Day))
            {
                YearsPassed--;
            }
            return YearsPassed;
        }
    }
}
