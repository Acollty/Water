using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WaterCarriage.Members
{
    public class MemberAppService_Tests:WaterCarriageApplicationTestBase
    {
        public readonly IMemberAppService _memberAppService;

        public MemberAppService_Tests() {
            _memberAppService = GetRequiredService<MemberAppService>();
        }

        [Fact]
        public async Task Should_Get_All_Members_Without_Any_Filter()
        {
            var result = await _memberAppService.GetListAsync(new GetMemberListDto());

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(2);
            result.Items.ShouldContain(member => member.Name == "George Orwell");
            result.Items.ShouldContain(member => member.Name == "Douglas Adams");
        }

        [Fact]
        public async Task Should_Get_Filtered_Members()
        {
            var result = await _memberAppService.GetListAsync(
                new GetMemberListDto { Filter = "George" });

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(1);
            result.Items.ShouldContain(member => member.Name == "George Orwell");
            result.Items.ShouldNotContain(member => member.Name == "Douglas Adams");
        }

        [Fact]
        public async Task Should_Create_A_New_Member()
        {
            var authorDto = await _memberAppService.CreateAsync(
                new CreateMemberDto
                {
                    Name = "Edward Bellamy",
                    Mobile = "13640902988",
                    Email = "Edward@mail.com",
                    Password = "1q2w3E*",
                    BirthDate = new DateTime(1850, 05, 22),
                    Gender = 1,
                    ShortBio = "Edward Bellamy was an American author..."
                }
            );;

            authorDto.Id.ShouldNotBe(Guid.Empty);
            authorDto.Name.ShouldBe("Edward Bellamy");
        }

        [Fact]
        public async Task Should_Not_Allow_To_Create_Duplicate_Member()
        {
            await Assert.ThrowsAsync<MemberAlreadyExistsException>(async () =>
            {
                await _memberAppService.CreateAsync(
                    new CreateMemberDto
                    {
                        Name = "Douglas Adams",
                        Mobile = "13640902989",
                        Email = "Adams@mail.com",
                        Password = "1q2w3E*",
                        BirthDate = DateTime.Now,
                        Gender = 1,
                        ShortBio = "..."
                    }
                );
            });
        }

    }
}
