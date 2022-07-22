using Volo.Abp.Application.Dtos;

namespace WaterCarriage.Members
{
    public class GetMemberListDto: PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}