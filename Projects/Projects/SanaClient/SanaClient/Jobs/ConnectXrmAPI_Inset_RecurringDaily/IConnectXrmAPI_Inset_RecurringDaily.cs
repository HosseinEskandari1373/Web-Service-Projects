using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SanaClient.Jobs.ConnectXrmAPI_Inset_RecurringDaily
{
    public interface IConnectXrmAPI_Inset_RecurringDaily
    {
        Task<object> Insert();
    }
}
