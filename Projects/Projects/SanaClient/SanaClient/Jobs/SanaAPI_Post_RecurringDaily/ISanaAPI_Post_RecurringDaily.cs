using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SanaClient.Jobs.SanaAPI_Post_Recurring3H
{
    public interface ISanaAPI_Post_RecurringDaily
    {
        Task<object> Create();
    }
}
