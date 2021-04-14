using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Domain.Repositories.MSSQL
{
    public class BaseContextRepository
    {
        protected readonly ArdTestContext context;
        public BaseContextRepository(ArdTestContext context)
        {
            this.context = context;
        }
    }
}
