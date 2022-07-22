    using AutoMapper;
using WaterCarriage.Channels;
using WaterCarriage.Members;
using WaterCarriage.Requirements;

namespace WaterCarriage;

public class WaterCarriageApplicationAutoMapperProfile : Profile
{
    public WaterCarriageApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Channel, ChannelDto>();
        CreateMap<CreateUpdateChannelDto, Channel>();

        CreateMap<Requirement, RequirementDto>();
        CreateMap<CreateUpdateRequirementDto, Requirement>();

        CreateMap<Member, MemberDto>();
        // CreateMap<MemberDto, Member>();
        // CreateMap<CreateMemberDto, Member>();
        // CreateMap<UpdateMemberDto, Member>();
    }
}
