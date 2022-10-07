using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using TwoHr.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace TwoHr.Employees
{
    public class EfCoreEmployeeRepository : EfCoreRepository<TwoHrDbContext, Employee, Guid>, IEmployeeRepository
    {
        public EfCoreEmployeeRepository( IDbContextProvider<TwoHrDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Employee> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(x => x.Name == name);
        }

        public async Task<List<Employee>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();

            return await dbSet.WhereIf(!filter.IsNullOrWhiteSpace(), x => x.Name.Contains(filter))
                .OrderBy<Employee>(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
