using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.AppServices.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }

        public DateTime GetUtcDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}
