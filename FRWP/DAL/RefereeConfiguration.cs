using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.Interception;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using FRWP.DAL;

namespace FRWP.DAL
{
    public class RefereeConfiguration : DbConfiguration
    {
        public RefereeConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
            DbInterception.Add(new RefereeInterceptorTransientErrors());
            DbInterception.Add(new RefereeInterceptorLogging());
        }
    }
}