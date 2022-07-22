using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using JetBrains.Annotations;
using Volo.Abp;

namespace WaterCarriage.Members
{
    public class Member : FullAuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// 会员昵称
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 会员手机号码
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        ///  性别
        /// </summary>
        public Int32 Gender { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string ShortBio { get; set; }

        private Member()
        {
            /* This constructor is for deserialization / ORM purpose */
        }

        internal Member(
            Guid id,
            [NotNull] string name,
            [NotNull] string mobile,
            [NotNull] string email,
            [NotNull] string password,
            DateTime birthDate,
            [NotNull] Int32 gender,
            [CanBeNull] string shortBio = null
            ) :base(id) {
            SetName(name);
            Mobile = mobile;
            Email = email;
            Password = password;
            BirthDate = birthDate;  
            Gender = gender;
            ShortBio = shortBio;

        }

        internal Member ChangeName([NotNull] string name) {
            SetName(name);
            return this;
        }


        private void SetName([NotNull] string name) { 
            Name = Check.NotNullOrWhiteSpace(
                name,
                nameof(name),
                maxLength:MemberConsts.MaxNameLength
                );
        }

    }
}
