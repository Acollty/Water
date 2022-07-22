using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace WaterCarriage.Requirements
{
    public interface IRequirementAppService :
        ICrudAppService< //Defines CRUD methods
            RequirementDto, //Used to show books
            Guid, //Primary key of the requirement entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateUpdateRequirementDto> //Used to create/update a requirement
    {

    }
}
