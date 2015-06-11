using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

using PI.Pimail.Models;

namespace PI.Pimail.Tests
{
    class TestPimailContext : IPimailContext
    {
        public TestPimailContext()
        {
            this.Emails = new TestPimailDbSet();
        }
        
        public DbSet<Email> Emails { get; set; }

        //public IQueryable<Email> Emails { get { return DbEmails; } set { DbEmails = (DbSet<Email>)value; } }

        public int SaveChanges()
        {
            return 0;
        }

        public async Task<int> SaveChangesAsync()
        {
            await Task.Delay(1);
            return 0;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            await Task.Delay(1);
            return 0;
        }

        public void MarkAsModified(object item) { }
        public void Dispose() { }
    }
}
