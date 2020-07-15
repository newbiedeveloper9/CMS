using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Cms.Domain.Entities;
using Cms.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cms.Infrastructure
{
    public class CmsContext : DbContext, IUnitOfWork
    {
        public CmsContext(DbContextOptions<CmsContext> options) : base(options)
        {
            
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await SaveChangesAsync(cancellationToken);
            return true;
        }

        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
