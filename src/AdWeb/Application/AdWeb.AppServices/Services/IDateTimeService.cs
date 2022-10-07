using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdWeb.AppServices.Services
{
    public interface IDateTimeService
    {
        DateTime GetDateTime();

        DateTime GetUtcDateTime();
    }
}
