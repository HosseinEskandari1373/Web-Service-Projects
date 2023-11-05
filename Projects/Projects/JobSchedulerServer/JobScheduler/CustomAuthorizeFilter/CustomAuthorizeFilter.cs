using Hangfire.Dashboard;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace JobSchedulerDashboard
{
    public class CustomAuthorizeFilter : IDashboardAuthorizationFilter
    {
        /*
            نمودن آن می بایست این کلاس اضافه گردد Publish هنگام HTTP 401 برای رفع ارور 
         */
        public bool Authorize([NotNull] DashboardContext context)
        {
            //var httpcontext = context.GetHttpContext();
            //return httpcontext.User.Identity.IsAuthenticated;
            return true;
        }
    }
}
