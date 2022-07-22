using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace WaterCarriage.Members
{
    /// <summary>
    /// 定义Member仓储接口
    /// </summary>
    public interface IMemberRepository : IRepository<Member, Guid>
    {
        Task<Member> FindByNameAsync(string name);
        Task<List<Member>> GetListAsync(
                int skipCount,
                int maxResultCount,
                string sorting,
                string filter = null
            );
    }
}
