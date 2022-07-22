using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using WaterCarriage.Channels;
using WaterCarriage.Members;
using WaterCarriage.Requirements;

namespace WaterCarriage
{
    public class WaterCarriageDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Channel, Guid> _channelRepository;
        private readonly IRepository<Requirement, Guid> _requirementRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly MemberManager _memberManager;

        public WaterCarriageDataSeederContributor(
                IRepository<Channel, Guid> channelRepository,
                IRepository<Requirement, Guid> requirementRepository,
                IMemberRepository memberRepository,
                MemberManager memberManager
            )
        {
            _channelRepository = channelRepository;
            _requirementRepository = requirementRepository;
            _memberRepository = memberRepository;
            _memberManager = memberManager;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            // Channel种子数据
            if (await _channelRepository.GetCountAsync() <= 0)
            {
                await _channelRepository.InsertAsync(
                    new Channel
                    {
                        Name = "Channel_001",
                        Type = ChannelType.Public, // 0-公开，1-专用
                        StartTime = new DateTime(2022, 05, 21),
                        EndTime = new DateTime(2082, 05, 20),
                        Ports = 110,
                    },
                    autoSave: true
                );

                await _channelRepository.InsertAsync(
                    new Channel
                    {
                        Name = "Channel_002",
                        Type = ChannelType.Public, 
                        StartTime = new DateTime(2022, 05, 21),
                        EndTime = new DateTime(2082, 05, 20),
                        Ports = 120,
                    },
                    autoSave: true
                );

                await _channelRepository.InsertAsync(
                    new Channel
                    {
                        Name = "Channel_003",
                        Type = ChannelType.Public, 
                        StartTime = new DateTime(2022, 05, 21),
                        EndTime = new DateTime(2082, 05, 20),
                        Ports = 120,
                    },
                    autoSave: true
                );
            }

            // Requirement种子数据
            if (await _requirementRepository.GetCountAsync() <= 0)
            {
                await _requirementRepository.InsertAsync(
                    new Requirement
                    {
                        Name = "Shipping_001",
                        Description = "Shipping_001",
                        PublishDate = new DateTime(2022, 7, 8),
                    },
                    autoSave: true
                );
                await _requirementRepository.InsertAsync(
                    new Requirement
                    {
                        Name = "Shipping_002",
                        Description = "Shipping_002",
                        PublishDate = new DateTime(2022, 8, 18),
                    },
                    autoSave: true
                );
                await _requirementRepository.InsertAsync(
                    new Requirement
                    {
                        Name = "Shipping_003",
                        Description = "Shipping_003",
                        PublishDate = new DateTime(2022, 9, 1),
                    },
                    autoSave: true
                );
            }

            // Member种子数据
            if (await _memberRepository.GetCountAsync() <= 0)
            {
                await _memberRepository.InsertAsync(

                    await _memberManager.CreateAsync(
                        "Json Dan",
                        "13640902988",
                        "13640902988@qq.com",
                        "1q2w3E*",
                        new DateTime(1988, 05, 20),
                        1,
                        ""
                        )
                );

                await _memberRepository.InsertAsync(

                    await _memberManager.CreateAsync(
                        "Tom",
                        "13640902981",
                        "qingyang@qq.com",
                        "1q2w3E*",
                        new DateTime(1978, 05, 20),
                        1,
                        ""
                        )
                );

                await _memberRepository.InsertAsync(

                    await _memberManager.CreateAsync(
                        "Snape",
                        "13640902982",
                        "tbg@qq.com",
                        "1q2w3E*",
                        new DateTime(1988, 05, 20),
                        1,
                        ""
                        )
                );
            }

        }
    }
}
