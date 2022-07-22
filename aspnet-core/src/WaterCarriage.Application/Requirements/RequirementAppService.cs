using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using WaterCarriage.Permissions;

namespace WaterCarriage.Requirements
{
    public class RequirementAppService :
        CrudAppService<
            Requirement, //The Requirement entity
            RequirementDto, //Used to show Requirement
            Guid, //Primary key of the Requirement entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateRequirementDto>, //Used to create/update a book
        IRequirementAppService //implement the IRequirement AppService
    {
        public RequirementAppService(IRepository<Requirement, Guid> repository)
            : base(repository)
        {
            GetPolicyName = WaterCarriagePermissions.Requirements.Default;
            GetListPolicyName = WaterCarriagePermissions.Requirements.Default;
            CreatePolicyName = WaterCarriagePermissions.Requirements.Create;
            UpdatePolicyName = WaterCarriagePermissions.Requirements.Edit;
            DeletePolicyName = WaterCarriagePermissions.Requirements.Delete;
        }
    }
}
