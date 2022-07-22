using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using WaterCarriage.EntityFrameworkCore;

namespace WaterCarriage.Members
{
    /// <summary>
    /// 实现IMemberRepository接口
    /// </summary>
    public class EfCoreMmberRepository : EfCoreRepository<WaterCarriageDbContext, Member, Guid>,
            IMemberRepository
    {
        public EfCoreMmberRepository(IDbContextProvider<WaterCarriageDbContext> dbContextProvider) 
            : base(dbContextProvider)
        {
        }  

        public async Task<Member> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(member => member.Name == name);
        }

        public async Task<List<Member>> GetListAsync(int skipCount, int maxResultCount, string sorting, string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    member => member.Name.Contains(filter)
                 )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
