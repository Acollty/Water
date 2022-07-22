using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace WaterCarriage.Channels
{
    public class ChannelAppService_Tests : WaterCarriageApplicationTestBase
    {
        private readonly IChannelAppService _channelAppService;

        public ChannelAppService_Tests()
        {
            _channelAppService = GetRequiredService<IChannelAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Channels()
        {
            //Act
            var result = await _channelAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
            );

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(b => b.Name == "channel_001");
        }

        /// <summary>
        /// 创建有效航道
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_Create_A_Valid_Channel()
        {
            //Act
            var result = await _channelAppService.CreateAsync(
                new CreateUpdateChannelDto
                {
                    Name = "channel_005",
                    Ports = 12,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now,
                    Type = ChannelType.Public
                }
            );

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("channel_005");
        }

        /// <summary>
        /// 创建一个无效且失败的航道
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Should_Not_Create_A_Channel_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _channelAppService.CreateAsync(
                    new CreateUpdateChannelDto
                    {
                        Name = "",
                        Ports = 12,
                        StartTime = DateTime.Now,
                        EndTime = DateTime.Now,
                        Type = ChannelType.Public
                    }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
        }
    }
}
