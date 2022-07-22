using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using WaterCarriage.Permissions;

namespace WaterCarriage.Channels
{
    public class ChannelAppService :
        CrudAppService<
            Channel,
            ChannelDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateChannelDto>,
        IChannelAppService
    {
        public ChannelAppService(IRepository<Channel, Guid> repository) :
            base(repository)
        {
            GetPolicyName = WaterCarriagePermissions.Channels.Default; 
            GetListPolicyName = WaterCarriagePermissions.Channels.Default;
            CreatePolicyName = WaterCarriagePermissions.Channels.Create;
            UpdatePolicyName = WaterCarriagePermissions.Channels.Edit;
            DeletePolicyName = WaterCarriagePermissions.Channels.Delete;
        }
    }
}
