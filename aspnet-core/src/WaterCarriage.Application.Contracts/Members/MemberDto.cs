using System;
using Volo.Abp.Application.Dtos;

namespace WaterCarriage.Members
{
    public class MemberDto : EntityDto<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// 
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Int32 Gender { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ShortBio { get; set; }
    }
}