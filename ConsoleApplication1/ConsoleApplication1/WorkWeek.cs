using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApplication1
{
    public class WorkWeek
    {






        public WorkWeek(string monday, string tuesday, string wednesday, string thursday, string friday,
            string saturday, string sunday, int payrate)
        {

            PayRate = payrate;
            Monday = monday;
            Tuesday = tuesday;
            Wednesday = wednesday;
            Thursday = thursday;
            Friday = friday;
            Saturday = saturday;
            Sunday = sunday;

        }

        public static decimal CalculatePay(Users currentUsers)
       {

            decimal weekPay = (Convert.ToDecimal(Monday) +
                               (Convert.ToDecimal(Tuesday) +
                                (Convert.ToDecimal(Wednesday) +
                                 (Convert.ToDecimal(Thursday) +
                                  (Convert.ToDecimal(Friday) * (PayRate))))));

            decimal weekendPay = ((Convert.ToDecimal(value: Saturday) * PayRate * (decimal)0.015f) +
                                  (Convert.ToDecimal(value: Sunday) * PayRate * (decimal)0.02f));

            decimal totalPay = weekPay + weekendPay;
            return totalPay;

        }



        public static int PayRate { get; set; }

        
        public static string Monday { set; get; }
        public static string Tuesday { set; get; }
        public static string Wednesday { set; get; }
        public static string Thursday { set; get; }
        public static string Friday { set; get; }
        public static string Saturday { set; get; }
        public static string Sunday { set; get; }

        public List<WorkWeek> WorkList { set; get; }



    }
}