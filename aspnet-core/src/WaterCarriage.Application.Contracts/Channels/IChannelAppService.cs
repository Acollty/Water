using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace WaterCarriage.Channels
{
    /// <summary>
    /// 定义航道服务接口
    /// </summary>
    public interface IChannelAppService :
        ICrudAppService<
            ChannelDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateChannelDto>
    {
    }
}
