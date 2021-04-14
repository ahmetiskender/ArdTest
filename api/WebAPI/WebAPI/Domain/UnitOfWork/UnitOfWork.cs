using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Domain.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ArdTestContext context;
        public UnitOfWork(ArdTestContext context)
        {
            this.context = context;
        }
        public async Task CompleteAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}