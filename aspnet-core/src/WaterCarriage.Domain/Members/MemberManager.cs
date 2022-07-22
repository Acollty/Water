using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace WaterCarriage.Members
{
    /// <summary>
    /// 域服务
    /// </summary>
    public class MemberManager : DomainService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberManager(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<Member> CreateAsync(
            [NotNull] string name,
            [NotNull] string mobile,
            [NotNull] string email,
            [NotNull] string password,
            DateTime birthDate,
            [CanBeNull] Int32 gender = 0,
            [CanBeNull] string shortBio = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var existingMember = await _memberRepository.FindByNameAsync(name);
            if (existingMember != null)
            {
                throw new MemberAlreadyExistsException(name);
            }

            return new Member(
                GuidGenerator.Create(),
                name,
                mobile,
                email,
                password,
                birthDate,
                gender,
                shortBio
            );

        }

        public async Task ChangeNameAsync(
        [NotNull] Member member,
        [NotNull] string newName)
        {
            Check.NotNull(member, nameof(Member));
            Check.NotNullOrWhiteSpace(newName, nameof(newName));

            var existingMember = await _memberRepository.FindByNameAsync(newName);
            if (existingMember != null && existingMember.Id != member.Id)
            {
                throw new MemberAlreadyExistsException(newName);
            }

            member.ChangeName(newName);
        }
    }
}
