using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using WaterCarriage.Permissions;

namespace WaterCarriage.Members
{
    /// <summary>
    /// 实现IMemberAppService接口
    /// </summary>
    [Authorize(WaterCarriagePermissions.Members.Default)]
    public class MemberAppService : WaterCarriageAppService,IMemberAppService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly MemberManager _memberManager;

        public MemberAppService(IMemberRepository memberRepository, MemberManager memberManager)
        {
            _memberRepository = memberRepository;
            _memberManager = memberManager;
        }

        /// <summary>
        /// 异步创建Member
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [Authorize(WaterCarriagePermissions.Members.Create)]
        public async Task<MemberDto> CreateAsync(CreateMemberDto input)
        {
            var member = await _memberManager.CreateAsync(
                input.Name,
                input.Mobile,
                input.Email,
                input.Password,
                input.BirthDate,
                input.Gender,
                input.ShortBio
                );

            await _memberRepository.InsertAsync(member);

            return ObjectMapper.Map<Member, MemberDto>(member);
        }

       /// <summary>
       /// 异步删除Member
       /// </summary>
       /// <param name="id"></param>
       /// <returns></returns>
       /// <exception cref="NotImplementedException"></exception>
        [Authorize(WaterCarriagePermissions.Members.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _memberRepository.DeleteAsync(id);
        }

        /// <summary>
        /// 通过ID异步获取Member信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<MemberDto> GetAsync(Guid id)
        {
            var member = await _memberRepository.GetAsync(id);
            return ObjectMapper.Map<Member, MemberDto>(member);
        }

        /// <summary>
        /// 异步获取列表数据
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<PagedResultDto<MemberDto>> GetListAsync(GetMemberListDto input)
        {
            if (input.Sorting.IsNullOrWhiteSpace()) {
                input.Sorting = nameof(Member.Name);
            }

            var members = await _memberRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
                );

            var totalCount = input.Filter == null
                ? await _memberRepository.CountAsync()
                : await _memberRepository.CountAsync(
                    member => member.Name.Contains(input.Filter)
                    );

            return new PagedResultDto<MemberDto>(
                totalCount,
                ObjectMapper.Map<List<Member>, List<MemberDto>>(members)
                ) ;
        }

        /// <summary>
        /// 异步更新Member
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [Authorize(WaterCarriagePermissions.Members.Edit)]
        public async Task UpdateAsync(Guid id, UpdateMemberDto input)
        {
            var member = await _memberRepository.GetAsync(id);

            if (member.Name != input.Name) {
                await _memberManager.ChangeNameAsync(member,input.Name);
            }

            member.Mobile = input.Mobile;
            member.Email = input.Email;
            member.Password = input.Password;
            member.BirthDate = input.BirthDate;
            member.Gender = input.Gender;
            member.ShortBio = input.ShortBio;

            await _memberRepository.UpdateAsync(member);
        }
    }
}
