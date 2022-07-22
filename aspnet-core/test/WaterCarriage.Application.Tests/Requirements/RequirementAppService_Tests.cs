using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;


namespace WaterCarriage.Requirements
{
    public class RequirementAppService_Tests : WaterCarriageApplicationTestBase
    {
        private readonly IRequirementAppService _requirementService;

        public RequirementAppService_Tests() { 
        _requirementService = GetRequiredService<IRequirementAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Requirements() {
            //Act
            var result = await _requirementService.GetListAsync(
                new PagedAndSortedResultRequestDto()
            );

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(b => b.Name == "shipping_001");
        }

        [Fact]
        public async Task Should_Create_A_Valid_Requirement()
        {
            //Act
            var result = await _requirementService.CreateAsync(
                new CreateUpdateRequirementDto
                {
                    Name = "shipping_005",
                    Description = "shipping_005",
                    PublishDate = DateTime.Now,
                }
            ); ; ;

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("shipping_001");
        }

        [Fact]
        public async Task Should_Not_Create_A_Requirement_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _requirementService.CreateAsync(
                    new CreateUpdateRequirementDto
                    {
                        Name = "",
                        Description = "",
                        PublishDate = DateTime.Now,
                    }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == "Name"));
        }

    }
}
