using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Application.Dtos;

namespace WaterCarriage.Members
{

    public interface IMemberAppService: IApplicationService
    {
        Task<MemberDto> GetAsync(Guid id);

        Task<PagedResultDto<MemberDto>> GetListAsync(GetMemberListDto input);

        Task<MemberDto> CreateAsync(CreateMemberDto input);

        Task UpdateAsync(Guid id, UpdateMemberDto input);

        Task DeleteAsync(Guid id);
    }
}
